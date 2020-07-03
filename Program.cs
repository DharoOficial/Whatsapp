using System;

namespace WhatsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Mensagem m1 = new Mensagem();
            Agenda agend = new Agenda();
            
            Contato c1 = new Contato();
            c1.ID = 1;
            c1.nome = "mamãe";
            c1.telefone = 910102020;
            agend.Cadastrar(c1);
            
            Contato c2 = new Contato();
            c2.ID = 2;
            c2.nome = "papai";
            c2.telefone = 912345678;  
            agend.Cadastrar(c2);   
            
            System.Console.WriteLine("para quem deseja enviar uma mensagem?");
            agend.Listar(c2);
            

            
            m1.Destinatario = Console.ReadLine();
            m1.Enviar();
            

        }
    }
}
