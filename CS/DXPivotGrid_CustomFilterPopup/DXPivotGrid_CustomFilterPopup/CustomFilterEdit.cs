using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.Editors;
using System.Windows;
using DevExpress.Xpf.PivotGrid;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core.Native;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Threading;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.PivotGrid.Internal;
using DevExpress.Xpf.Grid.LookUp;

namespace DXPivotGrid_CustomFilterPopup {

    class PivotGridCustomFilter : LookUpEdit {
        public PivotGridCustomFilter() {
            PopupOpening += new OpenPopupEventHandler(PivotGridRadioFilter_PopupOpening);
            PopupClosed += new ClosePopupEventHandler(PivotGridRadioFilter_PopupClosed);
        }
        public PivotGridField PivotField {
            get { return (PivotGridField)GetValue(PivotFieldProperty); }
            set { SetValue(PivotFieldProperty, value); }
        }
        public static readonly DependencyProperty PivotFieldProperty =
            DependencyProperty.Register("PivotField", typeof(PivotGridField), typeof(PivotGridCustomFilter), new UIPropertyMetadata(null));

        void PivotGridRadioFilter_PopupOpening(object sender, OpenPopupEventArgs e) {
            if (PivotField == null) {
                e.Cancel = true;
                e.Handled = true;
                return;
            }
            this.BeginDataUpdate();
            
            var uniqueItems = PivotField.GetUniqueValues().Select(v => new PivotValueInfo() { Value = v, DisplayText = PivotField.GetDisplayText(v) }).ToArray();
            var editValue = PivotField.FilterValues.ValuesIncluded;
            ItemsSource = uniqueItems;
            
            this.EditValue = editValue;
            this.EndDataUpdate();
        }

        void PivotGridRadioFilter_PopupClosed(object sender, ClosePopupEventArgs e) {
            PivotGridControl pivot = PivotField.Parent as PivotGridControl;
            if (e.CloseMode == DevExpress.Xpf.Editors.PopupCloseMode.Cancel || PivotField == null || SelectedItems == null || pivot == null)
                return;
            var values = SelectedItems.OfType<PivotValueInfo>().Select(v => v.Value).ToArray();
            if (PivotField.FilterValues.FilterType == FieldFilterType.Included)
                PivotField.FilterValues.ValuesIncluded = values;
            else
                PivotField.FilterValues.ValuesExcluded = PivotField.GetUniqueValues().Except(values).ToArray();
        }
    }

    public class PivotValueInfo {
        public object Value { get; set; }
        public string DisplayText { get; set; }
    }

}
