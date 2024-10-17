using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// bURAYI UNUTMA
using System.Data.OleDb;

namespace vt_baglanti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Bağlantı oluştur
        OleDbConnection bgl = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=vt.mdb");
        void formgoster()
        {
        bgl.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM tablo1", bgl);
        DataTable dt = new DataTable();
        da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.Close();
            }
    



        private void Form1_Load(object sender, EventArgs e)
        {
            formgoster();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            OleDbCommand sqlsorgu = new OleDbCommand(" INSERT INTO Tablo1 (ogr_no,adSoyad) VALUES('"+textBox1.Text+"','"+textBox2.Text+"')",bgl);
            bgl.Open();
            sqlsorgu.ExecuteNonQuery();
            bgl.Close();

          
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            OleDbCommand sqlsorgu = new OleDbCommand(" DELETE FROM Tablo1  WHERE Kimlik = " + textBox3.Text,bgl);
            bgl.Open();
            sqlsorgu.ExecuteNonQuery();
            bgl.Close();
            formgoster();
            textBox3.Text = "";

        }
    }
}
