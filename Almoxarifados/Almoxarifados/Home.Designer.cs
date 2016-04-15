namespace Almoxarifados
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.btPesquisar = new System.Windows.Forms.Button();
            this.dgvMateriais = new System.Windows.Forms.DataGridView();
            this.btNovoItem = new System.Windows.Forms.Button();
            this.btEditar = new System.Windows.Forms.Button();
            this.btDeletar = new System.Windows.Forms.Button();
            this.btPesquisarTudo = new System.Windows.Forms.Button();
            this.tbUkey = new System.Windows.Forms.TextBox();
            this.btSalvar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateriais)).BeginInit();
            this.SuspendLayout();
            // 
            // btPesquisar
            // 
            this.btPesquisar.Location = new System.Drawing.Point(12, 43);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btPesquisar.TabIndex = 0;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // dgvMateriais
            // 
            this.dgvMateriais.AllowUserToAddRows = false;
            this.dgvMateriais.AllowUserToDeleteRows = false;
            this.dgvMateriais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMateriais.Location = new System.Drawing.Point(12, 72);
            this.dgvMateriais.Name = "dgvMateriais";
            this.dgvMateriais.ReadOnly = true;
            this.dgvMateriais.Size = new System.Drawing.Size(549, 150);
            this.dgvMateriais.TabIndex = 1;
            // 
            // btNovoItem
            // 
            this.btNovoItem.Location = new System.Drawing.Point(12, 228);
            this.btNovoItem.Name = "btNovoItem";
            this.btNovoItem.Size = new System.Drawing.Size(75, 23);
            this.btNovoItem.TabIndex = 2;
            this.btNovoItem.Text = "Novo item";
            this.btNovoItem.UseVisualStyleBackColor = true;
            this.btNovoItem.Click += new System.EventHandler(this.btNovoItem_Click);
            // 
            // btEditar
            // 
            this.btEditar.Location = new System.Drawing.Point(93, 228);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(75, 23);
            this.btEditar.TabIndex = 3;
            this.btEditar.Text = "Editar";
            this.btEditar.UseVisualStyleBackColor = true;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // btDeletar
            // 
            this.btDeletar.Location = new System.Drawing.Point(174, 228);
            this.btDeletar.Name = "btDeletar";
            this.btDeletar.Size = new System.Drawing.Size(75, 23);
            this.btDeletar.TabIndex = 4;
            this.btDeletar.Text = "Deletar";
            this.btDeletar.UseVisualStyleBackColor = true;
            this.btDeletar.Click += new System.EventHandler(this.btDeletar_Click);
            // 
            // btPesquisarTudo
            // 
            this.btPesquisarTudo.Location = new System.Drawing.Point(12, 3);
            this.btPesquisarTudo.Name = "btPesquisarTudo";
            this.btPesquisarTudo.Size = new System.Drawing.Size(75, 34);
            this.btPesquisarTudo.TabIndex = 5;
            this.btPesquisarTudo.Text = "Pesquisar tudo";
            this.btPesquisarTudo.UseVisualStyleBackColor = true;
            this.btPesquisarTudo.Click += new System.EventHandler(this.btPesquisarTudo_Click);
            // 
            // tbUkey
            // 
            this.tbUkey.Location = new System.Drawing.Point(93, 46);
            this.tbUkey.Name = "tbUkey";
            this.tbUkey.Size = new System.Drawing.Size(100, 20);
            this.tbUkey.TabIndex = 6;
            // 
            // btSalvar
            // 
            this.btSalvar.Enabled = false;
            this.btSalvar.Location = new System.Drawing.Point(255, 228);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(75, 23);
            this.btSalvar.TabIndex = 7;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(573, 258);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.tbUkey);
            this.Controls.Add(this.btPesquisarTudo);
            this.Controls.Add(this.btDeletar);
            this.Controls.Add(this.btEditar);
            this.Controls.Add(this.btNovoItem);
            this.Controls.Add(this.dgvMateriais);
            this.Controls.Add(this.btPesquisar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Home";
            this.Text = "Almoxarifados";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateriais)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.DataGridView dgvMateriais;
        private System.Windows.Forms.Button btNovoItem;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.Button btDeletar;
        private System.Windows.Forms.Button btPesquisarTudo;
        private System.Windows.Forms.TextBox tbUkey;
        private System.Windows.Forms.Button btSalvar;
    }
}

