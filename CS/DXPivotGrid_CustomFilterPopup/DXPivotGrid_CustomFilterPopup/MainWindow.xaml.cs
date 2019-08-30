using DevExpress.Mvvm.UI;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DXPivotGrid_CustomFilterPopup {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            pivotGridControl1.DataSource = Enumerable.Range(0, 2 * 1000).Select(i => new { ProductName = "Name " + i, Value = i });
        }
    }
   
}
