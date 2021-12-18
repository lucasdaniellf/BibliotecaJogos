using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Genero
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string nome { get; set; }
    }
}
