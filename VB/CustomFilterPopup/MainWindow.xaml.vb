Imports System.Data
Imports System.Data.OleDb
Imports System.Windows
Imports DevExpress.Xpf.PivotGrid
Imports DevExpress.Xpf.Editors.Popups
'using DevExpress.Xpf.Editors.Filtering;
Imports System.Reflection
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Core.Native
Imports DevExpress.Xpf.Editors
Imports System.Windows.Controls

Namespace HowToBindToMDB

    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim connection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=NWIND.MDB")
            Dim adapter As New OleDbDataAdapter("SELECT * FROM SalesPerson", connection)
            Dim sourceDataSet As New DataSet()
            adapter.Fill(sourceDataSet, "SalesPerson")
            pivotGridControl1.DataSource = sourceDataSet.Tables("SalesPerson")
        End Sub
    End Class
End Namespace
