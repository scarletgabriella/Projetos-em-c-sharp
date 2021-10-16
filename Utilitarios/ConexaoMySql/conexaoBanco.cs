using MySql.Data.MySqlClient;
using System;
using System.Data;
namespace ConexaoMySql
{
    class conexaoBanco
    {
        // info do banco
        static string connectionString = "datasource=;port=;username=;password=;database=dindindb;SslMode=none";
        static MySqlConnection conn = new MySqlConnection(connectionString);

        static public int? executaComando(string sql, bool queroID)
        {
            MySqlTransaction transaction = null;
            transaction = conn.BeginTransaction();

            int ID = 0;

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();

                if (queroID)
                {
                    cmd.Parameters.Add(new MySqlParameter("ultimoId", cmd.LastInsertedId));
                    ID = Convert.ToInt32(cmd.Parameters["@ultimoId"].Value);
                    return ID;
                }

                transaction.Commit();
            }
            catch (System.Exception ex)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return null;
        }

        static public DataTable retornaDados(string sql)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (System.Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
