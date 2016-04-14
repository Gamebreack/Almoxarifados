using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using DB_Classes;

namespace Almoxarifados
{
    public partial class Home : Form
    {
        DB_SQLite Almo_DB = new DB_SQLite();
        public Home()
        {
            InitializeComponent();
        }

        private void btPesquisarTudo_Click(object sender, EventArgs e)
        {
            string query = "select Materiais.*, Materiais.ukey as Código from Materiais";
            SQLiteConnection conn = new SQLiteConnection("C:\\Program Files\\Almoxarifado\\Banco de dados\\Almoxarifado.db");
            DataSet ds = Almo_DB.SQLite_select(query,conn);
            dgvMateriais.DataSource = ds.Tables[0];
            dgvMateriais.Refresh();
        }
    }
}
