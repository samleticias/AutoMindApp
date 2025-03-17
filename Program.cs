using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Lista para armazenar os usuários cadastrados
    static List<Usuario> usuarios = new List<Usuario>();

    static void Main()
    {
        string opcao = "";

        do
        {
            Console.Clear(); // Limpa a tela a cada iteração do menu
            ExibirMenu();  // Exibe as opções do menu

            opcao = Console.ReadLine(); // Lê a escolha do usuário

            // Estrutura de decisão para chamar a funcionalidade escolhida
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
                    // Mensagem ao sair do programa
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nSaindo...\n");
                    Console.ResetColor();
                    break;
                default:
                    // Mensagem para opção inválida
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOpção inválida!");
                    Console.ResetColor();
                    AguardarEnter(); // Aguarda o usuário pressionar Enter antes de voltar ao menu
                    break;
            }

        } while (opcao != "0"); // Continua no loop até o usuário escolher "0" (Sair)
    }

    // Exibe o menu de opções
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

    // Método para cadastrar um novo usuário
    static void CadastrarUsuario()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("===== CADASTRO DE USUÁRIO =====");
        Console.ResetColor();

        // Solicita o nome do usuário
        Console.Write("\n> Nome: ");
        string nome = Console.ReadLine();

        // Solicita o e-mail do usuário
        Console.Write("\n> E-mail: ");
        string email = Console.ReadLine();

        int idade;
        bool idadeValida;
        
        // Loop para garantir que o usuário digite uma idade válida
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

        } while (!idadeValida); // Continua pedindo até o usuário digitar um número válido

        // Adiciona o novo usuário à lista
        usuarios.Add(new Usuario(nome, email, idade));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nUsuário cadastrado com sucesso!");
        Console.ResetColor();
        AguardarEnter(); // Aguarda Enter antes de voltar ao menu
    }

    // Lista os usuários cadastrados
    static void ListarUsuarios()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("===== LISTA DE USUÁRIOS =====");
        Console.ResetColor();

        // Verifica se a lista de usuários está vazia
        if (usuarios.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nNenhum usuário cadastrado.");
            Console.ResetColor();
        }
        else
        {
            // Exibe todos os usuários cadastrados
            foreach (var usuario in usuarios)
            {
                Console.WriteLine(usuario);
            }
        }
        AguardarEnter(); // Aguarda Enter antes de voltar ao menu
    }

    // Busca um usuário pelo nome
    static void BuscarUsuario()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("===== BUSCAR USUÁRIO =====");
        Console.ResetColor();

        // Solicita o nome para a busca
        Console.Write("\nDigite o nome do usuário para busca: ");
        string nome = Console.ReadLine();

        // Procura um usuário com o nome fornecido (sem considerar maiúsculas/minúsculas)
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
        AguardarEnter(); // Aguarda Enter antes de voltar ao menu
    }

    // Método auxiliar para aguardar Enter antes de continuar
    static void AguardarEnter()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nPressione <Enter> para continuar...");
        Console.ResetColor();
        Console.ReadLine();
    }
}