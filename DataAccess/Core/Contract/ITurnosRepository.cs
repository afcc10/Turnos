using Common.Utilities.Services;
using DataAccess.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Contract
{
    public interface ITurnosRepository
    {
        Task<Response<List<dynamic>>> GetTurnos(string connectionString);

        Task<Response<bool>> CrearTurnos(TurnosDto turnos, string connectionString);

        Task<Response<List<dynamic>>> GetTurnoByFecha(DateTime fechaTurno, string connectionString);
        
    }
}
