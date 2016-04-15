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
            dgvMateriais.DataSource = null;
            dgvMateriais.Rows.Clear();
            dgvMateriais.Columns.Clear();
            string query = "select Materiais.Material, Materiais.Quantidade, Materiais.Obs as Observações, Materiais.ukey as Código from Materiais";
            SQLiteConnection conn = new SQLiteConnection(connstring);
            DataSet ds = Almo_DB.SQLite_select(query, conn);
            dgvMateriais.DataSource = ds.Tables[0];
            dgvMateriais.Refresh();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            dgvMateriais.DataSource = null;
            dgvMateriais.Rows.Clear();
            dgvMateriais.Columns.Clear();
            string query = "select Materiais.Material, Materiais.Quantidade, Materiais.Obs as Observações, Materiais.ukey as Código from Materiais where Materiais.ukey = '" + tbUkey.Text.Trim().ToUpper() + "'";
            SQLiteConnection conn = new SQLiteConnection(connstring);
            DataSet ds = Almo_DB.SQLite_select(query, conn);
            dgvMateriais.DataSource = ds.Tables[0];
            dgvMateriais.Refresh();
        }

        private void btNovoItem_Click(object sender, EventArgs e)
        {
            dgvMateriais.DataSource = null;
            dgvMateriais.Rows.Clear();
            dgvMateriais.Columns.Clear();
            dgvMateriais.Columns.Add("Material", "Material");
            dgvMateriais.Columns.Add("Quantidade", "Quantidade");
            dgvMateriais.Columns.Add("Obs", "Observações");
            dgvMateriais.Columns.Add("Ukey", "Código");
            dgvMateriais.Columns["Ukey"].ReadOnly = true;
            dgvMateriais.Rows.Add();
            btNovoItem.Enabled = false;
            btEditar.Enabled = false;
            btDeletar.Enabled = false;
            Enable_save("NovoItem");
        }

        private void Enable_save(string origem)
        {
            btSalvar.Enabled = true;
            switch (origem)
            {
                case "Editar":
                    string updateQuery = "update Materiais set Material = '"
                        + dgvMateriais.Rows[dgvMateriais.SelectedRows[0].Index].Cells["Material"].FormattedValue.ToString()
                        + "', Quantidade = "
                        + int.Parse(dgvMateriais.Rows[dgvMateriais.SelectedRows[0].Index].Cells["Quantidade"].FormattedValue.ToString())
                        + ", Obs = '"
                        + dgvMateriais.Rows[dgvMateriais.SelectedRows[0].Index].Cells["Obs"].FormattedValue.ToString()
                        + "' where ukey = '"
                        + dgvMateriais.Rows[dgvMateriais.SelectedRows[0].Index].Cells["Ukey"].FormattedValue.ToString().Trim()
                        + "'";
                    break;

                case "NovoItem":
                    string insertQuery = "INSERT INTO Materiais(Material, Quantidade, Obs, ukey) VALUES('"
                        + dgvMateriais.Rows[dgvMateriais.SelectedRows[0].Index].Cells["Material"].FormattedValue.ToString()
                        + "', "
                        + int.Parse(dgvMateriais.Rows[dgvMateriais.SelectedRows[0].Index].Cells["Quantidade"].FormattedValue.ToString())
                        + ", '"
                        + dgvMateriais.Rows[dgvMateriais.SelectedRows[0].Index].Cells["Obs"].FormattedValue.ToString()
                        + "', '"
                        + dgvMateriais.Rows[dgvMateriais.SelectedRows[0].Index].Cells["Ukey"].FormattedValue.ToString().Trim()
                        + "');";
                    break;

                case "Deletar":
                    string deleteQuery = "delete from Materiais where ukey = '"
                        + dgvMateriais.Rows[dgvMateriais.SelectedRows[0].Index].Cells["Ukey"].FormattedValue.ToString().Trim()
                        + "'";
                    break;
            }
        }

        void dgvMateriais_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvMateriais.Rows[e.RowIndex].ErrorText = String.Empty;
        }
    }
}