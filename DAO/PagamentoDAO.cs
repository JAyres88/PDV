using Model;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace DAO
{
    public class PagamentoDAO: Conexao
    {
        MySqlDataAdapter da = new MySqlDataAdapter();
    

        public string gravaPagamentos(List<PagamentoModel> pagamentoAux, VendaModel vendaAux)
        {
            try
            {
                abrirConexao();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("sp_pagamento_novo_pagamento", Con);                
                cmd.CommandType = CommandType.StoredProcedure;
     
                foreach (var item in pagamentoAux)
                {
                    if (item.ValorPagamento > 0)
                    {
                        cmd.Parameters.AddWithValue("id_regfinanceiro", vendaAux.NroDoc);                   
                        cmd.Parameters.AddWithValue("id_tipopagamento", item.TipoPagamento);
                        cmd.Parameters.AddWithValue("valor", item.ValorPagamento);
                        cmd.Parameters.AddWithValue("observacao", item.Observacao);
                        cmd.Parameters.AddWithValue("terceiro", item.Terceiro);
                        cmd.Parameters.AddWithValue("usuario", AppStatic.Nome);                    
                        cmd.ExecuteNonQuery();
                       
                    }                 
                }
                return "Pagamento gravado.";
            }
            catch (MySqlException ex)
            {
                throw ex;                
            }
            finally
            {
                fecharConexao();
            }
        }       
    }
}
