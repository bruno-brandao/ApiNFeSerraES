using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace UnclePhill.WebAPI_NFeS.API.Models
{
    public class ConnectionManager
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string ConnectionString { get; set; }

        public ConnectionManager(string Server, string Database, string Port, string User, string Password)
        {
            this.Server = Server;
            this.Database = Database;
            this.Port = Port;
            this.User = User;
            this.Password = Password;
            this.Port = Port == string.Empty ? "" : "," + Port; 
            this.ConnectionString = "Data Source=" + this.Server + this.Port + ";MultipleActiveResultSets=true;Initial Catalog=" + this.Database + ";User ID=" + this.User + ";Password=" + this.Password;
        }

        public ConnectionManager()
        {
            this.Server = "ALLEJO\\MSSQLSERVER2017";
            this.Database = "BD_NFeS";
            this.Port = "";
            this.User = "sa";
            this.Password = "M1n3Rv@7";
            this.ConnectionString = "Data Source=" + Server + ";MultipleActiveResultSets=true;Initial Catalog=" + Database + ";User ID=" + User + ";Password=" + Password;
        }
            
        public long Insert(string Query)
        {
            SqlConnection SqlConnection = new SqlConnection(this.ConnectionString);
            try
            {
                SqlConnection.Open();
                SqlCommand Command = new SqlCommand(Query, SqlConnection);
                if(Command.ExecuteNonQuery() > 0)
                {
                    Command = new SqlCommand("Select @@Identity;", SqlConnection);
                    return long.Parse(Command.ExecuteScalar().ToString());
                }
                return 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlConnection != null && SqlConnection.State == ConnectionState.Open) { SqlConnection.Close(); }
            }
        }
        
        public bool Delete(string Query)
        {
            return Execute(Query);
        }

        public bool Update(string Query)
        {
            return Execute(Query);
        }

        public bool Execute(string Query)
        {
            SqlConnection SqlConnection = new SqlConnection(this.ConnectionString);
            try
            {
                SqlConnection.Open();
                SqlCommand Command = new SqlCommand(Query, SqlConnection);                
                return Command.ExecuteNonQuery() > 0;                
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlConnection != null && SqlConnection.State == ConnectionState.Open) { SqlConnection.Close(); }
            }
        }

        public DataTable GetDataTable(string Query, string TableName)
        {
            SqlConnection SqlConnection = new SqlConnection(this.ConnectionString);
            try
            {
                SqlConnection.Open();
                DataTable Data = new DataTable(TableName);
                SqlCommand Command = new SqlCommand(Query, SqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(Command);
                adapter.Fill(Data);
                return Data;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlConnection != null && SqlConnection.State == ConnectionState.Open) { SqlConnection.Close(); }
            }            
        }
        
        public DataSet GetDataSet(string Query, string TableName)
        {
            SqlConnection SqlConnection = new SqlConnection(this.ConnectionString);
            try
            {
                SqlConnection.Open();
                DataSet Data = new DataSet(TableName);
                SqlCommand Command = new SqlCommand(Query, SqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(Command);
                adapter.Fill(Data);
                return Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlConnection != null && SqlConnection.State == ConnectionState.Closed) { SqlConnection.Close(); }
            }
        }       
    }
}