using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kulinaria_app
{
    public partial class Form1 : Form
    {
        public static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Den/source/repos/Kulinaria_app/Kulinaria1.accdb;";
        public OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }
        public int row_index, column_index;
        private void Form1_Load(object sender, EventArgs e)
        {
            Controls.Add(panel1);
            panel1.Controls.Clear();
            panel1.Controls.Add(button1);
            string query = "SELECT Name from Recept";
            DataSet Rece = new DataSet();
            OleDbDataAdapter Rec = new OleDbDataAdapter(query, myConnection);
            Rec.Fill(Rece);
            dataGridView1.DataSource = Rece.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(button2);
            row_index = dataGridView1.CurrentCell.RowIndex;
            string query_info = $"SELECT Name, Ingradients, Receipt from Recept WHERE Name = '{dataGridView1.Rows[row_index].Cells[0].Value.ToString()}'";
            DataSet Rec_i1 = new DataSet();
            OleDbDataAdapter Rec_i = new OleDbDataAdapter(query_info, myConnection);
            Rec_i.Fill(Rec_i1);
            dataGridView1.DataSource = Rec_i1.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1_Load(null,null);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }
    }
}