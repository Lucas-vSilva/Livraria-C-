using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//Imports para conexão com o banco de dados
using MySql.Data.MySqlClient;//Imports para realizar comandos no banco

namespace BancoDeDadosTI13N
{
    public class Cadastro
    {
        MySqlConnection conexao;
        public string dados;
        public string resultado;
        //Declarando os vetores:
        public long[] cpf;
        public string[] nome;
        public string[] telefone;
        public string[] dataDeNascimento;
        public string[] endereco;
        public string[] enderecoEmail;
        public string[] login;
        public string[] senha;
        public int i;
        public string msg;
        public int contador = 0;
        //Contrutor
        public Cadastro(string nomeDoBancoDeDados)
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
        public void Inserir(long cpf, string nome, string dataDeNascimento, string telefone, string endereco, string enderecoEmail, string login, string senha)
        {
            try
            {
                dados = "('" + cpf + "','" + nome + "','" + dataDeNascimento + "','" + telefone + "','" + endereco + "','" + enderecoEmail + "','" + login + "','" + senha + "')";
                resultado = "Insert into Cliente(cpf, nome, dataDeNascimento, telefone, endereco, enderecoEmail, login, senha) values" + dados;
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
            string query = "select * from Cliente";//Coletando o dado do BD

            //Instanciando os vetores
            cpf = new long[100];
            nome = new string[100];
            dataDeNascimento = new string[100];
            telefone = new string[100];
            endereco = new string[100];
            enderecoEmail = new string[100];
            login = new string[100];
            senha = new string[100];


            //Dar valores iniciais para ele
            for (i = 0; i < 100; i++)
            {
                cpf[i] = 0;
                nome[i] = "";
                dataDeNascimento[i] = "";
                telefone[i] = "";
                endereco[i] = "";
                enderecoEmail[i] = "";
                login[i] = "";
                senha[i] = "";
            }//fim da repetição

            //Criar o comando para coleta de dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                cpf[i] = Convert.ToInt32(leitura["cpf"]);
                nome[i] = leitura["nome"] + "";
                dataDeNascimento[i] = leitura["dataDeNascimento"] + "";
                telefone[i] = leitura["telefone"] + "";
                endereco[i] = leitura["endereco"] + "";
                enderecoEmail[i] = leitura["enderecoEmail"] + "";
                login[i] = leitura["login"] + "";
                senha[i] = leitura["senha"] + "";
                i++;
                contador++;
            }//fim do while

            //Fechar o dataReader
            leitura.Close();
        }//fim do preencher Vetor

        public string ConsultarTudo()
        {
            //Preencher o vetor
            PreencherVetor();
            msg = "";
            for (long i = 0; i < contador; i++)
            {
                msg += "\n\nCPF: " + cpf[i]
                    + ", Nome: " + nome[i]
                    + ", Data de Nascimento: " + dataDeNascimento[i]
                    + ", Telefone: " + telefone[i]
                    + ", Endereço: " + endereco[i]
                    + ", Endereço E-mail: " + enderecoEmail[i]
                    + ", Login: " + login[i]
                    + ", Senha: " + senha[i];
            }//fim do for
            return msg;
        }//fim do consultarTudo

        public long ConsultarCPF(int codigo)
        {
            PreencherVetor();
            for (long i = 0; i < contador; i++)
            {
                if (codigo == cpf[i])
                {
                    return cpf[i];
                }
            }//fim do for
            return -1;
        }//fim do consultarNome
        public string ConsultarNome(int codigo)
        {
            PreencherVetor();
            for (long i = 0; i < contador; i++)
            {
                if (codigo == cpf[i])
                {
                    return nome[i];
                }
            }//fim do for
            return "CPF não encontrado!";
        }//fim do consultarNome
        public string ConsultarData(int codigo)
        {
            PreencherVetor();
            for (long i = 0; i < contador; i++)
            {
                if (codigo == cpf[i])
                {
                    return dataDeNascimento[i];
                }
            }//fim do for
            return "CPF não encontrado!";
        }//fim do consultarNome

        public string ConsultarTelefone(int codigo)
        {
            PreencherVetor();
            for (long i = 0; i < contador; i++)
            {
                if (codigo == cpf[i])
                {
                    return telefone[i];
                }
            }//fim do for
            return "CPF não encontrado!";
        }//fim do consultarTelefone

        public string ConsultarEndereco(int codigo)
        {
            PreencherVetor();
            for (long i = 0; i < contador; i++)
            {
                if (codigo == cpf[i])
                {
                    return endereco[i];
                }
            }//fim do for
            return "CPF não encontrado!";
        }//fim do consultarEndereço
        public string ConsultarEnderecoEmail(int codigo)
        {
            PreencherVetor();
            for (long i = 0; i < contador; i++)
            {
                if (codigo == cpf[i])
                {
                    return enderecoEmail[i];
                }
            }//fim do for
            return "CPF não encontrado!";
        }//fim do consultarNome
        public string ConsultarLogin(int codigo)
        {
            PreencherVetor();
            for (long i = 0; i < contador; i++)
            {
                if (codigo == cpf[i])
                {
                    return login[i];
                }
            }//fim do for
            return "CPF não encontrado!";
        }//fim do consultarNome
        public string ConsultarSenha(int codigo)
        {
            PreencherVetor();
            for (long i = 0; i < contador; i++)
            {
                if (codigo == cpf[i])
                {
                    return senha[i];
                }
            }//fim do for
            return "CPF não encontrado!";
        }//fim do consultarNome

        public void Atualizar(string campo, string novoDado, int codigo)
        {
            try
            {
                resultado = "update Cliente set " + campo + " = '" +
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

        public void Deletar(int codigo)
        {
            resultado = "delete from Cliente where codigo = '" + codigo + "'";
            //Executar o comando
            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();
            //Mensagem...
            Console.WriteLine("Dados Excluídos com sucesso!");
        }//fim do deletar


    }//fim da classe
}//fim do projeto