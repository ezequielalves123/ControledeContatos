

using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int id
        {
            get; set;
        }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string nome
        {
            get; set;
        }
        [Required(ErrorMessage = "Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
        public string email
        {
            get; set;
        }
        [Required(ErrorMessage = "Digite o e-mail do contato")]
        [Phone(ErrorMessage = "O Celular informado não é valido!")]
        public string celular
        {
            get; set;
        }
    }
}
