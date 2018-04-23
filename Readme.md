# How to use a Spreadsheet control as an in-place editor (GridControl, PropertyGridControl)


<p> This example illustrates a way of displaying a Spreadsheet control as an in-place editor in Editor Container components.</p><p>This approach is based on using the <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsPopupContainerEdittopic"><u>RepositoryItemPopupContainerEdit</u></a> component, which contains a Spreadsheet instance, and handling the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraEditorsPopupBaseEdit_QueryPopUptopic"><u>QueryPopUp</u></a> and <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraEditorsPopupContainerEdit_QueryResultValuetopic"><u>QueryResultValue</u></a> events for reading/writing data to this Spreadsheet instance.</p>

<br/>


