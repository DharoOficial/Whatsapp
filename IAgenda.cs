using System.Collections.Generic;

namespace WhatsApp
{
    public interface IAgenda
    {
        void Cadastrar(Contato conta);
        void Excluir(Contato co );
        List<Contato> Listar();
    }
}