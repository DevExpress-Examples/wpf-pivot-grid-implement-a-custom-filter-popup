<!-- default file list -->
*Files to look at*:

* [CustomFilterPopup.cs](./CS/CustomFilterPopup/CustomFilterPopup.cs) (VB: [CustomFilterPopup.vbproj](./VB/CustomFilterPopup/CustomFilterPopup.vbproj))
* [MainWindow.xaml](./CS/CustomFilterPopup/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/CustomFilterPopup/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/CustomFilterPopup/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/CustomFilterPopup/MainWindow.xaml.vb))
* [StringToFilterCriteriaMultiConverter.cs](./CS/CustomFilterPopup/StringToFilterCriteriaMultiConverter.cs) (VB: [StringToFilterCriteriaMultiConverter.vb](./VB/CustomFilterPopup/StringToFilterCriteriaMultiConverter.vb))
<!-- default file list end -->
# How to Implement a Custom Filter Popup

This example uses a custom data template with a custom control inherited from the [ComboBoxEdit](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.ComboBoxEdit) class. 
The data template is assigned to the [PivotGridField.HeaderTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotGridField.HeaderTemplate) property.

![screenshot](./images/screenshot.png)

> Starting from v19.1 you are encouraged to implement a custom filter drop-down template and assign it to the [PivotGridField.CustomFilterPopupTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotGridField.CustomFilterPopupTemplate) property.

See also:

* [Filtering Basics](https://docs.devexpress.com/WPF/8010)
