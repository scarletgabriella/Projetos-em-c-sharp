using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Web.UI;
using Transaction.DAO;

namespace Transaction.Views
{
    public partial class transaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Transaction();
        }

        private void Transaction()
        {
            string stringConnection = ConexaoOracle.connectionStringBanco;
            OracleConnection con = new OracleConnection(stringConnection);

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            
            OracleTransaction transaction;
            transaction = con.BeginTransaction(IsolationLevel.ReadCommitted); // 1° inicia a transação

            try
            {
                ConexaoOracle.ExecutaInsercao($"INSERT INTO nome_da_tabela VALUES(' ')", transaction, false);
                
                transaction.Commit(); // 2° efetiva a transação 
                
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert_msg","alert('Inserido com sucesso.');", true);  

            }
            catch (Exception)
            {
              
                transaction.Rollback(); // 3° cancela a transação

                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert_msg", "alert('Falha.');", true);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        
    }
}
