<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128613944/19.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4777)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Spreadsheet for WinForms - How to Use a SpreadsheetControl as an In-Place Editor (GridControl, PropertyGridControl)


This example illustrates how to display a Spreadsheet control as an in-place editor in Editor Container components.

## Implementation Details

This approach is based on the <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsPopupContainerEdittopic"><u>RepositoryItemPopupContainerEdit</u></a> component usage, which contains a Spreadsheet instance. Handle the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraEditorsPopupBaseEdit_QueryPopUptopic"><u>QueryPopUp</u></a> and <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraEditorsPopupContainerEdit_QueryResultValuetopic"><u>QueryResultValue</u></a> events to read and write data to this Spreadsheet instance.

## Files to Review

* [Form1.cs](./CS/WindowsFormsApplication1/Form1.cs) (VB: [Form1.vb](./VB/WindowsFormsApplication1/Form1.vb))
* [Program.cs](./CS/WindowsFormsApplication1/Program.cs) (VB: [Program.vb](./VB/WindowsFormsApplication1/Program.vb))
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-spreadsheet-use-a-spreadsheet-control-as-inplace-editor&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-spreadsheet-use-a-spreadsheet-control-as-inplace-editor&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
