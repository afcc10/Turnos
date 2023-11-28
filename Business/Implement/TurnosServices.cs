using AutoMapper;
using Business.Contract;
using Common.Helpers;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implement
{
    public class TurnosServices : ITurnosServices
    {
        #region Propierties
        private readonly ITurnosRepository _turnoRepository;        
        #endregion

        #region Constructor
        public TurnosServices(ITurnosRepository turnoRepository)
        {
            _turnoRepository = turnoRepository;            
        }       


        #endregion

        public async Task<Response<bool>> CrearTurno(TurnosDto turnos, string ConnectionStrings)
        {
            Response<bool> response = new()
            {
                Status = true                
            };

            if (turnos.FechaFin < turnos.FechaInicio)
            {
                response.ObjectResponse = false;
                response.Status = false;
                response.Message = MessageExtension.AddMessageList("Rango de fechas invalidos");

            }
            if (string.IsNullOrEmpty(ConnectionStrings))
            {
                    response.ObjectResponse = false;
                    response.Status = false;
                    response.Message = MessageExtension.AddMessageList("No hay configurada una cadena de conexion");
            }

            if (!response.Status)
            {
                return response;
            }
            
            var result = await _turnoRepository.CrearTurnos(turnos, ConnectionStrings);
            return result;
        }

        public async Task<Response<List<dynamic>>> GetTurnoByFecha(DateTime fechaTurno, string connectionString)
        {
            var result = await _turnoRepository.GetTurnoByFecha(fechaTurno, connectionString);
            return result;
        }

        public async Task<Response<List<dynamic>>> GetTurnos(string connectionString)
        {
            var result = await _turnoRepository.GetTurnos(connectionString);
            return result;
        }

        
    }
}
