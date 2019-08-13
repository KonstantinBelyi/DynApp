using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Dyna.Models
{
    public class HomeCollection
    {
        public static List<Home> ErrorLog
        {
            get
            {
                return GetErrorLog();
            }
            
        }

        private static List<Home> GetErrorLog()
        {
            OracleDB oracle = new OracleDB();
            //oracle.OpenConnect();

            List<Home> result = new List<Home>();
            try
            {
                using (OracleCommand command = new OracleCommand("select e.err_id, e.err_name from error_log e", oracle.Connect))
                {
                    OracleDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        //for (int i = 0; i < reader.FieldCount; i++)
                        //{
                        result.Add(new Home()
                        {
                            id = reader.GetInt32(0),
                            name = reader.GetString(1)
                        });
                        //}
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            

            oracle.CloseConnect();

            return result;
        }
    }
}