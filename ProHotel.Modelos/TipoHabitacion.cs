using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHotel.Modelos
{
    [Table("tipos_habitacion")]
    public class TipoHabitacion
    {       
        [Key]
        [Column("id_tipo_habitacion")]
        public int idTipoHabitacion { get; set; }

        [Column("nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        public string nombre { get; set; }

        [Column("descripcion")]
        [Required]
        public string descripcion { get; set; }

        [Column("capacidad_personas")]
        [Required(ErrorMessage = "La capacidad es obligatoria")]
        public int capacidadPersonas { get; set; }

        [Column("precio_base_noche", TypeName = "numeric(10,2)")]
        [Required(ErrorMessage = "El precio base es obligatorio")]
        public decimal precioBaseNoche { get; set; }

        //relaciones
        public List<Habitacion>? Habitaciones { get; set; } = new List<Habitacion>();
    }
}
