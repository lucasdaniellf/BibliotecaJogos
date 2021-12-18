using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Jogo
    {
        public int idJogo { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string nome { get; set; }
        [Required(ErrorMessage = "Data de Compra é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime dataCompra { get; set; }

        public decimal precoCompra { get; set; }

        public int? idEstudio { get; set; }
    }
}
