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
            splitContainer1 = new SplitContainer();
            dtgAgendas = new DataGridView();
            colHora = new DataGridViewTextBoxColumn();
            colIntervalo = new DataGridViewTextBoxColumn();
            colPastaOrigem = new DataGridViewTextBoxColumn();
            colPastaDestino = new DataGridViewTextBoxColumn();
            colTipos = new DataGridViewTextBoxColumn();
            colRoot = new DataGridViewTextBoxColumn();
            colAtivo = new DataGridViewTextBoxColumn();
            label4 = new Label();
            txtTiposArquivos = new TextBox();
            label3 = new Label();
            cmbIntervalo = new ComboBox();
            label2 = new Label();
            txtPastaDestino = new TextBox();
            txtPastaOrigem = new TextBox();
            btnTipoArquivo = new Button();
            txtHora = new TextBox();
            btnPastaDestino = new Button();
            label1 = new Label();
            btnPastaOrigem = new Button();
            chkAtivo = new CheckBox();
            fileExplorerSelectionControl1 = new FileExplorerSelectionControl();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rosto).BeginInit();
            rosto.Panel1.SuspendLayout();
            rosto.Panel2.SuspendLayout();
            rosto.SuspendLayout();
            ts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            panel1.Size = new Size(1175, 709);
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
            rosto.Panel2.Controls.Add(splitContainer1);
            rosto.Size = new Size(1173, 707);
            rosto.SplitterDistance = 35;
            rosto.SplitterWidth = 1;
            rosto.TabIndex = 0;
            // 
            // ts
            // 
            ts.Items.AddRange(new ToolStripItem[] { tsBtnAdicionar, tsBtnDeletar, tsBtnSalvar, tsCancelarEdicao, toolStripSeparator1, tsExecutarNow });
            ts.Location = new Point(0, 0);
            ts.Margin = new Padding(0, 1, 0, 0);
            ts.Name = "ts";
            ts.Size = new Size(1173, 25);
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
            tsExecutarNow.Visible = false;
            tsExecutarNow.Click += tsExecutarNow_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dtgAgendas);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(txtTiposArquivos);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(cmbIntervalo);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(txtPastaDestino);
            splitContainer1.Panel1.Controls.Add(txtPastaOrigem);
            splitContainer1.Panel1.Controls.Add(btnTipoArquivo);
            splitContainer1.Panel1.Controls.Add(txtHora);
            splitContainer1.Panel1.Controls.Add(btnPastaDestino);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(btnPastaOrigem);
            splitContainer1.Panel1.Controls.Add(chkAtivo);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(fileExplorerSelectionControl1);
            splitContainer1.Size = new Size(1173, 671);
            splitContainer1.SplitterDistance = 348;
            splitContainer1.TabIndex = 18;
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
            dtgAgendas.Location = new Point(0, 133);
            dtgAgendas.Margin = new Padding(4, 3, 4, 3);
            dtgAgendas.MultiSelect = false;
            dtgAgendas.Name = "dtgAgendas";
            dtgAgendas.RowHeadersVisible = false;
            dtgAgendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgAgendas.Size = new Size(1173, 215);
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(4, 106);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(109, 13);
            label4.TabIndex = 10;
            label4.Text = "Tipos de Arquivos";
            // 
            // txtTiposArquivos
            // 
            txtTiposArquivos.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTiposArquivos.Location = new Point(121, 101);
            txtTiposArquivos.Margin = new Padding(4, 3, 4, 3);
            txtTiposArquivos.MaxLength = 200;
            txtTiposArquivos.Name = "txtTiposArquivos";
            txtTiposArquivos.Size = new Size(706, 21);
            txtTiposArquivos.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(4, 75);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(83, 13);
            label3.TabIndex = 4;
            label3.Text = "Pasta destino";
            // 
            // cmbIntervalo
            // 
            cmbIntervalo.FormattingEnabled = true;
            cmbIntervalo.Location = new Point(121, 7);
            cmbIntervalo.Name = "cmbIntervalo";
            cmbIntervalo.Size = new Size(257, 23);
            cmbIntervalo.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(4, 41);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(82, 13);
            label2.TabIndex = 3;
            label2.Text = "Pasta origem";
            // 
            // txtPastaDestino
            // 
            txtPastaDestino.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPastaDestino.Location = new Point(121, 69);
            txtPastaDestino.Margin = new Padding(4, 3, 4, 3);
            txtPastaDestino.MaxLength = 200;
            txtPastaDestino.Name = "txtPastaDestino";
            txtPastaDestino.Size = new Size(706, 21);
            txtPastaDestino.TabIndex = 7;
            // 
            // txtPastaOrigem
            // 
            txtPastaOrigem.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPastaOrigem.Location = new Point(121, 36);
            txtPastaOrigem.Margin = new Padding(4, 3, 4, 3);
            txtPastaOrigem.MaxLength = 200;
            txtPastaOrigem.Name = "txtPastaOrigem";
            txtPastaOrigem.Size = new Size(706, 21);
            txtPastaOrigem.TabIndex = 6;
            txtPastaOrigem.TextChanged += txtPastaOrigem_TextChanged;
            // 
            // btnTipoArquivo
            // 
            btnTipoArquivo.FlatStyle = FlatStyle.Flat;
            btnTipoArquivo.Image = BackupIncremental.DeskTop.Properties.Resources.text_list_bullets;
            btnTipoArquivo.Location = new Point(839, 95);
            btnTipoArquivo.Margin = new Padding(4, 3, 4, 3);
            btnTipoArquivo.Name = "btnTipoArquivo";
            btnTipoArquivo.Size = new Size(46, 27);
            btnTipoArquivo.TabIndex = 12;
            btnTipoArquivo.UseVisualStyleBackColor = true;
            btnTipoArquivo.Click += btnTipoArquivo_Click;
            // 
            // txtHora
            // 
            txtHora.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHora.Location = new Point(58, 8);
            txtHora.Margin = new Padding(4, 3, 4, 3);
            txtHora.MaxLength = 5;
            txtHora.Name = "txtHora";
            txtHora.Size = new Size(47, 21);
            txtHora.TabIndex = 5;
            txtHora.KeyPress += txtHora_KeyPress;
            txtHora.KeyUp += txtHora_KeyUp;
            // 
            // btnPastaDestino
            // 
            btnPastaDestino.FlatStyle = FlatStyle.Flat;
            btnPastaDestino.Image = BackupIncremental.DeskTop.Properties.Resources.folder_explore;
            btnPastaDestino.Location = new Point(838, 63);
            btnPastaDestino.Margin = new Padding(4, 3, 4, 3);
            btnPastaDestino.Name = "btnPastaDestino";
            btnPastaDestino.Size = new Size(46, 27);
            btnPastaDestino.TabIndex = 9;
            btnPastaDestino.UseVisualStyleBackColor = true;
            btnPastaDestino.Click += btnPastaDestino_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(4, 11);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(34, 13);
            label1.TabIndex = 2;
            label1.Text = "Hora";
            // 
            // btnPastaOrigem
            // 
            btnPastaOrigem.FlatStyle = FlatStyle.Flat;
            btnPastaOrigem.Image = BackupIncremental.DeskTop.Properties.Resources.folder_explore;
            btnPastaOrigem.Location = new Point(838, 32);
            btnPastaOrigem.Margin = new Padding(4, 3, 4, 3);
            btnPastaOrigem.Name = "btnPastaOrigem";
            btnPastaOrigem.Size = new Size(46, 27);
            btnPastaOrigem.TabIndex = 8;
            btnPastaOrigem.UseVisualStyleBackColor = true;
            btnPastaOrigem.Click += btnPastaOrigem_Click;
            // 
            // chkAtivo
            // 
            chkAtivo.AutoSize = true;
            chkAtivo.Location = new Point(835, 8);
            chkAtivo.Margin = new Padding(4, 3, 4, 3);
            chkAtivo.Name = "chkAtivo";
            chkAtivo.Size = new Size(54, 19);
            chkAtivo.TabIndex = 14;
            chkAtivo.Text = "Ativo";
            chkAtivo.UseVisualStyleBackColor = true;
            // 
            // fileExplorerSelectionControl1
            // 
            fileExplorerSelectionControl1.Dock = DockStyle.Fill;
            fileExplorerSelectionControl1.Location = new Point(0, 0);
            fileExplorerSelectionControl1.Name = "fileExplorerSelectionControl1";
            fileExplorerSelectionControl1.Size = new Size(1173, 319);
            fileExplorerSelectionControl1.TabIndex = 0;
            // 
            // FrmAgenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1175, 709);
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
            ((System.ComponentModel.ISupportInitialize)rosto).EndInit();
            rosto.ResumeLayout(false);
            ts.ResumeLayout(false);
            ts.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
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
        private SplitContainer splitContainer1;
        private FileExplorerSelectionControl fileExplorerSelectionControl1;
    }
}