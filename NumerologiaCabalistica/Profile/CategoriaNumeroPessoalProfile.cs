namespace NumerologiaCabalistica.Profile;
using AutoMapper;
using NumerologiaCabalistica.Data.DTO.Categoria;
using NumerologiaCabalistica.Models.TextosNumericos;

public class CategoriaNumeroPessoalProfile : Profile
{
	public CategoriaNumeroPessoalProfile()
	{
		CreateMap<CreateCategoriaDTO, CategoriaNumeroPessoalModel>();
		CreateMap<UpdateCategoriaDTO, CategoriaNumeroPessoalModel>();
		CreateMap<CategoriaNumeroPessoalModel, UpdateCategoriaDTO>();
		CreateMap<CategoriaNumeroPessoalModel, ReadCategoriaDTO>();
    }
}
