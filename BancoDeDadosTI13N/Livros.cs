using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//Imports para conexão com o banco de dados
using MySql.Data.MySqlClient;//Imports para realizar comandos no banco

namespace BancoDeDadosTI13N
{
    class Livros
    {
        MySqlConnection conexao;
        public string dados;
        public string resultado;
        //Declarando os vetores:
        public int[] isbn;
        public string[] nome2;
        public string[] autor;
        public double[] preco;
        public int i;
        public string msg;
        public int contador = 0;
        public Livros(string nomeDoBancoDeDados)
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
        public void Inserir(int isbn, string nome2, string autor, double preco)
        {
            try
            {
                dados = "('" + isbn + "','" + nome2 + "','" + autor + "','" + preco + "')";
                resultado = "Insert into Livros(isbn, nome, autor, preco) values" + dados;
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
            string query = "select * from Livros";//Coletando o dado do BD

            //Instanciando os vetores
            isbn = new int[100];
            nome2 = new string[100];
            autor = new string[100];
            preco = new double[100];


            //Dar valores iniciais para ele
            for (i = 0; i < 100; i++)
            {
                isbn[i] = 0;
                nome2[i] = "";
                autor[i] = "";
                preco[i] = 0;

            }//fim da repetição

            //Criar o comando para coleta de dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                isbn[i] = Convert.ToInt32(leitura["isbn"]);
                nome2[i] = leitura["nome"] + "";
                autor[i] = leitura["autor"] + "";
                preco[i] = Convert.ToDouble(leitura["preco"]);
                i++;
                contador++;
            }//fim do while

            //Fechar o dataReader
            leitura.Close();
        }//fim do preencher Vetor

        public string ConsultarLivro()
        {
            //Preencher o vetor
            PreencherVetor();
            msg = "";
            for (long i = 0; i < contador; i++)
            {
                msg += "\n\nISBN: " + isbn[i]
                    + ", Nome: " + nome2[i]
                    + ", Autor: " + autor[i]
                    + ", Preço: " + preco[i];        
            }//fim do for
            return msg;
        }//fim do consultarTudo

        public int ConsultarISBN(int cdg)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cdg == isbn[i])
                {
                    return isbn[i];
                }
            }//fim do for
            return -1 ;

        }//fim do consultar
        public string ConsultarNome(int cdg)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cdg == isbn[i])
                {
                    return nome2[i];
                }
            }//fim do for
            return "Livro não encontrado!";

        }//fim do consultar
        public string ConsultarAutor(int cdg)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cdg == isbn[i])
                {
                    return autor[i];
                }
            }//fim do for
            return "Livro não encontrado!";

        }//fim do consultar
        public double ConsultarPreco(int cdg)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cdg == isbn[i])
                {
                    return preco[i];
                }
            }//fim do for
            return -1;


        }//fim do consultar

        public void Atualizar2(string campo, string novoDado, int codigo)
        {
            try
            {
                resultado = "update Livros set " + campo + " = '" +
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

        public void Deletar2(int codigo)
        {
            resultado = "delete from Livros where codigo = '" + codigo + "'";
            //Executar o comando
            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();
            //Mensagem...
            Console.WriteLine("Dados Excluídos com sucesso!");
        }//fim do deletar
    }//fim da classe
}//fim do projeto

