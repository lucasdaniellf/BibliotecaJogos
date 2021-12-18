using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Estudio
    {
        public int idEstudio { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string nome { get; set; }
    }
}
