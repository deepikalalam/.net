using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace phoneDairy
{
    public partial class phone : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=db1;Integrated Security=True");
        public phone()
        {
            InitializeComponent();
        }

        private void phone_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string cmdstr = "insert into Mobiles values ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+comboBox1.Text+"')";
            SqlCommand cmd = new SqlCommand(cmdstr,conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("successfully inserted!!");
            display();
            
        }

        void display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Mobiles", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = row[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = row["lname"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = row[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = row[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = row[4].ToString();
            }

        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string cmdstr = "delete from Mobiles where (mobile='"+textBox3.Text+"')";
            SqlCommand cmd = new SqlCommand(cmdstr, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("successfully deleted!!");
            display();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            string cmdstr = "update Mobiles set fname='"+textBox1.Text+"',lname='"+textBox2.Text+"',mobile='"+textBox3.Text+"',email='"+textBox4.Text+"',category='"+comboBox1.SelectedItem+"' where mobile='"+textBox3.Text+"'";
            SqlCommand cmd = new SqlCommand(cmdstr, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("successfully updated!!");
            display();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Mobiles where (mobile like '%"+textBox5.Text+ "%') or (fname like '%" + textBox5.Text + "%')", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = row[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = row["lname"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = row[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = row[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = row[4].ToString();
            }
        }
    }
}
