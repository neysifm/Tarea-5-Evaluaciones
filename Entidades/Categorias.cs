﻿using System;
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
        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }
        public decimal PromedioPerdida { get; set; }
        public DateTime Fecha { get; set; }

        public Categorias(int categoriaId, string descripcion, decimal promedioPerdida, DateTime fecha)
        {
            CategoriaId = categoriaId;
            Descripcion = descripcion;
            PromedioPerdida = promedioPerdida;
            Fecha = fecha;
        }

        public Categorias()
        {
            CategoriaId = 0;
            Descripcion = string.Empty;
            PromedioPerdida = 0;
            Fecha = DateTime.Now;
        }
    }
}
