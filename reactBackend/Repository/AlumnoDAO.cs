using reactBackend.Context;
using reactBackend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactBackend.Repository
{
    public class AlumnoDAO
    {
        #region Contex
        public RegistroAlumnoContext contexto = new RegistroAlumnoContext();
        #endregion

        #region Select All
        public List<Alumno> SelectAll()
        {
            var alumno = contexto.Alumnos.ToList<Alumno>();
            return alumno;
        }
        #endregion

        #region Seleccionamos por ID
        public Alumno? GetById(int id)
        {
            var alumno = contexto.Alumnos.Where(x => x.Id == id).FirstOrDefault();
            return alumno == null ? null : alumno;
        }

        #endregion

        public bool insertarAlumno(Alumno alumno)
        {
            try
            {
                var alum = new Alumno
                {
                    Direccion = alumno.Direccion,
                    Edad = alumno.Edad,
                    Email = alumno.Email,
                    Dni = alumno.Dni
                };
                contexto.Alumnos.Add(alum);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #region update alumno
        public bool update(int id, Alumno actualizar)
        {
            try
            {
                var alumnoUpdate = GetById(id);

                if (actualizar == null)
                {
                    Console.WriteLine("Alumno es null");
                    return false;
                }
                alumnoUpdate.Direccion = actualizar.Direccion;
                alumnoUpdate.Dni = actualizar.Dni;
                alumnoUpdate.Nombre = actualizar.Nombre;
                alumnoUpdate.Email = actualizar.Email;

                contexto.Alumnos.Update(alumnoUpdate);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;

            }
            #endregion
        }

        #region Delete 
        public bool deleteAlumno(int id)
        {
            var borrar = GetById(id);
            try
            {
                if (borrar == null)
                {
                    return false;
                }
                else
                {
                    contexto.Alumnos.Remove(borrar);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }
        #endregion

        #region LeftJoin
        public List<AlumnoAsignatura> SelectAlumAsig()
        {
            var consulta = from a in contexto.Alumnos
                           join m in contexto.Matriculas on a.Id equals m.AlumnoId
                           join asig in contexto.Asignaturas on m.Id equals asig.Id
                           select new AlumnoAsignatura
                           {
                               nombreAlumno = a.Nombre,
                               nombreAsignatura = asig.Nombre
                           };

            return consulta.ToList();
        }
        #endregion

        #region LeftJoinAlumnoMatriculaMateria
        public List<AlumnoProfesor> alumnoProfesors(string nombreProfesor)
        {
            var listadoALumno = from a in contexto.Alumnos
                                join m in contexto.Matriculas on a.Id equals m.AlumnoId
                                join asig in contexto.Asignaturas on m.AsignaturaId equals asig.Id
                                where asig.Profesor == nombreProfesor
                                select new AlumnoProfesor
                                {
                                    Id = a.Id,
                                    Dni = a.Dni,
                                    Nombre = a.Nombre,
                                    Direccion = a.Direccion,
                                    Edad = a.Edad,
                                    Email = a.Email,
                                    asignatura = asig.Nombre
                                };

            return listadoALumno.ToList();
        }
        #endregion

        #region SelccionarPorDni
        public Alumno DNIAlumno(Alumno alumno)
        {
            var alumnos = contexto.Alumnos.Where(x => x.Dni == alumno.Dni).FirstOrDefault();
            return alumnos == null ? null : alumnos;
        }
        #endregion

        #region Insertar Matricula
        public bool InsertarMatricula(Alumno alumno, int idAsing)
        {
            try
            {

                var alumnoDNI = DNIAlumno(alumno);
                if (alumnoDNI == null)
                {
                    insertarAlumno(alumno);
                    var alumnoInsertado = DNIAlumno(alumno);
                    var unirAlumnoMatricula = matriculaAsignaturaAlumno(alumno, idAsing);
                    if (unirAlumnoMatricula == false)
                    {
                        return false;
                    }

                    return true;
                }
                else
                {
                    matriculaAsignaturaAlumno(alumnoDNI, idAsing);
                    return true;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

        #region Matriucla
        public bool matriculaAsignaturaAlumno(Alumno alumno, int idAsignatura)
        {
            try
            {
                Matricula matricula = new Matricula();
                matricula.AlumnoId = alumno.Id;
                matricula.AsignaturaId = idAsignatura;
                contexto.Matriculas.Add(matricula);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

    }
}
