namespace WhatsApp
{
    public class Mensagem
    {
        
        public string texto { get; set; }
        public string Destinatario { get; set; }
        public void Enviar()
        {
            System.Console.WriteLine("mensagem enviada para: "+ Destinatario );
        }
    }
}