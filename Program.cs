namespace EditorTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que deseja? ");
            Console.WriteLine("1 - Abrir arquivo\n2 - Criar arquivo\n0 - Sair");
            short option = short.Parse(Console.Readline());

            switch (option)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1:
                    Abrir();
                    break;
                case 2:
                    Editar();
                    break;
                default:
                    Menu();
                    break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo? ");
            string path = Console.ReadLine();

            using(var file = new StreamReader(path)){
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();

        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo: (ESC para sair)\n--------------------------");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Enviroment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape); /*Enquanto não pressionar ESC*/
            
            Salvar(text);
        }

        static void Salvar(string text)
        {
            Console.Clear();
            console.WriteLine("Onde quer salvar o arquivo? ");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo salvo em {path}!");
            Console.ReadLine();
            Menu();
        }
    }
}