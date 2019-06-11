using System;
using System.IO;

namespace AAI
{
    class Program
    {
        public static string arquivo;
        public static AF AF;

        static void Main(string[] args)
        {
            AF = new AF();
            Console.WriteLine("---- Software de transformação de AFNs em AFDs ----");
            Console.WriteLine("");
            Console.WriteLine("");
            do
            {
                Console.WriteLine("Digite o nome do arquivo para ser lido");
                arquivo = Console.ReadLine();
            }
            while(!LerArquivo());

            GerarArquivoSaida();

            Console.ReadKey();
        }

        public static bool LerArquivo()
        {            
            try
            {   
                using (StreamReader sr = new StreamReader(arquivo))
                {
                    AF.Montar(sr);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Não foi possível encontrar o arquivo informado...");
                return false;
            }
            return true;
        }

        public static void GerarArquivoSaida()
        {        
            try
            {   
                using (StreamWriter sw = File.CreateText("saida.txt"))
                {
                    sw.WriteLine("oi sumido");
                }
                Console.WriteLine("AFD criada com sucesso!");
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro fatal");
                Console.WriteLine(e.Message);
            }
        }
    }
}
