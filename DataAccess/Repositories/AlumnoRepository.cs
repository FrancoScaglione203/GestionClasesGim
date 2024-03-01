using GestionClasesGim.DataAccess.Repositories.Interfaces;
using GestionClasesGim.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionClasesGim.DataAccess.Repositories
{
    public class AlumnoRepository : Repository<Alumno>, IAlumnoRepository
    {
        public AlumnoRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Actualiza el usuario con el id de updateUsuario por el mismo 
        /// </summary>
        /// <param name="updateAlumno"></param>
        /// <returns>Retorna true si se actualizo o false si hubo algun error</returns>
        public override async Task<bool> Update(Alumno updateAlumno)
        {
            var alumno = await _context.Alumnos.FirstOrDefaultAsync(x => x.Id == updateAlumno.Id);
            if (alumno == null) { return false; }

            alumno.Nombre = updateAlumno.Nombre;
            alumno.Apellido = updateAlumno.Apellido;
            alumno.RoleId = updateAlumno.RoleId;
            alumno.Dni = updateAlumno.Dni;
            alumno.Clave = updateAlumno.Clave;
            alumno.imagenUrl = updateAlumno.imagenUrl;
            alumno.Activo = updateAlumno.Activo;

            _context.Alumnos.Update(alumno);
            return true;
        }

        /// <summary>
        /// Cambia Activo=false del Alumno con el id enviado por parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteLogico(int id)
        {
            var alumno = await _context.Alumnos.FirstOrDefaultAsync(x => x.Id == id);
            if (alumno == null) { return false; }

            alumno.Activo = false;

            _context.Alumnos.Update(alumno);
            return true;
        }

        /// <summary>
        /// Retorna lista de Alumnos que se inscribieron en la clase con el id ingresado por parametro
        /// </summary>
        /// <param name="idClase"></param>
        /// <returns></returns>
        public async Task<List<Alumno>> GetAllByIdClase(int idClase) 
        {
            var alumnos = await _context.Alumnos.Where(x => x.Activo == true).ToListAsync();
            var historiales = await _context.Historiales.Where(x=>x.ClaseId == idClase).ToListAsync();
            List<Alumno> listaAlumnos = new List<Alumno>();
            HashSet<int> alumnosIds = new HashSet<int>();
            foreach (var historial in historiales)
            {

                alumnosIds.Add(historial.UsuarioId);
            }

            foreach (int alumnoId in alumnosIds) 
            {
                bool inscrip = true;
                foreach (var historial in historiales)
                {
                    if(alumnoId == historial.UsuarioId && historial.TipoMovId == 2) 
                    {
                        inscrip = false;
                    }
                    if (alumnoId == historial.UsuarioId && historial.TipoMovId == 1 && inscrip == false)
                    {
                        inscrip = true;
                    }
                }

                if (inscrip) 
                {
                    Alumno alumno = alumnos.FirstOrDefault(alumno => alumno.Id == alumnoId);
                    listaAlumnos.Add(alumno);
                }
            }

            return listaAlumnos;

        }

        /// <summary>
        /// Retorna Alumno con el dni ingresado por parametro
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public async Task<Alumno> GetByDni(int dni)
        {
            Alumno alumnoreturn = new Alumno();
            var alumno = await _context.Alumnos.FirstOrDefaultAsync(x => x.Dni == dni);


            if (alumno == null)
            {
                return alumno;
            }
            else
            {
                alumnoreturn.Id = alumno.Id;
                alumnoreturn.Nombre = alumno.Nombre;
                alumnoreturn.Dni = alumno.Dni;
                alumnoreturn.Apellido = alumno.Apellido;
                alumnoreturn.RoleId = alumno.RoleId;
                alumnoreturn.Clave = alumno.Clave;
                alumnoreturn.FechaInscripcion = alumno.FechaInscripcion;
                alumnoreturn.imagenUrl = alumno.imagenUrl;
                alumnoreturn.Activo = alumno.Activo;
            }
            return alumnoreturn;
        }


        /// <summary>
        /// Retorna lista de alumnos con Active=true
        /// </summary>
        /// <returns></returns>
        public async Task<List<Alumno>> GetAllActivos()
        {
            var activeAlumnos = await _context.Alumnos.Where(x => x.Activo == true).ToListAsync();
            return activeAlumnos;
        }
    }
}
