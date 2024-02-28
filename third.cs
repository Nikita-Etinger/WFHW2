using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace hw2
{
    public partial class third : Form
    {
        private CountryList countryList;

        public third()
        {
            InitializeComponent();
            LoadDataFromJson();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            textBox6.KeyPress += textBox6_KeyPress;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            dateTimePicker1.MaxDate = DateTime.Now;
        }

        private void LoadDataFromJson()
        {
            try
            {

                string jsonFilePath = "countries.json";
                string jsonData = File.ReadAllText(jsonFilePath, Encoding.UTF8);

                // Десериализуем JSON 
                countryList = JsonConvert.DeserializeObject<CountryList>(jsonData);


                foreach (var country in countryList.Countries)
                {
                    comboBox1.Items.Add(country.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке данных из JSON файла: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox2.Items.Clear();
            comboBox2.Text = "";

            string selectedCountryName = comboBox1.SelectedItem.ToString();


            Country selectedCountry = countryList.Countries.Find(country => country.Name == selectedCountryName);

            foreach (var city in selectedCountry.Cities)
            {
                comboBox2.Items.Add(city);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool allFieldsFilled = true;


            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        textBox.BackColor = Color.Red; 
                        allFieldsFilled = false; 
                    }
                    else
                    {
                        textBox.BackColor = SystemColors.Window; 
                    }
                }
            }

            if (textBox6.Text.Length < 16)
            {
                textBox6.BackColor = Color.Red;
                allFieldsFilled = false;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                comboBox1.BackColor = Color.Red;
                allFieldsFilled = false;
            }
            else
            {
                comboBox1.BackColor = SystemColors.Window;
            }


            if (string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                comboBox2.BackColor = Color.Red;
                allFieldsFilled = false;
            }
            else
            {
                comboBox2.BackColor = SystemColors.Window;
            }
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                allFieldsFilled = false;
            }


            if (!allFieldsFilled)
            {
                MessageBox.Show("Необходимо заполнить все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ShowFormData();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (char.IsDigit(e.KeyChar) && textBox.Text.Length < 16)
            {
                if (textBox.Text.Length == 0)
                {
                    textBox.Text += "+";
                    textBox.SelectionStart = textBox.Text.Length;
                }
                else if (textBox.Text.Length == 1)
                {
                    textBox.Text += e.KeyChar + "(";
                    textBox.SelectionStart = textBox.Text.Length;
                }
                else if (textBox.Text.Length == 6)
                {
                    textBox.Text += ")" + e.KeyChar;
                    textBox.SelectionStart = textBox.Text.Length;
                }
                else if (textBox.Text.Length == 10)
                {
                    textBox.Text += "-" + e.KeyChar;
                    textBox.SelectionStart = textBox.Text.Length;
                }
                else if (textBox.Text.Length == 13)
                {
                    textBox.Text += "-" + e.KeyChar;
                    textBox.SelectionStart = textBox.Text.Length;
                }
                else
                {
                    textBox.Text += e.KeyChar;
                    textBox.SelectionStart = textBox.Text.Length;
                }

                e.Handled = true;
            }

            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }
        }

        private void ShowFormData()
        {

            string fullName = $"{textBox1.Text} {textBox2.Text} {textBox3.Text}";
            string country = comboBox1.Text;
            string city = comboBox2.Text;
            string phoneNumber = textBox6.Text;
            string birthDate = dateTimePicker1.Value.ToShortDateString();
            string gender = radioButton1.Checked ? "Мужской" : "Женский";


            string message = $"ФИО: {fullName}\n" +
                             $"Страна: {country}\n" +
                             $"Город: {city}\n" +
                             $"Номер телефона: {phoneNumber}\n" +
                             $"Дата рождения: {birthDate}\n" +
                             $"Пол: {gender}";


            MessageBox.Show(message, "Анкета", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }


    public class CountryList
    {
        public List<Country> Countries { get; set; }
    }


    public class Country
    {
        public string Name { get; set; }
        public List<string> Cities { get; set; }
    }


}
