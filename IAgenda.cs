namespace WhatsApp
{
    public interface IAgenda
    {
        void Cadastrar(Contato conta);
        void Excluir(string _nome);
        void Listar(Contato c);
    }
}