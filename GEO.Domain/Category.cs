using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEO.Domain
{
    public class Category

    {
        [Key] 
        public int CategoryID
        {
            get;
            set;
        }
        [Required(ErrorMessage ="El campo{0} es requerido")]
        public string Description
        {
            get;
            set;
        }
    }
}
