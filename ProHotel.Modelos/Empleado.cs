using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHotel.Modelos
{
    [Table("empleados")]
    public class Empleado
    {
        [Key]
        [Column("id_empleado")]
        public int idEmpleado { get; set; }

        [Column("cedula")]
        [Required(ErrorMessage = "La cédula es obligatoria")]
        [MaxLength(20)]
        public string cedula { get; set; }

        [Column("nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50)]
        public string nombre { get; set; }

        [Column("apellido")]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        [MaxLength(50)]
        public string apellido { get; set; }

        [Column("cargo")]
        [Required(ErrorMessage = "El cargo es obligatorio")]
        [MaxLength(50)]
        public string cargo { get; set; }

        [Column("activo")]
        [Required(ErrorMessage = "El estado activo es obligatorio")]
        public bool activo { get; set; }
    }
}
