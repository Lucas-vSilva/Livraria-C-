using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//Imports para conexão com o banco de dados
using MySql.Data.MySqlClient;//Imports para realizar comandos no banco

namespace BancoDeDadosTI13N
{
    class Reserva
    {
        MySqlConnection conexao;
        public string dados;
        public string resultado;
        //Declarando os vetores:
        public int[] reserv;
        public double[] estoque;
        public string[] dataDeReserva;
        public int i;
        public string msg;
        public int contador = 0;
        public Reserva(string nomeDoBancoDeDados)
        {
            conexao = new MySqlConnection("server=localhost;DataBase=" + nomeDoBancoDeDados + ";Uid=root;Password=;");
            try
            {
                conexao.Open();//Solicitando a entrada ao banco de dados
                Console.WriteLine("Entrei!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
                conexao.Close();//Fechando a conexão com banco de dados
            }//fim da tentativa de conexão com o banco de dados
        }//fim do construtor

        //Criar o método INSERIR
        public void Inserir(int reserv, double estoque, string dataDeReserva)
        {
            try
            {
                dados = "('" + reserv + "','" +estoque + "','" + dataDeReserva + "')";
                resultado = "Insert into Reserva(reserv, estoque, dataDeReserva) values" + dados;
                //Executar o comando resultado no banco de dados
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + " Linha(s) Afetada(s)!");

            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
            }//fim do catch
        }//fim do método inserir
        public void PreencherVetor()
        {
            string query = "select * from Reserva";//Coletando o dado do BD

            //Instanciando os vetores
            reserv = new int[100];
            estoque = new double[100];
            dataDeReserva = new string[100];
          


            //Dar valores iniciais para ele
            for (i = 0; i < 100; i++)
            {
                reserv[i] = 0;
                estoque[i] = 0;
                dataDeReserva[i] = "";
               

            }//fim da repetição

            //Criar o comando para coleta de dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                reserv[i] = Convert.ToInt32(leitura["isbn"]);
                estoque[i] = Convert.ToDouble(leitura["preco"]);
                dataDeReserva[i] = leitura["autor"] + "";
               
                i++;
                contador++;
            }//fim do while

            //Fechar o dataReader
            leitura.Close();
        }//fim do preencher Vetor

        public string ConsultarReserva()
        {
            //Preencher o vetor
            PreencherVetor();
            msg = "";
            for (int i = 0; i < contador; i++)
            {
                msg += "\n\nReserva: " + reserv[i]
                    + ", Estoque: " + estoque[i]
                    + ", Data de Reserva: " + dataDeReserva[i];
                    
            }//fim do for
            return msg;
        }//fim do consultarTudo

        public int ConsultarReserva1(int cdg)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cdg == reserv[i])
                {
                    return reserv[i];
                }
            }//fim do for
            return -1;

        }//fim do consultar
        public double ConsultarEstoque(int cdg)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cdg == reserv[i])
                {
                    return estoque[i];
                }
            }//fim do for
            return -1;

        }//fim do consultar
        public string ConsultarDataR(int cdg)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cdg == reserv[i])
                {
                    return dataDeReserva[i];
                }
            }//fim do for
            return "Livro não encontrado!";

        }//fim do consultar

        public void Atualizar4(string campo, string novoDado, int codigo)
        {
            try
            {
                resultado = "update Rserva set " + campo + " = '" +
                            novoDado + "' where codigo = '" + codigo + "'";
                //Executar o script
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Dado Atualizado com Sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!" + e);
            }
        }//fim do atualizar

        public void Deletar4(int codigo)
        {
            resultado = "delete from Reserva where codigo = '" + codigo + "'";
            //Executar o comando
            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();
            //Mensagem...
            Console.WriteLine("Dados Excluídos com sucesso!");
        }//fim do deletar
    }//fim da classe
}//fim do projeto
