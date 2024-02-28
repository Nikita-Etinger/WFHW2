using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;




namespace hw2
{
    public partial class Fourth1 : Form
    {
        private BindingList<Good> goods; 

        public Fourth1()
        {
            InitializeComponent();
            goods = new BindingList<Good>();
            InitializeGrid();

           // goods.Add(new Good("test", "test", (float)123.4));
            LoadJson();
        }
        private void LoadJson()
        {
            try
            {
                string jsonFilePath = "doc.json"; 
                if (File.Exists(jsonFilePath))
                {
                    string jsonData = File.ReadAllText(jsonFilePath);
                    goods = JsonConvert.DeserializeObject<BindingList<Good>>(jsonData);
                    dataGridView1.DataSource = goods;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveJson()
        {
            try
            {
                string jsonFilePath = "doc.json"; 
                string jsonData = JsonConvert.SerializeObject(goods, Formatting.Indented);
                File.WriteAllText(jsonFilePath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InitializeGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ReadOnly = true; // Блокировка редактирования
            dataGridView1.DataSource = goods;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Выбор всей строки
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "Name";
            nameColumn.Width = 145; 
            dataGridView1.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn countryColumn = new DataGridViewTextBoxColumn();
            countryColumn.DataPropertyName = "Country";
            countryColumn.HeaderText = "Country";
            countryColumn.Width = 145; 
            dataGridView1.Columns.Add(countryColumn);

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.DataPropertyName = "Price";
            priceColumn.HeaderText = "Price";
            priceColumn.Width = 145; 
            dataGridView1.Columns.Add(priceColumn);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            Good good = new Good();
            Fourth2 f = new Fourth2(good);
            DialogResult result = f.ShowDialog();

            
            if (result == DialogResult.OK)
            {
                goods.Add(good);
              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                int selectedIndex = dataGridView1.SelectedRows[0].Index;


                Good newGood = goods[selectedIndex];
                Fourth2 f = new Fourth2(newGood);
                DialogResult result = f.ShowDialog();

               
                if (result == DialogResult.OK)
                {
                    goods[selectedIndex] = newGood;

                    
                    dataGridView1.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для редактирования.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                DialogResult result = MessageBox.Show($"Удалить товар {goods[selectedIndex].Name} ?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    goods.Remove(goods[selectedIndex]);
                }


            }
        }

        private void Fourth1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveJson();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Очистить всё?", "Очистка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                goods.Clear();
                SaveJson();
            }
        }

        private void goodToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Good good = new Good();
            Fourth2 f = new Fourth2(good);
            DialogResult result = f.ShowDialog();


            if (result == DialogResult.OK)
            {
                goods.Add(good);

            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int selectedIndex = dataGridView1.SelectedRows[0].Index;


                Good newGood = goods[selectedIndex];
                Fourth2 f = new Fourth2(newGood);
                DialogResult result = f.ShowDialog();


                if (result == DialogResult.OK)
                {
                    goods[selectedIndex] = newGood;


                    dataGridView1.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для редактирования.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                DialogResult result = MessageBox.Show($"Удалить товар {goods[selectedIndex].Name} ?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    goods.Remove(goods[selectedIndex]);
                }


            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Очистить всё?", "Очистка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                goods.Clear();
                SaveJson();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveJson();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}