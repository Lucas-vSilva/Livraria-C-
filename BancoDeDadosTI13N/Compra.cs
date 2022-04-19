using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//Imports para conexão com o banco de dados
using MySql.Data.MySqlClient;//Imports para realizar comandos no banco



namespace BancoDeDadosTI13N
{
    class Compra
    {
        MySqlConnection conexao;
        public string dados;
        public string resultado;
        //Declarando os vetores:
        public int[] codigoDoCartao;
        public string[] dataCompra;
        public double[] valorTotal;
        public int i;
        public string msg;
        public int contador = 0;
        //Contrutor
        public Compra(string nomeDoBancoDeDados)
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
        public void Inserir(int codigoDoCartao, string dataCompra, double valorTotal)
        {
            try
            {
                dados = "('" + codigoDoCartao + "','" + dataCompra + "','" + valorTotal + "')";
                resultado = "Insert into Compra(codigoDoCartao, dataCompra, valorTotal) values" + dados;
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



            //Instanciando os vetores
            codigoDoCartao = new int[100];
            dataCompra = new string[100];
            valorTotal = new double[100];



            //Dar valores iniciais para ele
            for (i = 0; i < 100; i++)
            {
                codigoDoCartao[i] = 0;
                dataCompra[i] = "";
                valorTotal[i] = 0;



            }//fim da repetição




        }//fim do preencher Vetor



        public string ConsultarCompra()
        {
            //Preencher o vetor
            PreencherVetor();
            msg = "";
            for (int i = 0; i < contador; i++)
            {
                msg += "\n\nCódigoDoCartao: " + codigoDoCartao[i]
                + ", dataCompra: " + dataCompra[i]
                + ", valorTotal: " + valorTotal[i];
            }//fim do for
            return msg;
        }//fim do consultarTudo



        public string ConsultarCodigoDoCartao(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == codigoDoCartao[i])
                {
                    return dataCompra[i];
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultarNome



        public string ConsultarDataCompra(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == codigoDoCartao[i])
                {
                    return dataCompra[i];
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultarvalorTotal
        public Double ConsultarvalorTotal(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == codigoDoCartao[i])
                {
                    return valorTotal[i];
                }
            }//fim do for
            return -1;
        }//fim do consultarNome



        public void Atualizar3(string campo, string novoDado, int codigo)
        {
            try
            {




                resultado = "update pessoa set " + campo + " = '" +
                novoDado + "' where codigo = '" + codigo + "'";
            }





            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!" + e);
            }
        }//fim do atualizar



        public void Deletar3(int codigo)
        {
            resultado = "delete from pessoa where codigo = '" + codigo + "'";
            //Executar o comando
            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();
            //Mensagem...
            Console.WriteLine("Dados Excluídos com sucesso!");
        }//fim do deletar




    }//fim da classe
}//fim do projeto