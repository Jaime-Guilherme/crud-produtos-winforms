using CrudProdutos.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CrudProdutos
{
    public partial class FrmCadastroProduto : Form
    {
        public Produto? Produto { get; private set; }

        private TextBox txtCodigo, txtNome, txtDescricao;
        private Button btnSalvar, btnCancelar;

        // Construtor para CADASTRAR novo produto
        public FrmCadastroProduto()
        {
            InitializeModalForm();
            this.Text = "📌 Cadastrar Novo Produto";
            txtCodigo.ReadOnly = false;
        }

        // Construtor para EDITAR produto existente
        public FrmCadastroProduto(Produto produto) : this()
        {
            this.Text = "✏️ Editar Produto";
            txtCodigo.ReadOnly = true;           // Código não deve mudar
            txtCodigo.Text = produto.Codigo;
            txtNome.Text = produto.Nome;
            txtDescricao.Text = produto.Descricao ?? "";

            Produto = produto;
        }

        private void InitializeModalForm()
        {
            this.Size = new Size(520, 420);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // ==================== CAMPOS ====================

            // Código
            var lblCodigo = new Label { Text = "Código:", Location = new Point(30, 30), AutoSize = true };
            txtCodigo = new TextBox { Location = new Point(30, 55), Size = new Size(180, 28), Font = new Font("Segoe UI", 10) };

            // Nome
            var lblNome = new Label { Text = "Nome do Item:", Location = new Point(30, 100), AutoSize = true };
            txtNome = new TextBox { Location = new Point(30, 125), Size = new Size(440, 28), Font = new Font("Segoe UI", 10) };

            // Descrição
            var lblDescricao = new Label { Text = "Descrição:", Location = new Point(30, 170), AutoSize = true };
            txtDescricao = new TextBox 
            { 
                Location = new Point(30, 195), 
                Size = new Size(440, 120), 
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Segoe UI", 10)
            };

            // ==================== BOTÕES ====================
            btnSalvar = new Button 
            { 
                Text = "💾 Salvar", 
                Location = new Point(250, 340), 
                Size = new Size(110, 40),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            btnCancelar = new Button 
            { 
                Text = "❌ Cancelar", 
                Location = new Point(370, 340), 
                Size = new Size(110, 40),
                Font = new Font("Segoe UI", 10)
            };

            // Adiciona os controles
            this.Controls.Add(lblCodigo);
            this.Controls.Add(txtCodigo);
            this.Controls.Add(lblNome);
            this.Controls.Add(txtNome);
            this.Controls.Add(lblDescricao);
            this.Controls.Add(txtDescricao);
            this.Controls.Add(btnSalvar);
            this.Controls.Add(btnCancelar);

            // Eventos
            btnSalvar.Click += BtnSalvar_Click;
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private void BtnSalvar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Código e Nome são obrigatórios!", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Produto == null) // Novo cadastro
            {
                Produto = new Produto(
                    txtCodigo.Text.Trim().ToUpper(),
                    txtNome.Text.Trim(),
                    txtDescricao.Text.Trim()
                );
            }
            else // Edição
            {
                Produto.Atualizar(txtNome.Text.Trim(), txtDescricao.Text.Trim());
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}