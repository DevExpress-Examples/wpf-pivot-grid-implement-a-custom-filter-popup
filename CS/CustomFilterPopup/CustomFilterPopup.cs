using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.PivotGrid;
using DevExpress.Xpf.PivotGrid.Internal;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomFilterPopup
{

    class PivotGridCustomFilter : ComboBoxEdit {
        public PivotGridCustomFilter() {
            PopupOpening += new OpenPopupEventHandler(PivotGridRadioFilter_PopupOpening);
            PopupClosed += new ClosePopupEventHandler(PivotGridRadioFilter_PopupClosed);
            InvertCommand = new DelegateCommand(Invert);
            EventManager.RegisterClassHandler(typeof(ComboBoxEditItem), ComboBoxEditItem.RequestBringIntoViewEvent, new RequestBringIntoViewEventHandler(OnRequestBringIntoView));
        }

        protected override void EndInitInternal(bool callBase) {
            var fieldHeaderControl = LayoutTreeHelper.GetVisualParents(Parent).First(i => i is FieldHeaderContentControl);
            var filterEdit = LayoutTreeHelper.GetVisualChildren(fieldHeaderControl).OfType<FilterPopupEdit>().FirstOrDefault();
            if (filterEdit != null) {
                var border = LayoutTreeHelper.GetVisualParents(filterEdit).First(i => i is Border) as Border;
                border.Visibility = Visibility.Collapsed;
            }

            base.EndInitInternal(callBase);
        }

        bool blockViewUpdates;

        void OnRequestBringIntoView(object sender, RequestBringIntoViewEventArgs e) {
            e.Handled = blockViewUpdates;
        }

        public ICommand InvertCommand { get; set; }

        public PivotGridField PivotField {
            get { return (PivotGridField)GetValue(PivotFieldProperty); }
            set { SetValue(PivotFieldProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Field.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PivotFieldProperty =
            DependencyProperty.Register("PivotField", typeof(PivotGridField), typeof(PivotGridCustomFilter), new UIPropertyMetadata(null));

        public static readonly DependencyProperty FilterButtonVisibleProperty =
    DependencyProperty.Register("FilterButtonVisible", typeof(Visibility), typeof(PivotGridCustomFilter), new UIPropertyMetadata(null));



        public void Invert() {
            blockViewUpdates = true;
            var unselectedItems = ListBox.ItemsSource.Cast<object>().OfType<PivotValueInfo>().Except(ListBox.SelectedItems.Cast<object>()).ToList();
            this.UnselectAllItems();
            unselectedItems.ForEach(i => SelectedItems.Add(i));
            blockViewUpdates = false;
        }

        void PivotGridRadioFilter_PopupOpening(object sender, OpenPopupEventArgs e) {
            if (PivotField == null) {
                e.Cancel = true;
                e.Handled = true;
                return;
            }
            this.BeginDataUpdate();
            Items.Clear();
            var uniqueItems = PivotField.GetUniqueValues().Select(v => new PivotValueInfo() { Value = v, DisplayText = PivotField.GetDisplayText(v) }).ToArray();
            var editValue = PivotField.FilterValues.ValuesIncluded;
            Items.AddRange(uniqueItems);
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
