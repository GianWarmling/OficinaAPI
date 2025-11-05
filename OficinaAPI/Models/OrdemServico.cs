namespace OficinaAPI.Models
{
    public class OrdemServico
    {
        public int Id { get; set; }
        public DateTime DataAbertura { get; set; } = DateTime.Now;
        public DateTime? DataFechamento { get; set; }
        public string Status { get; set; } = "Aberta";
        public decimal ValorTotal { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        public ICollection<OrdemServicoServico> Servicos { get; set; } = new List<OrdemServicoServico>();
        public ICollection<OrdemServicoProduto> Produtos { get; set; } = new List<OrdemServicoProduto>();
    }

    public class OrdemServicoServico
    {
        public int OrdemServicoId { get; set; }
        public OrdemServico OrdemServico { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
        public decimal ValorCobrado { get; set; }
    }

    public class OrdemServicoProduto
    {
        public int OrdemServicoId { get; set; }
        public OrdemServico OrdemServico { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int QuantidadeUsada { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
