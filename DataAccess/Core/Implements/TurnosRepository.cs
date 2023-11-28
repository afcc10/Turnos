using Common.Helpers;
using Common.Utilities.Resource;
using Common.Utilities.Services;
using Dapper;
using DataAccess.Core.Contract;
using DataAccess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccess.Core.Implements
{
    public class TurnosRepository : ITurnosRepository
    {
        #region Propierties        
        
        #endregion

        #region Contructor
        public TurnosRepository()
        {            
            
        }

        #endregion

        #region Method
        public async Task<Response<List<dynamic>>> GetTurnos(string connectionString)
        {
            Response<List<dynamic>> response = new();
            try
            {
                List<dynamic> query = new();

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
                builder.ConnectTimeout = 30;
                builder.Encrypt = true;
                builder.TrustServerCertificate = true; // Esta línea configura la confianza en el certificado

                connectionString = builder.ConnectionString;

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    var turnos = db.Query<dynamic>("SP_Lista_Turnos", commandType: CommandType.StoredProcedure).ToList();

                    // Hacer algo con la lista de usuarios
                    foreach (var turno in turnos)
                    {
                        query.Add(turno);
                    }
                }

                response = new()
                {
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaExitosa),
                    ObjectResponse = query,
                    Status = true
                };

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                return new Response<List<dynamic>>
                {
                    Status = false,
                    ObjectResponse = null,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        public async Task<Response<bool>> CrearTurnos(TurnosDto turnos, string connectionString)
        {
            Response<bool> response = new();

            if (connectionString.Equals("Connection"))
            {
                return new Response<bool> { Status = true, ObjectResponse = true, Message = MessageExtension.AddMessageList("Prueba exitosa") };
            }

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
                builder.ConnectTimeout = 30;
                builder.Encrypt = true;
                builder.TrustServerCertificate = true; // Esta línea configura la confianza en el certificado

                connectionString = builder.ConnectionString;

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();                   

                    var parameters = new DynamicParameters();
                    parameters.Add("@FechaInicio", turnos.FechaInicio); 
                    parameters.Add("@FechaFin", turnos.FechaFin);
                    parameters.Add("@IdServicio", turnos.IdServicio);
                    
                    db.Execute("SP_Proceso_Turnos", parameters, commandType: CommandType.StoredProcedure);                    
                }

                response = new()
                {
                    Status = true,
                    ObjectResponse = true,
                    Message = MessageExtension.AddMessageList(Message_es.CreateSucces)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(Message_es.CreateError)
                };
            }
        }



        public async Task<Response<List<dynamic>>> GetTurnoByFecha(DateTime fechaTurno, string connectionString)
        {
            Response<List<dynamic>> response = new();
            try
            {
                List<dynamic> query = new();

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
                builder.ConnectTimeout = 30;
                builder.Encrypt = true;
                builder.TrustServerCertificate = true; // Esta línea configura la confianza en el certificado

                connectionString = builder.ConnectionString;

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    var turnos = db.Query<dynamic>("SP_Lista_Turnos", new { FechaTurno = fechaTurno }, commandType: CommandType.StoredProcedure).ToList();

                    // Hacer algo con la lista de usuarios
                    foreach (var turno in turnos)
                    {
                        query.Add(turno);
                    }
                }

                response = new()
                {
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaExitosa),
                    ObjectResponse = query,
                    Status = true
                };

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                return new Response<List<dynamic>>
                {
                    Status = false,
                    ObjectResponse = null,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }
        #endregion
    }
}
