using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_commerce.Models
{
    public class Compras
    {
        public Int16 envioId { get; set; }
        [Required]
        public Int16 usuarioId { get; set; }
        [Required]
        public String direccion { get; set; }
        [Required]
        public String ciudad { get; set; }
        public Decimal costo { get; set; }
        [Required]
        public String tipoPago { get; set; }
    }
}