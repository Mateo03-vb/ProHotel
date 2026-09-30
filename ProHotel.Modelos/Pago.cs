using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHotel.Modelos
{
    [Table("pagos")]
    public class Pago
    {
        [Key]
        [Column("id_pago")]
        public int idPago { get; set; }

        [Column("monto", TypeName = "numeric(10,2)")]
        [Required(ErrorMessage = "El monto es obligatorio")]
        public decimal monto { get; set; }

        [Column("metodo_pago", TypeName = "varchar(30)")]
        [Required(ErrorMessage = "El método de pago es obligatorio")]
        public string metodoPago { get; set; }

        [Column("fecha_pago", TypeName = "date")]
        [Required(ErrorMessage = "La fecha de pago es obligatoria")]
        public DateTime fechaPago { get; set; }

        [Column("referencia_transaccion", TypeName = "varchar(100)")]
        public string referenciaTransaccion { get; set; }

        //foranea
        [ForeignKey("Reserva")]
        [Column("id_reserva")]
        public int idReserva { get; set; }
        public Reserva? Reserva { get; set; }

        
    }
}
