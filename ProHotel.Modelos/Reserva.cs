using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHotel.Modelos
{
    [Table("reservas")]
    public class Reserva
    {
        [Key]
        [Column("id_reserva")]
        public int idReserva { get; set; }

        [Column("fecha_reserva", TypeName = "date")]
        public DateTime fechaReserva { get; set; }

        [Column("fecha_check_in", TypeName = "date")]
        [Required(ErrorMessage = "La fecha de Check-In es obligatoria")]
        public DateTime fechaCheckIn { get; set; }

        [Column("fecha_check_out", TypeName = "date")]
        [Required(ErrorMessage = "La fecha de Check-Out es obligatoria")]
        public DateTime fechaCheckOut { get; set; }

        [Column("estado")]
        [Required(ErrorMessage = "El estado es obligatorio")]
        [MaxLength(20)]
        public string estado { get; set; }

        [Column("monto_total", TypeName = "numeric(10,2)")]
        [Required(ErrorMessage = "El monto total es obligatorio")]
        public decimal montoTotal { get; set; }

        //foraneas
        [ForeignKey("Cliente")]
        [Column("id_cliente")]
        public int idCliente { get; set; }

        [ForeignKey("Empleado")]
        [Column("id_empleado")]
        public int idEmpleado { get; set; }
        //objetos de navegacion
        public Cliente? Cliente { get; set; }
        public Empleado? Empleado { get; set; }

        //relaciones
        public List<DetalleReserva>? DetallesReserva { get; set; } = new List<DetalleReserva>();

    }
}
