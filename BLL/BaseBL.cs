using InfoManager.Data.Models;
using InfoManager.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoManager.BLL
{
    public abstract class BaseBL
    {
        public IGenericRepository<Entity> Repository { get; protected set; }

        public BaseBL(IGenericRepository<Entity> repository)
        {
            this.Repository = repository;
        }
    }
}
