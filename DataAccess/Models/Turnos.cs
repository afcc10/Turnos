using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("Turnos")]
    public class Turnos
    {
        [Key]
        [Column("id_turno")]
        public int Id { get; set; }
        
        [Column("id_servicio")]
        public int ID_Servicio { get; set; }

        [Column("fecha_turno")]
        public DateTime FechaTurno { get; set; }

        [Column("hora_inicio")]
        public TimeSpan HoraInicio { get; set; }

        [Column("hora_fin")]
        public TimeSpan HoraFin { get; set; }

        [Column("estado")]
        public int Estado { get; set; }
    }
}
