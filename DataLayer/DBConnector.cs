using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class DBConnector
    {
        public static SqlConnectionStringBuilder GetBuilder()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"dbsys.cs.vsb.cz\STUDENT";
            builder.UserID = "foj0104";
            builder.Password = "AcVEMbEWQD";
            builder.InitialCatalog = "FOJ0104";
            
            return builder;
        }
    }
}
