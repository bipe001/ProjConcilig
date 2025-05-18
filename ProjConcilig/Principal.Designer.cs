namespace ProjConcilig
{
    partial class Principal
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
            this.btnImportCSV = new System.Windows.Forms.Button();
            this.gridImport = new System.Windows.Forms.DataGridView();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.tabControlPrincipal = new System.Windows.Forms.TabControl();
            this.tabImportacao = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabConsulta = new System.Windows.Forms.TabPage();
            this.gridConsulta = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFiltroConsulta = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridImport)).BeginInit();
            this.tabControlPrincipal.SuspendLayout();
            this.tabImportacao.SuspendLayout();
            this.tabConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportCSV
            // 
            this.btnImportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportCSV.Location = new System.Drawing.Point(6, 6);
            this.btnImportCSV.Name = "btnImportCSV";
            this.btnImportCSV.Size = new System.Drawing.Size(180, 23);
            this.btnImportCSV.TabIndex = 0;
            this.btnImportCSV.Text = "Importar CSV";
            this.btnImportCSV.UseVisualStyleBackColor = true;
            this.btnImportCSV.Click += new System.EventHandler(this.btnImportCSV_Click);
            // 
            // gridImport
            // 
            this.gridImport.AllowUserToAddRows = false;
            this.gridImport.AllowUserToDeleteRows = false;
            this.gridImport.AllowUserToResizeRows = false;
            this.gridImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridImport.Location = new System.Drawing.Point(6, 35);
            this.gridImport.Name = "gridImport";
            this.gridImport.ReadOnly = true;
            this.gridImport.RowHeadersVisible = false;
            this.gridImport.Size = new System.Drawing.Size(720, 312);
            this.gridImport.TabIndex = 4;
            // 
            // txtFiltro
            // 
            this.txtFiltro.BackColor = System.Drawing.SystemColors.Window;
            this.txtFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFiltro.Location = new System.Drawing.Point(546, 9);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(180, 20);
            this.txtFiltro.TabIndex = 5;
            this.txtFiltro.Text = "\r\n";
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // tabControlPrincipal
            // 
            this.tabControlPrincipal.Controls.Add(this.tabImportacao);
            this.tabControlPrincipal.Controls.Add(this.tabConsulta);
            this.tabControlPrincipal.Location = new System.Drawing.Point(12, 12);
            this.tabControlPrincipal.Name = "tabControlPrincipal";
            this.tabControlPrincipal.SelectedIndex = 0;
            this.tabControlPrincipal.Size = new System.Drawing.Size(740, 379);
            this.tabControlPrincipal.TabIndex = 6;
            this.tabControlPrincipal.Click += new System.EventHandler(this.tabControlPrincipal_Click);
            // 
            // tabImportacao
            // 
            this.tabImportacao.Controls.Add(this.label1);
            this.tabImportacao.Controls.Add(this.btnImportCSV);
            this.tabImportacao.Controls.Add(this.gridImport);
            this.tabImportacao.Controls.Add(this.txtFiltro);
            this.tabImportacao.Location = new System.Drawing.Point(4, 22);
            this.tabImportacao.Name = "tabImportacao";
            this.tabImportacao.Padding = new System.Windows.Forms.Padding(3);
            this.tabImportacao.Size = new System.Drawing.Size(732, 353);
            this.tabImportacao.TabIndex = 0;
            this.tabImportacao.Text = "Importacao";
            this.tabImportacao.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(484, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pesquisar:";
            // 
            // tabConsulta
            // 
            this.tabConsulta.Controls.Add(this.label2);
            this.tabConsulta.Controls.Add(this.txtFiltroConsulta);
            this.tabConsulta.Controls.Add(this.gridConsulta);
            this.tabConsulta.Location = new System.Drawing.Point(4, 22);
            this.tabConsulta.Name = "tabConsulta";
            this.tabConsulta.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsulta.Size = new System.Drawing.Size(732, 353);
            this.tabConsulta.TabIndex = 1;
            this.tabConsulta.Text = "Consulta";
            this.tabConsulta.UseVisualStyleBackColor = true;
            // 
            // gridConsulta
            // 
            this.gridConsulta.AllowUserToAddRows = false;
            this.gridConsulta.AllowUserToDeleteRows = false;
            this.gridConsulta.AllowUserToResizeRows = false;
            this.gridConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridConsulta.Location = new System.Drawing.Point(6, 32);
            this.gridConsulta.Name = "gridConsulta";
            this.gridConsulta.ReadOnly = true;
            this.gridConsulta.RowHeadersVisible = false;
            this.gridConsulta.Size = new System.Drawing.Size(720, 315);
            this.gridConsulta.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(484, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Pesquisar:";
            // 
            // txtFiltroConsulta
            // 
            this.txtFiltroConsulta.BackColor = System.Drawing.SystemColors.Window;
            this.txtFiltroConsulta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroConsulta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFiltroConsulta.Location = new System.Drawing.Point(546, 6);
            this.txtFiltroConsulta.Name = "txtFiltroConsulta";
            this.txtFiltroConsulta.Size = new System.Drawing.Size(180, 20);
            this.txtFiltroConsulta.TabIndex = 7;
            this.txtFiltroConsulta.Text = "\r\n";
            this.txtFiltroConsulta.TextChanged += new System.EventHandler(this.txtFiltroConsulta_TextChanged);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 403);
            this.Controls.Add(this.tabControlPrincipal);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importacao";
            this.Load += new System.EventHandler(this.Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridImport)).EndInit();
            this.tabControlPrincipal.ResumeLayout(false);
            this.tabImportacao.ResumeLayout(false);
            this.tabImportacao.PerformLayout();
            this.tabConsulta.ResumeLayout(false);
            this.tabConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridConsulta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImportCSV;
        private System.Windows.Forms.DataGridView gridImport;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.TabControl tabControlPrincipal;
        private System.Windows.Forms.TabPage tabImportacao;
        private System.Windows.Forms.TabPage tabConsulta;
        private System.Windows.Forms.DataGridView gridConsulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFiltroConsulta;
    }
}