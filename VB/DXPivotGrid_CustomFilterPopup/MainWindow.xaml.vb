Imports DevExpress.Mvvm.UI
Imports DevExpress.Mvvm.UI.Interactivity
Imports DevExpress.Xpf.Grid
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace DXPivotGrid_CustomFilterPopup
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
			pivotGridControl1.DataSource = Enumerable.Range(0, 2 * 1000).Select(Function(i) New With {
				Key .ProductName = "Name " & i,
				Key .Value = i
			})
		End Sub
	End Class

End Namespace
