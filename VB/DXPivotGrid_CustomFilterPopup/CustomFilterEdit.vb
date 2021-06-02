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
Imports DevExpress.Xpf.Grid.LookUp

Namespace DXPivotGrid_CustomFilterPopup

	Friend Class PivotGridCustomFilter
		Inherits LookUpEdit

		Public Sub New()
			AddHandler Me.PopupOpening, AddressOf PivotGridRadioFilter_PopupOpening
			AddHandler Me.PopupClosed, AddressOf PivotGridRadioFilter_PopupClosed
		End Sub
		Public Property PivotField() As PivotGridField
			Get
				Return DirectCast(GetValue(PivotFieldProperty), PivotGridField)
			End Get
			Set(ByVal value As PivotGridField)
				SetValue(PivotFieldProperty, value)
			End Set
		End Property
		Public Shared ReadOnly PivotFieldProperty As DependencyProperty = DependencyProperty.Register("PivotField", GetType(PivotGridField), GetType(PivotGridCustomFilter), New UIPropertyMetadata(Nothing))

		Private Sub PivotGridRadioFilter_PopupOpening(ByVal sender As Object, ByVal e As OpenPopupEventArgs)
			If PivotField Is Nothing Then
				e.Cancel = True
				e.Handled = True
				Return
			End If
			Me.BeginDataUpdate()

			Dim uniqueItems = PivotField.GetUniqueValues().Select(Function(v) New PivotValueInfo() With {
				.Value = v,
				.DisplayText = PivotField.GetDisplayText(v)
			}).ToArray()
'INSTANT VB NOTE: The variable editValue was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim editValue_Renamed = PivotField.FilterValues.ValuesIncluded
			ItemsSource = uniqueItems

			Me.EditValue = editValue_Renamed
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
