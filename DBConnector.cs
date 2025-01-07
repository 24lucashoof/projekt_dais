using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace DataLayer
{
    public class DBConnector
    {
        public static SqlConnectionStringBuilder GetBuilder()
        {
            Debug.Assert(false, "connect to DB");
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"";
            builder.UserID = "";
            builder.Password = "";
            builder.InitialCatalog = "";
            
            return builder;
        }
    }
}
