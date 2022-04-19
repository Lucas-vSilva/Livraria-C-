using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDadosTI13N
{
    class MenuGeral
    {
        public int opcaoG;
        Cadastro cadastro;
        Livros livro;
        Compra compra;
        Reserva reservas;
     
        public MenuGeral()
        {

            opcaoG = 0;
            cadastro = new Cadastro("LivrariaTI13");
            livro = new Livros("LivrariaTI13");
            compra = new Compra("LivrariaTI13");
            reservas = new Reserva("LivrariaTI13");
        }//fim do construtor

        public void OpcoesMenu()
        {
            Console.WriteLine("\n\nEscolha qual tabela deseja utilizar: \n\n" +
            "\n1.Cliente" +
            "\n2 Livros" +
            "\n3.Compra" +
            "\n4.Reserva");

            opcaoG = Convert.ToInt32(Console.ReadLine());


        }//fim do método OpcoesUm

        public void ExecutarTudo()
        {
            do
            {

                switch (opcaoG)
                {
                    case 1:
                        Executar();
                        break;
                    case 2:
                        Executar2();
                        break;
                    case 3:
                        Executar3();
                        break;
                    case 4:
                        Exec();
                        break;
                }
            }
            while (opcaoG != 0);
        }//fim do método






    }
}
