<!-- default file list -->
*Files to look at*:

* [CustomFilterPopup.cs](./CS/CustomFilterPopup/CustomFilterPopup.cs) (VB: [CustomFilterPopup.vbproj](./VB/CustomFilterPopup/CustomFilterPopup.vbproj))
* [MainWindow.xaml](./CS/CustomFilterPopup/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/CustomFilterPopup/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/CustomFilterPopup/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/CustomFilterPopup/MainWindow.xaml.vb))
* [StringToFilterCriteriaMultiConverter.cs](./CS/CustomFilterPopup/StringToFilterCriteriaMultiConverter.cs) (VB: [StringToFilterCriteriaMultiConverter.vb](./VB/CustomFilterPopup/StringToFilterCriteriaMultiConverter.vb))
<!-- default file list end -->
# How to define a custom Filter Popup with custom toolbar buttons and a filter editor


<p>To accomplish this task, define a custom <a href="https://documentation.devexpress.com/AspNet/clsDevExpressWebASPxPivotGridPivotGridFieldtopic.aspx">PivotGridField.</a><a href="https://documentation.devexpress.com/AspNet/DevExpressWebASPxPivotGridPivotGridField_HeaderTemplatetopic.aspx">HeaderTemplate</a>. In the attached solution, this template is defined in the <strong>MainWindow.xaml</strong> file. The custom functionality is implemented in the <a href="https://documentation.devexpress.com/WPF/CustomDocument6166.aspx">ComboBoxEdit</a> descendant. This descendant is defined in the <strong>CustomFilterPopup.cs</strong> file. Filter popup is populated from the <em>PivotGridRadioFilter_PopupOpening</em> event handler. To apply the filter, the <em>PivotGridRadioFilter_PopupClosed</em> event handler is used. <br>The custom filter edit provides custom functionality using the <em>Invert</em> button and the <em>TextEditor </em>filter<em>.</em></p>

<br/>


