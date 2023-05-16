using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicNotebook_Coursework
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            UpdateData();
        }

        private void AddNewEntry(object sender, EventArgs e)
        {
            var addForm = new EntryForm();
            addForm.ShowDialog();
            UpdateData();
        }

        private void EditEntry(object sender, EventArgs e)
        {
            string[] words = { dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString(), dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString(), dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString()};
            var addForm = new EntryForm(words);
            addForm.ShowDialog();
            UpdateData();
        }

        private void DeleteEntry(object sender, EventArgs e)
        {
            string text;
            string oldObject = $"{dataGridView1[0, dataGridView1.CurrentRow.Index].Value} {dataGridView1[1, dataGridView1.CurrentRow.Index].Value} {dataGridView1[2, dataGridView1.CurrentRow.Index].Value}";
            string path = "NotebookDB.txt";
            string newObject = "";
            using (StreamReader reader = new StreamReader(path))
            {
                text = reader.ReadToEnd();
            }
            text = text.Replace(oldObject, newObject);
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLineAsync(text);
            }
            UpdateData();
        }
        private void UpdateData()
        {
            dataGridView1.Rows.Clear();
            string path = "NotebookDB.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length > 0)
                    {
                        dataGridView1.Rows.Add(words[0], words[1], words[2]);
                    }
                }
            }
        }
    }
}
