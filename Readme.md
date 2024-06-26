<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128578615/18.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T357159)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [CustomFilterPopup.cs](./CS/CustomFilterPopup/CustomFilterPopup.cs) (VB: [CustomFilterPopup.vbproj](./VB/CustomFilterPopup/CustomFilterPopup.vbproj))
* [MainWindow.xaml](./CS/CustomFilterPopup/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/CustomFilterPopup/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/CustomFilterPopup/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/CustomFilterPopup/MainWindow.xaml.vb))
* [StringToFilterCriteriaMultiConverter.cs](./CS/CustomFilterPopup/StringToFilterCriteriaMultiConverter.cs) (VB: [StringToFilterCriteriaMultiConverter.vb](./VB/CustomFilterPopup/StringToFilterCriteriaMultiConverter.vb))
<!-- default file list end -->
# How to Implement a Custom Filter Popup

This example uses a custom data template with a custom control inherited from the [ComboBoxEdit](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.ComboBoxEdit) class. It implements incremental search and allows you to invert selection.
 
The data template is assigned to the [PivotGridField.HeaderTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotGridField.HeaderTemplate) property.

![screenshot](./images/screenshot.png)


See also:

* [Filtering Basics](https://docs.devexpress.com/WPF/8010)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-pivot-grid-implement-a-custom-filter-popup&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-pivot-grid-implement-a-custom-filter-popup&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
