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
            c1.ID = "1";
            c1.nome = "mamae";
            c1.telefone = "(11) 910102020";
            agend.Cadastrar(c1);
             
            Contato c3 = new Contato();
            c3.ID = "3";
            c3.nome = "pato_donald";
            c3.telefone = "(11) 92893020";
            agend.Cadastrar(c3);
            
            Contato c2 = new Contato();
            c2.ID = "2";
            c2.nome = "papai";
            c2.telefone = "(11) 912345678";  
            agend.Cadastrar(c2);   
            
            System.Console.WriteLine("para quem deseja enviar uma mensagem?");
            foreach(Contato item in agend.Listar()){
                System.Console.WriteLine($"ID: {item.ID}; Nome: {item.nome}; Telefone: {item.telefone}");
            }

            agend.Excluir(c1);
            

            
            m1.Destinatario = Console.ReadLine();
            m1.Enviar();
            

        }
    }
}
