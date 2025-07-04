﻿namespace ControleDeMedicamentos.ConsoleApp.Model;

public class NotificacaoViewModel
{
    public string Titulo { get; set; }
    public string Mensagem { get; set; }

    public NotificacaoViewModel(string titulo, string mensagem)
    {
        Titulo = titulo;
        Mensagem = mensagem;
    }
}