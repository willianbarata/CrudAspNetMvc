using System.ComponentModel.DataAnnotations;

namespace EmpresaWebApp.Models
{
    public class ClienteViewModel
    {
        [Display(Name = "Código")]
        public int ClienteId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Preenchimento obrigatório !")]
        [DataType(DataType.Text, ErrorMessage = "O campo nome está Vazio")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Preenchimento obrigatório !")]
        [DataType(DataType.Text, ErrorMessage = "O campo CPF está Vazio")]
        public string CPF { get; set; }
       
        [Display(Name = "Idade")]
        [Required(ErrorMessage = "Preenchimento obrigatório !")]
        public int Idade { get; set; }

        public ClienteViewModel()
        {
            ClienteId = 0;
        }

    }
}
