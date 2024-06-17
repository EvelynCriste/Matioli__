using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Dados;
using Negocio;

namespace Apresentacao
{
    public partial class frmFornecedor : Form
    {
        private readonly FornecedorService fornecedorService;
        private DataTable tblFornecedor = new DataTable();

        //sinaliza qual operação está em andamento
        //0 = nada
        //1 = inclusão (novo)
        //2 = alteração
        private int modo = 0; //sinaliza qual operação está em andamento
        public frmFornecedor()
        {
            InitializeComponent();
            _fornecedor = new FornecedorService();

            dgFornecedor.Columns.Add("Id", "ID");
            dgFornecedor.Columns.Add("Nome", "NOME");
            dgFornecedor.Columns.Add("tipoPesso", "TIPO PESSOA");
            dgFornecedor.Columns.Add("email", "EMAIL");

            dgFornecedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgFornecedor.AllowUserToAddRows = false;
            dgFornecedor.AllowUserToDeleteRows = false;
            dgFornecedor.AllowUserToOrderColumns = true;
            dgFornecedor.ReadOnly = true;

            tblFornecedor = _fornecedorService.getAll();
        }

        private void Habilita()
        {
            switch (modo)
            {
                case 0: //neutro
                    btnInclui.Enabled = true;
                    btnAltera.Enabled = true;
                    btnExclui.Enabled = true;
                    btnSalva.Enabled = false;
                    btnCancela.Enabled = false;
                    grpDados.Enabled = false;
                    dgFornecedor.Enabled = true;
                    break;
                case 1: //inclusão
                    btnInclui.Enabled = false;
                    btnAltera.Enabled = false;
                    btnExclui.Enabled = false;
                    btnSalva.Enabled = true;
                    btnCancela.Enabled = true;
                    grpDados.Enabled = true;
                    dgFornecedor.Enabled = false;
                    break;
                case 2:
                    btnInclui.Enabled = false;
                    btnAltera.Enabled = false;
                    btnExclui.Enabled = false;
                    btnSalva.Enabled = true;
                    btnCancela.Enabled = true;
                    grpDados.Enabled = true;
                    dgFornecedor.Enabled = false;
                    break;
             }

        }

        public void LimpaForm()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtId.Clear();
            radioPessoaFisica.Checked = false;
            radioPessoaJuridica.Checked = false;

            txtNome.Focus();
        }


        private void frmFornecedor_load(object sender, System.EventArgs e)
        {
            radioPessoaFisica.Text = TipoFornecedor.PESSOA_FISICA.ToString();
            radioPessoaJuridica.Text = TipoFornecedor.PESSOA_JURIDICA.ToString();

            // NOVO ====================
            dgFornecedor.ColumnCount = 4;
            dgFornecedor.AutoGenerateColumns = false;
            dgFornecedor.Columns[0].Width = 20;
            dgFornecedor.Columns[0].HeaderText = "ID";
            dgFornecedor.Columns[0].DataPropertyName = "Id";
            //dgCliente.Columns[0].Visible = false;
            dgFornecedor.Columns[1].Width = 275;
            dgFornecedor.Columns[1].HeaderText = "NOME";
            dgFornecedor.Columns[1].DataPropertyName = "Nome";
            dgFornecedor.Columns[2].Width = 300;
            dgFornecedor.Columns[2].HeaderText = "EMAIL";
            dgFornecedor.Columns[2].DataPropertyName = "email";
            dgFornecedor.Columns[3].Width = 100;
            dgFornecedor.Columns[3].HeaderText = "TIPO";
            dgFornecedor.Columns[3].DataPropertyName = "tipoPessoa";

            dgFornecedor.AllowUserToAddRows = false;
            dgFornecedor.AllowUserToDeleteRows = false;
            dgFornecedor.MultiSelect = false;
            dgFornecedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            carregaGridView();

        }

        private void carregaGridView()
        {
            dgFornecedor.DataSource = _fornecedorService.getAll();
            dgFornecedor.Refresh();
        }

        private void dgCliente_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView row = (DataGridView)sender;
            if (row.CurrentRow == null)
                return;

            //limpa os TextBoxes
            txtId.Text = dgFornecedor.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgFornecedor.CurrentRow.Cells[1].Value.ToString();
            txtEmail.Text = dgFornecedor.CurrentRow.Cells[2].Value.ToString();
            if (dgFornecedor.CurrentRow.Cells[3].Value.ToString() == ((int)TipoPessoa.PESSOA_FISICA).ToString())
                radioPessoaFisica.Checked = true;
            else
                radioPessoaJuridica.Checked = true;
        }

        private void btnAltera_Click(object sender, EventArgs e)
        {
            modo = 2;
            Habilita();
        }

        private void btnInclui_Click(object sender, EventArgs e)
        {
            modo = 1;
            Habilita();
            LimpaForm();
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            int id=0;
            string nome;
            string email;
            string resultado;
            string msg;
            int regAtual = 0;

            if (String.IsNullOrEmpty(txtId.Text))
                id = -1;
            else
                id = Convert.ToInt32(txtId.Text);

            nome = txtNome.Text;
            email = txtEmail.Text;

            TipoPessoa tp = radioPessoaFisica.Checked ? TipoPessoa.PESSOA_FISICA : TipoPessoa.PESSOA_JURIDICA;

            if (modo == 1)
            {
                resultado = _clienteService.Update(null, tp, nome, email);
                if (resultado == "SUCESSO")
                {
                    msg = "CLIENTE cadastrado com sucesso!";
                    carregaGridView();
                }
                else
                {
                    msg = "Falha ao cadastrar PRODUTO!";
                }
                MessageBox.Show(msg, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (modo == 2)
            {
                resultado = _clienteService.Update(id, tp, nome, email);
                if (resultado == "SUCESSO")
                {
                    msg = "CLIENTE atualizado com sucesso!";
                    carregaGridView();
                 }
                else
                {
                    msg = "Falha ao atualizar CLIENTE!";
                }
                MessageBox.Show(msg, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            modo = 0;
            Habilita();

        }

        private void btnExclui_Click(object sender, EventArgs e)
        {
            string resultado;
            String msg;
            DialogResult resposta;
            resposta = MessageBox.Show("Confirma exclusão?", "Aviso do sistema!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resposta == DialogResult.OK)
            {
                int idCliente = Convert.ToInt32(txtId.Text);
                resultado = _clienteService.Remove(idCliente);
                if (resultado == "SUCESSO")
                {
                    msg = "CLIENTE excluido com sucesso!";
                    carregaGridView();
                }
                else
                {
                    msg = "Falha ao excluir CLIENTE!";
                }
                MessageBox.Show(msg, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            modo = 0;
            Habilita();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            frmPrompt f = new frmPrompt();
            string txtBusca = "";
            f.ShowDialog();
            txtBusca = f.Texto;
            DataTable tbFornecedor = _fornecedorService.filterByName(txtBusca);
            if(tbFornecedor!=null)
            {
                dgFornecedor.DataSource = tbFornecedor;
                dgFornecedor.Refresh();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void frmFornecedor_Load(object sender, EventArgs e)
        {

        }

        private void dgFornecedor_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView row = (DataGridView)sender;
            if (row.CurrentRow == null)
                return;

            //limpa os TextBoxes
            txtId.Text = dgFornecedor.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgFornecedor.CurrentRow.Cells[1].Value.ToString();
            txtEmail.Text = dgFornecedor.CurrentRow.Cells[2].Value.ToString();
            if (dgFornecedor.CurrentRow.Cells[3].Value.ToString() == ((int)TipoFornecedor.PESSOA_FISICA).ToString())
                radioPessoaFisica.Checked = true;
            else
                radioPessoaJuridica.Checked = true;
        }
    }
}
