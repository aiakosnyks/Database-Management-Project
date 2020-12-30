using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;


namespace DatabaseProje
{
    public partial class KullaniciSatisİkinciEl : Form
    {
        public KullaniciSatisİkinciEl()
        {
            InitializeComponent();
        }
        NpgsqlConnection connect = new NpgsqlConnection("server=localhost; port=5432; Database=CarDealer; user ID=postgres; password=1234");

        private void KullaniciSatisİkinciEl_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void viewBtn_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand sorgu = new NpgsqlCommand("select * from \"MusteriSatisİkinciElView\"", connect);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connect.Close();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ekleBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("INSERT INTO musteri(kullaniciId, name, lastname, username, password, infoId) VALUES(@p1, @p2, @p3, @p4, @p5, @p6", connect);
            NpgsqlCommand command2 = new NpgsqlCommand("INSERT INTO ikinciEl(aracId, yakitTipi, satisId, kategoriId, renk, modelId, yil, marka, fiyat, km, plaka, saseNo, resim) VALUES(@p1, @p2, @p3, @p4, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13)", connect);
            command3.Parameters.AddWithValue("@p1",kullaniciIdTxt.Text);
            command3.Parameters.AddWithValue("@p2", isimTxt.Text);
            command3.Parameters.AddWithValue("@p3", soyisimTxt.Text);
            command3.Parameters.AddWithValue("@p4", usernameTxt.Text);
            command3.Parameters.AddWithValue("@p5", passwordTxt.Text);
            command3.Parameters.AddWithValue("@p6", infoIdTxt.Text);    
            command2.Parameters.AddWithValue("@p1", aracIdTxt.Text);
            command2.Parameters.AddWithValue("@p2", yakitTipiTxt.Text);
            command2.Parameters.AddWithValue("@p3", satisIdTxt.Text);
            command2.Parameters.AddWithValue("@p4", kategoriIdTxt.Text);
            command2.Parameters.AddWithValue("@p5", renkTxt.Text);
            command2.Parameters.AddWithValue("@p6", modelIdTxt.Text);
            command2.Parameters.AddWithValue("@p7", yilTxt.Text);
            command2.Parameters.AddWithValue("@p8", markaTxt.Text);
            command2.Parameters.AddWithValue("@p9", fiyatTxt.Text);
            command2.Parameters.AddWithValue("@p10", kmTxt.Text);
            command2.Parameters.AddWithValue("@p11", plakaTxt.Text);
            command2.Parameters.AddWithValue("@p12", saseNoTxt.Text);
            //command2.Parameters.AddWithValue("@p12", resimBtn); ////////!!!!!!!!!!!!!!!!!!
            command2.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Ekleme işlemi başarılı.");
        }

        private void modelAdTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void silBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("DELETE FROM musteri WHERE musteriId = @p1", connect);
            command1.Parameters.AddWithValue("@p1", int.Parse(kullaniciIdTxt.Text));
            NpgsqlCommand command2 = new NpgsqlCommand("DELETE FROM musteri WHERE satisId = @p2", connect);
            command1.Parameters.AddWithValue("@p2", int.Parse(satisIdTxt.Text));
            NpgsqlCommand command3 = new NpgsqlCommand("DELETE FROM musteri WHERE aracId = @p3", connect);
            command1.Parameters.AddWithValue("@p3", int.Parse(aracIdTxt.Text));
            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Silme işlemi başarıyla gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void guncelleBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("UPDATE satis set odemeTarih = @p2, kdv = @p3, indirim = @p4, alisFiyati = @p5, satisFiyat = @p6 where satisId=@p1", connect);
            NpgsqlCommand command1 = new NpgsqlCommand("UPDATE musteri set name = @p2, lastname = @3, username = @p4, password = @p5, satisId = @p6 where kullaniciId = @p1", connect);
            NpgsqlCommand command2 = new NpgsqlCommand("UPDATE ikinciEl set  yakitTipi= @p2, renk = @p3, saseNo = @p4, plaka = @p5, km = @p6, modelId = @p7, yil = @p8, marka = @9, fiyat = @10, resim = @p12, kategoriId =@p11 where aracId = @p1", connect);
            command2.Parameters.AddWithValue("@p2", yakitTipiTxt.Text);
            command2.Parameters.AddWithValue("@p1", aracIdTxt.Text);
            command2.Parameters.AddWithValue("@p3", renkTxt.Text);
            command2.Parameters.AddWithValue("@p4", saseNoTxt.Text);
            command2.Parameters.AddWithValue("@p5", plakaTxt.Text);
            command2.Parameters.AddWithValue("@p6", kmTxt.Text);
            command2.Parameters.AddWithValue("@p7", modelIdTxt.Text);
            command2.Parameters.AddWithValue("@p8", yilTxt.Text);
            command2.Parameters.AddWithValue("@p9", markaTxt.Text);
            command2.Parameters.AddWithValue("@p10", fiyatTxt.Text);
            command2.Parameters.AddWithValue("@p11", kategoriIdTxt.Text);
           // command2.Parameters.AddWithValue("@p12", resimTxt.Text);
            command1.Parameters.AddWithValue("@p1", kullaniciIdTxt.Text);
            command1.Parameters.AddWithValue("@p2", isimTxt.Text);
            command1.Parameters.AddWithValue("@p3", soyisimTxt.Text);
            command1.Parameters.AddWithValue("@p4", usernameTxt.Text);
            command1.Parameters.AddWithValue("@p5", passwordTxt.Text);
            command1.Parameters.AddWithValue("@p6", satisIdTxt.Text);
            command3.Parameters.AddWithValue("@p1", satisIdTxt.Text);
            command3.Parameters.AddWithValue("@p2",yakitTipiTxt.Text);
            command3.Parameters.AddWithValue("@p3", renkTxt.Text);
            command3.Parameters.AddWithValue("@p4", saseNoTxt.Text);
            command3.Parameters.AddWithValue("@p5", plakaTxt.Text);
            command3.Parameters.AddWithValue("@p6", kmTxt.Text);
            command3.Parameters.AddWithValue("@p7", modelIdTxt.Text);
            command3.Parameters.AddWithValue("@p8", yilTxt.Text);
            command3.Parameters.AddWithValue("@p9", markaTxt.Text);
            command3.Parameters.AddWithValue("@p10", fiyatTxt.Text);
            command3.Parameters.AddWithValue("@p11", kategoriIdTxt.Text);
            command2.ExecuteNonQuery();
            command1.ExecuteNonQuery();
            command3.ExecuteNonQuery();
        }

        private void modelIdTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
