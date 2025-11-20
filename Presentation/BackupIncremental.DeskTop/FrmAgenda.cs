using Bkp.Incremental.Application;

namespace nsBackup
{
    public partial class FrmAgenda : Form
    {

        int X = 0;
        int Y = 0;
        int linhaSelecionada = -1;
        // List<AgendaDto> tarefas;
        private readonly BindingSource bsAgendas = new();
        public Jobs job;

        public FrmAgenda()
        {
            InitializeComponent();
            PopulaComboIntervalo();
            habilitaCampos(false);
            botoesInicio();
            populaDataGrid();
        }

        private void PopulaComboIntervalo()
        {
            var values = Enum.GetValues(typeof(IntervaloEnum)).Cast<IntervaloEnum>();
            var list = values
                .Select(v => new
                {
                    Value = (int)v,
                    Text = v.GetDescription()
                })
                .ToList();

            cmbIntervalo.DisplayMember = "Text";
            cmbIntervalo.ValueMember = "Value";
            cmbIntervalo.DataSource = list;
        }

        void populaDataGrid()
        {
            dtgAgendas.AutoGenerateColumns = false;
            dtgAgendas.Columns["colHora"].DataPropertyName = nameof(AgendaDto.HoraExecucao);
            dtgAgendas.Columns["colPastaOrigem"].DataPropertyName = nameof(AgendaDto.PastaOrigem);
            dtgAgendas.Columns["colPastaDestino"].DataPropertyName = nameof(AgendaDto.PastaDestino);
            dtgAgendas.Columns["colTipos"].DataPropertyName = nameof(AgendaDto.TiposArquivos);
            dtgAgendas.Columns["colRoot"].DataPropertyName = nameof(AgendaDto.CaminhoCompleto);
            dtgAgendas.Columns["colAtivo"].DataPropertyName = nameof(AgendaDto.Ativo);
            dtgAgendas.Columns["colIntervalo"].DataPropertyName = nameof(AgendaDto.Intervalo);
            dtgAgendas.DataSource = null;

            Agenda agenda = new Agenda();
            var lista = agenda.LerDados() ?? new List<AgendaDto>();
            lista.Sort((x, y) => x.HoraExecucao.CompareTo(y.HoraExecucao));

            bsAgendas.DataSource = lista;
            dtgAgendas.DataSource = bsAgendas;
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
            cmbIntervalo.Enabled = habilita;
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
            if (dr == DialogResult.OK)
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
            FrmFiltroTipoArquivo tipos = new FrmFiltroTipoArquivo();
            txtTiposArquivos.Text = FrmFiltroTipoArquivo.buscaExtensoes(txtPastaOrigem.Text, txtTiposArquivos.Text);
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

            if (txtPastaOrigem.Text == string.Empty)
            {
                MessageBox.Show("Informe a pasta de origem !");
                return;
            }

            if (txtPastaDestino.Text == string.Empty)
            {
                MessageBox.Show("Informe a pasta de destino !");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTiposArquivos.Text)) txtTiposArquivos.Text = "*.*";

            Agenda agenda = new Agenda();
            AgendaDto dto = new AgendaDto();
            if (linhaSelecionada == -1)
            {
                dto.HoraExecucao = txtHora.Text;
                dto.PastaOrigem = txtPastaOrigem.Text;
                dto.PastaDestino = txtPastaDestino.Text;
                dto.TiposArquivos = txtTiposArquivos.Text;
                dto.CaminhoCompleto = chkRoot.Checked;
                dto.Ativo = chkAtivo.Checked;
                if (cmbIntervalo.SelectedValue != null)
                {
                    var enumVal = (IntervaloEnum)Enum.ToObject(typeof(IntervaloEnum),(int)cmbIntervalo.SelectedValue);
                    dto.Intervalo = enumVal.ToString();
                }
                var lista = bsAgendas.DataSource as List<AgendaDto>;
                if (lista == null) lista = new List<AgendaDto>();
                lista.Add(dto);
                bsAgendas.DataSource = lista;
            }
            else
            {
                var lista = bsAgendas.DataSource as List<AgendaDto>;
                if (lista != null && linhaSelecionada >= 0 && linhaSelecionada < lista.Count)
                {
                    lista[linhaSelecionada].HoraExecucao = txtHora.Text;
                    lista[linhaSelecionada].PastaOrigem = txtPastaOrigem.Text;
                    lista[linhaSelecionada].PastaDestino = txtPastaDestino.Text;
                    lista[linhaSelecionada].TiposArquivos = txtTiposArquivos.Text;
                    lista[linhaSelecionada].CaminhoCompleto = chkRoot.Checked;
                    lista[linhaSelecionada].Ativo = chkAtivo.Checked;
                    if (cmbIntervalo.SelectedValue != null)
                    {
                        var enumVal = (IntervaloEnum)Enum.ToObject(typeof(IntervaloEnum), (int)cmbIntervalo.SelectedValue);
                        lista[linhaSelecionada].Intervalo = enumVal.ToString();
                    }
                }
            }

            var currentList = bsAgendas.DataSource as List<AgendaDto> ?? new List<AgendaDto>();
            if (agenda.SalvarDados(currentList))
            {
                job.atualizaAgenda = true;
            }

            bsAgendas.ResetBindings(false);

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
            if (e.RowIndex < 0) return;

            linhaSelecionada = e.RowIndex;

            var row = dtgAgendas.Rows[e.RowIndex];
            var dto = row.DataBoundItem as AgendaDto;

            if (dto == null) return;

            txtHora.Text = dto.HoraExecucao ?? string.Empty;
            txtPastaDestino.Text = dto.PastaDestino ?? string.Empty;
            txtPastaOrigem.Text = dto.PastaOrigem ?? string.Empty;
            txtTiposArquivos.Text = dto.TiposArquivos ?? string.Empty;
            chkRoot.Checked = dto.CaminhoCompleto;
            chkAtivo.Checked = dto.Ativo;

            if (!string.IsNullOrEmpty(dto.Intervalo))
            {
                if (Enum.TryParse<IntervaloEnum>(dto.Intervalo, out var enumVal))
                    cmbIntervalo.SelectedValue = (int)enumVal;
            }

            habilitaCampos(true);
            botoesEditar();
        }

        private void dtgAgendas_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgAgendas.Rows.Count == 0) return;

            var nomeColuna = dtgAgendas.Columns[e.ColumnIndex].Name;
            var lista = bsAgendas.DataSource as List<AgendaDto>;
            if (lista == null) return;

            if (nomeColuna.Equals("colHora"))
                lista.Sort((x, y) => x.HoraExecucao.CompareTo(y.HoraExecucao));
            else if (nomeColuna.Equals("colPastaOrigem"))
                lista.Sort((x, y) => x.PastaOrigem.CompareTo(y.PastaOrigem));
            else if (nomeColuna.Equals("colPastaDestino"))
                lista.Sort((x, y) => x.PastaDestino.CompareTo(y.PastaDestino));
            else if (nomeColuna.Equals("colTipos"))
                lista.Sort((x, y) => x.TiposArquivos.CompareTo(y.TiposArquivos));
            else if (nomeColuna.Equals("colRoot"))
                lista.Sort((x, y) => x.CaminhoCompleto.CompareTo(y.CaminhoCompleto));
            else if (nomeColuna.Equals("colAtivo"))
                lista.Sort((x, y) => x.Ativo.CompareTo(y.Ativo));

            bsAgendas.ResetBindings(false);
        }

        private void tsExecutarNow_Click(object sender, EventArgs e)
        {
            var dto = new AgendaDto
            {
                HoraExecucao = txtHora.Text,
                PastaOrigem = txtPastaOrigem.Text,
                PastaDestino = txtPastaDestino.Text,
                TiposArquivos = txtTiposArquivos.Text,
                CaminhoCompleto = chkRoot.Checked,
                Ativo = chkAtivo.Checked
            };

            Jobs job = new Jobs();
            job.ExecutaBackup(dto);

        }
    }
}
