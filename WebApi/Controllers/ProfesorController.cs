using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reactBackend.Models;
using reactBackend.Repository;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private ProfesorDAO _proDao = new ProfesorDAO();
        [HttpPost("autenticacion")]
        public string loginProfesor([FromBody] Profesor prof)
        {
            var prof1 = _proDao.login(prof.Usuario, prof.Pass);
            if (prof1 != null)
            {
                return prof1.Usuario;
            }

            return "Elemento no encontrado";
        }
    }
}
