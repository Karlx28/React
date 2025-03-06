using reactBackend.Repository;

AlumnoDAO alumnoDAO = new reactBackend.Repository.AlumnoDAO();
var alumno = alumnoDAO.SelectAll();
foreach (var item in alumno)
{
    Console.WriteLine(item.Nombre);
}

Console.WriteLine(" ");
#region SelectById
var selectById = alumnoDAO.GetById(1000);
Console.WriteLine(selectById?.Nombre);
#endregion
