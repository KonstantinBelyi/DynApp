using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Dyna.Models
{
    public class OracleDB
    {
        public OracleConnection Connect { get; }
        public static string ConnectString { get; set; }
        public OracleDB()
        {
            try
            {
                Connect = new OracleConnection
                {
                    ConnectionString = ConnectString
                };
                Connect.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void CloseConnect()
        {
            Connect.Close();
            Connect.Dispose();
        }
    }
}