using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHotel.Modelos
{
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        [Column("id_cliente")]
        public int idCliente { get; set; }

        [Column("tipo_documento")]
        [Required(ErrorMessage = "El tipo de documento es obligatorio")]
        [MaxLength(10)]
        public string tipoDocumento { get; set; }

        [Column("numero_documento")]
        [Required(ErrorMessage = "El número de documento es obligatorio")]
        [MaxLength(20)]
        public string numeroDocumento { get; set; }

        [Column("nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50)]
        public string nombre { get; set; }

        [Column("apellido")]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        [MaxLength(50)]
        public string apellido { get; set; }

        [Column("email")]
        [Required(ErrorMessage = "El email es obligatorio")]
        [MaxLength(100)]
        public string email { get; set; }

        [Column("telefono")]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [MaxLength(20)]
        public string telefono { get; set; }
    }
}
