using System.Data;
using System.Data.OleDb;
using System.Windows;
//using DevExpress.Xpf.Editors.Filtering;

namespace CustomFilterPopup
{

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=NWIND.MDB");
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM SalesPerson", connection);
            DataSet sourceDataSet = new DataSet();
            adapter.Fill(sourceDataSet, "SalesPerson");
            pivotGridControl1.DataSource = sourceDataSet.Tables["SalesPerson"];
        }
    }
}
