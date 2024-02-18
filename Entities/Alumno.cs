using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GestionClasesGim.DTOs;
using GestionClasesGim.Helpers;

namespace GestionClasesGim.Entities
{
    public class Alumno : Usuario
    {

        public Alumno(AlumnoDto dto)
        {
            Nombre = dto.Nombre;
            Apellido = dto.Apellido;
            Dni = dto.Dni;
            RoleId = dto.RoleId;
            Clave = PasswordEncryptHelper.EncryptPassword(dto.Clave, dto.Dni); 
            Activo = true;
            FechaInscripcion = dto.FechaInscripcion;
        }

        public Alumno(AlumnoDto dto, int id)
        {
            Id = id;
            Nombre = dto.Nombre;
            Apellido = dto.Apellido;
            Dni = dto.Dni;
            RoleId = dto.RoleId;
            Clave = PasswordEncryptHelper.EncryptPassword(dto.Clave, dto.Dni);
            FechaInscripcion = dto.FechaInscripcion;
            Activo = true;
        }

        public Alumno()
        {

        }

        [Column("alumno_fechainscripcion", TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaInscripcion { get; set; }
    }
}
