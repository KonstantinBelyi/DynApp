using Dyna.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Collections.Generic;

namespace Dyna.Areas.Analitic.Models.Marking
{
    public class ExecuteMarking
    {
        public static object DropDraft()
        {
            object count;
            string query = "dyna.marking.drop_draft";
            OracleDB oracle = null;
            try
            {
                oracle = new OracleDB();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = oracle.Connect;
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("v_count", OracleDbType.Int32);
                    command.Parameters["v_count"].Direction = ParameterDirection.ReturnValue;
                    command.ExecuteNonQuery();

                    count = command.Parameters["v_count"].Value;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (oracle != null) oracle.CloseConnect();                     
            }

            return count;
        }
        public static object SetDraft()
        {
            object count;
            string query = "dyna.marking.draft";
            OracleDB oracle = null;

            try
            {
                oracle = new OracleDB();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = oracle.Connect;
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("v_count", OracleDbType.Int32);
                    command.Parameters["v_count"].Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    count = command.Parameters["v_count"].Value;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if(oracle != null) oracle.CloseConnect();
            }
            return count;
        }
        public static List<DraftPins> GetDealWithDraft()
        {
            string query = "dyna.marking.get_with_draft";
            OracleDB oracle = null;

            List<DraftPins> result = new List<DraftPins>();

            try
            {
                oracle = new OracleDB();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = oracle.Connect;
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("cur_draft", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    OracleDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        result.Add(new DraftPins()
                        {
                            Count = reader.GetString(0),//.GetInt32(0).ToString(),//GetString(0),
                            Reestr = reader.GetString(1),
                            Draft = reader.GetString(2)
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (oracle != null) oracle.CloseConnect();
            }

            return result;
        }
        public static List<CleanPins> GetDealWithoutDraft()
        {
            string query = "dyna.marking.get_without_draft";

            OracleDB oracle = null;

            List<CleanPins> result = new List<CleanPins>();

            try
            {
                oracle = new OracleDB();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = oracle.Connect;
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;

                    //command.Parameters.Add("p_pin", OracleDbType.Varchar2, 32767).Value = incomingPins;
                    command.Parameters.Add("cur_draft", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    OracleDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(new CleanPins()
                        {
                            Count = reader.GetString(0),//.GetInt32(0).ToString(), //
                            Reestr = reader.GetString(1),
                            Draft = reader.GetString(2)

                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (oracle != null) oracle.CloseConnect();
            }

            return result;
        }
        public static void SetIncomingPins(string incomingPins)
        {
            string query = "dyna.marking.set_incoming_pins";

            OracleDB oracle = null;

            try
            {
                oracle = new OracleDB();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = oracle.Connect;
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;
                    //OracleParameter param = new OracleParameter();
                    
                    command.Parameters.Add("v_incoming_pins", OracleDbType.Varchar2, 32767).Value = incomingPins;                  
                    
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (oracle != null) oracle.CloseConnect();
            }
        }
        public static void SetIncomingPins(string[] incomingPins)
        {
            string query = "dyna.marking.set_incoming_pins";

            OracleDB oracle = null;

            try
            {
                oracle = new OracleDB();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = oracle.Connect;
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;

                    OracleParameter param = new OracleParameter();
                    param.OracleDbType = OracleDbType.Varchar2;
                    param.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    param.Value = incomingPins;

                    command.Parameters.Add(param);                  

                    command.ExecuteNonQuery();                                      
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (oracle != null) oracle.CloseConnect();
            }
        }
        public static void SetNullVariables()
        {
            string query = "dyna.marking.set_null_variables";

            OracleDB oracle = null;

            try
            {
                oracle = new OracleDB();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = oracle.Connect;
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (oracle != null) oracle.CloseConnect();
            }
        }

        //public static object Test(string incomingPins)
        //{
        //    string count = "";
        //    string query = "dyna.marking.test";
        //    OracleDB oracle = new OracleDB();

        //    try
        //    {
        //        using (OracleCommand command = new OracleCommand())
        //        {
        //            command.Connection = oracle.connect;
        //            command.CommandText = query;
        //            command.CommandType = CommandType.StoredProcedure;

        //            command.Parameters.Add("p_par", OracleDbType.Varchar2, 999).Value = incomingPins;
        //            //command.Parameters["p_par"].Direction = ParameterDirection.Input;

        //            command.Parameters.Add("d_select", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.ReturnValue;
        //            //command.Parameters["d_select"].Direction = ParameterDirection.ReturnValue;


        //            command.ExecuteNonQuery();

        //            count = Convert.ToString(command.Parameters["d_select"].Value);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        oracle.CloseConnect();
        //    }

        //    return count;
        //}
    }
}