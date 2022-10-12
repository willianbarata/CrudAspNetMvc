using EmpresaData.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaData.DAO
{
    public class ClienteDao : BdSqlServerDao
    {
       public void IncluiCliente(Cliente cliente)
       {
            //instanciando a conexão
            SqlConnection conexao = new SqlConnection();
            //Configurar conexão
            conexao.ConnectionString = conexaoSqlServer;

            //Instancia o comando
            SqlCommand comando = new SqlCommand();

            string sql = "Insert Into " +
                "Cliente(Nome, CPF, Idade) " +
                "Values (@Nome, @CPF, @Idade); ";

            comando.CommandText = sql;

            comando.CommandType = System.Data.CommandType.Text;

            comando.Parameters.AddWithValue("@Nome", cliente.Nome);
            comando.Parameters.AddWithValue("@CPF", cliente.CPF);
            comando.Parameters.AddWithValue("@Idade", cliente.Idade);

            comando.Connection = conexao;

            try
            {
                //Abre Conexão
                conexao.Open();
                //Executa o comando
                comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
            finally
            {
                conexao.Close();
            }

        }

       public void AlterarCliente(Cliente cliente)
       {
            //instanciando a conexão
            SqlConnection conexao = new SqlConnection();
            //Configurar conexão
            conexao.ConnectionString = conexaoSqlServer;

            //Instancia o comando
            SqlCommand comando = new SqlCommand();

            string sql = "Update Cliente Set " +
                "Nome = @Nome, CPF = @CPF, Idade = @Idade " +
                "Where ClienteId = @ClienteId";

            comando.CommandText = sql;

            comando.CommandType = System.Data.CommandType.Text;

            comando.Parameters.AddWithValue("@Nome", cliente.Nome);
            comando.Parameters.AddWithValue("@CPF", cliente.CPF);
            comando.Parameters.AddWithValue("@Idade", cliente.Idade);
            comando.Parameters.AddWithValue("@ClienteId", cliente.ClienteId);

            comando.Connection = conexao;

            try
            {
                //Abre Conexão
                conexao.Open();
                //Executa o comando
                comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
            finally
            {
                conexao.Close();
            }

        }

       public void ExcluirCliente(int clienteId)
        {
            //instanciando a conexão
            SqlConnection conexao = new SqlConnection();
            //Configurar conexão
            conexao.ConnectionString = conexaoSqlServer;

            //Instancia o comando
            SqlCommand comando = new SqlCommand();

            string sql = "Delete From Cliente " +
                "Where ClienteId = @ClienteId";

            comando.CommandText = sql;

            comando.CommandType = System.Data.CommandType.Text;

            comando.Parameters.AddWithValue("@ClienteId", clienteId);

            comando.Connection = conexao;

            try
            {
                //Abre Conexão
                conexao.Open();
                //Executa o comando
                comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {

                throw new Exception(error.Message);
            }
            finally
            {
                conexao.Close();
            }

        }

       public Cliente ObtemCliente(int clienteId)
        {
            //instanciando a conexão
            SqlConnection conexao = new SqlConnection();
            //Configurar conexão
            conexao.ConnectionString = conexaoSqlServer;

            //Instancia o comando
            SqlCommand comando = new SqlCommand();

            string sql = "Select * From Cliente " +
                "Where ClienteId = @ClienteId";

            comando.CommandText = sql;

            comando.CommandType = System.Data.CommandType.Text;

            comando.Parameters.AddWithValue("@ClienteId", clienteId);

            comando.Connection = conexao;

            try
            {
                //Abre Conexão
                conexao.Open();
                //Executa o comando
                SqlDataReader tabela = comando.ExecuteReader();

                if (tabela.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.ClienteId = int.Parse(tabela["ClienteId"].ToString());
                    cliente.Nome = tabela["Nome"].ToString();
                    cliente.CPF = tabela["CPF"].ToString();
                    cliente.Idade = int.Parse(tabela["Idade"].ToString());

                    return cliente;
                }
                return null;

            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            finally
            {
                conexao.Close();
            }

        }

       public List<Cliente> ListarClientes()
        {
            //instanciando a conexão
            SqlConnection conexao = new SqlConnection();
            //Configurar conexão
            conexao.ConnectionString = conexaoSqlServer;

            //Instancia o comando
            SqlCommand comando = new SqlCommand();

            string sql = "Select * From Cliente; ";

            comando.CommandText = sql;

            comando.CommandType = System.Data.CommandType.Text;

            comando.Connection = conexao;

            try
            {
                //Abre Conexão
                conexao.Open();
                //Executa o comando
                SqlDataReader tabela = comando.ExecuteReader();

                List<Cliente> lista = new List<Cliente>();
               

                while (tabela.HasRows)
                {
                    while (tabela.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente.ClienteId = int.Parse(tabela["ClienteId"].ToString());
                        cliente.Nome = tabela["Nome"].ToString();
                        cliente.CPF = tabela["CPF"].ToString();
                        cliente.Idade = int.Parse(tabela["Idade"].ToString());

                        lista.Add(cliente);
                    }
                    return lista;
                }

                return null;

            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            finally
            {
                conexao.Close();
            }

        }

    }
}
