using AutoMapper;
using AutomapperApi.Models;

namespace AutomapperApi.AutoMapperConfig
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapperConfig : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public AutoMapperConfig()
        {
            CreateMap<Person, Pessoa>()
                // Name to Nome
                .ForMember(pessoa => pessoa.Nome, map => map.MapFrom(person => person.Name))
                // BirthDate to DataNascimento
                .ForMember(pessoa => pessoa.DataNascimento, map => map.MapFrom(person => person.BirthDate))
                // Address to Endereco
                .ForMember(pessoa => pessoa.Endereco, map => map.MapFrom(person => person.Address))
                .ReverseMap();
        }

    }
}
