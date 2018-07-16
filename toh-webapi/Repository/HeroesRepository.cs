using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TOHWebApi.Model;

namespace TOHWebApi.Repository
{
    public interface IHeroesRepository
    {
        Task<IEnumerable<Hero>> GetAll(string nameFilter);
        Task<IEnumerable<Hero>> GetAll();
        Task<Hero> GetById(int id);
    }

    public class HeroesRepository : IHeroesRepository
    {
        private HeroesDbContext _dbContext;

        public HeroesRepository(HeroesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
       

        public async Task<IEnumerable<Hero>> GetAll(string nameFilter)
        {
            var query = this._dbContext.Heroes.Where(
                hero => hero.Name.ToUpper().Contains(nameFilter.ToUpper()));
            return await query.ToArrayAsync();
        }

        public async Task<IEnumerable<Hero>> GetAll()
        {
            return await this._dbContext.Heroes.ToArrayAsync();
        }


        public async Task<Hero> GetById(int id)
        {
            return await this._dbContext.Heroes.FirstOrDefaultAsync(hero => hero.Id == id);
        }
    }
}
