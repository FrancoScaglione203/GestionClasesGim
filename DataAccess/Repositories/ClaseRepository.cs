using GestionClasesGim.DataAccess.Repositories.Interfaces;
using GestionClasesGim.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionClasesGim.DataAccess.Repositories
{
    public class ClaseRepository : Repository<Clase>, IClaseRepository
    {
        public ClaseRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Actualiza el usuario con el id de updateUsuario por el mismo 
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
            clase.Activo = updateClase.Activo;

            _context.Clases.Update(clase);
            return true;
        }

        public async Task<bool> DeleteLogico(int id)
        {
            var clase = await _context.Clases.FirstOrDefaultAsync(x => x.Id == id);
            if (clase == null) { return false; }

            clase.Activo = false;

            _context.Clases.Update(clase);
            return true;
        }

        public async Task<bool> Inscripcion(int idClase, int idAlumno)
        {
            var clase = await _context.Clases.FirstOrDefaultAsync(x => x.Id == idClase);
            if (clase == null) { return false; }

            
            //VALIDACION SI EL ALUMNO YA ESTA ANOTADO
           

            if (clase.Cupos == clase.CapacidadMax) { return false; } //VALIDACION SI LA CLASE TIENE CUPOS

            clase.Cupos++;
            Historial historial = new Historial(idAlumno, idClase, 1);

            _context.Historiales.Add(historial);
            _context.Clases.Update(clase);
            return true;
        }

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


        public async Task<List<Clase>> GetAllByIdAlumno(int idAlumno)
        {
            var clases = await _context.Clases.Where(x => x.Activo == true).ToListAsync();
            var historiales = await _context.Historiales.Where(x => x.UsuarioId == idAlumno).ToListAsync();
            List<Clase> listaClases = new List<Clase>();
            HashSet<int> clasesIds = new HashSet<int>();
            foreach (var historial in historiales)
            {
                clasesIds.Add(historial.ClaseId);
            }

            foreach (int claseId in clasesIds) 
            { 
                bool inscrip = true;
                foreach (var historial in historiales)
                {
                    if (claseId == historial.ClaseId && historial.TipoMovId == 2 && historial.UsuarioId == idAlumno)
                    {
                        inscrip = false;
                    }
                    if (claseId == historial.ClaseId && historial.TipoMovId == 1 && inscrip == false && historial.UsuarioId == idAlumno)
                    {
                        inscrip = true;
                    }
                }

                if (inscrip)
                {
                    Clase clase = clases.FirstOrDefault(clase => clase.Id == claseId);
                    listaClases.Add(clase);
                }
            }

            return listaClases;

        }

    }
}
