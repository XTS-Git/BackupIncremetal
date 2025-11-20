namespace nsBackup
{
    partial class FrmAgenda
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgenda));
            panel1 = new Panel();
            rosto = new SplitContainer();
            ts = new ToolStrip();
            tsBtnAdicionar = new ToolStripButton();
            tsBtnDeletar = new ToolStripButton();
            tsBtnSalvar = new ToolStripButton();
            tsCancelarEdicao = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsExecutarNow = new ToolStripButton();
            cmbIntervalo = new ComboBox();
            chkAtivo = new CheckBox();
            chkRoot = new CheckBox();
            btnTipoArquivo = new Button();
            txtTiposArquivos = new TextBox();
            label4 = new Label();
            btnPastaDestino = new Button();
            btnPastaOrigem = new Button();
            txtPastaDestino = new TextBox();
            txtPastaOrigem = new TextBox();
            txtHora = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dtgAgendas = new DataGridView();
            colHora = new DataGridViewTextBoxColumn();
            colIntervalo = new DataGridViewTextBoxColumn();
            colPastaOrigem = new DataGridViewTextBoxColumn();
            colPastaDestino = new DataGridViewTextBoxColumn();
            colTipos = new DataGridViewTextBoxColumn();
            colRoot = new DataGridViewTextBoxColumn();
            colAtivo = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rosto).BeginInit();
            rosto.Panel1.SuspendLayout();
            rosto.Panel2.SuspendLayout();
            rosto.SuspendLayout();
            ts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgAgendas).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(rosto);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1167, 389);
            panel1.TabIndex = 1;
            // 
            // rosto
            // 
            rosto.Dock = DockStyle.Fill;
            rosto.FixedPanel = FixedPanel.Panel1;
            rosto.Location = new Point(0, 0);
            rosto.Margin = new Padding(0);
            rosto.Name = "rosto";
            rosto.Orientation = Orientation.Horizontal;
            // 
            // rosto.Panel1
            // 
            rosto.Panel1.BackColor = SystemColors.Control;
            rosto.Panel1.Controls.Add(ts);
            rosto.Panel1.MouseDown += rosto_Panel1_MouseDown;
            rosto.Panel1.MouseMove += rosto_Panel1_MouseMove;
            // 
            // rosto.Panel2
            // 
            rosto.Panel2.Controls.Add(cmbIntervalo);
            rosto.Panel2.Controls.Add(chkAtivo);
            rosto.Panel2.Controls.Add(chkRoot);
            rosto.Panel2.Controls.Add(btnTipoArquivo);
            rosto.Panel2.Controls.Add(txtTiposArquivos);
            rosto.Panel2.Controls.Add(label4);
            rosto.Panel2.Controls.Add(btnPastaDestino);
            rosto.Panel2.Controls.Add(btnPastaOrigem);
            rosto.Panel2.Controls.Add(txtPastaDestino);
            rosto.Panel2.Controls.Add(txtPastaOrigem);
            rosto.Panel2.Controls.Add(txtHora);
            rosto.Panel2.Controls.Add(label3);
            rosto.Panel2.Controls.Add(label2);
            rosto.Panel2.Controls.Add(label1);
            rosto.Panel2.Controls.Add(dtgAgendas);
            rosto.Size = new Size(1165, 387);
            rosto.SplitterDistance = 35;
            rosto.SplitterWidth = 1;
            rosto.TabIndex = 0;
            // 
            // ts
            // 
            ts.Items.AddRange(new ToolStripItem[] { tsBtnAdicionar, tsBtnDeletar, tsBtnSalvar, tsCancelarEdicao, toolStripSeparator1, tsExecutarNow });
            ts.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            ts.Location = new Point(0, 0);
            ts.Name = "ts";
            ts.Size = new Size(1165, 25);
            ts.TabIndex = 1;
            ts.Text = "toolStrip1";
            // 
            // tsBtnAdicionar
            // 
            tsBtnAdicionar.BackgroundImageLayout = ImageLayout.Center;
            tsBtnAdicionar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnAdicionar.Image = BackupIncremental.DeskTop.Properties.Resources.add;
            tsBtnAdicionar.ImageTransparentColor = Color.Magenta;
            tsBtnAdicionar.Name = "tsBtnAdicionar";
            tsBtnAdicionar.Size = new Size(23, 22);
            tsBtnAdicionar.ToolTipText = "Adicionar tarefa";
            tsBtnAdicionar.Click += tsBtnAdicionar_Click;
            // 
            // tsBtnDeletar
            // 
            tsBtnDeletar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnDeletar.Image = BackupIncremental.DeskTop.Properties.Resources.delete;
            tsBtnDeletar.ImageTransparentColor = Color.Magenta;
            tsBtnDeletar.Name = "tsBtnDeletar";
            tsBtnDeletar.Size = new Size(23, 22);
            tsBtnDeletar.ToolTipText = "Deletar tarefa selecionada";
            tsBtnDeletar.Click += tsBtnDeletar_Click;
            // 
            // tsBtnSalvar
            // 
            tsBtnSalvar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnSalvar.Image = BackupIncremental.DeskTop.Properties.Resources.disk;
            tsBtnSalvar.ImageTransparentColor = Color.Magenta;
            tsBtnSalvar.Name = "tsBtnSalvar";
            tsBtnSalvar.Size = new Size(23, 22);
            tsBtnSalvar.ToolTipText = "Salvar";
            tsBtnSalvar.Click += tsBtnSalvar_Click;
            // 
            // tsCancelarEdicao
            // 
            tsCancelarEdicao.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsCancelarEdicao.Image = BackupIncremental.DeskTop.Properties.Resources.page_white_delete;
            tsCancelarEdicao.ImageTransparentColor = Color.Magenta;
            tsCancelarEdicao.Name = "tsCancelarEdicao";
            tsCancelarEdicao.Size = new Size(23, 22);
            tsCancelarEdicao.Text = "Cancela edição";
            tsCancelarEdicao.Click += tsCancelarEdicao_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // tsExecutarNow
            // 
            tsExecutarNow.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsExecutarNow.Image = BackupIncremental.DeskTop.Properties.Resources._new;
            tsExecutarNow.ImageTransparentColor = Color.Magenta;
            tsExecutarNow.Name = "tsExecutarNow";
            tsExecutarNow.Size = new Size(23, 22);
            tsExecutarNow.Text = "toolStripButton1";
            tsExecutarNow.Click += tsExecutarNow_Click;
            // 
            // cmbIntervalo
            // 
            cmbIntervalo.FormattingEnabled = true;
            cmbIntervalo.Location = new Point(227, 7);
            cmbIntervalo.Name = "cmbIntervalo";
            cmbIntervalo.Size = new Size(257, 23);
            cmbIntervalo.TabIndex = 15;
            // 
            // chkAtivo
            // 
            chkAtivo.AutoSize = true;
            chkAtivo.Location = new Point(918, 12);
            chkAtivo.Margin = new Padding(4, 3, 4, 3);
            chkAtivo.Name = "chkAtivo";
            chkAtivo.Size = new Size(54, 19);
            chkAtivo.TabIndex = 14;
            chkAtivo.Text = "Ativo";
            chkAtivo.UseVisualStyleBackColor = true;
            // 
            // chkRoot
            // 
            chkRoot.AutoSize = true;
            chkRoot.Location = new Point(583, 11);
            chkRoot.Margin = new Padding(4, 3, 4, 3);
            chkRoot.Name = "chkRoot";
            chkRoot.Size = new Size(198, 19);
            chkRoot.TabIndex = 13;
            chkRoot.Text = "Grava caminho Completo (Root)";
            chkRoot.UseVisualStyleBackColor = true;
            // 
            // btnTipoArquivo
            // 
            btnTipoArquivo.FlatStyle = FlatStyle.Flat;
            btnTipoArquivo.Image = BackupIncremental.DeskTop.Properties.Resources.text_list_bullets;
            btnTipoArquivo.Location = new Point(983, 97);
            btnTipoArquivo.Margin = new Padding(4, 3, 4, 3);
            btnTipoArquivo.Name = "btnTipoArquivo";
            btnTipoArquivo.Size = new Size(46, 27);
            btnTipoArquivo.TabIndex = 12;
            btnTipoArquivo.UseVisualStyleBackColor = true;
            btnTipoArquivo.Click += btnTipoArquivo_Click;
            // 
            // txtTiposArquivos
            // 
            txtTiposArquivos.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTiposArquivos.Location = new Point(152, 97);
            txtTiposArquivos.Margin = new Padding(4, 3, 4, 3);
            txtTiposArquivos.MaxLength = 200;
            txtTiposArquivos.Name = "txtTiposArquivos";
            txtTiposArquivos.Size = new Size(825, 21);
            txtTiposArquivos.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(13, 102);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(109, 13);
            label4.TabIndex = 10;
            label4.Text = "Tipos de Arquivos";
            // 
            // btnPastaDestino
            // 
            btnPastaDestino.FlatStyle = FlatStyle.Flat;
            btnPastaDestino.Image = BackupIncremental.DeskTop.Properties.Resources.folder_explore;
            btnPastaDestino.Location = new Point(983, 65);
            btnPastaDestino.Margin = new Padding(4, 3, 4, 3);
            btnPastaDestino.Name = "btnPastaDestino";
            btnPastaDestino.Size = new Size(46, 27);
            btnPastaDestino.TabIndex = 9;
            btnPastaDestino.UseVisualStyleBackColor = true;
            btnPastaDestino.Click += btnPastaDestino_Click;
            // 
            // btnPastaOrigem
            // 
            btnPastaOrigem.FlatStyle = FlatStyle.Flat;
            btnPastaOrigem.Image = BackupIncremental.DeskTop.Properties.Resources.folder_explore;
            btnPastaOrigem.Location = new Point(983, 35);
            btnPastaOrigem.Margin = new Padding(4, 3, 4, 3);
            btnPastaOrigem.Name = "btnPastaOrigem";
            btnPastaOrigem.Size = new Size(46, 27);
            btnPastaOrigem.TabIndex = 8;
            btnPastaOrigem.UseVisualStyleBackColor = true;
            btnPastaOrigem.Click += btnPastaOrigem_Click;
            // 
            // txtPastaDestino
            // 
            txtPastaDestino.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPastaDestino.Location = new Point(152, 66);
            txtPastaDestino.Margin = new Padding(4, 3, 4, 3);
            txtPastaDestino.MaxLength = 200;
            txtPastaDestino.Name = "txtPastaDestino";
            txtPastaDestino.Size = new Size(825, 21);
            txtPastaDestino.TabIndex = 7;
            // 
            // txtPastaOrigem
            // 
            txtPastaOrigem.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPastaOrigem.Location = new Point(152, 36);
            txtPastaOrigem.Margin = new Padding(4, 3, 4, 3);
            txtPastaOrigem.MaxLength = 200;
            txtPastaOrigem.Name = "txtPastaOrigem";
            txtPastaOrigem.Size = new Size(825, 21);
            txtPastaOrigem.TabIndex = 6;
            // 
            // txtHora
            // 
            txtHora.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHora.Location = new Point(152, 7);
            txtHora.Margin = new Padding(4, 3, 4, 3);
            txtHora.MaxLength = 5;
            txtHora.Name = "txtHora";
            txtHora.Size = new Size(47, 21);
            txtHora.TabIndex = 5;
            txtHora.KeyPress += txtHora_KeyPress;
            txtHora.KeyUp += txtHora_KeyUp;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 69);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(83, 13);
            label3.TabIndex = 4;
            label3.Text = "Pasta destino";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(13, 39);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(82, 13);
            label2.TabIndex = 3;
            label2.Text = "Pasta origem";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(13, 7);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(34, 13);
            label1.TabIndex = 2;
            label1.Text = "Hora";
            // 
            // dtgAgendas
            // 
            dtgAgendas.AllowUserToAddRows = false;
            dtgAgendas.AllowUserToDeleteRows = false;
            dtgAgendas.AllowUserToOrderColumns = true;
            dtgAgendas.AllowUserToResizeRows = false;
            dtgAgendas.BackgroundColor = Color.White;
            dtgAgendas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtgAgendas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgAgendas.ColumnHeadersHeight = 20;
            dtgAgendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dtgAgendas.Columns.AddRange(new DataGridViewColumn[] { colHora, colIntervalo, colPastaOrigem, colPastaDestino, colTipos, colRoot, colAtivo });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtgAgendas.DefaultCellStyle = dataGridViewCellStyle2;
            dtgAgendas.Dock = DockStyle.Bottom;
            dtgAgendas.EnableHeadersVisualStyles = false;
            dtgAgendas.Location = new Point(0, 136);
            dtgAgendas.Margin = new Padding(4, 3, 4, 3);
            dtgAgendas.MultiSelect = false;
            dtgAgendas.Name = "dtgAgendas";
            dtgAgendas.RowHeadersVisible = false;
            dtgAgendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgAgendas.Size = new Size(1165, 215);
            dtgAgendas.TabIndex = 0;
            dtgAgendas.CellMouseDoubleClick += dtgAgendas_CellMouseDoubleClick;
            dtgAgendas.ColumnHeaderMouseDoubleClick += dtgAgendas_ColumnHeaderMouseDoubleClick;
            // 
            // colHora
            // 
            colHora.HeaderText = "Hora";
            colHora.Name = "colHora";
            colHora.Width = 50;
            // 
            // colIntervalo
            // 
            colIntervalo.HeaderText = "Intervalo";
            colIntervalo.Name = "colIntervalo";
            colIntervalo.Resizable = DataGridViewTriState.False;
            colIntervalo.Width = 150;
            // 
            // colPastaOrigem
            // 
            colPastaOrigem.HeaderText = "Pasta de origem";
            colPastaOrigem.Name = "colPastaOrigem";
            colPastaOrigem.Width = 350;
            // 
            // colPastaDestino
            // 
            colPastaDestino.HeaderText = "Pasta de Destino";
            colPastaDestino.Name = "colPastaDestino";
            colPastaDestino.Width = 350;
            // 
            // colTipos
            // 
            colTipos.HeaderText = "Tipos de Arquivos";
            colTipos.Name = "colTipos";
            colTipos.Width = 200;
            // 
            // colRoot
            // 
            colRoot.HeaderText = "Root";
            colRoot.Name = "colRoot";
            colRoot.Visible = false;
            // 
            // colAtivo
            // 
            colAtivo.HeaderText = "Ativo";
            colAtivo.Name = "colAtivo";
            colAtivo.Width = 50;
            // 
            // FrmAgenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1167, 389);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmAgenda";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastrar tarefa de backup";
            MouseDown += frmAgenda_MouseDown;
            MouseMove += frmAgenda_MouseMove;
            panel1.ResumeLayout(false);
            rosto.Panel1.ResumeLayout(false);
            rosto.Panel1.PerformLayout();
            rosto.Panel2.ResumeLayout(false);
            rosto.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)rosto).EndInit();
            rosto.ResumeLayout(false);
            ts.ResumeLayout(false);
            ts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgAgendas).EndInit();
            ResumeLayout(false);

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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsExecutarNow;
        private ComboBox cmbIntervalo;
        private DataGridViewTextBoxColumn colHora;
        private DataGridViewTextBoxColumn colIntervalo;
        private DataGridViewTextBoxColumn colPastaOrigem;
        private DataGridViewTextBoxColumn colPastaDestino;
        private DataGridViewTextBoxColumn colTipos;
        private DataGridViewTextBoxColumn colRoot;
        private DataGridViewTextBoxColumn colAtivo;
    }
}