using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing;
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
            SQLiteConnection conn = new SQLiteConnection(connstring);
            dgvMateriais.Rows[dgvMateriais.CurrentCell.RowIndex].Cells["ukey"].Value = ukeygen(conn);
            dgvMateriais.Columns["ukey"].ReadOnly = true;
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
                dgvMateriais.Columns["Código"].ReadOnly = true;
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

        private void btImprimir_Click(object sender, EventArgs e)
        {
            pdGrid.Print();
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
                    if (string.IsNullOrEmpty(dgvMateriais.Rows[0].Cells["Material"].Value.ToString()))
                    {
                        MessageBox.Show("O campo Material não pode ser nulo", "Atenção");
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(dgvMateriais.Rows[0].Cells["Quantidade"].Value.ToString()))
                        {
                            MessageBox.Show("O campo Quantidade não pode ser nulo", "Atenção");
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(dgvMateriais.Rows[0].Cells["Observações"].Value.ToString()))
                            {
                                MessageBox.Show("O campo Observações não pode ser nulo", "Atenção");
                            }
                            else
                            {
                                if (string.IsNullOrWhiteSpace(dgvMateriais.Rows[0].Cells["Mapeamento"].Value.ToString()))
                                {
                                    MessageBox.Show("O campo Mapeamento não pode ser nulo", "Atenção");
                                }
                                else
                                {
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
                                }
                            }
                        }
                    }
                    break;

                case "NovoItem":
                    if (string.IsNullOrEmpty(dgvMateriais.Rows[0].Cells["Material"].Value.ToString()))
                    {
                        MessageBox.Show("O campo Material não pode ser nulo", "Atenção");
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(dgvMateriais.Rows[0].Cells["Quantidade"].Value.ToString()))
                        {
                            MessageBox.Show("O campo Quantidade não pode ser nulo", "Atenção");
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(dgvMateriais.Rows[0].Cells["Obs"].Value.ToString()))
                            {
                                MessageBox.Show("O campo Observações não pode ser nulo", "Atenção");
                            }
                            else
                            {
                                if (string.IsNullOrWhiteSpace(dgvMateriais.Rows[0].Cells["Mapeamento"].Value.ToString()))
                                {
                                    MessageBox.Show("O campo Mapeamento não pode ser nulo", "Atenção");
                                }
                                else
                                {
                                    string insertQuery = "INSERT INTO Materiais(Material, Quantidade, Obs, Mapeamento, ukey) VALUES('"
                                + dgvMateriais.Rows[0].Cells["Material"].Value.ToString()
                                + "', "
                                + int.Parse(dgvMateriais.Rows[0].Cells["Quantidade"].Value.ToString())
                                + ", '"
                                + dgvMateriais.Rows[0].Cells["Obs"].Value.ToString()
                                + "', '"
                                + dgvMateriais.Rows[0].Cells["Mapeamento"].Value.ToString().ToUpper()
                                + "', '"
                                + dgvMateriais.Rows[0].Cells["ukey"].Value.ToString().ToUpper()
                                + "');";
                                    Almo_DB.SQLite_insert(insertQuery, conn);
                                }
                            }
                        }
                    }
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

        String ukeygen(SQLiteConnection con)
        {
            SQLiteConnection conn = con;
            String ukey = "LAB";
            String Querry = "select MAX(substr(ukey,4,6)) as ukey from Materiais";
            DataSet dsUkey = Almo_DB.SQLite_select(Querry, conn);
            int max = (Convert.ToInt16(dsUkey.Tables[0].Rows[0][0]) + 1);
            ukey += max.ToString().PadLeft(6, '0').ToUpper();
            return ukey;
        }

        private void pdGrid_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //int widthMaterial = dgvMateriais.Columns["Material"].Width;
            //int widthQuantidade = dgvMateriais.Columns["Quantidade"].Width;
            //int widthObservações = dgvMateriais.Columns["Observações"].Width;
            //int widthMapeamento = dgvMateriais.Columns["Mapeamento"].Width;
            //int widthCodigo = dgvMateriais.Columns["Código"].Width;
            //int height = dgvMateriais.Rows[0].Height;

            //if (height > e.MarginBounds.Height)
            //{
            //    height = x;
            //    width = y;
            //    e.HasMorePages = true;
            //}

            Bitmap bm = new Bitmap(dgvMateriais.Width, dgvMateriais.Height);
            dgvMateriais.DrawToBitmap(bm, new Rectangle(0, 0, dgvMateriais.Width, dgvMateriais.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }
    }
}