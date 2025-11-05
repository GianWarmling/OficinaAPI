namespace OficinaAPI.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public String Placa { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public int Ano { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<OrdemServico> OrdemServico { get; set; } = new List<OrdemServico>();
    }
}
