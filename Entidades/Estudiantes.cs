using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Estudiantes
    {
        [Key]
        public int EstudianteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [NotMapped]
        public string NombreCompleto
        {
            get { return $"{Nombre} {Apellido}"; }
        }
        public decimal PuntosPerdidos { get; set; }
        public DateTime Fecha { get; set; }

        public Estudiantes(int estudianteID, string nombre, string apellido, decimal puntosPerdidos, DateTime fecha)
        {
            EstudianteID = estudianteID;
            Nombre = nombre;
            Apellido = apellido;
            PuntosPerdidos = puntosPerdidos;
            Fecha = fecha;
        }

        public Estudiantes()
        {
            EstudianteID = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            PuntosPerdidos = 0;
            Fecha = DateTime.Now;
        }
    }
}
