using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioEvaluacion : RepositorioBase<Evaluaciones>
    {
        // METODO MODIFICAR
        public override bool Modificar(Evaluaciones entity)
        {
            bool paso = false;
            Evaluaciones Anterior = Buscar(entity.EvaluacionID);
            Contexto contexto = new Contexto();
            try
            {
                using (Contexto baseDatos = new Contexto())
                {
                    foreach (var item in Anterior.DetalleEvaluaciones.ToList())
                    {
                        if (!entity.DetalleEvaluaciones.Exists(x => x.DetalleID == item.DetalleID))
                        {
                            baseDatos.Entry(item).State = EntityState.Deleted;
                        }
                    }
                    baseDatos.SaveChanges();
                }
                foreach (var item in entity.DetalleEvaluaciones)
                {
                    var estado = EntityState.Unchanged;
                    if (item.DetalleID == 0)
                        estado = EntityState.Added;
                    contexto.Entry(item).State = estado;
                }
                contexto.Entry(entity).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        // METODO BUSCAR
        public override Evaluaciones Buscar(int id)
        {
            Evaluaciones Evaluacion = new Evaluaciones();
            Contexto contexto = new Contexto();
            try
            {
                Evaluacion = contexto.Evaluacion.Include(x => x.DetalleEvaluaciones).Where(x => x.EvaluacionID == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Evaluacion;
        }
    }
}
