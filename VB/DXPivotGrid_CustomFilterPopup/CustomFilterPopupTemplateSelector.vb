Imports DevExpress.Xpf.PivotGrid.Internal
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows

Namespace DXPivotGrid_CustomFilterPopup
	Friend Class CustomFilterPopupTemplateSelector
		Inherits FilterPopupTemplateSelector

		Public Property CustomTemplate() As DataTemplate
		Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
		Dim field = FieldHeader.GetHeader(container)?.Field
			If field IsNot Nothing AndAlso field.Group Is Nothing Then
				Return CustomTemplate
			End If
			Return LegacyTemplate
		End Function
	End Class
End Namespace
