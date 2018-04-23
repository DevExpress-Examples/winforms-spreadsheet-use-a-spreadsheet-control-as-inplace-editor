Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSpreadsheet
Imports DevExpress.Spreadsheet


Namespace WindowsFormsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim rePopupContainer As RepositoryItemPopupContainerEdit = TryCast(propertyGridControl1.RepositoryItems.Add("PopupContainerEdit"), RepositoryItemPopupContainerEdit)

			rePopupContainer.PopupControl = popupContainerControl1
			AddHandler rePopupContainer.QueryPopUp, AddressOf rePopupContainer_QueryPopUp
			AddHandler rePopupContainer.QueryResultValue, AddressOf rePopupContainer_QueryResultValue

			propertyGridControl1.DefaultEditors.Add(GetType(DataTable), rePopupContainer)
			AddHandler rePopupContainer.CustomDisplayText, AddressOf rePopupContainer_CustomDisplayText

			Dim newObject As New MyObject()

			propertyGridControl1.SelectedObject = newObject
			gridControl1.DataSource = New BindingList(Of MyObject) (New MyObject() {newObject})
			gridControl1.ForceInitialize()

			gridView1.Columns("MySpreadSheet").ColumnEdit = rePopupContainer
		End Sub

		Private Sub rePopupContainer_CustomDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs)
			e.DisplayText = "(table data)"
		End Sub

		Private Sub rePopupContainer_QueryResultValue(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.QueryResultValueEventArgs)
			Dim currentTable As DataTable = (TryCast(propertyGridControl1.SelectedObject, MyObject)).MySpreadSheet
			If currentTable Is Nothing Then
				currentTable = New DataTable()
				TryCast(propertyGridControl1.SelectedObject, MyObject).MySpreadSheet = currentTable
			End If
			currentTable.Clear()
			currentTable.Columns.Clear()
			Dim spreadSheet As SpreadsheetControl = TryCast((TryCast(sender, PopupContainerEdit)).Properties.PopupControl.Controls(0), SpreadsheetControl)
			Dim workSheet As Worksheet = spreadSheet.Document.Worksheets(0)
			Dim usedRange As Range = workSheet.GetUsedRange()

			For i As Integer = 0 To usedRange.ColumnCount - 1
				currentTable.Columns.Add("Column" & i.ToString())
			Next i

			For i As Integer = 0 To usedRange.RowCount - 1
				Dim newRow As DataRow = currentTable.NewRow()
				For j As Integer = 0 To usedRange.ColumnCount - 1
					newRow(j) = workSheet.Cells(i,j).DisplayText
				Next j
				currentTable.Rows.Add(newRow)
			Next i
		End Sub

		Private Sub rePopupContainer_QueryPopUp(ByVal sender As Object, ByVal e As CancelEventArgs)
			Dim currentTable As DataTable = (TryCast(propertyGridControl1.SelectedObject, MyObject)).MySpreadSheet
			If currentTable IsNot Nothing Then
				Dim spreadSheet As SpreadsheetControl = TryCast((TryCast(sender, PopupContainerEdit)).Properties.PopupControl.Controls(0), SpreadsheetControl)
				Dim workSheet As Worksheet = spreadSheet.Document.Worksheets(0)
				For i As Integer = 0 To currentTable.Columns.Count - 1
					For j As Integer = 0 To currentTable.Rows.Count - 1
						workSheet.Cells(j, i).Value = currentTable.Rows(j)(i).ToString()
					Next j
				Next i
			End If
		End Sub
	End Class

	Public Class MyObject
		Public Sub New()
			Name = "Some name"
			MySpreadSheet = New DataTable()
			For i As Integer = 0 To 4
				MySpreadSheet.Columns.Add("Value" & i.ToString(), GetType(Integer))
			Next i
			Dim myRand As New Random()
			For i As Integer = 0 To 19
				MySpreadSheet.Rows.Add(myRand.Next(1, 100), myRand.Next(1, 100), myRand.Next(1, 100), myRand.Next(1, 100), myRand.Next(1, 100))
			Next i
		End Sub

		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Private privateMySpreadSheet As DataTable
		Public Property MySpreadSheet() As DataTable
			Get
				Return privateMySpreadSheet
			End Get
			Set(ByVal value As DataTable)
				privateMySpreadSheet = value
			End Set
		End Property
	End Class
End Namespace
