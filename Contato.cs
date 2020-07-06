namespace WhatsApp
{
    public class Contato
    {
        public string ID { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public Contato()
        {

        }
        
        public Contato(string _ID, string _nome, string _telefone)
        {
            this.ID = _ID;
            this.nome = _nome;
            this.telefone = telefone;

        }
    }
}