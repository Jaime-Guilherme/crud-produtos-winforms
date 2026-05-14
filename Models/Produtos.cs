namespace CrudProdutos.Models
{
    public class Produto
    {
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }

        public Produto(string codigo, string nome, string? descricao = null)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("Código é obrigatório.");
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório.");

            Codigo = codigo.ToUpper().Trim();
            Nome = nome.Trim();
            Descricao = string.IsNullOrWhiteSpace(descricao) ? null : descricao.Trim();
        }

        public void Atualizar(string nome, string? descricao)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório.");
            
            Nome = nome.Trim();
            Descricao = string.IsNullOrWhiteSpace(descricao) ? null : descricao.Trim();
        }

        public override string ToString() => $"{Codigo} - {Nome}";
    }
}