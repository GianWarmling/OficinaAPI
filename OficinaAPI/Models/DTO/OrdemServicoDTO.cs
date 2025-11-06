namespace OficinaAPI.Models.DTO
{
    public class OrdemServicoDTO
    {
        public int ClienteId { get; set; }
        public int VeiculoId { get; set; }
        public List<int> ServicosIds { get; set; }
        public List<int> ProdutosIds { get; set; }
    }
}
