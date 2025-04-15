using Commun.Repositories;
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
    public class CocktailService:ICocktailRepository<Cocktail>
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

        public Guid Insert(Cocktail cocktail) 
        {
            using (SqlConnection connection = new SqlConnection(ConnexionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Cocktail_Insert";
                    command.CommandType= CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Cocktail.Cocktail_id), cocktail.Cocktail_id);
                    command.Parameters.AddWithValue(nameof(Cocktail.Name), cocktail.Name);
                    command.Parameters.AddWithValue(nameof(Cocktail.Description), cocktail.Description);
                    command.Parameters.AddWithValue(nameof(Cocktail.Instructions), cocktail.Instructions);
                    connection.Open ();
                    return (Guid)command.ExecuteScalar();
                }
            }
        }
        public void Update(Guid Cocktail_id, Cocktail cocktail)
        {
            using (SqlConnection connection = new SqlConnection(ConnexionString))
            {
                using (SqlCommand command = connection.CreateCommand()) 
                {
                    command.CommandText = "SP_Cocktail_Update";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Cocktail.Cocktail_id), Cocktail_id);
                    command.Parameters.AddWithValue(nameof(Cocktail.Name), cocktail.Name);
                    command.Parameters.AddWithValue(nameof(Cocktail.Description), cocktail.Description);
                    command.Parameters.AddWithValue(nameof(Cocktail.Instructions), cocktail.Instructions);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(Guid cocktail_id) 
        {
            using (SqlConnection connection = new SqlConnection(ConnexionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Cocktail_Delete";
                    command.CommandType= CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Cocktail.Cocktail_id), cocktail_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }
        

    }
}
