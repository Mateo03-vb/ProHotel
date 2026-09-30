using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHotel.Modelos
{
    [Table("habitaciones")]
    public class Habitacion
    {
        [Key]
        [Column("id_habitacion")]
        public int idHabitacion { get; set; }

        [Column("numero")]
        [Required(ErrorMessage = "El número de habitación es obligatorio")]
        [MaxLength(10)]
        public string numero { get; set; }

        [Column("piso")]
        [Required(ErrorMessage = "El piso es obligatorio")]
        public int piso { get; set; }

        [Column("estado")]
        [Required(ErrorMessage = "El estado es obligatorio")]
        [MaxLength(20)]
        public string estado { get; set; }

        //foranea
        [ForeignKey("TipoHabitacion")]
        [Column("id_tipo_habitacion")]
        public int idTipoHabitacion { get; set; }
        public TipoHabitacion? TipoHabitacion { get; set; }
    }
}
