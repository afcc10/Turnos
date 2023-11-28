using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class TurnosDto
    {
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaFin { get; set; }
        
        public int IdServicio { get; set; }       
        
    }
}
