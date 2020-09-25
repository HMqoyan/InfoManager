using InfoManager.Data.Models;
using InfoManager.Data.Repositories;
using InfoManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoManager.BLL
{
    public class PersonBL : BaseBL
    {
        public PersonBL(IGenericRepository<Entity> repository) :base(repository)
        {
        }


    }
}
