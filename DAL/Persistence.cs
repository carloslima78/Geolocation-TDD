using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using Infra;

namespace DAL
{
    public class Persistence<T> where T : class, new()
    {
        public List<T> List( string sql)
        {
            DbConnection dbConnection = null;
            List<T> entities = new List<T>();

            try
            {
                dbConnection = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateConnection();
                dbConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Cnova"].ConnectionString;

                DbCommand command = dbConnection.CreateCommand();
                command.Connection = dbConnection;
                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.Text;

                dbConnection.Open();

                DbDataReader reader = null;

                reader = command.ExecuteReader();

                var entity = new T();

                while (reader.Read())
                {
                    entity = new T();

                    foreach (PropertyInfo property in entity.GetType().GetProperties()) 
                    {
                        var attributes = property.GetCustomAttributes(typeof(CustomAttributes), false) as CustomAttributes[];

                        if (attributes.ToList().Exists(x => x.NoMapp == true) == false)
                        {
                            if (property.PropertyType == typeof(Int32))
                                if (reader[property.Name] != DBNull.Value)
                                    property.SetValue(entity, Convert.ToInt32(reader[property.Name]), null);

                            if (property.PropertyType == typeof(String))
                                if (reader[property.Name] != DBNull.Value)
                                    property.SetValue(entity, reader[property.Name].ToString().Trim(), null);

                            if (property.PropertyType == typeof(Double))
                                if (reader[property.Name] != DBNull.Value)
                                    property.SetValue(entity, Convert.ToDouble(reader[property.Name]), null);
                        }

                    }

                    entities.Add(entity);
                }
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.Close();
            }

            return entities;
        }

        public T Get( string sql)
        {
            DbConnection dbConnection = null;
            var entity = new T();

            try
            {
                dbConnection = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateConnection();
                dbConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Cnova"].ConnectionString;

                DbCommand command = dbConnection.CreateCommand();
                command.Connection = dbConnection;
                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.Text;

                dbConnection.Open();

                DbDataReader reader = null;

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    entity = new T();

                    foreach (PropertyInfo property in entity.GetType().GetProperties())
                    {
                        var attributes = property.GetCustomAttributes(typeof(CustomAttributes), false) as CustomAttributes[];

                        if (attributes.ToList().Exists(x => x.NoMapp == true) == false)
                        {
                            if (property.PropertyType == typeof(Int32))
                                if (reader[property.Name] != DBNull.Value)
                                    property.SetValue(entity, Convert.ToInt32(reader[property.Name]), null);

                            if (property.PropertyType == typeof(String))
                                if (reader[property.Name] != DBNull.Value)
                                    property.SetValue(entity, reader[property.Name].ToString().Trim(), null);

                            if (property.PropertyType == typeof(Double))
                                if (reader[property.Name] != DBNull.Value)
                                    property.SetValue(entity, Convert.ToDouble(reader[property.Name]), null);
                        }
                    }
                }
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.Close();
            }

            return entity;
        }
    }
}
