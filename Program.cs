using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Usuario> usuarios = new List<Usuario>();

    static void Main()
    {
        string opcao = "";

        do
        {
            Console.Clear(); 
            ExibirMenu();

            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarUsuario();
                    break;
                case "2":
                    ListarUsuarios();
                    break;
                case "3":
                    BuscarUsuario();
                    break;
                case "0":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nSaindo...\n");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOpção inválida!");
                    Console.ResetColor();
                    AguardarEnter();
                    break;
            }

        } while (opcao != "0");
    }

    static void ExibirMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=======================================");
        Console.WriteLine("         GERENCIADOR DE USUÁRIOS      ");
        Console.WriteLine("=======================================");
        Console.ResetColor();
        Console.WriteLine("[1] Cadastrar Usuário");
        Console.WriteLine("[2] Listar Usuários");
        Console.WriteLine("[3] Buscar Usuário");
        Console.WriteLine("[0] Sair");
        Console.WriteLine("=======================================");
        Console.Write("> Escolha uma opção: ");
    }

    static void CadastrarUsuario()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("===== CADASTRO DE USUÁRIO =====");
        Console.ResetColor();

        Console.Write("\n> Nome: ");
        string nome = Console.ReadLine();

        Console.Write("\n> E-mail: ");
        string email = Console.ReadLine();

        int idade;
        bool idadeValida;
        
        do
        {
            Console.Write("\n> Idade: ");
            idadeValida = int.TryParse(Console.ReadLine(), out idade);

            if (!idadeValida)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nIdade inválida! Deve ser um número.");
                Console.ResetColor();
            }

        } while (!idadeValida);

        usuarios.Add(new Usuario(nome, email, idade));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nUsuário cadastrado com sucesso!");
        Console.ResetColor();
        AguardarEnter();
    }

    static void ListarUsuarios()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("===== LISTA DE USUÁRIOS =====");
        Console.ResetColor();

        if (usuarios.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nNenhum usuário cadastrado.");
            Console.ResetColor();
        }
        else
        {
            foreach (var usuario in usuarios)
            {
                Console.WriteLine(usuario);
            }
        }
        AguardarEnter();
    }

    static void BuscarUsuario()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("===== BUSCAR USUÁRIO =====");
        Console.ResetColor();

        Console.Write("\nDigite o nome do usuário para busca: ");
        string nome = Console.ReadLine();

        var usuario = usuarios.FirstOrDefault(u => u.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

        if (usuario != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nUsuário encontrado:");
            Console.ResetColor();
            Console.WriteLine(usuario);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nUsuário não encontrado.");
            Console.ResetColor();
        }
        AguardarEnter();
    }

    static void AguardarEnter()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nPressione <Enter> para continuar...");
        Console.ResetColor();
        Console.ReadLine();
    }
}