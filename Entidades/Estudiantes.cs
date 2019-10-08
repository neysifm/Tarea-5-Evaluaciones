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
        public int EstudianteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal PuntosPerdidos { get; set; }
        public DateTime Fecha { get; set; }

        public Estudiantes(int estudianteId, string nombre, string apellido, decimal puntosPerdidos, DateTime fecha)
        {
            EstudianteId = estudianteId;
            Nombre = nombre;
            Apellido = apellido;
            PuntosPerdidos = puntosPerdidos;
            Fecha = fecha;
        }

        public Estudiantes()
        {
            EstudianteId = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            PuntosPerdidos = 0;
            Fecha = DateTime.Now;
        }

    }
}
