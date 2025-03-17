using System;

// Classe que representa um usuário
public class Usuario
{
    public string Nome { get; set; } // Nome do usuário
    public string Email { get; set; } // E-mail do usuário
    public int Idade { get; set; } // Idade do usuário

    // Construtor para inicializar um novo usuário
    public Usuario(string nome, string email, int idade)
    {
        Nome = nome;
        Email = email;
        Idade = idade;
    }

    // Sobrescreve o método ToString() para exibir as informações do usuário formatadas
    public override string ToString()
    {
        return $"Nome: {Nome}, Email: {Email}, Idade: {Idade}";
    }
}