using AutoMapper;
using InfoManager.Data.Models;

namespace InfoManager.ViewModels
{
    public class PersonProfile : Profile
    {
        public const string ViewModel = "PersonProfile";

        public override string ProfileName => ViewModel;

        public PersonProfile()
        {
            this.CreateMap<Person, PersonViewModel>()
                .ForMember(p => p.Name, src => src.MapFrom(i => $"{i.FirstName} {i.LastName}"));
        }


    }
}
