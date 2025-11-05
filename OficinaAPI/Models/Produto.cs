namespace OficinaAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int QuantidadeEstoque { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
