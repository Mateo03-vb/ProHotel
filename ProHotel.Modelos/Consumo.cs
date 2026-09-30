using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHotel.Modelos
{
    [Table("consumos")]
    public class Consumo
    {
        [Key]
        [Column("id_consumo")]
        public int idConsumo { get; set; }
           
        [Column("cantidad")]
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public int cantidad { get; set; }

        [Column("precio_unitario", TypeName = "numeric(10,2)")]
        [Required(ErrorMessage = "El precio unitario es obligatorio")]
        public decimal precioUnitario { get; set; }

        [Column("fecha_consumo", TypeName = "date")]
        public DateTime fechaConsumo { get; set; }

        //foraneas
        [ForeignKey("DetalleReserva")]
        [Column("id_detalle_reserva")]
        public int idDetalleReserva { get; set; }
        

        [ForeignKey("Servicio")]
        [Column("id_servicio")]
        public int idServicio { get; set; }
        

        //objetos de navegacion
        public DetalleReserva? DetalleReserva { get; set; }
        public Servicio? Servicio { get; set; }
    }
}
