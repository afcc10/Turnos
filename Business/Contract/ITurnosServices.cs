using Common.Utilities.Services;
using DataAccess.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract
{
    public interface ITurnosServices
    {
        Task<Response<List<dynamic>>> GetTurnos(string connectionString);


        Task<Response<bool>> CrearTurno(TurnosDto turno, string ConnectionStrings);

        Task<Response<List<dynamic>>> GetTurnoByFecha(DateTime fechaTurno, string connectionString);
      
    }
}
