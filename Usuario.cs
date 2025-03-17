using System;

public class Usuario
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Idade { get; set; }

    public Usuario(string nome, string email, int idade)
    {
        Nome = nome;
        Email = email;
        Idade = idade;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Email: {Email}, Idade: {Idade}";
    }
}