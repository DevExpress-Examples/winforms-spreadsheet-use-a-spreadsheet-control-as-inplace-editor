<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128613944/19.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4777)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WindowsFormsApplication1/Form1.cs) (VB: [Form1.vb](./VB/WindowsFormsApplication1/Form1.vb))
* [Program.cs](./CS/WindowsFormsApplication1/Program.cs) (VB: [Program.vb](./VB/WindowsFormsApplication1/Program.vb))
<!-- default file list end -->
# How to use a Spreadsheet control as an in-place editor (GridControl, PropertyGridControl)


<p> This example illustrates a way of displaying a Spreadsheet control as an in-place editor in Editor Container components.</p><p>This approach is based on using the <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsPopupContainerEdittopic"><u>RepositoryItemPopupContainerEdit</u></a> component, which contains a Spreadsheet instance, and handling the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraEditorsPopupBaseEdit_QueryPopUptopic"><u>QueryPopUp</u></a> and <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraEditorsPopupContainerEdit_QueryResultValuetopic"><u>QueryResultValue</u></a> events for reading/writing data to this Spreadsheet instance.</p>

<br/>


