using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using DB_Classes;

namespace Almoxarifados
{
    public partial class Materiais : Form
    {
        string connstring = "data source = C:\\Program Files\\Almoxarifado\\Banco de dados\\Almoxarifado.db";
        DB_SQLite Almo_DB = new DB_SQLite();
        string origemSAVE;
        public Materiais()
        {
            InitializeComponent();
        }

        private void btPesquisarTudo_Click(object sender, EventArgs e)
        {
            dgvMateriais.DataSource = null;
            dgvMateriais.Rows.Clear();
            dgvMateriais.Columns.Clear();
            string query = "select Materiais.Material, Materiais.Quantidade, Materiais.Obs as Observações, Materiais.Mapeamento, Materiais.ukey as Código from Materiais";
            SQLiteConnection conn = new SQLiteConnection(connstring);
            DataSet ds = Almo_DB.SQLite_select(query, conn);
            dgvMateriais.DataSource = ds.Tables[0];
            dgvMateriais.Refresh();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbBarcode.SelectedIndex > -1)
            {
                dgvMateriais.DataSource = null;
                dgvMateriais.Rows.Clear();
                dgvMateriais.Columns.Clear();
                string pesquisa = null;
                string query = null;
                switch (cbBarcode.SelectedIndex)
                {
                    case 0:
                        pesquisa = "Material";
                        query = "select Materiais.Material, Materiais.Quantidade, Materiais.Obs as Observações, Materiais.Mapeamento, Materiais.ukey as Código from Materiais where Materiais." + pesquisa + " = '" + tbUkey.Text.Trim() + "'";
                        if (cbPesquisa.Checked)
                        {
                            query = "select Materiais.Material, Materiais.Quantidade, Materiais.Obs as Observações, Materiais.Mapeamento, Materiais.ukey as Código from Materiais where Materiais." + pesquisa + " like '%" + tbUkey.Text.Trim() + "%'";
                        }
                        break;
                    case 1:
                        pesquisa = "Quantidade";
                        query = "select Materiais.Material, Materiais.Quantidade, Materiais.Obs as Observações, Materiais.Mapeamento, Materiais.ukey as Código from Materiais where Materiais." + pesquisa + " = '" + tbUkey.Text.Trim().ToUpper() + "'";
                        if (cbPesquisa.Checked)
                        {

                            query = "select Materiais.Material, Materiais.Quantidade, Materiais.Obs as Observações, Materiais.Mapeamento, Materiais.ukey as Código from Materiais where Materiais." + pesquisa + " like '%" + tbUkey.Text.Trim().ToUpper() + "%'";
                        }
                        break;
                    case 2:
                        pesquisa = "Obs";
                        query = "select Materiais.Material, Materiais.Quantidade, Materiais.Obs as Observações, Materiais.Mapeamento, Materiais.ukey as Código from Materiais where Materiais." + pesquisa + " = '" + tbUkey.Text.Trim() + "'";
                        if (cbPesquisa.Checked)
                        {
                            query = "select Materiais.Material, Materiais.Quantidade, Materiais.Obs as Observações, Materiais.Mapeamento, Materiais.ukey as Código from Materiais where Materiais." + pesquisa + " like '%" + tbUkey.Text.Trim() + "%'";
                        }
                        break;
                    case 3:
                        pesquisa = "Mapeamento";
                        query = "select Materiais.Material, Materiais.Quantidade, Materiais.Obs as Observações, Materiais.Mapeamento, Materiais.ukey as Código from Materiais where Materiais." + pesquisa + " = '" + tbUkey.Text.Trim().ToUpper() + "'";
                        if (cbPesquisa.Checked)
                        {
                            query = "select Materiais.Material, Materiais.Quantidade, Materiais.Obs as Observações, Materiais.Mapeamento, Materiais.ukey as Código from Materiais where Materiais." + pesquisa + " like '%" + tbUkey.Text.Trim().ToUpper() + "%'";
                        }
                        break;
                    case 4:
                        pesquisa = "ukey";
                        query = "select Materiais.Material, Materiais.Quantidade, Materiais.Obs as Observações, Materiais.Mapeamento, Materiais.ukey as Código from Materiais where Materiais." + pesquisa + " = '" + tbUkey.Text.Trim().ToUpper() + "'";
                        if (cbPesquisa.Checked)
                        {
                            query = "select Materiais.Material, Materiais.Quantidade, Materiais.Obs as Observações, Materiais.Mapeamento, Materiais.ukey as Código from Materiais where Materiais." + pesquisa + " like '%" + tbUkey.Text.Trim().ToUpper() + "%'";
                        }
                        break;
                }
                SQLiteConnection conn = new SQLiteConnection(connstring);
                DataSet ds = Almo_DB.SQLite_select(query, conn);
                dgvMateriais.DataSource = ds.Tables[0];
                dgvMateriais.Refresh();
            }
            else
            {
                MessageBox.Show("Selecione uma categoria para a busca", "Atenção");
            }
        }

        private void btNovoItem_Click(object sender, EventArgs e)
        {
            dgvMateriais.DataSource = null;
            dgvMateriais.Rows.Clear();
            dgvMateriais.Columns.Clear();
            dgvMateriais.Columns.Add("Material", "Material");
            dgvMateriais.Columns.Add("Quantidade", "Quantidade");
            dgvMateriais.Columns.Add("Obs", "Observações");
            dgvMateriais.Columns.Add("Mapeamento", "Mapeamento");
            dgvMateriais.Columns.Add("ukey", "Código");
            dgvMateriais.Rows.Add();
            dgvMateriais.ReadOnly = false;
            //dgvMateriais.Columns["ukey"].ReadOnly = true;
            Enable_save("NovoItem");
        }

        private void btDeletar_Click(object sender, EventArgs e)
        {
            if (dgvMateriais.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Deseja deletar o registro?", "Confirmação", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Enable_save("Deletar");
                    btSalvar.PerformClick();
                    MessageBox.Show("Registro deletado", "Confirmação");
                }
            }
            else
            {
                MessageBox.Show("Selecione um registro para deletar", "Atenção");
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            QueryAdapter(origemSAVE);
            btSalvar.Enabled = false;
            btCancelar.Enabled = false;
            btGerar.Enabled = true;
            btPesquisar.Enabled = true;
            btPesquisarTudo.Enabled = true;
            btNovoItem.Enabled = true;
            btEditar.Enabled = true;
            btDeletar.Enabled = true;
            dgvMateriais.ReadOnly = true;
            origemSAVE = null;
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            if (dgvMateriais.Rows.Count > 0)
            {
                dgvMateriais.ReadOnly = false;
                Enable_save("Editar");
            }
            else
            {
                MessageBox.Show("Selecione um registro para editar", "Atenção");
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            btNovoItem.Enabled = true;
            btEditar.Enabled = true;
            btDeletar.Enabled = true;
            btPesquisar.Enabled = true;
            btPesquisarTudo.Enabled = true;
            btGerar.Enabled = true;
            btSalvar.Enabled = false;
            btCancelar.Enabled = false;
            dgvMateriais.ReadOnly = true;
            origemSAVE = null;
        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            if (dgvMateriais.Rows.Count > 0)
            {
                string url = "http://www.barcode-generator.de/Generate_Barcode?type=code128&msg="
                    + dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells["Código"].FormattedValue.ToString().Trim()
                    + "&height=10&mw=0.20&hrp=bottom&hrsize=1.2mm&res=300&target=1&print=0";
                System.Diagnostics.Process.Start(url);
            }
            else
            {
                MessageBox.Show("Selecione um registro para gerar o código", "Atenção");
            }
        }

        private void Enable_save(string origem)
        {
            btNovoItem.Enabled = false;
            btEditar.Enabled = false;
            btDeletar.Enabled = false;
            btPesquisar.Enabled = false;
            btPesquisarTudo.Enabled = false;
            btGerar.Enabled = false;
            btSalvar.Enabled = true;
            btCancelar.Enabled = true;
            origemSAVE = origem;
        }

        void QueryAdapter(string origem)
        {

            SQLiteConnection conn = new SQLiteConnection(connstring);
            switch (origem)
            {
                case "Editar":
                    string updateQuery = "update Materiais set Material = '"
                        + dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells["Material"].FormattedValue.ToString()
                        + "', Quantidade = "
                        + int.Parse(dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells["Quantidade"].FormattedValue.ToString())
                        + ", Obs = '"
                        + dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells["Observações"].FormattedValue.ToString().ToUpper()
                        + "', Mapeamento = '"
                        + dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells["Mapeamento"].Value.ToString()
                        + "' where ukey = '"
                        + dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells["Código"].FormattedValue.ToString().Trim().ToUpper()
                        + "'";
                    Almo_DB.SQLite_update(updateQuery, conn);
                    break;

                case "NovoItem":
                    string insertQuery = "INSERT INTO Materiais(Material, Quantidade, Obs, Mapeamento, ukey) VALUES('"
                        + dgvMateriais.Rows[0].Cells["Material"].Value.ToString()
                        + "', "
                        + int.Parse(dgvMateriais.Rows[0].Cells["Quantidade"].Value.ToString())
                        + ", '"
                        + dgvMateriais.Rows[0].Cells["Obs"].Value.ToString()
                        + "', '"
                        + dgvMateriais.Rows[0].Cells["Mapeamento"].Value.ToString().ToUpper()
                        + "', '"
                        + dgvMateriais.Rows[0].Cells["ukey"].Value.ToString().Trim().ToUpper()
                        + "');";
                    Almo_DB.SQLite_insert(insertQuery, conn);
                    break;

                case "Deletar":
                    string deleteQuery = "delete from Materiais where ukey = '"
                        + dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells["Código"].FormattedValue.ToString().Trim()
                        + "'";
                    Almo_DB.SQLite_delete(deleteQuery, conn);
                    break;
            }
        }

        void dgvMateriais_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvMateriais.Rows[e.RowIndex].ErrorText = String.Empty;
        }
    }
}