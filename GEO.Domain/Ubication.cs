using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEO.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    class Ubication
    {
        [Key]
        public int UbicationId { get; set; }
        [Required(ErrorMessage ="El campo{0} es requerido.")]
        [MaxLength(50, ErrorMessage ="El campo {0} solo puede contener {1} máximo de caracteres.")]
        [Index("Ubication_Description_Index", IsUnique = true)]
        public string Description { get; set; }
        [MaxLength(100, ErrorMessage ="The field {1} characters lenght.")]
        public string Address { get; set; }
        [MaxLength(20, ErrorMessage ="The field {0} only can contain {1} characters lenght.")]
        public string Phone { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
