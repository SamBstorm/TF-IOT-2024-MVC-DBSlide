using Common_DBSlide.Repositories;
using DAL_DBSlide.Entities;
using DAL_DBSlide.Mappers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DAL_DBSlide.Services
{
    public class SectionService : BaseService, ISectionRepository<Section>
    {

        private readonly DbProviderFactory _factory = SqlClientFactory.Instance;
        public SectionService(IConfiguration config) : base(config, "DBSlide")
        {
        }

        public void Delete(int id)
        {
            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM section WHERE section_id = @id";
                    #region Parameters
                    DbParameter p_id = command.CreateParameter();
                    p_id.Value = id;
                    p_id.ParameterName = "id";
                    command.Parameters.Add(p_id);
                    #endregion
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Section> Get()
        {
            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM section";
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToSection();
                        }
                    }
                }
            }
        }

        public Section Get(int id)
        {
            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM section WHERE section_id = @id";
                    DbParameter p_id = command.CreateParameter();
                    p_id.Value = id;
                    p_id.ParameterName = "id";
                    command.Parameters.Add(p_id);
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToSection();
                        }
                        throw new ArgumentOutOfRangeException(nameof(id), "Identifiant non-valide");
                    }
                }
            }
        }

        public int Insert(Section entity)
        {
            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO section (section_id, section_name, delegate_id) OUTPUT inserted.section_id VALUES (@section_id, @section_name, @delegate_id)";
                    #region Parameters
                    DbParameter p_id = command.CreateParameter();
                    p_id.Value = entity.Section_id;
                    p_id.ParameterName = "section_id";
                    command.Parameters.Add(p_id);
                    DbParameter p_sn = command.CreateParameter();
                    p_sn.Value = entity.Section_name;
                    p_sn.ParameterName = "section_name";
                    command.Parameters.Add(p_sn);
                    DbParameter p_did = command.CreateParameter();
                    p_did.Value = (object?)entity.Delegate_id ?? DBNull.Value;
                    p_did.ParameterName = "delegate_id";
                    command.Parameters.Add(p_did);
                    #endregion
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(int id, Section entity)
        {
            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE section SET section_name = @section_name, delegate_id = @delegate_id WHERE section_id = @section_id";
                    #region Parameters
                    DbParameter p_id = command.CreateParameter();
                    p_id.Value = id;
                    p_id.ParameterName = "section_id";
                    command.Parameters.Add(p_id);
                    DbParameter p_sn = command.CreateParameter();
                    p_sn.Value = entity.Section_name;
                    p_sn.ParameterName = "section_name";
                    command.Parameters.Add(p_sn);
                    DbParameter p_did = command.CreateParameter();
                    p_did.Value = (object?)entity.Delegate_id ?? DBNull.Value;
                    p_did.ParameterName = "delegate_id";
                    command.Parameters.Add(p_did);
                    #endregion
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
