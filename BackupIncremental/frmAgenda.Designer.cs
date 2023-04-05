namespace nsBackup
{
    partial class frmAgenda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgenda));
            this.panel1 = new System.Windows.Forms.Panel();
            this.rosto = new System.Windows.Forms.SplitContainer();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.chkRoot = new System.Windows.Forms.CheckBox();
            this.btnTipoArquivo = new System.Windows.Forms.Button();
            this.txtTiposArquivos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPastaDestino = new System.Windows.Forms.Button();
            this.btnPastaOrigem = new System.Windows.Forms.Button();
            this.txtPastaDestino = new System.Windows.Forms.TextBox();
            this.txtPastaOrigem = new System.Windows.Forms.TextBox();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ts = new System.Windows.Forms.ToolStrip();
            this.tsBtnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDeletar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalvar = new System.Windows.Forms.ToolStripButton();
            this.tsCancelarEdicao = new System.Windows.Forms.ToolStripButton();
            this.dtgAgendas = new System.Windows.Forms.DataGridView();
            this.colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPastaOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPastaDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAtivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsExecutarNow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1.SuspendLayout();
            this.rosto.Panel1.SuspendLayout();
            this.rosto.Panel2.SuspendLayout();
            this.rosto.SuspendLayout();
            this.ts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAgendas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rosto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 337);
            this.panel1.TabIndex = 1;
            // 
            // rosto
            // 
            this.rosto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rosto.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.rosto.Location = new System.Drawing.Point(0, 0);
            this.rosto.Margin = new System.Windows.Forms.Padding(0);
            this.rosto.Name = "rosto";
            this.rosto.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rosto.Panel1
            // 
            this.rosto.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.rosto.Panel1.Controls.Add(this.ts);
            this.rosto.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rosto_Panel1_MouseDown);
            this.rosto.Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rosto_Panel1_MouseMove);
            // 
            // rosto.Panel2
            // 
            this.rosto.Panel2.Controls.Add(this.chkAtivo);
            this.rosto.Panel2.Controls.Add(this.chkRoot);
            this.rosto.Panel2.Controls.Add(this.btnTipoArquivo);
            this.rosto.Panel2.Controls.Add(this.txtTiposArquivos);
            this.rosto.Panel2.Controls.Add(this.label4);
            this.rosto.Panel2.Controls.Add(this.btnPastaDestino);
            this.rosto.Panel2.Controls.Add(this.btnPastaOrigem);
            this.rosto.Panel2.Controls.Add(this.txtPastaDestino);
            this.rosto.Panel2.Controls.Add(this.txtPastaOrigem);
            this.rosto.Panel2.Controls.Add(this.txtHora);
            this.rosto.Panel2.Controls.Add(this.label3);
            this.rosto.Panel2.Controls.Add(this.label2);
            this.rosto.Panel2.Controls.Add(this.label1);
            this.rosto.Panel2.Controls.Add(this.dtgAgendas);
            this.rosto.Size = new System.Drawing.Size(998, 335);
            this.rosto.SplitterDistance = 30;
            this.rosto.SplitterWidth = 1;
            this.rosto.TabIndex = 0;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(787, 10);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(50, 17);
            this.chkAtivo.TabIndex = 14;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // chkRoot
            // 
            this.chkRoot.AutoSize = true;
            this.chkRoot.Location = new System.Drawing.Point(189, 8);
            this.chkRoot.Name = "chkRoot";
            this.chkRoot.Size = new System.Drawing.Size(177, 17);
            this.chkRoot.TabIndex = 13;
            this.chkRoot.Text = "Grava caminho Completo (Root)";
            this.chkRoot.UseVisualStyleBackColor = true;
            // 
            // btnTipoArquivo
            // 
            this.btnTipoArquivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTipoArquivo.Image = global::nsBackup.Properties.Resources.folder_explore;
            this.btnTipoArquivo.Location = new System.Drawing.Point(843, 84);
            this.btnTipoArquivo.Name = "btnTipoArquivo";
            this.btnTipoArquivo.Size = new System.Drawing.Size(39, 23);
            this.btnTipoArquivo.TabIndex = 12;
            this.btnTipoArquivo.UseVisualStyleBackColor = true;
            this.btnTipoArquivo.Click += new System.EventHandler(this.btnTipoArquivo_Click);
            // 
            // txtTiposArquivos
            // 
            this.txtTiposArquivos.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTiposArquivos.Location = new System.Drawing.Point(130, 84);
            this.txtTiposArquivos.MaxLength = 200;
            this.txtTiposArquivos.Name = "txtTiposArquivos";
            this.txtTiposArquivos.Size = new System.Drawing.Size(708, 21);
            this.txtTiposArquivos.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tipos de Arquivos";
            // 
            // btnPastaDestino
            // 
            this.btnPastaDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPastaDestino.Image = global::nsBackup.Properties.Resources.folder_explore;
            this.btnPastaDestino.Location = new System.Drawing.Point(843, 56);
            this.btnPastaDestino.Name = "btnPastaDestino";
            this.btnPastaDestino.Size = new System.Drawing.Size(39, 23);
            this.btnPastaDestino.TabIndex = 9;
            this.btnPastaDestino.UseVisualStyleBackColor = true;
            this.btnPastaDestino.Click += new System.EventHandler(this.btnPastaDestino_Click);
            // 
            // btnPastaOrigem
            // 
            this.btnPastaOrigem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPastaOrigem.Image = global::nsBackup.Properties.Resources.folder_explore;
            this.btnPastaOrigem.Location = new System.Drawing.Point(843, 30);
            this.btnPastaOrigem.Name = "btnPastaOrigem";
            this.btnPastaOrigem.Size = new System.Drawing.Size(39, 23);
            this.btnPastaOrigem.TabIndex = 8;
            this.btnPastaOrigem.UseVisualStyleBackColor = true;
            this.btnPastaOrigem.Click += new System.EventHandler(this.btnPastaOrigem_Click);
            // 
            // txtPastaDestino
            // 
            this.txtPastaDestino.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPastaDestino.Location = new System.Drawing.Point(130, 57);
            this.txtPastaDestino.MaxLength = 200;
            this.txtPastaDestino.Name = "txtPastaDestino";
            this.txtPastaDestino.Size = new System.Drawing.Size(708, 21);
            this.txtPastaDestino.TabIndex = 7;
            // 
            // txtPastaOrigem
            // 
            this.txtPastaOrigem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPastaOrigem.Location = new System.Drawing.Point(130, 31);
            this.txtPastaOrigem.MaxLength = 200;
            this.txtPastaOrigem.Name = "txtPastaOrigem";
            this.txtPastaOrigem.Size = new System.Drawing.Size(708, 21);
            this.txtPastaOrigem.TabIndex = 6;
            // 
            // txtHora
            // 
            this.txtHora.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.Location = new System.Drawing.Point(130, 6);
            this.txtHora.MaxLength = 5;
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(41, 21);
            this.txtHora.TabIndex = 5;
            this.txtHora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHora_KeyPress);
            this.txtHora.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHora_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pasta destino";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pasta origem";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hora";
            // 
            // ts
            // 
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAdicionar,
            this.tsBtnDeletar,
            this.tsBtnSalvar,
            this.tsCancelarEdicao,
            this.toolStripSeparator1,
            this.tsExecutarNow});
            this.ts.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ts.Location = new System.Drawing.Point(0, 0);
            this.ts.Name = "ts";
            this.ts.Size = new System.Drawing.Size(998, 25);
            this.ts.TabIndex = 1;
            this.ts.Text = "toolStrip1";
            // 
            // tsBtnAdicionar
            // 
            this.tsBtnAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tsBtnAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAdicionar.Image = global::nsBackup.Properties.Resources.add;
            this.tsBtnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAdicionar.Name = "tsBtnAdicionar";
            this.tsBtnAdicionar.Size = new System.Drawing.Size(23, 22);
            this.tsBtnAdicionar.ToolTipText = "Adicionar tarefa";
            this.tsBtnAdicionar.Click += new System.EventHandler(this.tsBtnAdicionar_Click);
            // 
            // tsBtnDeletar
            // 
            this.tsBtnDeletar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDeletar.Image = global::nsBackup.Properties.Resources.delete;
            this.tsBtnDeletar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDeletar.Name = "tsBtnDeletar";
            this.tsBtnDeletar.Size = new System.Drawing.Size(23, 22);
            this.tsBtnDeletar.ToolTipText = "Deletar tarefa selecionada";
            this.tsBtnDeletar.Click += new System.EventHandler(this.tsBtnDeletar_Click);
            // 
            // tsBtnSalvar
            // 
            this.tsBtnSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnSalvar.Image = global::nsBackup.Properties.Resources.disk;
            this.tsBtnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalvar.Name = "tsBtnSalvar";
            this.tsBtnSalvar.Size = new System.Drawing.Size(23, 22);
            this.tsBtnSalvar.ToolTipText = "Salvar";
            this.tsBtnSalvar.Click += new System.EventHandler(this.tsBtnSalvar_Click);
            // 
            // tsCancelarEdicao
            // 
            this.tsCancelarEdicao.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsCancelarEdicao.Image = global::nsBackup.Properties.Resources.page_white_delete;
            this.tsCancelarEdicao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCancelarEdicao.Name = "tsCancelarEdicao";
            this.tsCancelarEdicao.Size = new System.Drawing.Size(23, 22);
            this.tsCancelarEdicao.Text = "Cancela edição";
            this.tsCancelarEdicao.Click += new System.EventHandler(this.tsCancelarEdicao_Click);
            // 
            // dtgAgendas
            // 
            this.dtgAgendas.AllowUserToAddRows = false;
            this.dtgAgendas.AllowUserToDeleteRows = false;
            this.dtgAgendas.AllowUserToOrderColumns = true;
            this.dtgAgendas.AllowUserToResizeRows = false;
            this.dtgAgendas.BackgroundColor = System.Drawing.Color.White;
            this.dtgAgendas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgAgendas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgAgendas.ColumnHeadersHeight = 20;
            this.dtgAgendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgAgendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHora,
            this.colPastaOrigem,
            this.colPastaDestino,
            this.colTipos,
            this.colRoot,
            this.colAtivo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgAgendas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgAgendas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgAgendas.EnableHeadersVisualStyles = false;
            this.dtgAgendas.Location = new System.Drawing.Point(0, 118);
            this.dtgAgendas.MultiSelect = false;
            this.dtgAgendas.Name = "dtgAgendas";
            this.dtgAgendas.RowHeadersVisible = false;
            this.dtgAgendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAgendas.Size = new System.Drawing.Size(998, 186);
            this.dtgAgendas.TabIndex = 0;
            this.dtgAgendas.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgAgendas_CellMouseDoubleClick);
            this.dtgAgendas.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgAgendas_ColumnHeaderMouseDoubleClick);
            // 
            // colHora
            // 
            this.colHora.HeaderText = "Hora";
            this.colHora.Name = "colHora";
            this.colHora.Width = 50;
            // 
            // colPastaOrigem
            // 
            this.colPastaOrigem.HeaderText = "Pasta de origem";
            this.colPastaOrigem.Name = "colPastaOrigem";
            this.colPastaOrigem.Width = 350;
            // 
            // colPastaDestino
            // 
            this.colPastaDestino.HeaderText = "Pasta de Destino";
            this.colPastaDestino.Name = "colPastaDestino";
            this.colPastaDestino.Width = 350;
            // 
            // colTipos
            // 
            this.colTipos.HeaderText = "Tipos de Arquivos";
            this.colTipos.Name = "colTipos";
            this.colTipos.Width = 200;
            // 
            // colRoot
            // 
            this.colRoot.HeaderText = "Root";
            this.colRoot.Name = "colRoot";
            this.colRoot.Visible = false;
            // 
            // colAtivo
            // 
            this.colAtivo.HeaderText = "Ativo";
            this.colAtivo.Name = "colAtivo";
            this.colAtivo.Width = 50;
            // 
            // tsExecutarNow
            // 
            this.tsExecutarNow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsExecutarNow.Image = global::nsBackup.Properties.Resources.up;
            this.tsExecutarNow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExecutarNow.Name = "tsExecutarNow";
            this.tsExecutarNow.Size = new System.Drawing.Size(23, 22);
            this.tsExecutarNow.Text = "toolStripButton1";
            this.tsExecutarNow.Click += new System.EventHandler(this.tsExecutarNow_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // frmAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 337);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAgenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastrar tarefa de backup";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmAgenda_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmAgenda_MouseMove);
            this.panel1.ResumeLayout(false);
            this.rosto.Panel1.ResumeLayout(false);
            this.rosto.Panel1.PerformLayout();
            this.rosto.Panel2.ResumeLayout(false);
            this.rosto.Panel2.PerformLayout();
            this.rosto.ResumeLayout(false);
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAgendas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer rosto;
        private System.Windows.Forms.DataGridView dtgAgendas;
        private System.Windows.Forms.ToolStrip ts;
        private System.Windows.Forms.ToolStripButton tsBtnAdicionar;
        private System.Windows.Forms.ToolStripButton tsBtnDeletar;
        private System.Windows.Forms.ToolStripButton tsBtnSalvar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.TextBox txtPastaDestino;
        private System.Windows.Forms.TextBox txtPastaOrigem;
        private System.Windows.Forms.Button btnPastaOrigem;
        private System.Windows.Forms.Button btnPastaDestino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTipoArquivo;
        private System.Windows.Forms.TextBox txtTiposArquivos;
        private System.Windows.Forms.ToolStripButton tsCancelarEdicao;
        private System.Windows.Forms.CheckBox chkRoot;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPastaOrigem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPastaDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAtivo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsExecutarNow;
    }
}