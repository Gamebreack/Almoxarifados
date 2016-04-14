using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB_Classes;

namespace Almoxarifados
{
    public partial class Home : Form
    {
        DB_SQLite Almo_DB = new DB_SQLite("C:/Program Files/Almoxarifado/Banco de dados/Almoxarifado.db");
        public Home()
        {
            InitializeComponent();
        }

    }
}
