namespace nsBackup
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.ntfI = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.rosto = new System.Windows.Forms.SplitContainer();
            this.ts = new System.Windows.Forms.ToolStrip();
            this.tsBtnAgenda = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.rosto.Panel1.SuspendLayout();
            this.rosto.SuspendLayout();
            this.ts.SuspendLayout();
            this.SuspendLayout();
            // 
            // ntfI
            // 
            this.ntfI.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfI.Icon")));
            this.ntfI.Text = "Backup";
            this.ntfI.Visible = true;
            this.ntfI.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ntfI_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rosto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 415);
            this.panel1.TabIndex = 0;
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
            this.rosto.Size = new System.Drawing.Size(618, 413);
            this.rosto.SplitterDistance = 30;
            this.rosto.SplitterWidth = 1;
            this.rosto.TabIndex = 0;
            // 
            // ts
            // 
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAgenda});
            this.ts.Location = new System.Drawing.Point(0, 0);
            this.ts.Name = "ts";
            this.ts.Size = new System.Drawing.Size(618, 25);
            this.ts.TabIndex = 0;
            this.ts.Text = "toolStrip1";
            // 
            // tsBtnAgenda
            // 
            this.tsBtnAgenda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAgenda.Image = global::nsBackup.Properties.Resources.text_list_bullets;
            this.tsBtnAgenda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAgenda.Name = "tsBtnAgenda";
            this.tsBtnAgenda.Size = new System.Drawing.Size(23, 22);
            this.tsBtnAgenda.ToolTipText = "Agenda";
            this.tsBtnAgenda.Click += new System.EventHandler(this.tsBtnAgenda_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 415);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup (Beta)";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmPrincipal_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmPrincipal_MouseMove);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.rosto.Panel1.ResumeLayout(false);
            this.rosto.Panel1.PerformLayout();
            this.rosto.ResumeLayout(false);
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon ntfI;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer rosto;
        private System.Windows.Forms.ToolStrip ts;
        private System.Windows.Forms.ToolStripButton tsBtnAgenda;
    }
}

