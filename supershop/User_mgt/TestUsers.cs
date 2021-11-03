using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Finisar.SQLite;

namespace supershop.User_mgt
{
    public partial class TestUsers : Form
    {
        public TestUsers()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection("Data Source=(local);Initial Catalog=Northwind; User ID=sa;Password=sapass123!");
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
         
        SqlCommand cmd = new SqlCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            listView1.Clear();
            ImageList imagelist = new ImageList();
            imagelist.ColorDepth = ColorDepth.Depth32Bit;
            listView1.LargeImageList = imagelist;
            listView1.LargeImageList.ImageSize = new System.Drawing.Size(130, 130);
            cmd.Connection = cn;
            cmd.CommandText = "Select * from Employees";
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var img_buffer = (byte[])(dr["Photo"]);
                MemoryStream img_stream = new MemoryStream(img_buffer, true);
                img_stream.Write(img_buffer, 0, img_buffer.Length);
                imagelist.Images.Add(dr["Photo"].ToString(), new Bitmap(img_stream));
                img_stream.Close();
                ListViewItem Ivpa = new ListViewItem();
                Ivpa.Text = dr["LastName"].ToString();
                Ivpa.ImageKey = dr["Photo"].ToString();
                listView1.Items.Add(Ivpa);
                listView1.Items.Add(dr["City"].ToString());
                listView1.Items.Add(dr["Country"].ToString());
            }

            cn.Close();
        }

        private void TestUsers_Load(object sender, EventArgs e)
        {
         //   dataGridView1.ColumnCount = 1;
           // dataGridView1.Columns[0].Name = "Product ID";
           // dataGridView1.Columns[1].Name = "Product Name";
           // dataGridView1.Columns[2].Name = "Product Price";

            string sql = "select id, name  from usermgt where TenentID = " + Tenent.TenentID + "  ";
            DataAccess.ExecuteSQL(sql);            
            
            DataTable dt = DataAccess.GetDataTable(sql);
            DataSet ds = DataAccess.GetDataSet(sql);

            dataGridView1.DataSource = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                string[] row = new string[] { dr["id"].ToString() };
                dataGridView1.Rows.Add(row);

                DataGridViewImageColumn img = new DataGridViewImageColumn();
                Image image = Image.FromFile(Application.StartupPath + @"\IMAGE\" + dr["id"].ToString() + ".jpg");
                img.Image = image;
                dataGridView1.Columns.Add(img);
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Rows[2].Height = 200;
                img.HeaderText = "Image";
                img.Name = "img";
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 120;
            dataGridView1.AllowUserToAddRows = false;

          ////  ds();

          //      dataGridView1.DataSource = dt;
            
           
          //      DataGridViewImageColumn img = new DataGridViewImageColumn();
          //      Image image = Image.FromFile(Application.StartupPath + @"\IMAGE\" + "1.jpg");
          //      img.Image = image;
          //      dataGridView1.Columns.Add(img);
          //      dataGridView1.Columns[2].Width = 200;
          //      dataGridView1.Rows[2].Height = 200;
          //      img.HeaderText = "Image";
          //      img.Name = "img";

          //      // Use of the DataGridViewColumnSelector
          //      DataGridViewColumnSelector cs = new DataGridViewColumnSelector(dataGridView1);
          //      cs.MaxHeight = 100;
          //      cs.Width = 110;
            
           
        }
    }
}
