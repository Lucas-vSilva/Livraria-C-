using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDadosTI13N
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuGeral men = new MenuGeral();
            men.Executar();
            Console.ReadLine();//Manter o Prompt Aberto
        }//fim do método
    }//fim da classe
}//fim do projeto
