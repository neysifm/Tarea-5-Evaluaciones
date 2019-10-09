using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Categorias
    {
        [Key]
        public int CategoriaID { get; set; }
        public string Descripcion { get; set; }
        public decimal PromedioPerdida { get; set; }
        public DateTime Fecha { get; set; }

        public Categorias(int categoriaID, string descripcion, decimal promedioPerdida, DateTime fecha)
        {
            CategoriaID = categoriaID;
            Descripcion = descripcion;
            PromedioPerdida = promedioPerdida;
            Fecha = fecha;
        }

        public Categorias()
        {
            CategoriaID = 0;
            Descripcion = string.Empty;
            PromedioPerdida = 0;
            Fecha = DateTime.Now;
        }
    }
}
