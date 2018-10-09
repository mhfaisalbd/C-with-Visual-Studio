using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public OracleConnection conn;
        public OracleCommand cmd;
        public OracleDataAdapter od;
        OracleDataReader or;
        OracleCommand show = new OracleCommand();
        string connection = "DATA SOURCE=XE;PASSWORD=hr;USER ID=HR;";
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(connection);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            od = new OracleDataAdapter();
            show.CommandText = "select * from phonebook";
            show.CommandType = CommandType.Text;
            od.SelectCommand = show;
            //t = new DataTable();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "insert into phonebook values ('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.SelectedItem.ToString() + "')";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "delete from phonebook where mobile_no='"+textBox3.Text+"'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
           
        }

    }
}
