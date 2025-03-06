using reactBackend.Models;
using reactBackend.Repository;
using System.ComponentModel.DataAnnotations;

AlumnoDAO alumnoDAO = new reactBackend.Repository.AlumnoDAO();
var alumno = alumnoDAO.SelectAll();
foreach (var item in alumno)
{
    Console.WriteLine(item.Nombre);
}

Console.WriteLine(" ");

#region SelectById
var selectById = alumnoDAO.GetById(1);
Console.WriteLine(selectById?.Nombre);
#endregion

Console.WriteLine(" ");

#region addAlumno
var nuevoAlumno = new Alumno
{

    Direccion = "Chalatenango, Barrio el centro",
    Dni = "1345",
    Edad = 30,
    Email = "12344321@email",
    Nombre = "Ricardo JR Milos"
};

var resultado = alumnoDAO.insertarAlumno(nuevoAlumno);
Console.WriteLine(resultado);
#endregion

#region updateAlumno
var nuevoAlumno2 = new Alumno
{
    Direccion = "Chalatenango, Barrio el centro",
    Dni = "1345",
    Edad = 30,
    Email = "5@email",
    Nombre = "Wiliams"
};

var resultado2 = alumnoDAO.update(2, nuevoAlumno2);
Console.WriteLine(resultado2);
#endregion

#region borrar
var result = alumnoDAO.deleteAlumno(1);
Console.WriteLine("Se elimino " + result);
#endregion