using System;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Transation.DAO
{
    public class ConexaoOracle
    {
        public static string connectionStringBanco = "";

        //  transações na execuções de instruções SQL

        public static string ExecutaInsercao(string sql, OracleTransaction transaction, bool queroID) // True retorna ID || False não retorna ID
        {
            OracleCommand comando = transaction.Connection.CreateCommand();

            OracleParameter retornaID = new OracleParameter(":c1", OracleDbType.Int32);

            string ID = "";

            if (queroID)
            {
                sql += " returning ID into :c1";
                retornaID.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add(retornaID);
            };

            comando.Transaction = transaction;

            try
            {
                comando.CommandText = sql;
                comando.ExecuteNonQuery();

                if (queroID)
                {
                    ID = retornaID.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ID;
        }
    }
}
