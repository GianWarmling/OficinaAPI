namespace OficinaAPI.Models.DTO
{
    public class ClienteDTO
    {
        public string Nome { get; set; } = null!;
        public string CpfCnpj { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
