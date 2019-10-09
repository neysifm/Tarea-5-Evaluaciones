﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Evaluaciones
    {
        [Key]
        public int EvaluacionID { get; set; }
        public DateTime Fecha { get; set; }
        public int EstudianteID { get; set; }
        [ForeignKey("EstudianteID")]
        public virtual Estudiantes Estudiantes { get; set; }
        public decimal TotalPerdido { get; set; }
        public virtual List<DetalleEvaluaciones> DetalleEvaluaciones { get; set; }

        public Evaluaciones(int evaluacionID, DateTime fecha, int estudianteID, Estudiantes estudiantes, decimal totalPerdido)
        {
            EvaluacionID = evaluacionID;
            Fecha = fecha;
            EstudianteID = estudianteID;
            Estudiantes = estudiantes;
            TotalPerdido = totalPerdido;
            DetalleEvaluaciones = new List<DetalleEvaluaciones>();
        }

        public Evaluaciones()
        {
            EvaluacionID = 0;
            Fecha = DateTime.Now;
            EstudianteID = 0;
            TotalPerdido = 0;
            DetalleEvaluaciones = new List<DetalleEvaluaciones>();
        }

        public void AgregarDetalle(int detalleID, int evaluacionID, int categoriaID, decimal valor, decimal logrado, decimal perdido)
        {
            DetalleEvaluaciones.Add(new DetalleEvaluaciones(detalleID, evaluacionID, categoriaID, valor, logrado, perdido));
        }

        public void RemoverDetalle(int Eliminar)
        {
            this.DetalleEvaluaciones.RemoveAt(Eliminar);
        }
    }
}
