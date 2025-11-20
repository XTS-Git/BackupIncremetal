namespace nsBackup
{
    partial class FrmPrincipal
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            ntfI = new NotifyIcon(components);
            panel1 = new Panel();
            rosto = new SplitContainer();
            ts = new ToolStrip();
            tsBtnAgenda = new ToolStripButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rosto).BeginInit();
            rosto.Panel1.SuspendLayout();
            rosto.SuspendLayout();
            ts.SuspendLayout();
            SuspendLayout();
            // 
            // ntfI
            // 
            ntfI.Icon = (Icon)resources.GetObject("ntfI.Icon");
            ntfI.Text = "Backup";
            ntfI.Visible = true;
            ntfI.MouseDoubleClick += ntfI_MouseDoubleClick;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(rosto);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(723, 479);
            panel1.TabIndex = 0;
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
            rosto.Size = new Size(721, 477);
            rosto.SplitterDistance = 35;
            rosto.SplitterWidth = 1;
            rosto.TabIndex = 0;
            // 
            // ts
            // 
            ts.Items.AddRange(new ToolStripItem[] { tsBtnAgenda });
            ts.Location = new Point(0, 0);
            ts.Name = "ts";
            ts.Size = new Size(721, 25);
            ts.TabIndex = 0;
            ts.Text = "toolStrip1";
            // 
            // tsBtnAgenda
            // 
            tsBtnAgenda.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnAgenda.Image = BackupIncremental.DeskTop.Properties.Resources.text_list_bullets;
            tsBtnAgenda.ImageTransparentColor = Color.Magenta;
            tsBtnAgenda.Name = "tsBtnAgenda";
            tsBtnAgenda.Size = new Size(23, 22);
            tsBtnAgenda.ToolTipText = "Agenda";
            tsBtnAgenda.Click += tsBtnAgenda_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 479);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmPrincipal";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Backup (Beta)";
            MouseDown += frmPrincipal_MouseDown;
            MouseMove += frmPrincipal_MouseMove;
            Resize += Form1_Resize;
            panel1.ResumeLayout(false);
            rosto.Panel1.ResumeLayout(false);
            rosto.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)rosto).EndInit();
            rosto.ResumeLayout(false);
            ts.ResumeLayout(false);
            ts.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon ntfI;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer rosto;
        private System.Windows.Forms.ToolStrip ts;
        private System.Windows.Forms.ToolStripButton tsBtnAgenda;
    }
}

