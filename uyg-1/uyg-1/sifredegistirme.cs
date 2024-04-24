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

namespace uyg_1
{
    public partial class sifredegistirme : Form
    {
        public sifredegistirme()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:Kütüphane.mdb");
        void sifregöster()
        {
            baglan.Open();
            OleDbDataAdapter adpt = new OleDbDataAdapter("SELECT * FROM şifredegiştir", baglan);
         
        
     
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglan = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =C:Kütüphane.mdb");
        
            if (textBox2.Text == textBox3.Text)
            {
                baglan.Open();

                OleDbCommand komut = new OleDbCommand("UPDATE klnc SET KullaniciAdi='" + textBox1.Text + "' WHERE Sifre='" + textBox2.Text + "'", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Şifre Başarıyla Değiştirilidi");
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }

        
            
        }

        private void sifredegistirme_Load(object sender, EventArgs e)
        {
            sifregöster();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
