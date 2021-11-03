using ResourceEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace supershop
{
    public partial class Resediter : Form
    {
        public Resediter()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Resediter_Load(object sender, EventArgs e)
        {
            string resourcespath = Application.StartupPath + @"\language\";
            DirectoryInfo dirInfo = new DirectoryInfo(resourcespath);
            foreach (FileInfo filInfo in dirInfo.GetFiles("*.RESX", SearchOption.AllDirectories))
            {
                string filename = filInfo.Name;
                comboBox1.Items.Add(filename);
            }
        }

        private ResourceHolder currentResourceHolder;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filename = Application.StartupPath + @"\language\" + comboBox1.Text;

            ResXResourceReader rrdr = null;
            rrdr = new ResXResourceReader(filename);
            currentResourceHolder = new ResourceHolder(rrdr);
            propertyGridResources.SelectedObject = currentResourceHolder;
        }

        private void WriteResXFile(string fileName)
        {
            ResXResourceWriter rwtr = null;
            try
            {
                rwtr = new ResXResourceWriter(fileName);
                currentResourceHolder.WriteResources(rwtr);
            }
            finally
            {
                if (null != rwtr) rwtr.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = Application.StartupPath + @"\language\" + comboBox1.Text;
            WriteResXFile(filename);
            MessageBox.Show("Save Successfull \n You Need restart the Application to Take Changes");

        }
    }
}
