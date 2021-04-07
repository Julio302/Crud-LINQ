using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DL;
namespace BL
{
    public class Alumno
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (var db = new DL.JFernandezAlumnosDigiProEntities())
                {
                    var query = (from d in db.Alumnos
                                 select new
                                 {
                                     d.idAlumno,
                                     d.nombre,
                                     d.apellidoPaterno,
                                     d.apellidoMaterno
                                 });

                    result.Objects = new List<object>();
                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var item in query)
                        {
                            ML.Alumno oalumno = new ML.Alumno();
                            oalumno.IdAlumno = item.idAlumno;
                            oalumno.Nombre = item.nombre;
                            oalumno.ApellidoPaterno = item.apellidoPaterno;
                            oalumno.ApellidoMaterno = item.apellidoMaterno;
                            result.Objects.Add(oalumno);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error en " + e.Message;
            }
            return result;
        }

        public static ML.Result GetByIdLQ(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (var bd = new DL.JFernandezAlumnosDigiProEntities())
                {
                    var query = (from p in bd.Alumnos.ToList()
                                 where p.idAlumno == IdAlumno
                                 select p).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Alumno oalumno = new ML.Alumno();
                        oalumno.IdAlumno = query.idAlumno;
                        oalumno.Nombre = query.nombre;
                        oalumno.ApellidoPaterno = query.apellidoPaterno;
                        oalumno.ApellidoMaterno = query.apellidoMaterno;
                        result.Object = oalumno;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error en " + e.Message;
            }
            return result;
        }
        public static ML.Result Add(ML.Alumno Alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (var bd = new DL.JFernandezAlumnosDigiProEntities())
                {
                    DL.Alumno oalumno = new DL.Alumno();
                    oalumno.nombre = Alumno.Nombre;
                    oalumno.apellidoPaterno = Alumno.ApellidoPaterno;
                    oalumno.apellidoMaterno = Alumno.ApellidoMaterno;
                    bd.Alumnos.Add(oalumno);
                    bd.SaveChanges();
                    result.Correct = true;
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error en " + e.Message;
            }
            return result;
        }

        public static ML.Result Update(ML.Alumno Alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (var bd = new DL.JFernandezAlumnosDigiProEntities())
                {
                    var query = (from p in bd.Alumnos
                                 where p.idAlumno == Alumno.IdAlumno
                                 select p).First();

                    if (query != null)
                    {
                        query.idAlumno = Alumno.IdAlumno;
                        query.nombre = Alumno.Nombre;
                        query.apellidoPaterno = Alumno.ApellidoPaterno;
                        query.apellidoMaterno = Alumno.ApellidoMaterno;
                        bd.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error en " + e.Message;
            }
            return result;
        }

        public static ML.Result Delete(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (var bd = new DL.JFernandezAlumnosDigiProEntities())
                {
                    var query = (from p in bd.Alumnos
                                 where p.idAlumno == IdAlumno
                                 select p).First();
                    bd.Alumnos.Remove(query);
                    bd.SaveChanges();
                    result.Correct = true;
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error en " + e.Message;
            }
            return result;
        }
    }
}
