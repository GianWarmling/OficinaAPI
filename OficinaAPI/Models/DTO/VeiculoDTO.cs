namespace OficinaAPI.Models.DTO
{
    public class VeiculoDTO
    {
        public string Placa { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public int Ano { get; set; }
        public int ClienteId { get; set; }
    }
}
