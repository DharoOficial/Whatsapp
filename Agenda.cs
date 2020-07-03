using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WhatsApp
{
    public class Agenda : IAgenda
    {
        List<Contato> contatoss = new List<Contato>();
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
            
            List<Contato> contatoss = new List<Contato>();

            
            string[] linhas = File.ReadAllLines(PATH);

            foreach(string linha in linhas){
                
                
                string[] dado = linha.Split(";");

                
                Contato c   = new Contato();
                c.ID        = int.Parse( Separar(dado[0]) );
                c.nome      = Separar(dado[1]);
                c.telefone  = int.Parse( Separar(dado[2]) );

                contatoss.Add(c);
                contatoss = contatoss.OrderBy(y => y.nome).ToList();
            }
                return contatoss; 
        }
        //----------------------------------
        private string Separar(string _coluna)
        {
            // 0      1
            // nome = Gibson
            return _coluna.Split("=")[1];
        }

        //----------------------------------
        public void Cadastrar(Contato conta)
        {
            var linha = new string[] { prepararLinhaCSV(conta) };
            File.AppendAllLines(PATH, linha);
            
        }
        //----------------------------------

        public void Excluir(string _nome)
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
            
            linhas.RemoveAll(z => z.Split(";")[1].Contains(_nome));
            

        }
        //----------------------------------

        public void Listar(Contato c)
        
        {
           
            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null)
                {
                    System.Console.WriteLine($"ID do do contato: {c.ID}; Nome do contato é : {c.nome}; e o telefone do contato é: {c.telefone}");
                }
            }
            
        }
        //----------------------------------
        private string prepararLinhaCSV( Contato c)
        {
            return $"ID do do contato: {c.ID}; Nome do contato é : {c.nome}; e o telefone do contato é: {c.telefone}";
        }
        //----------------------------------
    }
}