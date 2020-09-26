using AutoMapper;
using InfoManager.Data.Models;
using InfoManager.Data.Repositories;
using InfoManager.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoManager.BLL
{
    public class PersonBL : BaseBL
    {
        private IGenericRepository<Person> _repository;
        private IMapper _mapper;

        public PersonBL(IGenericRepository<Person> repository, IMapper mapper)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        public async Task<PersonViewModel> GetPersonFullModel(int id)
        {
            return await this.GetFullModel(id);
        }

        public async Task<List<PersonViewModel>> GetPeopleFullModel()
        {
            var people = new List<PersonViewModel>();
            var ids = this._repository.ListAsync().Result.Select(r => r.Id);

            foreach (var id in ids)
            {
                var person = await this.GetFullModel(id);
                if (!(person is null))
                {
                    people.Add(person);
                }
            }

            return people;
        }

        private async Task<PersonViewModel> GetFullModel(int id)
        {
            var person = await this._repository.GetByIdAsync(id);

            if (person is null)
            {
                return null;
            }

            var personViewModel = this._mapper.Map<Person, PersonViewModel>(person);

            if (person.FatherId > 0)
            {
                var father = await this._repository.GetByIdAsync(person.FatherId);
                personViewModel.Father = this._mapper.Map<Person, PersonViewModel>(father);
            }
            if (person.MotherId > 0)
            {
                var mother = await this._repository.GetByIdAsync(person.FatherId);
                personViewModel.Mother = this._mapper.Map<Person, PersonViewModel>(mother);
            }

            return personViewModel;
        }
    }
}
