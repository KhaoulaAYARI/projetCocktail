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
    public class UserService: IUserRepository<User>
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WAD24-DemoASP-DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public IEnumerable<User> Get()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    {
                        command.CommandText = "SP_User_GetAllActive";
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            {
                                while (reader.Read())
                                {
                                    yield return reader.ToUser();
                                }

                            }
                        }
                    }
                }
            }
        }

        public User GetById(Guid user_id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_GetById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(user_id), user_id);/*Nous créons un paramètre qui se nomme user_id nécessaire pour notre StoredProcedure(le premier (user_id)) et utilisant l'information du GUID transmis en paramètre(le deuxieme (user_id)) à notre méthode get.*/
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToUser();
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(user_id));
                        }
                    }
                }
            }
        }
        //le cour de 28Janvier est terminé

        public Guid Insert(User user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(User.First_Name), user.First_Name);
                    command.Parameters.AddWithValue(nameof(User.Last_Name), user.Last_Name);
                    command.Parameters.AddWithValue(nameof(User.Email), user.Email);
                    command.Parameters.AddWithValue(nameof(User.Password), user.Password);
                    /*Ma procédure stockée à ces 4 paramètres, ils ont leur nom correspondant à celles définies dans la procédure stockée.
Je les appelle @first_name @last_name @email @password .Ils vont faire parallèle avec le nom du AddWithValue, première colonne nameof(User.First_Name), nameof(User.Last_Name) nameof(User.Email) nameof(User.Password).
Et ensuite, par rapport à leur valeur user.First_Name, user.Last_Name, user.Email,user.Password mais ici pas de nameof() puisque ce n'est pas le nom qu'on recherche, mais leur valeur.*/
                    //video29Janvier2025 part1(52:26) 07:01
                    connection.Open();
                    return (Guid)command.ExecuteScalar();/*ExecuteScalar return un objet donc il faut le caster*/



                }
            }
        }

        public void Update(Guid user_id, User user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_Update";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(User.First_Name), user.First_Name);
                    command.Parameters.AddWithValue(nameof(User.Last_Name), user.Last_Name);
                    command.Parameters.AddWithValue(nameof(User.Email), user.Email);
                    command.Parameters.AddWithValue(nameof(user_id), user_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }

        public void Delete(Guid user_id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_Delete";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(user_id), user_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Guid CheckPassword(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand()) 
                {
                    command.CommandText = "SP_User_CheckPassword";
                    command.CommandType= CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(email), email);
                    command.Parameters.AddWithValue(nameof(password), password);
                    connection.Open();
                    return (Guid)command.ExecuteScalar();
                }

            }
        }
    }

}