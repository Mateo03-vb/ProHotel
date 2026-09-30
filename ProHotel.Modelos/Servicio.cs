using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHotel.Modelos
{
    [Table("servicios")]
    public class Servicio
    {
        [Key]
        [Column("id_servicio")]
        public int idServicio { get; set; }

        [Column("nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100)]
        public string nombre { get; set; }

        [Column("descripcion")]
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [MaxLength(255)]
        public string descripcion { get; set; }

        [Column("precio", TypeName = "numeric(10,2)")]
        [Required(ErrorMessage = "El precio es obligatorio")]
        public decimal precio { get; set; }
    }
}
