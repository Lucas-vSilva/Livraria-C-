using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//Imports para conexão com o banco de dados
using MySql.Data.MySqlClient;//Imports para realizar comandos no banco



namespace BancoDeDadosTI13N
{
    class MenuCompra
    {
        Compra compra;
        public int opcao3;
        public MenuCompra()
        {
            opcao3 = 0;
            compra = new Compra("LivrariaTI13");
        }//fim do construtor



        public void MostrarOpcoes()
        {
            Console.WriteLine("\n\nEscolha uma das opções abaixo: \n\n" +
            "\n1. Cadastrar Compra" +
            "\n2. Consultar Compras" +
            "\n3. Consultar Compra" +
            "\n4. Atualizar Compra" +
            "\n5. Excluir Compra");
            opcao3 = Convert.ToInt32(Console.ReadLine());
        }//fim do método



        public void Executar3()
        {
            do
            {
                MostrarOpcoes();//Mostrando o menu para o usuário



                switch (opcao3)
                {
                    case 1:
                        //Colentando os dados
                        Console.WriteLine("Informe codigo do Cartao: ");
                        int codigoDoCartao = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nInforme data de Compra: ");
                        string dataCompra = Console.ReadLine();
                        Console.WriteLine("\nInforme seu valorTotal: ");
                        double valorTotal = Convert.ToDouble(Console.ReadLine());
                        compra.Inserir(codigoDoCartao, dataCompra, valorTotal);


                        break;
                    case 2:
                        //Consultar os dados
                        Console.WriteLine(compra.ConsultarCompra());
                        break;
                    case 3:
                        //Consultar Individual
                        Console.WriteLine("Informe o código que deseja consultar");
                        int codigo = Convert.ToInt32(Console.ReadLine());



                        Console.WriteLine("CodigoDoCartao: " + compra.ConsultarCodigoDoCartao(codigo) +
                        "\nDataCompra: " + compra.ConsultarDataCompra(codigo) +
                        "\nvalorTotal: " + compra.ConsultarvalorTotal(codigo));
                        break;
                    case 4:
                        //Atualizar
                        Console.WriteLine("Qual campo desejas atualizar?");
                        string campo = Console.ReadLine();
                        Console.WriteLine("Qual o novo dado?");
                        string novoDado = Console.ReadLine();
                        Console.WriteLine("Qual o código da pessoa que deseja atualizar?");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        compra.Atualizar3(campo, novoDado, codigo);
                        break;
                    case 5:
                        //Deletar
                        Console.WriteLine("Informe o código que deseja deletar");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        //Usar o método da classe DAO
                        compra.Deletar3(codigo);
                        break;
                    case 0:
                        Console.WriteLine("Obrigado!");
                        break;
                    default:
                        Console.WriteLine("Código digitado não é valido!");
                        break;
                }//fim do switch_Case
            } while (opcao3 != 0);
        }//fim do método





    }//fim da classe
}//fim do projeto