using System;
using DIO.Series.Classes;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUser = ObterOpcaoUser();

        while (opcaoUser.ToUpper() != "X"){

            switch (opcaoUser)
            {
                case "1":
                ListarSeries();
                break;
                case "2":
                InserirSerie();
                break;
                case "3":
                AtualizarSerie();
                break;
                case "4":
                ExcluirSerie();
                break;
                case "5":
                VisualizarSerie();
                break;
                case "C":
                Console.Clear();
                break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            opcaoUser = ObterOpcaoUser();
        }

        Console.WriteLine("Obrigado por utilizar nossos Servicos.");
        Console.ReadLine();

        }

        private static void ExcluirSerie()
         {
             Console.Write("Digite o Id da Serie: ");
             int indiceSerie = int.Parse(Console.ReadLine());

             Console.WriteLine("Digite: 1 - Confimar e 2- Cancelar");
             int comfirmacaoUser = int.Parse(Console.ReadLine());
            
            switch(comfirmacaoUser) 
            {
                case 1 :
                Console.WriteLine("Exluindo....");
                repositorio.Exclui(indiceSerie);
                break;
                case 2:
                Console.WriteLine("Cancelando exclusão");
                break;
            }
            
         }
         private static void VisualizarSerie()
         {
             Console.Write("Digite o Id da Serie: ");
             int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
            
         }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.List();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Serie Encontrada");
                return;
            }
            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));

            }
        }

        private static void AtualizarSerie()
         {
             Console.Write("Digite o Id da Serie: ");
             int indiceSerie = int.Parse(Console.ReadLine());
             System.Console.WriteLine();
         
            foreach ( int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine();
            Console.WriteLine("Gênero: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            System.Console.WriteLine();
            Console.WriteLine("É um filme ou uma série? ");
            string entradaTipo = (Console.ReadLine());
            System.Console.WriteLine();
            Console.WriteLine("Título: ");
            string entradaTitulo = Console.ReadLine();
            System.Console.WriteLine();
            Console.WriteLine("Lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());
            System.Console.WriteLine();
            Console.WriteLine("Sinopse: ");
            string entradaDesc = Console.ReadLine();
            System.Console.WriteLine();
            Console.WriteLine("Diretor: ");
            string entradaDir = Console.ReadLine();
            System.Console.WriteLine();
           
           Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        tipo: entradaTipo,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDesc,
                                        diretor: entradaDir); 

            repositorio.Atualizar(indiceSerie, atualizaSerie);
        }

        private static void InserirSerie()
        {
            System.Console.WriteLine();
            foreach ( int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine();
            Console.WriteLine("Gênero: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            System.Console.WriteLine();
            Console.WriteLine("É um filme ou uma série? ");
            string entradaTipo = (Console.ReadLine());
            System.Console.WriteLine();
            Console.WriteLine("Título");
            string entradaTitulo = Console.ReadLine();
            System.Console.WriteLine();
            Console.WriteLine("Lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());
            System.Console.WriteLine();
            Console.WriteLine("Sinopse: ");
            string entradaDesc = Console.ReadLine();
            System.Console.WriteLine();
            Console.WriteLine("Diretor: ");
            string entradaDir = Console.ReadLine();
            System.Console.WriteLine();
           
           Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        tipo : entradaTipo,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDesc,
                                        diretor: entradaDir); 

            repositorio.Insere(novaSerie);
        }


        private static string ObterOpcaoUser()
        {
            Console.WriteLine();
            Console.WriteLine(" PÊPEFLIX ");
            Console.WriteLine(" O que deseja? ");

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir Nova Serie");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Visualizar Séries");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("x- Sair");
            Console.WriteLine();

            string opcaoUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUser;
        }
    }
}