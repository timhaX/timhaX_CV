using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }
		
		
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                try
                {
                    DataRow nRow = main.testDataSet.Tables[0].NewRow();
                    int rc = main.dataGridView1.RowCount + 1;
                    nRow[0] = rc;
                    nRow[1] = tbName.Text;
                    nRow[2] = tbGod.Text;
                    nRow[3] = tbD.Text;
                    nRow[4] = tbT.Text;
                    main.testDataSet.Tables[0].Rows.Add(nRow);
                    main.справочник_МетеорологаTableAdapter.Update(main.testDataSet.Справочник_Метеоролога);
                    main.testDataSet.Tables[0].AcceptChanges();
                    main.dataGridView1.Refresh();
                    tbName.Text = "";
                    tbGod.Text = "";
                    tbD.Text = "";
                    tbT.Text = "";
                }
                catch { MessageBox.Show("Error(Неверные данные)"); };
                
            }
        }
    }
}
