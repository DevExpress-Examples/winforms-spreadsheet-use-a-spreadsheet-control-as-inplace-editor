Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSpreadsheet
Imports DevExpress.Spreadsheet

Namespace WindowsFormsApplication1

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim rePopupContainer As RepositoryItemPopupContainerEdit = TryCast(propertyGridControl1.RepositoryItems.Add("PopupContainerEdit"), RepositoryItemPopupContainerEdit)
            rePopupContainer.PopupControl = popupContainerControl1
            AddHandler rePopupContainer.QueryPopUp, New CancelEventHandler(AddressOf rePopupContainer_QueryPopUp)
            AddHandler rePopupContainer.QueryResultValue, New DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(AddressOf rePopupContainer_QueryResultValue)
            propertyGridControl1.DefaultEditors.Add(GetType(DataTable), rePopupContainer)
            AddHandler rePopupContainer.CustomDisplayText, New DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(AddressOf rePopupContainer_CustomDisplayText)
            Dim newObject As MyObject = New MyObject()
            propertyGridControl1.SelectedObject = newObject
            gridControl1.DataSource = New BindingList(Of MyObject)() From {newObject}
            gridControl1.ForceInitialize()
            gridView1.Columns("MySpreadSheet").ColumnEdit = rePopupContainer
        End Sub

        Private Sub rePopupContainer_CustomDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs)
            e.DisplayText = "(table data)"
        End Sub

        Private Sub rePopupContainer_QueryResultValue(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.QueryResultValueEventArgs)
            Dim currentTable As DataTable = TryCast(propertyGridControl1.SelectedObject, MyObject).MySpreadSheet
            If currentTable Is Nothing Then
                currentTable = New DataTable()
                TryCast(propertyGridControl1.SelectedObject, MyObject).MySpreadSheet = currentTable
            End If

            currentTable.Clear()
            currentTable.Columns.Clear()
            Dim spreadSheet As SpreadsheetControl = TryCast(TryCast(sender, PopupContainerEdit).Properties.PopupControl.Controls(0), SpreadsheetControl)
            Dim workSheet As Worksheet = spreadSheet.Document.Worksheets(0)
            Dim usedRange As CellRange = workSheet.GetUsedRange()
            For i As Integer = 0 To usedRange.ColumnCount - 1
                currentTable.Columns.Add("Column" & i.ToString())
            Next

            For i As Integer = 0 To usedRange.RowCount - 1
                Dim newRow As DataRow = currentTable.NewRow()
                For j As Integer = 0 To usedRange.ColumnCount - 1
                    newRow(j) = workSheet.Cells(i, j).DisplayText
                Next

                currentTable.Rows.Add(newRow)
            Next
        End Sub

        Private Sub rePopupContainer_QueryPopUp(ByVal sender As Object, ByVal e As CancelEventArgs)
            Dim currentTable As DataTable = TryCast(propertyGridControl1.SelectedObject, MyObject).MySpreadSheet
            If currentTable IsNot Nothing Then
                Dim spreadSheet As SpreadsheetControl = TryCast(TryCast(sender, PopupContainerEdit).Properties.PopupControl.Controls(0), SpreadsheetControl)
                Dim workSheet As Worksheet = spreadSheet.Document.Worksheets(0)
                For i As Integer = 0 To currentTable.Columns.Count - 1
                    For j As Integer = 0 To currentTable.Rows.Count - 1
                        workSheet.Cells(j, i).Value = currentTable.Rows(j)(i).ToString()
                    Next
                Next
            End If
        End Sub
    End Class

    Public Class MyObject

        Public Sub New()
            Name = "Some name"
            MySpreadSheet = New DataTable()
            For i As Integer = 0 To 5 - 1
                MySpreadSheet.Columns.Add("Value" & i.ToString(), GetType(Integer))
            Next

            Dim myRand As Random = New Random()
            For i As Integer = 0 To 20 - 1
                MySpreadSheet.Rows.Add(myRand.Next(1, 100), myRand.Next(1, 100), myRand.Next(1, 100), myRand.Next(1, 100), myRand.Next(1, 100))
            Next
        End Sub

        Public Property Name As String

        Public Property MySpreadSheet As DataTable
    End Class
End Namespace
