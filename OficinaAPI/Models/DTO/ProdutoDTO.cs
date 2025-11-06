namespace OficinaAPI.Models.DTO
{
    public class ProdutoDTO
    {
        public string Nome { get; set; } = null!;
        public int QuantidadeEstoque { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
