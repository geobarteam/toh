using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TOHWebApi.Model;

namespace TOHWebApi.Repository
{
    public interface IHeroesRepository
    {
        IEnumerable<Heroe> GetAll(string filter);
    }

    public class HeroesRepository : IHeroesRepository
    {
        private string _connectionString;
        public HeroesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public IEnumerable<Heroe> GetAll(string filter)
        {

            string queryString =
                $"SELECT * FROM Heroes";

            if (filter !=null)
            {
                queryString += $" Where {filter}";
            }

            var heroes = new List<Heroe>();

            using (SqlConnection connection =
                new SqlConnection(_connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    heroes.Add(new Heroe
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString()
                    });
                }
                reader.Close();

                return heroes;

            }

        }
    }
}
