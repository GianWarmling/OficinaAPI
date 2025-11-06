using AutoMapper;

namespace OficinaAPI.Models.DTO
{
    public class OficinaProfile : Profile
    {
        public OficinaProfile()
        {
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<VeiculoDTO, Veiculo>();
            CreateMap<ProdutoDTO, Produto>();
            CreateMap<ServicoDTO, Servico>();
            CreateMap<OrdemServicoDTO, OrdemServico>();
        }
    }
}
