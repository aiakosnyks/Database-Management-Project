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
    public partial class model : Form
    {
        public model()
        {
            InitializeComponent();
        }
        NpgsqlConnection connect = new NpgsqlConnection("server=localhost; port=5432; Database=CarDealer; user ID=postgres; password=1234");

        private void aracIdLbl_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("INSERT INTO \"model\"(modelId, versiyon, modelAd, kasaTipi, vites) VALUES(@p1,@p2 @p3, @p4, @p4, @p5)", connect);
            command1.Parameters.AddWithValue("@p1", int.Parse(TxtModelId.Text));
            command1.Parameters.AddWithValue("@p2", TxtVersiyon.Text);
            command1.Parameters.AddWithValue("@p3", TxtModelAd.Text);
            command1.Parameters.AddWithValue("@p4", TxtKasaTipi.Text);
            command1.Parameters.AddWithValue("@p5", TxtVites.Text);
            command1.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Ekleme işlemi başarılı.");
        }

        private void ekleBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("INSERT INTO \"model\"(\"modelId\", \"versiyon\", \"modelAd\", \"kasaTipi\", \"vites\") VALUES(@p1, @p2, @p3, @p4, @p5)", connect);
            command1.Parameters.AddWithValue("@p1", int.Parse(TxtModelId.Text));
            command1.Parameters.AddWithValue("@p2", TxtVersiyon.Text);
            command1.Parameters.AddWithValue("@p3", TxtModelAd.Text);
            command1.Parameters.AddWithValue("@p4", TxtKasaTipi.Text);
            command1.Parameters.AddWithValue("@p5", TxtVites.Text);
            command1.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Ekleme işlemi başarılı.");
        }

        private void silBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("DELETE FROM \"model\" WHERE \"modelId\" = @p1", connect);
            command1.Parameters.AddWithValue("@p1", int.Parse(TxtModelId.Text));
            command1.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Silme işlemi başarıyla gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void guncelleBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("UPDATE \"model\" set \"modelAd\" = @p2, \"versiyon\" = @p3, \"kasaTipi\" = @p4, \"vites\" = @p5 where \"modelId\" = @p1 ", connect);
            command3.Parameters.AddWithValue("@p1", int.Parse(TxtModelId.Text));
            command3.Parameters.AddWithValue("@p2", TxtModelAd.Text);
            command3.Parameters.AddWithValue("@p3", TxtVersiyon.Text);
            command3.Parameters.AddWithValue("@p4", TxtKasaTipi.Text);
            command3.Parameters.AddWithValue("@p5", TxtVites.Text);
            command3.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Güncelleme Başarılı.");

        }

        private void araBtn_Click(object sender, EventArgs e)
        {
            /*
            connect.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("SELECT * from model_bul('@p1%')", connect);
            command1.Parameters.AddWithValue("@p1", TxtModelAd.Text);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connect.Close();
            MessageBox.Show("Arama işlemi sona erdi.");
            */
            connect.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from \"model\" where \"modelAd\" like '%" + TxtModelAd.Text + "%'", connect);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connect.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand sorgu = new NpgsqlCommand("select * from \"model\"", connect);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connect.Close();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            //System.Windows.Forms.Application.Exit();
        }
    }
}
