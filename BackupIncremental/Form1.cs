using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using XTS.Tools;

namespace nsBackup
{
    public partial class frmPrincipal : Form
    {
        Jobs job;
        int X = 0;
        int Y = 0;

        public frmPrincipal()
        {
            InitializeComponent();

            try
            {
                RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                string caminhoReg = Application.ExecutablePath.ToString();
                string[] chaves = rkApp.GetValueNames();
                string nomeChave = "exatosBackup";
                if ( !existeChave(chaves, nomeChave)) rkApp.SetValue(nomeChave, caminhoReg);
                rkApp.Close();

                job = new Jobs();
                job.onStart += job_onStart;
                job.start();

            }
            catch (Exception ex)
            {
                Arquivos.geraLog(string.Format("Erro: {0} Trace: {1}",ex.Message, ex.StackTrace));
            }

            // return;
        }

        bool existeChave(string[] chaves, string nomeChave)
        {
            bool b = false;
            foreach (string chave in chaves)
            {
                if (chave.Equals(nomeChave))
                {
                    b = true;
                    break;
                }
            }
            return b;

        }
        void job_onStart(object sender, EventArgs e)
        {
            // IniciaBackup();
        }

        private void IniciaBackup()
        {
            //backup = new Backup();
            //string s = backup.start(pastaOrigem, pastaDestino, tiposArquivos);
        }

        private void ntfI_MouseDoubleClick(object sender, MouseEventArgs e)
        {                       
            this.Show();
            WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
            }
        
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region
        private void frmPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }
        private void frmPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }
        private void rosto_Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            frmPrincipal_MouseDown(sender, e);
        }
        private void rosto_Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            frmPrincipal_MouseMove(sender, e);
        }
        #endregion

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tsBtnAgenda_Click(object sender, EventArgs e)
        {
            frmAgenda agenda = new frmAgenda();
            agenda.job = job;
            agenda.ShowDialog(this);
        }
    }



}
