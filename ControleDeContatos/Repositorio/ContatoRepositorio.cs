using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ContatoModel listarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.id == id);
   ;      }
        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = listarPorId(contato.id);
            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato!");

            contatoDB.nome = contato.nome;
            contatoDB.email = contato.email;
            contatoDB.celular = contato.celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;

        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = listarPorId(id);
            if (contatoDB == null) throw new System.Exception("Houve um erro deleção do contato!");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
