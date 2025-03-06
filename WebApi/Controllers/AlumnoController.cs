using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reactBackend.Models;
using reactBackend.Repository;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private AlumnoDAO _dao = new AlumnoDAO();

        #region EndPointAlumnoProfesor
        [HttpGet("alumnoProfesor")]
        public List<AlumnoProfesor> GetAlumnoProfesor(string usuario)
        {
            return _dao.alumnoProfesors(usuario);
        }
        #endregion
    }

    #region selectByID
    [HttpGet("alumno")]
    public Alumno selectById(int id)
    {
        var alumno = _dao.GettById(id);
        return alumno;
    }
    #endregion

    #region Actualizar Datos
    [HttpPut("alumno")]
    public bool actualizarAlumno([FromBody] Alumno alumno)
    {
        return _dao.Update(alumno.Id, alumno);
    }
}
