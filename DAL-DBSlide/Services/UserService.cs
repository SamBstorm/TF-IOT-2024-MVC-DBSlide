using Common_DBSlide.Repositories;
using DAL_DBSlide.Entities;
using DAL_DBSlide.Mappers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DAL_DBSlide.Services
{
    public class UserService : BaseService, IUserRepository<User,string>
    {
        private readonly DbProviderFactory _factory = SqlClientFactory.Instance;
        public UserService(IConfiguration config) : base(config, "DBUser")
        {
        }

        public Guid? CheckPassword(string email, string password)
        {
            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_CheckPassword";
                    command.CommandType = CommandType.StoredProcedure;
                    DbParameter p_email = command.CreateParameter();
                    p_email.ParameterName = "email";
                    p_email.Value = email;
                    command.Parameters.Add(p_email);
                    DbParameter p_pwd = command.CreateParameter();
                    p_pwd.ParameterName = "password";
                    p_pwd.Value = password;
                    command.Parameters.Add(p_pwd);
                    return (Guid?)command.ExecuteScalar();
                }
            }
        }

        public void ClearRole(Guid id)
        {
            throw new NotImplementedException();
        }

        public User Get(Guid id)
        {
            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT User_Id, Email, '********' AS Password, First_Name, Last_Name FROM [User] WHERE User_Id = @id";
                    DbParameter p_id = command.CreateParameter();
                    p_id.ParameterName = "id";
                    p_id.Value = id;
                    command.Parameters.Add(p_id);
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToUser();
                        }
                        throw new ArgumentOutOfRangeException(nameof(id), "Aucune valeur pour cet identifiant.");
                    }
                }
            }
        }

        public IEnumerable<string> GetRoles(Guid id)
        {
            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [role] FROM [User_Role] WHERE [User_Id] = @user_id";
                    DbParameter p_id = command.CreateParameter();
                    p_id.ParameterName = "user_id";
                    p_id.Value = id;
                    command.Parameters.Add(p_id);
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader["Role"].ToString();
                        }
                    }
                }
            }
        }

        public Guid Insert(User user)
        {
            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    DbParameter p_email = command.CreateParameter();
                    p_email.ParameterName = "email";
                    p_email.Value = user.Email;
                    command.Parameters.Add(p_email);
                    DbParameter p_pwd = command.CreateParameter();
                    p_pwd.ParameterName = "password";
                    p_pwd.Value = user.Password;
                    command.Parameters.Add(p_pwd);
                    DbParameter p_fn = command.CreateParameter();
                    p_fn.ParameterName = "first_name";
                    p_fn.Value = user.First_Name;
                    command.Parameters.Add(p_fn);
                    DbParameter p_ln = command.CreateParameter();
                    p_ln.ParameterName = "last_name";
                    p_ln.Value = user.Last_Name;
                    command.Parameters.Add(p_ln);
                    return (Guid)command.ExecuteScalar();
                }
            }
        }

        public void SetAdmin(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SetAutor(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SetModerator(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
