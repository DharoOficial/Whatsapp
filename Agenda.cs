using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WhatsApp
{
    public class Agenda : IAgenda
    {
        List<Contato> contatos = new List<Contato>();
        private string PATH = @"Database/produto.csv";

        //----------------------------------
        public Agenda()
        {
            string pasta = PATH.Split('/')[0];

            if(!Directory.Exists(pasta)){
                Directory.CreateDirectory(pasta);
            }


            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }
        //----------------------------------
        private List<Contato> Ler()
        {
            
            

            
            string[] linhas = File.ReadAllLines(PATH);

            foreach(string linha in linhas){
                
                
                string[] dado = linha.Split(";");

                
                Contato c   = new Contato();
                c.ID        = (dado[0]);
                c.nome      = (dado[1]);
                c.telefone  = (dado[2]);

                contatos.Add(c);
                contatos = contatos.OrderBy(y => y.nome).ToList();
            }
                return contatos; 
        }
        //----------------------------------
       

        //----------------------------------
        public void Cadastrar(Contato conta)
        {
            var linha = new string[] { prepararLinhaCSV(conta) };
            File.AppendAllLines(PATH, linha);
            
        }
        //----------------------------------

        public void Excluir(Contato co)
        {
            
            List<string> linhas = new List<string>();
            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            linhas.RemoveAll(z => z.Contains(co.ID));
        }
        //----------------------------------

        public List<Contato> Listar()
        
        {
            
            string[] linhas = File.ReadAllLines(PATH);
           
            foreach(string linha in linhas)
            {
                string[] dado = linha.Split(";");
                contatos.Add(new Contato(dado[0], dado[1], dado [2] ));
            }         
            contatos = contatos.OrderBy(z => z.nome).ToList();
            return contatos;   
            
        }
        //----------------------------------
        private string prepararLinhaCSV( Contato c)
        {
            return $"{c.ID}; {c.nome}; {c.telefone}";
        }

        
        //----------------------------------
    }
}