Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpf.Editors
Imports System.Windows
Imports DevExpress.Xpf.PivotGrid
Imports System.Windows.Input
Imports DevExpress.Mvvm
Imports DevExpress.Xpf.Core.Native
Imports System.Windows.Controls
Imports System.Threading
Imports System.Windows.Threading
Imports DevExpress.Mvvm.UI
Imports DevExpress.Xpf.PivotGrid.Internal

Namespace HowToBindToMDB

    Friend Class PivotGridCustomFilter
        Inherits ComboBoxEdit


        Public Sub New()
            AddHandler PopupOpening, AddressOf PivotGridRadioFilter_PopupOpening
            AddHandler PopupClosed, AddressOf PivotGridRadioFilter_PopupClosed
            InvertCommand = New DelegateCommand(AddressOf Invert)
            EventManager.RegisterClassHandler(GetType(ComboBoxEditItem), ComboBoxEditItem.RequestBringIntoViewEvent, New RequestBringIntoViewEventHandler(AddressOf OnRequestBringIntoView))
        End Sub

        Protected Overrides Sub EndInitInternal(callBase As Boolean)
            Dim fieldHeaderControl = LayoutTreeHelper.GetVisualParents(Parent).First(Function(i) TypeOf i Is FieldHeaderContentControl)
            Dim filterEdit = LayoutTreeHelper.GetVisualChildren(fieldHeaderControl).OfType(Of FilterPopupEdit)().FirstOrDefault()
            If filterEdit IsNot Nothing Then
                Dim border = CType(LayoutTreeHelper.GetVisualParents(filterEdit).First(Function(i) TypeOf i Is Border), Border)
                border.Visibility = System.Windows.Visibility.Collapsed
            End If
            MyBase.EndInitInternal(callBase)
        End Sub

        Private blockViewUpdates As Boolean

        Private Sub OnRequestBringIntoView(ByVal sender As Object, ByVal e As RequestBringIntoViewEventArgs)
            e.Handled = blockViewUpdates
        End Sub

        Public Property InvertCommand() As ICommand

        Public Property PivotField() As PivotGridField
            Get
                Return CType(GetValue(PivotFieldProperty), PivotGridField)
            End Get
            Set(ByVal value As PivotGridField)
                SetValue(PivotFieldProperty, value)
            End Set
        End Property

        ' Using a DependencyProperty as the backing store for Field.  This enables animation, styling, binding, etc...
        Public Shared ReadOnly PivotFieldProperty As DependencyProperty = DependencyProperty.Register("PivotField", GetType(PivotGridField), GetType(PivotGridCustomFilter), New UIPropertyMetadata(Nothing))

        Public Shared ReadOnly FilterButtonVisibleProperty As DependencyProperty = DependencyProperty.Register("FilterButtonVisible", GetType(Visibility), GetType(PivotGridCustomFilter), New UIPropertyMetadata(Nothing))



        Public Sub Invert()
            blockViewUpdates = True
            Dim selectedValues = ListBox.SelectedItems.Cast(Of Object)().ToArray()
            Dim unselectedItems = ListBox.ItemsSource.Cast(Of Object)().OfType(Of PivotValueInfo)().Cast(Of Object)().Except(selectedValues).ToList()
            Me.UnselectAllItems()
            unselectedItems.ForEach(Sub(i) SelectedItems.Add(i))
            blockViewUpdates = False
        End Sub

        Private Sub PivotGridRadioFilter_PopupOpening(ByVal sender As Object, ByVal e As OpenPopupEventArgs)
            If PivotField Is Nothing Then
                e.Cancel = True
                e.Handled = True
                Return
            End If
            Me.BeginDataUpdate()
            Items.Clear()
            Dim uniqueItems = PivotField.GetUniqueValues().Select(Function(v) New PivotValueInfo() With {.Value = v, .DisplayText = PivotField.GetDisplayText(v)}).ToArray()
            Dim editValue = PivotField.FilterValues.ValuesIncluded
            Items.AddRange(uniqueItems)
            Me.EditValue = editValue
            Me.EndDataUpdate()
        End Sub

        Private Sub PivotGridRadioFilter_PopupClosed(ByVal sender As Object, ByVal e As ClosePopupEventArgs)
            Dim pivot As PivotGridControl = TryCast(PivotField.Parent, PivotGridControl)
            If e.CloseMode = DevExpress.Xpf.Editors.PopupCloseMode.Cancel OrElse PivotField Is Nothing OrElse SelectedItems Is Nothing OrElse pivot Is Nothing Then
                Return
            End If
            Dim values = SelectedItems.OfType(Of PivotValueInfo)().Select(Function(v) v.Value).ToArray()
            If PivotField.FilterValues.FilterType = FieldFilterType.Included Then
                PivotField.FilterValues.ValuesIncluded = values
            Else
                PivotField.FilterValues.ValuesExcluded = PivotField.GetUniqueValues().Except(values).ToArray()
            End If
        End Sub
    End Class

    Public Class PivotValueInfo
        Public Property Value() As Object
        Public Property DisplayText() As String
    End Class

End Namespace
