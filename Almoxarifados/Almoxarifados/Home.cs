using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using DB_Classes;

namespace Almoxarifados
{
    public partial class Home : Form
    {
        string connstring = "data source = C:\\Program Files\\Almoxarifado\\Banco de dados\\Almoxarifado.db";
        DB_SQLite Almo_DB = new DB_SQLite();
        public Home()
        {
            InitializeComponent();
        }

        private void btPesquisarTudo_Click(object sender, EventArgs e)
        {
            string query = "select Materiais.Material, Materiais.Quantidade, Materiais.Obs as Observações, Materiais.ukey as Código from Materiais";
            SQLiteConnection conn = new SQLiteConnection(connstring);
            DataSet ds = Almo_DB.SQLite_select(query, conn);
            dgvMateriais.DataSource = ds.Tables[0];
            dgvMateriais.Refresh();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            string query = "select Materiais.Material, Materiais.Quantidade, Materiais.Obs as Observações, Materiais.ukey as Código from Materiais where Materiais.ukey = '" + tbUkey.Text.Trim() + "'";
            SQLiteConnection conn = new SQLiteConnection(connstring);
            DataSet ds = Almo_DB.SQLite_select(query, conn);
            dgvMateriais.DataSource = ds.Tables[0];
            dgvMateriais.Refresh();
        }
    }
}