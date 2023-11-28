using Business.Contract;
using Common.Helpers;
using Common.Utilities.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_sqlLite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurnosController : ControllerBase
    {
        #region Propierties
        private readonly ITurnosServices Service;
        private readonly ILogger<TurnosController> _logger;
        private readonly IConfiguration _config;
        #endregion

        #region Constructor
        public TurnosController(ITurnosServices service, IConfiguration config)
        {
            Service = service;            
            _config = config;
        }
        #endregion


        [HttpPost]
        [Route("CrearTurno")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> CrearTurno(TurnosDto turnosDto)
        {
            Response<bool> response;
            try
            {
                response = await Service.CrearTurno(turnosDto, _config.GetValue<string>("ConnectionStrings:defaultConnection"));
                return response;
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }


        [HttpGet]
        [Route("GetTurnos")]
        [ProducesResponseType(typeof(Response<List<dynamic>>), StatusCodes.Status200OK)]
        public async Task<Response<List<dynamic>>> GetTurnos()
        {
            Response<List<dynamic>> response;
            try
            {
                response = await Service.GetTurnos(_config.GetValue<string>("ConnectionStrings:defaultConnection"));
                return response;
            }
            catch (Exception ex)
            {
                return new Response<List<dynamic>>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        /// <summary>
        /// Obtiene recursos según la fecha proporcionada.
        /// </summary>
        /// <param name="fecha">DD/MM/YYYY</param>
        /// <returns>Los turnos de la fecha indicada.</returns>
        [HttpGet]
        [Route("GetTurnosporFecha")]
        [ProducesResponseType(typeof(Response<List<dynamic>>), StatusCodes.Status200OK)]
        public async Task<Response<List<dynamic>>> GetTurnosByFecha(String fecha)
        {
            Response<List<dynamic>> response;
            try
            {
                response = await Service.GetTurnoByFecha(Convert.ToDateTime(fecha), _config.GetValue<string>("ConnectionStrings:defaultConnection"));
                return response;
            }
            catch (Exception ex)
            {
                return new Response<List<dynamic>>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

    }
}
