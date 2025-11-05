namespace OficinaAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string CpfCnpj { get; set; } = null!;
        public string Telefone { get; set; }
        public string Email { get; set; }
        public ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
    }
}
