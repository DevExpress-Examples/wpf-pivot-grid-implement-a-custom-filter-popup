<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128578615/19.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T357159)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [DXPivotGrid_CustomFilterPopup.csproj](./CS/DXPivotGrid_CustomFilterPopup/DXPivotGrid_CustomFilterPopup.csproj) (VB: [DXPivotGrid_CustomFilterPopup.csproj](./VB/DXPivotGrid_CustomFilterPopup/DXPivotGrid_CustomFilterPopup.vbproj))
* [MainWindow.xaml](./CS/DXPivotGrid_CustomFilterPopup/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/DXPivotGrid_CustomFilterPopup/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/DXPivotGrid_CustomFilterPopup/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DXPivotGrid_CustomFilterPopup/MainWindow.xaml.vb))
* [CustomFilterPopupTemplateSelector.cs](./CS/DXPivotGrid_CustomFilterPopup/CustomFilterPopupTemplateSelector.cs) (VB: [CustomFilterPopupTemplateSelector.vb](./VB/DXPivotGrid_CustomFilterPopup/CustomFilterPopupTemplateSelector.vb))
<!-- default file list end -->
# How to Implement a Custom Filter Popup

This example uses custom FilterPopupTemplateSelector that allows to to provide different filter data templates for different fields. Now it replaces all default filters with a custom control inherited from the [LookUpEdit](https://docs.devexpress.com/WPF/8862/controls-and-libraries/data-editors/editor-types/lookupedit) class.

![screenshot](./images/screenshot_19.1.png)

> Starting from v19.1.5 it is also possible to customize the Filter Popup used by the Excel style filter using the [PivotGridField.CustomExcelStyleFilterPopupTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotGridField.CustomExcelStyleFilterPopupTemplate) property.

See also:

* [Filtering Basics](https://docs.devexpress.com/WPF/8010)
