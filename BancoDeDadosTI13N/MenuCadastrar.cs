using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDadosTI13N
{
    class MenuCadastrar
    {

        Cadastro cadastro;
        public int opcao;

        public MenuCadastrar()
        {

            opcao = 0;
            cadastro = new Cadastro("LivrariaTI13");

        }//fim do construtor

        public void MostrarOpcoes()
        {
            Console.WriteLine("\n\nEscolha uma das opções abaixo: \n\n" +
                              "\n1. Cadastrar Cliente" +
                              "\n2. Consultar Clientes" +
                              "\n3. Consultar Cliente" +
                              "\n4. Atualizar Cliente" +
                              "\n5. Excluir Cliente");
            opcao = Convert.ToInt32(Console.ReadLine());
        }//fim do método

        public void Executar()
        {
            do
            {
                MostrarOpcoes();//Mostrando o menu para o usuário

                switch (opcao)
                {
                    case 1:
                        //Colentando os dados
                        Console.WriteLine("Informe seu cpf: ");
                        long cpf = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Informe seu nome: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Informe sua data de nascimento: ");
                        string dataDeNascimento = Console.ReadLine();
                        Console.WriteLine("\nInforme seu telefone: ");
                        string telefone = Console.ReadLine();
                        Console.WriteLine("\nInforme seu endereço: ");
                        string endereco = Console.ReadLine();
                        Console.WriteLine("Informe seu e-mail: ");
                        string enderecoEmail = Console.ReadLine();
                        Console.WriteLine("Informe seu login: ");
                        string login = Console.ReadLine();
                        Console.WriteLine("Informe sua senha: ");
                        string senha = Console.ReadLine();
                        //Executar o método inserir
                        cadastro.Inserir(cpf, nome, dataDeNascimento, telefone, endereco, enderecoEmail, login, senha);
                        break;
                    case 2:
                        //Consultar os dados
                        Console.WriteLine(cadastro.ConsultarTudo());
                        break;
                    case 3:
                        //Consultar Individual
                        Console.WriteLine("Informe o código que deseja consultar");
                        int codigo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Nome: " + cadastro.ConsultarNome(codigo) +
                                          "\nData de Nascimento: " + cadastro.ConsultarData(codigo) +
                                          "\nTelefone: " + cadastro.ConsultarTelefone(codigo) +
                                          "\nEndereço: " + cadastro.ConsultarEndereco(codigo) +
                                          "\nEndereço E-mail: " + cadastro.ConsultarEnderecoEmail(codigo) +
                                          "\nLogin: " + cadastro.ConsultarLogin(codigo) +
                                          "\nSenha: " + cadastro.ConsultarSenha(codigo));

                        break;
                    case 4:
                        //Atualizar
                        Console.WriteLine("Qual campo desejas atualizar?");
                        string campo = Console.ReadLine();
                        Console.WriteLine("Qual o novo dado?");
                        string novoDado = Console.ReadLine();
                        Console.WriteLine("Qual o código da pessoa que deseja atualizar?");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        cadastro.Atualizar(campo, novoDado, codigo);
                        break;
                    case 5:
                        //Deletar
                        Console.WriteLine("Informe o CPF que deseja deletar");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        //Usar o método da classe DAO
                        cadastro.Deletar(codigo);
                        break;
                    case 0:
                        Console.WriteLine("Obrigado!");
                        break;
                    default:
                        Console.WriteLine("Código digitado não é valido!");
                        break;
                }//fim do switch_Case
            } while (opcao != 0);
        }//fim do método





    }
}

