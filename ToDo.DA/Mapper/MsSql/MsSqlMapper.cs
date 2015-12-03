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
            return new SqlConnection(ConfigurationManager.ConnectionStrings["ToDoDatabase"].ToString());
        }
    }
}
