using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void AddNewEntry(object sender, EventArgs e)
        {
            var addForm = new EntryForm();
            addForm.ShowDialog();
            UpdateData();
        }

        private void EditEntry(object sender, EventArgs e)
        {

        }

        private void DeleteEntry(object sender, EventArgs e)
        {

        }
        private void UpdateData()
        {

        }
    }
}
