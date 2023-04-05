using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Tools;

namespace nsBackup
{
    public partial class frmAgenda : Form
    {

        int X = 0;
        int Y = 0;
        int linhaSelecionada=-1;
        List<AgendaDto> tarefas;
        public Jobs job;

        public frmAgenda()
        {
            InitializeComponent();
            habilitaCampos(false);
            botoesInicio();
            populaDataGrid();
        }

        void populaDataGrid()
        {
            dtgAgendas.AutoGenerateColumns = false;
            dtgAgendas.Columns["colHora"].DataPropertyName = "horaDaExecucao";
            dtgAgendas.Columns["colPastaOrigem"].DataPropertyName = "pastaOrigem";
            dtgAgendas.Columns["colPastaDestino"].DataPropertyName = "pastaDestino";
            dtgAgendas.Columns["colTipos"].DataPropertyName = "tiposArquivos";
            dtgAgendas.Columns["colRoot"].DataPropertyName = "caminhoCompleto";
            dtgAgendas.Columns["colAtivo"].DataPropertyName = "ativo";
            dtgAgendas.DataSource = null;

            Agenda agenda = new Agenda();
            tarefas = agenda.lerDados();
            tarefas.Sort((x, y) => x.horaDaExecucao.CompareTo(y.horaDaExecucao));
            dtgAgendas.DataSource = null;
            dtgAgendas.DataSource = tarefas;
        }

        void habilitaCampos(bool habilita)
        {
            txtHora.Enabled = habilita;
            txtPastaDestino.Enabled = habilita;
            txtPastaOrigem.Enabled = habilita;
            txtTiposArquivos.Enabled = habilita;
            btnPastaDestino.Enabled = habilita;
            btnPastaOrigem.Enabled = habilita;
            btnTipoArquivo.Enabled = habilita;
            if (!habilita)
            {
                txtHora.Text = string.Empty;
                txtPastaDestino.Text = string.Empty;
                txtPastaOrigem.Text = string.Empty;
                txtTiposArquivos.Text = string.Empty;
                linhaSelecionada = -1;
            }
            else
            {
                txtHora.Focus();
            }
        }
        void botoesInicio()
        {
            tsBtnDeletar.Enabled = false;
            tsBtnAdicionar.Enabled = true;
            tsBtnSalvar.Enabled = false;
            tsCancelarEdicao.Enabled = false;
            tsExecutarNow.Enabled = false;
        }
        void botoesEditar()
        {
            tsBtnAdicionar.Enabled = false;
            tsBtnDeletar.Enabled = false;
            tsBtnSalvar.Enabled = true;
            tsCancelarEdicao.Enabled = true;
            tsExecutarNow.Enabled = true;
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHora_KeyUp(object sender, KeyEventArgs e)
        {
            int tama = txtHora.Text.Length;
            if (tama == 2)
            {
                txtHora.Text = txtHora.Text + ":";
                txtHora.SelectionStart = txtHora.Text.Length;
                txtHora.ScrollToCaret();
            }
        }

        #region
        private void frmAgenda_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;

        }
        private void frmAgenda_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;

        }
        private void rosto_Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            frmAgenda_MouseDown(sender, e);
        }
        private void rosto_Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            frmAgenda_MouseMove(sender, e);
        }
        #endregion


        private string listaPastas()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                return fbd.SelectedPath;
            }
            else
            {
                return null;
            }
        }

        private void btnPastaOrigem_Click(object sender, EventArgs e)
        {
            txtPastaOrigem.Text = listaPastas();
        }

        private void btnPastaDestino_Click(object sender, EventArgs e)
        {
            txtPastaDestino.Text = listaPastas();
        }

        private void btnTipoArquivo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPastaOrigem.Text))
            {
                MessageBox.Show("Para criar uma seleção para tipos de arquivos é necessário informar a pasta de origem.");
                return;
            }
            frmFiltroTipoArquivo tipos = new frmFiltroTipoArquivo();
            txtTiposArquivos.Text = frmFiltroTipoArquivo.buscaExtensoes(txtPastaOrigem.Text, txtTiposArquivos.Text);
            // tipos.ShowDialog();
        }

        private void tsBtnAdicionar_Click(object sender, EventArgs e)
        {
            habilitaCampos(true);
            botoesEditar();
        }

        private void tsBtnDeletar_Click(object sender, EventArgs e)
        {

        }

        private void tsBtnSalvar_Click(object sender, EventArgs e)
        {
            if (txtHora.Text == string.Empty)
            {
                MessageBox.Show("Hora do Backup não poder estar em branco");
                return;
            }

            if( txtPastaOrigem.Text == string.Empty )
            {
                MessageBox.Show("Informe a pasta de origem !");
                return;
            }

            if ( txtPastaDestino.Text == string.Empty)
            {
                MessageBox.Show("Informe a pasta de destino !");
                return;
            }

            if (txtTiposArquivos.Text.isNullOrEmpty()) txtTiposArquivos.Text = "*.*";

            Agenda agenda = new Agenda();
            AgendaDto dto = new AgendaDto();
            // Jobs job = new Jobs();
            if (linhaSelecionada == -1)
            {
                // linhaSelecionada = dtgAgendas.Rows.Add();
                dto.horaDaExecucao = txtHora.Text;
                dto.pastaOrigem = txtPastaOrigem.Text;
                dto.pastaDestino = txtPastaDestino.Text;
                dto.tiposArquivos = txtTiposArquivos.Text;
                dto.caminhoCompleto = chkRoot.Checked;
                dto.ativo = chkAtivo.Checked;
                tarefas.Add(dto);
            }
            else
            {
                tarefas = (List<AgendaDto>)dtgAgendas.DataSource;
                tarefas[linhaSelecionada].horaDaExecucao = txtHora.Text;
                tarefas[linhaSelecionada].pastaOrigem = txtPastaOrigem.Text;
                tarefas[linhaSelecionada].pastaDestino = txtPastaDestino.Text;
                tarefas[linhaSelecionada].tiposArquivos = txtTiposArquivos.Text;
                tarefas[linhaSelecionada].caminhoCompleto = chkRoot.Checked;
                tarefas[linhaSelecionada].ativo = chkAtivo.Checked;
            }

            if (agenda.salvaDados(tarefas))
            {
                job.atualizaAgenda = true;
            }
            dtgAgendas.DataSource = null;
            dtgAgendas.DataSource = tarefas;

            botoesInicio();
            habilitaCampos(false);
        }

        private void tsCancelarEdicao_Click(object sender, EventArgs e)
        {

            botoesInicio();
            habilitaCampos(false);
        }

        private void dtgAgendas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                linhaSelecionada = e.RowIndex;
                txtHora.Text = dtgAgendas.Rows[e.RowIndex].Cells["colHora"].Value.ToString();
                txtPastaDestino.Text = dtgAgendas.Rows[e.RowIndex].Cells["colPastaDestino"].Value.ToString();
                txtPastaOrigem.Text = dtgAgendas.Rows[e.RowIndex].Cells["colPastaOrigem"].Value.ToString();
                txtTiposArquivos.Text = dtgAgendas.Rows[e.RowIndex].Cells["colTipos"].Value.ToString();
                chkRoot.Checked = Convert.ToBoolean(dtgAgendas.Rows[e.RowIndex].Cells["colRoot"].Value.ToString());
                chkAtivo.Checked = Convert.ToBoolean(dtgAgendas.Rows[e.RowIndex].Cells["colAtivo"].Value.ToString());
                habilitaCampos(true);
                botoesEditar();

            }
        }

        private void dtgAgendas_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || dtgAgendas.Rows.Count > 0)
            {
                string nomeColuna = dtgAgendas.Columns[e.ColumnIndex].Name;
                if ( nomeColuna.Equals("colHora") )
                   tarefas.Sort((x, y) => x.horaDaExecucao.CompareTo(y.horaDaExecucao));
                else if ( nomeColuna.Equals("colPastaOrigem") )
                   tarefas.Sort((x, y) => x.pastaOrigem.CompareTo(y.pastaOrigem));
                else if ( nomeColuna.Equals("colPastaDestino") )
                   tarefas.Sort((x, y) => x.pastaDestino.CompareTo(y.pastaDestino));
                else if ( nomeColuna.Equals("colTipos") )
                   tarefas.Sort((x, y) => x.tiposArquivos.CompareTo(y.tiposArquivos));
                else if ( nomeColuna.Equals("colRoot") )
                   tarefas.Sort((x, y) => x.caminhoCompleto.CompareTo(y.caminhoCompleto));
                else if ( nomeColuna.Equals("colAtivo") )
                   tarefas.Sort((x, y) => x.ativo.CompareTo(y.ativo));
                dtgAgendas.DataSource = null;
                dtgAgendas.DataSource = tarefas;
            }
        }

        private void tsExecutarNow_Click(object sender, EventArgs e)
        {
            AgendaDto dto = new AgendaDto();
            dto.horaDaExecucao = txtHora.Text;
            dto.pastaOrigem = txtPastaOrigem.Text;
            dto.pastaDestino = txtPastaDestino.Text;
            dto.tiposArquivos = txtTiposArquivos.Text;
            dto.caminhoCompleto = chkRoot.Checked;
            dto.ativo = chkAtivo.Checked;
            Jobs job = new Jobs();
            job.executaBackup(dto);

        }
    }
}
