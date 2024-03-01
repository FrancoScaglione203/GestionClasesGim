using GestionClasesGim.DataAccess.Repositories.Interfaces;
using GestionClasesGim.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace GestionClasesGim.DataAccess.Repositories
{
    public class ClaseRepository : Repository<Clase>, IClaseRepository
    {
        public ClaseRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Validacin si ya existe una clase con la fecha y hora que se ingresa por parametro
        /// </summary>
        /// <param name="fechaHora"></param>
        /// <returns>retorna Null si no coincide con ninguna clase o retorna la clase que tiene esa fecha y horario</returns>
        public async Task<bool> HorarioOcup(DateTime fechaHora)
        {

            return await _context.Clases.AnyAsync(x =>
            x.FechaHorario.Year == fechaHora.Year &&
            x.FechaHorario.Month == fechaHora.Month &&
            x.FechaHorario.Day == fechaHora.Day &&
            x.FechaHorario.Hour == fechaHora.Hour);

        }


        /// <summary>
        /// Funcion que recorre toda las clases con Active=true y valida si la fecha y hora ya pasaron, si ya paso active=false
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Actualizacion()
        {
            var now = DateTime.Now;
            var clases = await _context.Clases.Where(x => x.Activo == true).ToListAsync();
            foreach (var clase in clases)
            {
                if (clase.FechaHorario >= now)
                {
                    clase.Activo = false;
                    _context.Clases.Update(clase);
                }
            }
            return true;
        }

        /// <summary>
        /// devuelve todas las clases con active=true
        /// </summary>
        /// <returns></returns>
        public async Task<List<Clase>> GetAll()
        {
            var clases = await _context.Clases.Where(x => x.Activo == true).ToListAsync();
            return clases;
        }

        /// <summary>
        /// Actualiza la clase que tiene el id de la Clase enviada por parametro
        /// </summary>
        /// <param name="updateAlumno"></param>
        /// <returns>Retorna true si se actualizo o false si hubo algun error</returns>
        public override async Task<bool> Update(Clase updateClase)
        {
            var clase = await _context.Clases.FirstOrDefaultAsync(x => x.Id == updateClase.Id);
            if (clase == null) { return false; }

            clase.Nombre = updateClase.Nombre;
            clase.FechaHorario = updateClase.FechaHorario;
            clase.CapacidadMax = updateClase.CapacidadMax;
            clase.Cupos = updateClase.Cupos;
            clase.imagenUrl = updateClase.imagenUrl;
            clase.Activo = updateClase.Activo;

            _context.Clases.Update(clase);
            return true;
        }

        /// <summary>
        /// Cambia Activo=false de la calse ingresada por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteLogico(int id)
        {
            var clase = await _context.Clases.FirstOrDefaultAsync(x => x.Id == id);
            if (clase == null) { return false; }

            clase.Activo = false;

            _context.Clases.Update(clase);
            return true;
        }


        /// <summary>
        /// Inscribe al alumno en la clase generando un historial del tipoMov Inscrip y modificando la propiedad cupos de la clase
        /// </summary>
        /// <param name="idClase"></param>
        /// <param name="idAlumno"></param>
        /// <returns>Retorna false si no hay clase con el id ingresado o si la cantidad de cupos alcanzo la capacidad max, true si salio todo bien</returns>
        public async Task<bool> Inscripcion(int idClase, int idAlumno)
        {
            var clase = await _context.Clases.FirstOrDefaultAsync(x => x.Id == idClase);
            if (clase == null) { return false; }


            if (clase.Cupos == clase.CapacidadMax) { return false; } //VALIDACION SI LA CLASE TIENE CUPOS

            clase.Cupos++;
            Historial historial = new Historial(idAlumno, idClase, 1);

            _context.Historiales.Add(historial);
            _context.Clases.Update(clase);
            return true;
        }


        /// <summary>
        /// Cancela Inscripciom del alumno en la clase generando un historial del tipoMov Cancelacion y modificando la propiedad cupos de la clase
        /// </summary>
        /// <param name="idClase"></param>
        /// <param name="idAlumno"></param>
        /// <returns></returns>
        public async Task<bool> Cancelacion(int idClase, int idAlumno)
        {
            var clase = await _context.Clases.FirstOrDefaultAsync(x => x.Id == idClase);
            if (clase == null) { return false; }


            //VALIDACION SI EL ALUMNO ESTA ANOTADO


            if (clase.Cupos == 0) { return false; } //VALIDACION SI LA CLASE TIENE CUPOS ANOTADOS

            clase.Cupos--;
            Historial historial = new Historial(idAlumno, idClase, 2);

            _context.Historiales.Add(historial);
            _context.Clases.Update(clase);
            return true;
        }


        /// <summary>
        /// Muestra las clases en las cual se anoto el alumno con el id ingresado por parametro
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns></returns>
        public async Task<List<Clase>> GetAllByIdAlumno(int idAlumno)
        {

            var clases = await _context.Clases.Where(x => x.Activo == true).ToListAsync();
            var historiales = await _context.Historiales.Where(x => x.UsuarioId == idAlumno).ToListAsync();
            List<Clase> listaClases = new List<Clase>();
            HashSet<int> clasesIds = new HashSet<int>();
            foreach (Clase clase in clases)
            {
                clasesIds.Add(clase.Id);
            }

            foreach (int claseId in clasesIds)
            {
                bool inscrip = true;
                bool controlId = false;
                foreach (var historial in historiales)
                {
                    if (claseId == historial.ClaseId && historial.TipoMovId == 2)
                    {
                        inscrip = false;
                    }
                    if (claseId == historial.ClaseId && historial.TipoMovId == 1 && controlId == false)
                    {
                        inscrip = true;
                        controlId = true;
                    }
                }

                if (inscrip == true && controlId == true)
                {
                    Clase clase = clases.FirstOrDefault(clase => clase.Id == claseId);
                    listaClases.Add(clase);
                }
            }

            return listaClases;

        }

        /// <summary>
        /// Muestra las clases en las cuales el alumno con el id ingresado por parametro no esta inscripto
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns></returns>
        public async Task<List<Clase>> GetClasesRestantesByIdAlumno(int idAlumno)
        {

            //var clases = await _context.Clases.Where(x => x.Activo == true).ToListAsync();
            var historiales = await _context.Historiales.Where(x => x.UsuarioId == idAlumno).ToListAsync();
            List<Clase> clases = await _context.Clases.Where(x => x.Activo == true).ToListAsync();
            HashSet<int> clasesIds = new HashSet<int>();
            foreach (Clase clase in clases)
            {
                clasesIds.Add(clase.Id);
            }

            foreach (int claseId in clasesIds)
            {
                bool inscrip = true;
                bool controlId = false;
                foreach (var historial in historiales)
                {
                    if (claseId == historial.ClaseId && historial.TipoMovId == 2)
                    {
                        inscrip = false;
                    }
                    if (claseId == historial.ClaseId && historial.TipoMovId == 1 && controlId == false)
                    {
                        inscrip = true;
                        controlId = true;
                    }
                }

                if (inscrip == true && controlId == true)
                {
                    Clase clase = clases.FirstOrDefault(clase => clase.Id == claseId);
                    clases.Remove(clase);
                }
            }

            return clases;

        }

    }
}
