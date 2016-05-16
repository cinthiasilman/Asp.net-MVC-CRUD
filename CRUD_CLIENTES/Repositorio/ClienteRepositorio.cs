using CRUD_CLIENTES.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD_CLIENTES.Repositorio
{
    public class ClienteRepositorio //métodos de conexão
    {
        private SqlConnection _con;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            _con = new SqlConnection(constr); //instancia a conexão
        }

        //Adicionar um cliente
        public bool AdicionarCliente(Cliente clienteObj)
        {
            Connection();
            int i;
            using (SqlCommand command = new SqlCommand("IncluirCliente", _con)) //cria um command
            {
                command.CommandType = CommandType.StoredProcedure; //chama a procedure
                command.Parameters.AddWithValue("@NOME", clienteObj.NOME);
                command.Parameters.AddWithValue("@IDADE", clienteObj.IDADE);
                command.Parameters.AddWithValue("@ENDERECO", clienteObj.ENDERECO);
                command.Parameters.AddWithValue("@TELEFONE", clienteObj.TELEFONE);
                command.Parameters.AddWithValue("@EMAIL", clienteObj.EMAIL);
                command.Parameters.AddWithValue("@CIDADE", clienteObj.CIDADE);
                command.Parameters.AddWithValue("@UF", clienteObj.UF);
                _con.Open(); //abro a conexão
                i = command.ExecuteNonQuery(); // se foi com sucesso, ele retorna quantas linhas foram afetadas 
            }
            _con.Close();
            return i >= 1; // retorna se i for igual ou maior que 1
        }


        //Obter todos os clientes
        public List<Cliente> ObterCliente()
        {
            Connection();
            List<Cliente> clienteList = new List<Cliente>();

            using (SqlCommand command = new SqlCommand("ObterCliente", _con))
            {
                command.CommandType = CommandType.StoredProcedure;

                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente()
                    {
                        ID_CLIENTE = Convert.ToInt32(reader["ID_CLIENTE"]),
                        NOME = Convert.ToString(reader["NOME"]),
                        IDADE = Convert.ToInt32(reader["IDADE"]),
                        ENDERECO = Convert.ToString(reader["ENDERECO"]),
                        TELEFONE = Convert.ToString(reader["TELEFONE"]),
                        EMAIL = Convert.ToString(reader["EMAIL"]),
                        CIDADE = Convert.ToString(reader["CIDADE"]),
                        UF = Convert.ToString(reader["UF"])
                    };
                    clienteList.Add(cliente);
                }
                _con.Close();
                return clienteList;
            }
        }

        //Atualizar cliente
        public bool AtualizarCliente(Cliente clienteObj)
        {
            Connection();
            int i;
            using (SqlCommand command = new SqlCommand("AtualizarCliente", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID_CLIENTE", clienteObj.ID_CLIENTE);
                command.Parameters.AddWithValue("@NOME", clienteObj.NOME);
                command.Parameters.AddWithValue("@IDADE", clienteObj.IDADE);
                command.Parameters.AddWithValue("@ENDERECO", clienteObj.ENDERECO);
                command.Parameters.AddWithValue("@TELEFONE", clienteObj.TELEFONE);
                command.Parameters.AddWithValue("@EMAIL", clienteObj.EMAIL);
                command.Parameters.AddWithValue("@CIDADE", clienteObj.CIDADE);
                command.Parameters.AddWithValue("@UF", clienteObj.UF);
                _con.Open();
                i = command.ExecuteNonQuery(); // se foi com sucesso, ele retorna quantas linhas foram afetadas 
            }
            _con.Close();
            return i >= 1; // retorna se i for igual ou maior que 1
        }

        //Excluir cliente
        public bool ExcluirCliente(int id)
        {
            Connection();
            int i;
            using (SqlCommand command = new SqlCommand("ExcluirClientePorId", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID_CLIENTE", id);

                _con.Open();
                i = command.ExecuteNonQuery(); // se foi com sucesso, ele retorna quantas linhas foram afetadas 
            }
            _con.Close();
            
            if(i >= 1)
            {
                return true;
            }
            return false;

        }
    }
}



