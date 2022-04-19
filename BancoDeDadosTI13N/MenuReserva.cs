using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDadosTI13N
{
    class MenuReserva
    {
        Reserva reservas;
        public int opcao4;
        public MenuReserva()
        {
            opcao4 = 0;
            reservas = new Reserva("LivrariaTI13");
        }
        public void MostrarReserva()
        {
            Console.WriteLine("\n\nEscolha uma das opções abaixo: \n\n" +
                              "\n1. Cadastrar Reserva" +
                              "\n2. Consultar Reserva" +
                              "\n3. Consultar Reservas" +
                              "\n4. Atualizar Reserva" +
                              "\n5. Excluir Reserva");
            opcao4 = Convert.ToInt32(Console.ReadLine());
        }


        public void Executar4()
        {
            MostrarReserva();//Mostrando o menu para o usuário
            do
            {
                switch (opcao4)
                {
                    case 1:
                        //Colentando os dados
                        Console.WriteLine("Informe o codigo da reserva: ");
                        int reserv = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Informe o numero de estoque: ");
                        double estoque = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Informe a data de reserva: ");
                        string dataDeReserva = Console.ReadLine();
                     

                        //Executar o método inserir
                        reservas.Inserir(reserv, estoque, dataDeReserva);
                        break;
                    case 2:
                        //Consultar os livros
                        Console.WriteLine(reservas.ConsultarReserva());
                        break;
                    case 3:
                        //Consultar Individual
                        Console.WriteLine("Informe o livro que deseja pesquisar");
                        int codigo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("ISBN: " + reservas.ConsultarReserva1(codigo) +
                                          "Nome: " + reservas.ConsultarEstoque(codigo) +
                                          "\nAutor: " + reservas.ConsultarDataR(codigo));                                      
                        break;
                    case 4:
                        //Atualizar
                        Console.WriteLine("Qual campo desejas atualizar?");
                        string campo = Console.ReadLine();
                        Console.WriteLine("Qual o novo dado?");
                        string novoDado = Console.ReadLine();
                        Console.WriteLine("Qual a reserva que deseja atualizar?");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        reservas.Atualizar4(campo, novoDado, codigo);
                        break;
                    case 5:
                        //Deletar
                        Console.WriteLine("Informe a reserva que deseja deletar");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        //Usar o método da classe DAO
                        reservas.Deletar4(codigo);
                        break;
                    case 0:
                        Console.WriteLine("Obrigado!");
                        break;
                    default:
                        Console.WriteLine("Código digitado não é valido!");
                        break;
                }//fim do switch_Case
            } while (opcao4 != 0);
        }//fim do executar
    }//fim da classe
}//fim do projeto
