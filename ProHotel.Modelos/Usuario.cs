using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHotel.Modelos
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id_usuario")]
        public int idUsuario { get; set; }

        [Column("username")]
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [MaxLength(50)]
        public string username { get; set; }

        [Column("password_hash")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [MaxLength(255)]
        public string passwordHash { get; set; }

        [Column("rol")]
        [Required(ErrorMessage = "El rol es obligatorio")]
        [MaxLength(30)]
        public string rol { get; set; }

        [Column("activo")]
        public bool activo { get; set; }

        //foranea
        [ForeignKey("Empleado")]
        [Column("id_empleado")]
        public int idEmpleado { get; set; }
        public Empleado? Empleado { get; set; }
    }
}
