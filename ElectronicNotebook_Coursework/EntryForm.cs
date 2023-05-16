using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ElectronicNotebook_Coursework
{
    public partial class EntryForm : Form
    {
        bool check = true;
        bool editing = false;
        string oldEntry;
        public EntryForm()
        {
            InitializeComponent();
        }
        public EntryForm(string[] words) : this()
        {
            editing = true;
            textBox1.Text = words[0];
            textBox2.Text = words[1];
            string[] date = words[2].Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            dateTimePicker1.Value = new DateTime(Int32.Parse(date[2]), Int32.Parse(date[1]), Int32.Parse(date[0]));
            button1.Text = "Изменить";
            oldEntry = $"{words[0]} {words[1]} {words[2]}";
        }

        private void AddOrEditEntry(object sender, EventArgs e)
        {
            string path = "NotebookDB.txt";

            if (textBox1.Text == "")
            {
                ErrorMessage("Фамилия и инициалы");
            }
            if (!int.TryParse(textBox2.Text, out int number) && textBox2.Text == "")
            {
                ErrorMessage("Номер телефона");
            }

            if (check)
            {
                if (editing)
                {
                    Edit(oldEntry);
                }
                else
                {
                    Entry entry = new Entry(textBox1.Text, number, dateTimePicker1.Value.ToShortDateString());
                    string text = $"{entry.Name} {entry.PhoneNumber} {entry.DOB}";

                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLineAsync(text);
                    }
                }
            }
            Close();
        }
        private void Edit(string oldObject)
        {
            string text;
            string path = "NotebookDB.txt";
            string newObject = $"{textBox1.Text} {textBox2.Text} {dateTimePicker1.Value.ToShortDateString()}";
            using (StreamReader reader = new StreamReader(path))
            {
                text = reader.ReadToEnd();
            }
            text = text.Replace(oldObject, newObject);
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLineAsync(text);
            }
            ClearEmptyLines();
        }
        private void ClearEmptyLines()
        {
            int i;
            string[] mass = File.ReadAllLines("NotebookDB.txt");
            StreamWriter NewFile = File.CreateText("NotebookDB.txt");
            for (i = 0; i < mass.Length; i++)
            {
                if (mass[i] != "")
                {
                    NewFile.WriteLine(mass[i]);
                }
            }
            NewFile.Close();
        }
        private void ErrorMessage(string field)
        {
            MessageBox.Show($"Поле \"{field}\" не может быть пустым!", "Ошибка!", MessageBoxButtons.OK);
            check = false;
        } 
    }
}
