using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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
        private string _connectionString;
        public HeroesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }
        
        private static Hero CreateHero(SqlDataReader reader)
        {
            return new Hero
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString()
            };
        }



        public async Task<IEnumerable<Hero>> GetAll(string nameFilter)
        {


            using (SqlConnection connection =
                new SqlConnection(_connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand("SearchHeroes", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("SearchTerm", SqlDbType.NVarChar, 255).Value = nameFilter;
                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                var heroes = new List<Hero>();

                while (reader.Read())
                {
                    heroes.Add(CreateHero(reader));
                }
                reader.Close();

                return heroes;
            }
        }

        public async Task<IEnumerable<Hero>> GetAll()
        {
            string queryString =
                $"SELECT * FROM Heroes";


            using (SqlConnection connection =
                new SqlConnection(_connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                
                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                var heroes = new List<Hero>();

                while (reader.Read())
                {
                    heroes.Add(CreateHero(reader));
                }
                reader.Close();

                return heroes;
            }
        }


        public async Task<Hero> GetById(int id)
        {
            string queryString =
                $"SELECT * FROM Heroes where id = @id";

            var heroes = new List<Hero>();

            using (SqlConnection connection =
                new SqlConnection(_connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                Hero hero = null;
                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    hero = CreateHero(reader);
                }
                reader.Close();

                return hero;

            }
        }
    }
}
