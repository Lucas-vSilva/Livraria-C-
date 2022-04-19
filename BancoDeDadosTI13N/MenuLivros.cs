using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDadosTI13N
{
    class MenuLivros
    {
        Livros livro;
        public int opcao2;
        public MenuLivros()
        {
            opcao2 = 0;
            livro = new Livros("LivrariaTI13");
        }
        public void MostrarLivros()
        {
            Console.WriteLine("\n\nEscolha uma das opções abaixo: \n\n" +
                              "\n1. Cadastrar Livro" +
                              "\n2. Consultar Livro" +
                              "\n3. Consultar Livros" +
                              "\n4. Atualizar Livro" +
                              "\n5. Excluir Livro");
            opcao2 = Convert.ToInt32(Console.ReadLine());
        }


        public void Executar2()
        {
            MostrarLivros();//Mostrando o menu para o usuário
            do
            {
                switch (opcao2)
                {
                    case 1:
                        //Colentando os dados
                        Console.WriteLine("Informe o isbn: ");
                        int isbn = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Informe o nome: ");
                        string nome2 = Console.ReadLine();
                        Console.WriteLine("Informe o autor: ");
                        string autor = Console.ReadLine();
                        Console.WriteLine("\nInforme o preço: ");
                        double preco = Convert.ToDouble(Console.ReadLine());

                        //Executar o método inserir
                        livro.Inserir(isbn, nome2, autor, preco);
                        break;
                    case 2:
                        //Consultar os livros
                        Console.WriteLine(livro.ConsultarLivro());
                        break;
                    case 3:
                        //Consultar Individual
                        Console.WriteLine("Informe o livro que deseja pesquisar");
                        int codigo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("ISBN: " + livro.ConsultarISBN(codigo) +
                                          "Nome: " + livro.ConsultarNome(codigo) +
                                          "\nAutor: " + livro.ConsultarAutor(codigo) +
                                          "\nPreco: " + livro.ConsultarPreco(codigo));
                        break;
                    case 4:
                        //Atualizar
                        Console.WriteLine("Qual campo desejas atualizar?");
                        string campo = Console.ReadLine();
                        Console.WriteLine("Qual o novo dado?");
                        string novoDado = Console.ReadLine();
                        Console.WriteLine("Qual o livro que deseja atualizar?");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        livro.Atualizar2(campo, novoDado, codigo);
                        break;
                    case 5:
                        //Deletar
                        Console.WriteLine("Informe o livro que deseja deletar");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        //Usar o método da classe DAO
                        livro.Deletar2(codigo);
                        break;
                    case 0:
                        Console.WriteLine("Obrigado!");
                        break;
                    default:
                        Console.WriteLine("Código digitado não é valido!");
                        break;
                }//fim do switch_Case
            } while (opcao2 != 0);
        }//fim do executar
    }//fim da classe
}//fim do projeto
