using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bkp.Incremental.Application.Dto;
using Bkp.Incremental.Application.Enums;
using Bkp.Incremental.Application.Extensions;

namespace nsBackup
{
    public partial class FrmAgenda : Form
    {

        int X = 0;
        int Y = 0;
        int linhaSelecionada = -1;
        private readonly BindingSource _bsAgendas = new();
        private readonly BindingSource _bsIncluded = new();
        private readonly BindingSource _bsExcluded = new();
        private FileExplorerSelectionControl? _fileExplorer;
        public Jobs job;

        public FrmAgenda()
        {
            InitializeComponent();
            PopulaComboIntervalo();
            habilitaCampos(false);
            BotoesInicio();
            PopulaDataGrid();

            // try to wire FileExplorerSelectionControl and UI lists if present on the form
            WireExplorerIfPresent();
        }

        private void WireExplorerIfPresent()
        {
            // safe lookup by name so the code doesn't depend on designer-generated field names
            var explorer = Controls.Find("fileExplorerSelectionControl1", true).FirstOrDefault() as FileExplorerSelectionControl;
            _fileExplorer = explorer;
            var lstIncluded = Controls.Find("lstIncludedFiles", true).FirstOrDefault() as ListBox;
            var lstExcluded = Controls.Find("lstExcludedFiles", true).FirstOrDefault() as ListBox;
            var btnRemoveIncluded = Controls.Find("btnRemoveIncluded", true).FirstOrDefault() as Button;
            var btnRemoveExcluded = Controls.Find("btnRemoveExcluded", true).FirstOrDefault() as Button;

            if (lstIncluded != null)
            {
                lstIncluded.DataSource = _bsIncluded;
                lstIncluded.DisplayMember = nameof(ItensAgendaDto.Nome);
            }

            if (lstExcluded != null)
            {
                lstExcluded.DataSource = _bsExcluded;
                lstExcluded.DisplayMember = nameof(ItensAgendaDto.Nome);
            }

            if (btnRemoveIncluded != null)
                btnRemoveIncluded.Click += (s, e) => RemoveSelectedFromBinding(lstIncluded, _bsIncluded);

            if (btnRemoveExcluded != null)
                btnRemoveExcluded.Click += (s, e) => RemoveSelectedFromBinding(lstExcluded, _bsExcluded);

            if (explorer != null)
            {
                explorer.IncludeRequested += (s, e) =>
                {
                    AddPathsToBinding(_bsIncluded, e.Paths);
                    // ensure explorer highlights the added items (explorer already does this internally,
                    // but call SetIncludedPaths to be sure form-driven additions stay in sync)
                    explorer.AddIncludedPaths(e.Paths);
                };

                explorer.ExcludeRequested += (s, e) =>
                {
                    AddPathsToBinding(_bsExcluded, e.Paths);
                    explorer.AddExcludedPaths(e.Paths);
                };

                // keep explorer root in sync when origin folder changes
                txtPastaOrigem.TextChanged += (s, e) =>
                {
                    if (!string.IsNullOrWhiteSpace(txtPastaOrigem.Text))
                        explorer.SetRoot(txtPastaOrigem.Text);
                };

                // if there is already a origem folder, set it
                if (!string.IsNullOrWhiteSpace(txtPastaOrigem.Text))
                    explorer.SetRoot(txtPastaOrigem.Text);
            }
        }

        private void AddPathsToBinding(BindingSource bs, IReadOnlyList<string> paths)
        {
            if (paths == null || paths.Count == 0) return;

            var list = bs.DataSource as List<ItensAgendaDto> ?? new List<ItensAgendaDto>();

            foreach (var p in paths)
            {
                if (string.IsNullOrWhiteSpace(p)) continue;
                // avoid duplicates by path (case-insensitive)
                if (list.Any(x => string.Equals(x.Nome, p, StringComparison.OrdinalIgnoreCase)))
                    continue;

                var item = new ItensAgendaDto
                {
                    Nome = p,
                    TipoIten = Directory.Exists(p) ? TipoItenAgendaEnum.Folder : TipoItenAgendaEnum.File,
                    Sucesso = false,
                    DataUltimoBkp = DateTime.MinValue
                };
                list.Add(item);
            }

            bs.DataSource = list;
            bs.ResetBindings(false);

            // reflect back to explorer highlighting when form updates lists programmatically
            try
            {
                if (bs == _bsIncluded)
                    _fileExplorer?.SetIncludedPaths(list.Select(x => x.Nome));
                else if (bs == _bsExcluded)
                    _fileExplorer?.SetExcludedPaths(list.Select(x => x.Nome));
            }
            catch { /* ignore if explorer not present */ }
        }

        private void RemoveSelectedFromBinding(ListBox? listBox, BindingSource bs)
        {
            var list = bs.DataSource as List<ItensAgendaDto>;
            if (list == null || list.Count == 0) return;

            if (listBox != null)
            {
                var selected = listBox.SelectedItems.Cast<ItensAgendaDto>().ToList();
                foreach (var s in selected)
                    list.RemoveAll(x => string.Equals(x.Nome, s.Nome, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                // fallback: remove currently selected item in binding source (if any)
                if (bs.Current is ItensAgendaDto current)
                    list.RemoveAll(x => string.Equals(x.Nome, current.Nome, StringComparison.OrdinalIgnoreCase));
            }

            bs.DataSource = list;
            bs.ResetBindings(false);

            // update explorer highlights
            try
            {
                if (bs == _bsIncluded)
                    _fileExplorer?.SetIncludedPaths(list.Select(x => x.Nome));
                else if (bs == _bsExcluded)
                    _fileExplorer?.SetExcludedPaths(list.Select(x => x.Nome));
            }
            catch { }
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

        void PopulaDataGrid()
        {
            dtgAgendas.AutoGenerateColumns = false;
            dtgAgendas.Columns["colHora"].DataPropertyName = nameof(AgendaDto.HoraExecucao);
            dtgAgendas.Columns["colPastaOrigem"].DataPropertyName = nameof(AgendaDto.PastaOrigem);
            dtgAgendas.Columns["colPastaDestino"].DataPropertyName = nameof(AgendaDto.PastaDestino);
            dtgAgendas.Columns["colTipos"].DataPropertyName = nameof(AgendaDto.TiposArquivos);
            dtgAgendas.Columns["colAtivo"].DataPropertyName = nameof(AgendaDto.Ativo);
            dtgAgendas.Columns["colIntervalo"].DataPropertyName = nameof(AgendaDto.Intervalo);
            dtgAgendas.DataSource = null;

            Agenda agenda = new Agenda();
            var lista = agenda.LerDados() ?? new List<AgendaDto>();
            lista.Sort((x, y) => x.HoraExecucao.CompareTo(y.HoraExecucao));

            _bsAgendas.DataSource = lista;
            dtgAgendas.DataSource = _bsAgendas;
        }

        void habilitaCampos(bool habilita)
        {
            txtHora.Enabled = habilita;
            txtPastaDestino.Enabled = habilita;
            txtPastaOrigem.Enabled = habilita;
            txtTiposArquivos.Enabled = habilita;
            cmbIntervalo.Enabled = habilita;

            btnPastaDestino.Enabled = habilita;
            btnPastaOrigem.Enabled = habilita;
            btnTipoArquivo.Enabled = habilita;

            // btnAddItens.Enabled = (!string.IsNullOrWhiteSpace(txtPastaOrigem.Text));
            // btnDelItens.Enabled = (!string.IsNullOrWhiteSpace(txtPastaOrigem.Text));


            chkAtivo.Checked = habilita;
            if (!habilita)
            {
                txtHora.Text = string.Empty;
                txtPastaDestino.Text = string.Empty;
                txtPastaOrigem.Text = string.Empty;
                txtTiposArquivos.Text = string.Empty;
                linhaSelecionada = -1;

                // clear temporary selections when leaving edit mode
                _bsIncluded.DataSource = new List<ItensAgendaDto>();
                _bsExcluded.DataSource = new List<ItensAgendaDto>();
                _bsIncluded.ResetBindings(false);
                _bsExcluded.ResetBindings(false);

                // clear highlights in explorer
                _fileExplorer?.ClearIncluded();
                _fileExplorer?.ClearExcluded();
            }
            else
            {
                txtHora.Focus();
            }
        }
        void BotoesInicio()
        {
            tsBtnDeletar.Enabled = false;
            tsBtnAdicionar.Enabled = true;
            tsBtnSalvar.Enabled = false;
            tsCancelarEdicao.Enabled = false;
            tsExecutarNow.Enabled = false;
        }
        void BotoesEditar()
        {
            tsBtnAdicionar.Enabled = false;
            tsBtnDeletar.Enabled = true;
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


        private string ListaPastas()
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
            txtPastaOrigem.Text = ListaPastas();
        }

        private void btnPastaDestino_Click(object sender, EventArgs e)
        {
            txtPastaDestino.Text = ListaPastas();
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
            BotoesEditar();
        }

        private void tsBtnDeletar_Click(object sender, EventArgs e)
        {
            int index = linhaSelecionada;
            if (index < 0 && dtgAgendas.CurrentRow != null)
                index = dtgAgendas.CurrentRow.Index;

            if (index < 0)
            {
                MessageBox.Show("Selecione uma tarefa para excluir.", "Excluir tarefa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var lista = _bsAgendas.DataSource as List<AgendaDto>;
            if (lista == null || index < 0 || index >= lista.Count)
            {
                MessageBox.Show("Seleção inválida.", "Excluir tarefa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = lista[index];
            var confirm = MessageBox.Show(
                $"Confirma exclusão da tarefa?\n\nHora: {dto.HoraExecucao}\nOrigem: {dto.PastaOrigem}\nDestino: {dto.PastaDestino}",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            lista.RemoveAt(index);
            Agenda agenda = new Agenda();
            try
            {
                if (agenda.SalvarDados(lista))
                {
                    if (job != null) job.atualizaAgenda = true;
                }
                else
                {
                    MessageBox.Show("Falha ao salvar alterações da agenda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir tarefa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // atualiza binding e UI
            _bsAgendas.DataSource = lista;
            _bsAgendas.ResetBindings(false);
            linhaSelecionada = -1;
            habilitaCampos(false);
            BotoesInicio();
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
                dto.Ativo = chkAtivo.Checked;
                if (cmbIntervalo.SelectedValue != null)
                {
                    var enumVal = (IntervaloEnum)Enum.ToObject(typeof(IntervaloEnum), (int)cmbIntervalo.SelectedValue);
                    dto.Intervalo = enumVal.ToString();
                }

                // persist included/excluded selections into the new dto
                dto.ItensAddAgenda = (_bsIncluded.DataSource as List<ItensAgendaDto>) ?? new List<ItensAgendaDto>();
                dto.ItensDelAgenda = (_bsExcluded.DataSource as List<ItensAgendaDto>) ?? new List<ItensAgendaDto>();

                var lista = _bsAgendas.DataSource as List<AgendaDto>;
                if (lista == null) lista = new List<AgendaDto>();
                lista.Add(dto);
                _bsAgendas.DataSource = lista;
            }
            else
            {
                var lista = _bsAgendas.DataSource as List<AgendaDto>;
                if (lista != null && linhaSelecionada >= 0 && linhaSelecionada < lista.Count)
                {
                    lista[linhaSelecionada].HoraExecucao = txtHora.Text;
                    lista[linhaSelecionada].PastaOrigem = txtPastaOrigem.Text;
                    lista[linhaSelecionada].PastaDestino = txtPastaDestino.Text;
                    lista[linhaSelecionada].TiposArquivos = txtTiposArquivos.Text;
                    lista[linhaSelecionada].Ativo = chkAtivo.Checked;
                    if (cmbIntervalo.SelectedValue != null)
                    {
                        var enumVal = (IntervaloEnum)Enum.ToObject(typeof(IntervaloEnum), (int)cmbIntervalo.SelectedValue);
                        lista[linhaSelecionada].Intervalo = enumVal.ToString();
                    }

                    // persist included/excluded selections into the existing dto
                    lista[linhaSelecionada].ItensAddAgenda = (_bsIncluded.DataSource as List<ItensAgendaDto>) ?? new List<ItensAgendaDto>();
                    lista[linhaSelecionada].ItensDelAgenda = (_bsExcluded.DataSource as List<ItensAgendaDto>) ?? new List<ItensAgendaDto>();
                }
            }

            var currentList = _bsAgendas.DataSource as List<AgendaDto> ?? new List<AgendaDto>();
            if (agenda.SalvarDados(currentList))
            {
                job.atualizaAgenda = true;
            }

            _bsAgendas.ResetBindings(false);

            BotoesInicio();
            habilitaCampos(false);
        }

        private void tsCancelarEdicao_Click(object sender, EventArgs e)
        {

            BotoesInicio();
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
            // chkRoot.Checked = dto.CaminhoCompleto;
            chkAtivo.Checked = dto.Ativo;

            if (!string.IsNullOrEmpty(dto.Intervalo))
            {
                if (Enum.TryParse<IntervaloEnum>(dto.Intervalo, out var enumVal))
                    cmbIntervalo.SelectedValue = (int)enumVal;
            }

            // load persisted include/exclude lists into the temporary binding sources
            _bsIncluded.DataSource = dto.ItensAddAgenda ?? new List<ItensAgendaDto>();
            _bsExcluded.DataSource = dto.ItensDelAgenda ?? new List<ItensAgendaDto>();
            _bsIncluded.ResetBindings(false);
            _bsExcluded.ResetBindings(false);

            // update explorer highlights for these persisted lists
            try
            {
                var explorer = _fileExplorer;
                if (explorer != null)
                {
                    explorer.SetIncludedPaths(dto.ItensAddAgenda?.Select(i => i.Nome) ?? Enumerable.Empty<string>());
                    explorer.SetExcludedPaths(dto.ItensDelAgenda?.Select(i => i.Nome) ?? Enumerable.Empty<string>());
                }
            }
            catch { /* ignore if explorer not present */ }

            habilitaCampos(true);
            BotoesEditar();
        }

        private void dtgAgendas_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgAgendas.Rows.Count == 0) return;

            var nomeColuna = dtgAgendas.Columns[e.ColumnIndex].Name;
            var lista = _bsAgendas.DataSource as List<AgendaDto>;
            if (lista == null) return;

            if (nomeColuna.Equals("colHora"))
                lista.Sort((x, y) => x.HoraExecucao.CompareTo(y.HoraExecucao));
            else if (nomeColuna.Equals("colPastaOrigem"))
                lista.Sort((x, y) => x.PastaOrigem.CompareTo(y.PastaOrigem));
            else if (nomeColuna.Equals("colPastaDestino"))
                lista.Sort((x, y) => x.PastaDestino.CompareTo(y.PastaDestino));
            else if (nomeColuna.Equals("colTipos"))
                lista.Sort((x, y) => x.TiposArquivos.CompareTo(y.TiposArquivos));
            else if (nomeColuna.Equals("colAtivo"))
                lista.Sort((x, y) => x.Ativo.CompareTo(y.Ativo));

            _bsAgendas.ResetBindings(false);
        }

        private void tsExecutarNow_Click(object sender, EventArgs e)
        {
            var dto = new AgendaDto
            {
                HoraExecucao = txtHora.Text,
                PastaOrigem = txtPastaOrigem.Text,
                PastaDestino = txtPastaDestino.Text,
                TiposArquivos = txtTiposArquivos.Text,
                Ativo = chkAtivo.Checked,
                ItensAddAgenda = (_bsIncluded.DataSource as List<ItensAgendaDto>) ?? new List<ItensAgendaDto>(),
                ItensDelAgenda = (_bsExcluded.DataSource as List<ItensAgendaDto>) ?? new List<ItensAgendaDto>()
            };

            Jobs job = new Jobs();
            job.ExecutaBackup(dto);

        }

        private void txtPastaOrigem_TextChanged(object sender, EventArgs e)
        {
            // btnAddItens.Enabled = (!string.IsNullOrWhiteSpace(txtPastaOrigem.Text));
            // btnDelItens.Enabled = (!string.IsNullOrWhiteSpace(txtPastaOrigem.Text));
        }
    }
}