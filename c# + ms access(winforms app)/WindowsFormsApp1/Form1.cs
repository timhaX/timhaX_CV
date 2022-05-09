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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet.Справочник_Метеоролога". При необходимости она может быть перемещена или удалена.
            this.справочник_МетеорологаTableAdapter.Fill(this.testDataSet.Справочник_Метеоролога);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusStrip1.Items[1].Text = "total=" + справочникМетеорологаBindingSource.Count;
            statusStrip1.Items[2].Text = "current=" + (справочникМетеорологаBindingSource.Position + 1);
            statusStrip1.Items[3].Text = System.DateTime.Now.ToString();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            testDataSet.WriteXml("db.txt");
            MessageBox.Show("Сохранено");
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddForm af = new AddForm();
            af.Owner = this;
            af.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm();
            sf.Owner = this;
            sf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                testDataSet.Справочник_Метеоролога.Clear();
                testDataSet.ReadXml("db.txt");
                MessageBox.Show("Открыто");
            }
            catch { MessageBox.Show("Error(Нет сохранения)"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var names = (from name in testDataSet.Справочник_Метеоролога.AsEnumerable()
                         where (int)name["Код"] > 0
                         select name).ToList();
            foreach (var x in names) listBox1.Items.Add(x._Давление_мм_);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                string s = comboBox1.Text;
                if (s == testDataSet.Справочник_Метеоролога.НазваниеColumn.ColumnName)
                    s += " = '" + textBoxFilter.Text + "'";
                if (s == testDataSet.Справочник_Метеоролога.Время_годаColumn.ColumnName)
                    s = "[Время года] = '" + textBoxFilter.Text + "'";
                if (s == testDataSet.Справочник_Метеоролога._Давление_мм_Column.ColumnName)
                    s = "[Давление(мм)] > " + textBoxFilter.Text;
                if (s == testDataSet.Справочник_Метеоролога._Температура_С_Column.ColumnName)
                    s = "[Температура(С)] > " + textBoxFilter.Text;

                this.справочникМетеорологаBindingSource.Filter = s;
            }
            catch { MessageBox.Show("Error"); }
        
        }

        private void button7_Click(object sender, EventArgs e)
        {
            справочникМетеорологаBindingSource.RemoveFilter();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Добро пожаловать в Справочник Метеоролога!\n1) Для сохранения таблицы нажмите кнопку 'Save'\n2) Для загрузки сохраненной таблицы нажмите кнопку 'Load'\n3) Для добавления новой записи в таблицу нажмите кнопку 'Add'\n4) Для поиска любого значения таблицы нажмите кнопку 'Search'\n5) Фильтрация: Выбирая Название или Время года вы вписываете в textbox нужное слово и все остальные записи в таблице стираются.\n Однако выбирая температуру или давление вы отфильтровываете все записи больше введенного значения, записи с значением меньше вписанного значения - удаляются\n6) Для сортировки данных в столбцах нажмите на название столбца\n7) Нажав на кнопку 'Pressure' программа выведет вам давление во все дни, а если нажать на кнопку 'Average Temp', то программа покажет среднюю температуру.\n8) Для удаления записи в таблице, выделите ряд и нажмите кнопку 'Del'");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var sum = (from name in testDataSet.Справочник_Метеоролога.AsEnumerable()
                       select name._Температура_С_).Average();
            textBoxSum.Text = sum.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
