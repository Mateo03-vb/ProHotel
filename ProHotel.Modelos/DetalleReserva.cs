using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHotel.Modelos
{
    [Table("detalles_reserva")]
    public class DetalleReserva
    {
        [Key]
        [Column("id_detalle_reserva")]
        public int IdDetalleReserva { get; set; }
                
        [Column("precio_noche_pactado")]
        [Required(ErrorMessage = "El precio por noche es obligatorio")]
        public decimal PrecioNochePactado { get; set; }

        //foraneas
        [ForeignKey("Reserva")]
        [Column("id_reserva")]
        public int idReserva { get; set; }
       

        [ForeignKey("Habitacion")]
        [Column("id_habitacion")]
        public int idHabitacion { get; set; }
        

        //objetos de navegacion
        public Reserva? Reserva { get; set; }
        public Habitacion? Habitacion { get; set; }

        //relaciones
        public List<Consumo>? Consumos { get; set; } = new List<Consumo>();
    }
}
