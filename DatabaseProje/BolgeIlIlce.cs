using System;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DatabaseProje
{
    public partial class BolgeIlIlce : Form
    {
        public BolgeIlIlce()
        {
            InitializeComponent();
        }
        NpgsqlConnection connect = new NpgsqlConnection("server=localhost; port=5432; Database=CarDealer; user ID=postgres; password=1234");
        private void aracIdLbl_Click(object sender, EventArgs e)
        {

        }

        private void Bolgeİlİlce_Load(object sender, EventArgs e)
        {

        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand sorgu = new NpgsqlCommand("select * from \"BolgeIlIlceView\"", connect);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connect.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void anaMenuBtn_Click(object sender, EventArgs e)
        {
                    }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ekleBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("INSERT INTO \"bolge\"(\"bolgeId\", \"bolgeAd\", \"ilId\") VALUES(@p1, @p2, @p3); ", connect);
            NpgsqlCommand command2 = new NpgsqlCommand("INSERT INTO \"il\"(\"ilAd\") VALUES(@p1); ", connect);
            NpgsqlCommand command3 = new NpgsqlCommand("INSERT INTO \"ilce\"(\"ilceId\", \"ilceAd\", \"infoId\") VALUES(@p1, @p2, @p3);", connect);
            command1.Parameters.AddWithValue("@p1", int.Parse(bolgeIdTxt.Text));
            command1.Parameters.AddWithValue("@p2", bolgeAdTxt.Text);
            command1.Parameters.AddWithValue("@p3", int.Parse(ilIdTxt.Text));
            command2.Parameters.AddWithValue("@p1", ilceAdTxt.Text);
            command3.Parameters.AddWithValue("@p1", int.Parse(ilceIdTxt.Text));
            command3.Parameters.AddWithValue("@p2", ilceAdTxt.Text);
            command3.Parameters.AddWithValue("@p3", int.Parse(infoIdTxt.Text));
            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command3.ExecuteNonQuery();

        }

        private void silBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("DELETE FROM \"bolge\" WHERE \"bolgeId\" = @p1", connect);
            command1.Parameters.AddWithValue("@p1", int.Parse(bolgeIdTxt.Text));
            NpgsqlCommand command2 = new NpgsqlCommand("DELETE FROM \"il\" WHERE \"ilId\" = @p2", connect);
            command1.Parameters.AddWithValue("@p2", int.Parse(ilIdTxt.Text));
            NpgsqlCommand command3 = new NpgsqlCommand("DELETE FROM \"ilce\" WHERE \"ilceId\" = @p3", connect);
            command1.Parameters.AddWithValue("@p3", int.Parse(ilceIdTxt.Text));
            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Silme işlemi başarıyla gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void guncelleBtn_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("UPDATE \"bolge\" set \"bolgeAd\" = @p2, \"ilId\" = @p3 where \"bolgeId\" = @p1 ", connect);
            NpgsqlCommand command2 = new NpgsqlCommand("UPDATE \"il\" set \"ilAd\" = @p2 where \"ilId\" = @p1 ", connect);
            NpgsqlCommand command3 = new NpgsqlCommand("UPDATE \"ilce\" set \"ilceAd\" = @p2, \"infoId\" = @p3 where \"ilceId\" = @p1 ", connect);
            command1.Parameters.AddWithValue("@p1", bolgeIdTxt.Text);
            command1.Parameters.AddWithValue("@p2", infoIdTxt.Text);
            command1.Parameters.AddWithValue("@p3", ilIdTxt.Text);
            command3.Parameters.AddWithValue("@p1", ilceIdTxt.Text);
            command3.Parameters.AddWithValue("@p2", ilceAdTxt.Text);
            command3.Parameters.AddWithValue("@p3", sss.Text);
            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command3.ExecuteNonQuery();
        }
    }
}
