using CrudProdutos.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CrudProdutos
{
    public partial class Form1 : Form
    {
        private List<Produto> produtos = new List<Produto>();

        // Controles da tela principal
        private DataGridView dgvProdutos;
        private Button btnCadastrar;
        private Button btnEditar;
        private Button btnExcluir;
        private Button btnLimpar;

        public Form1()
        {
            InitializeComponent();
            ConfigurarFormularioPrincipal();
            CarregarDadosExemplo();
        }

        private void ConfigurarFormularioPrincipal()
        {
            this.Text = "CRUD de Produtos - Análise Orientada a Objetos";
            this.Size = new Size(960, 680);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            // ==================== GRID ====================
            dgvProdutos = new DataGridView 
            { 
                Location = new Point(20, 20),
                Size = new Size(910, 480),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
                Font = new Font("Segoe UI", 10),
                AllowUserToAddRows = false,
                BackgroundColor = Color.White
            };

            // ==================== BOTÕES ====================
            int y = 520;
            btnCadastrar = new Button { Text = "📌 Cadastrar", Location = new Point(20, y), Size = new Size(140, 50), Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            btnEditar    = new Button { Text = "✏️ Editar",    Location = new Point(170, y), Size = new Size(140, 50), Font = new Font("Segoe UI", 10) };
            btnExcluir   = new Button { Text = "🗑️ Excluir",   Location = new Point(320, y), Size = new Size(140, 50), Font = new Font("Segoe UI", 10) };
            btnLimpar    = new Button { Text = "🧹 Limpar",    Location = new Point(470, y), Size = new Size(140, 50), Font = new Font("Segoe UI", 10) };

            // Adiciona na tela
            this.Controls.Add(dgvProdutos);
            this.Controls.Add(btnCadastrar);
            this.Controls.Add(btnEditar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnLimpar);

            // Eventos
            btnCadastrar.Click += btnCadastrar_Click;
            btnEditar.Click    += btnEditar_Click;
            btnExcluir.Click   += btnExcluir_Click;
            btnLimpar.Click    += (s, e) => dgvProdutos.ClearSelection();

            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            dgvProdutos.Columns.Clear();
            dgvProdutos.Columns.Add("Codigo", "Código");
            dgvProdutos.Columns.Add("Nome", "Nome");
            dgvProdutos.Columns.Add("Descricao", "Descrição");
        }

        private void CarregarDadosExemplo()
        {
            produtos.Add(new Produto("RES330", "Resistor 330Ω 1/4W", "Resistor de carbono para circuitos"));
            produtos.Add(new Produto("CAP100", "Capacitor 100uF 25V", "Capacitor eletrolítico"));
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            dgvProdutos.Rows.Clear();
            foreach (var p in produtos)
            {
                dgvProdutos.Rows.Add(p.Codigo, p.Nome, p.Descricao);
            }
        }

        // ==================== AÇÕES ====================

        private void btnCadastrar_Click(object? sender, EventArgs e)
        {
            using var frm = new FrmCadastroProduto();
            if (frm.ShowDialog(this) == DialogResult.OK && frm.Produto != null)
            {
                produtos.Add(frm.Produto);
                AtualizarGrid();
                MessageBox.Show("✅ Produto cadastrado com sucesso!", "Sucesso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow == null)
            {
                MessageBox.Show("Selecione um produto para editar.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var codigo = dgvProdutos.CurrentRow.Cells[0].Value?.ToString();
            var produto = produtos.FirstOrDefault(p => p.Codigo == codigo);

            if (produto != null)
            {
                using var frm = new FrmCadastroProduto(produto);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    AtualizarGrid();
                    MessageBox.Show("✅ Produto atualizado com sucesso!", "Sucesso");
                }
            }
        }

        private void btnExcluir_Click(object? sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow == null)
            {
                MessageBox.Show("Selecione um produto para excluir.", "Atenção");
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir este produto?", "Confirmar", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var codigo = dgvProdutos.CurrentRow.Cells[0].Value?.ToString();
                var produto = produtos.FirstOrDefault(p => p.Codigo == codigo);

                if (produto != null)
                {
                    produtos.Remove(produto);
                    AtualizarGrid();
                    MessageBox.Show("Produto excluído com sucesso!");
                }
            }
        }
    }
}