using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace ToDo.DA.Mapper.MsSql
{
    public abstract class MsSqlMapper
    {
        public IDbConnection GetConnection()
        {

            //Check for empty connection object.
            if (ConfigurationManager.ConnectionStrings["ToDoDatabase"] == null)
            { 
                //Record Connection object Null Reference Exception
            }
            //get connection string from web.config            
            string conn = ConfigurationManager.ConnectionStrings["ToDoDatabase"].ToString();

            if (conn == string.Empty)
            {                 
               //Record empty connections string Exception 
            }
            // TODO: Get connection string from the config. A valid connection string already exists in the relevant config
            return new SqlConnection(conn);
        }
    }
}
