using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraSpreadsheet;
using DevExpress.Spreadsheet;


namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            RepositoryItemPopupContainerEdit rePopupContainer = propertyGridControl1.RepositoryItems.Add("PopupContainerEdit") as RepositoryItemPopupContainerEdit;

            rePopupContainer.PopupControl = popupContainerControl1;
            rePopupContainer.QueryPopUp += new CancelEventHandler(rePopupContainer_QueryPopUp);
            rePopupContainer.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(rePopupContainer_QueryResultValue);

            propertyGridControl1.DefaultEditors.Add(typeof(DataTable), rePopupContainer);
            rePopupContainer.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(rePopupContainer_CustomDisplayText);

            MyObject newObject = new MyObject();

            propertyGridControl1.SelectedObject = newObject;
            gridControl1.DataSource = new BindingList<MyObject>() { newObject };
            gridControl1.ForceInitialize();

            gridView1.Columns["MySpreadSheet"].ColumnEdit = rePopupContainer;
        }

        void rePopupContainer_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e) {
            e.DisplayText = "(table data)";
        }

        void rePopupContainer_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e) {
            DataTable currentTable = (propertyGridControl1.SelectedObject as MyObject).MySpreadSheet;
            if(currentTable == null) {
                currentTable = new DataTable();
                (propertyGridControl1.SelectedObject as MyObject).MySpreadSheet = currentTable;
            }            
            currentTable.Clear();
            currentTable.Columns.Clear();
            SpreadsheetControl spreadSheet = (sender as PopupContainerEdit).Properties.PopupControl.Controls[0] as SpreadsheetControl;
            Worksheet workSheet = spreadSheet.Document.Worksheets[0];
            CellRange usedRange = workSheet.GetUsedRange();

            for(int i = 0; i < usedRange.ColumnCount; i++) {
                currentTable.Columns.Add("Column" + i.ToString());
            }

            for(int i = 0; i < usedRange.RowCount; i++) {
                DataRow newRow = currentTable.NewRow();
                for (int j = 0; j < usedRange.ColumnCount; j++)
			    {
                    newRow[j] = workSheet.Cells[i,j].DisplayText;
			    }
                currentTable.Rows.Add(newRow);
            }            
        }

        void rePopupContainer_QueryPopUp(object sender, CancelEventArgs e) {
            DataTable currentTable = (propertyGridControl1.SelectedObject as MyObject).MySpreadSheet;
            if(currentTable != null) {
                SpreadsheetControl spreadSheet = (sender as PopupContainerEdit).Properties.PopupControl.Controls[0] as SpreadsheetControl;
                Worksheet workSheet = spreadSheet.Document.Worksheets[0];
                for(int i = 0; i < currentTable.Columns.Count; i++) {
                    for(int j = 0; j < currentTable.Rows.Count; j++) {
                        workSheet.Cells[j, i].Value = currentTable.Rows[j][i].ToString();
                    }
                }
            }
        }
    }

    public class MyObject {
        public MyObject() {
            Name = "Some name";
            MySpreadSheet = new DataTable();
            for(int i = 0; i < 5; i++) {
                MySpreadSheet.Columns.Add("Value" + i.ToString(), typeof(int));
            }
            Random myRand = new Random();
            for(int i = 0; i < 20; i++) {
                MySpreadSheet.Rows.Add(myRand.Next(1, 100), myRand.Next(1, 100), myRand.Next(1, 100), myRand.Next(1, 100), myRand.Next(1, 100));
            }        
        }

        public string Name { get; set; }    
        public DataTable MySpreadSheet {get; set;}
    }
}
