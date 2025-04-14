using DAL_Khaoula.Entities;
using DAL_Khaoula.Mappers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Khaoula.Srvices
{
    public class CocktailService
    {
        private const string ConnexionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WAD24-DemoASP-DB;Integrated Security=True;";
        public IEnumerable<Cocktail> Get()
        {
            using (SqlConnection connexion = new SqlConnection(ConnexionString))
            {
                using (SqlCommand command = connexion.CreateCommand())
                {
                    command.CommandText = "SP_Cocktail_GetAll";
                    command.CommandType = CommandType.StoredProcedure;
                    connexion.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToCocktail();
                        }
                    }
                }
            }
        }

        public Cocktail GetById(Guid Cocktail_id)
        {
            using (SqlConnection connection = new SqlConnection(ConnexionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Cocktail_GetById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Cocktail_id), Cocktail_id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                           return reader.ToCocktail();
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(Cocktail_id));
                        }
                    }
                }
            }
        }
    }
}
