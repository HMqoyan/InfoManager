using AutoMapper;
using InfoManager.Data.Models;
using InfoManager.Data.Repositories;

namespace InfoManager.ViewModels
{
    public class PersonProfile : Profile
    {
        public const string ViewModel = "PersonProfile";

        public override string ProfileName => ViewModel;

        public PersonProfile(IGenericRepository<Person> repository)
        {
            var t = new PersonViewModel();
            this.CreateMap<Person, PersonViewModel>()
                .ForMember(p => p.Name, src => src.MapFrom(i => $"{i.FirstName} {i.LastName}"));
           
            //.ForMember(p => p.Father, src => src.MapFrom(i => i.FatherId > 0 ? repository.GetByIdAsync(i.Id).Result : null))
            //.ForMember(p => p.Mother, src => src.MapFrom(i => i.MotherId > 0 ? repository.GetByIdAsync(i.Id).Result : null));
        }
    }
}
