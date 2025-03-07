using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reactBackend.Models;
using reactBackend.Repository;

namespace WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CalificationController : ControllerBase
    {
        private CalificacionDAO _cdao = new CalificacionDAO();

        #region Lista de Calificaciones
        [HttpGet("calificaciones")]

        public List<Calificacion> get(int idMatricula)
        {
            return _cdao.seleccion(idMatricula);
        }
        #endregion

        #region Ingresar Datos
        [HttpPost("calificacion")]
        public bool insertar([FromBody] Calificacion calificacion)
        {
            return _cdao.insertar(calificacion);
        }
        #endregion
    }
}
