using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Entidades
{
    public static class Utilidades
    {
        public static int ToInt(this string entero)
        {
            if (entero == null)
                return 0;
            int.TryParse(entero, out int valor);
            return valor;
        }
        public static decimal ToDecimal(this string decimales)
        {
            Decimal.TryParse(decimales, out decimal valor);
            return valor;
        }
        public static void ShowToastr(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
            String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }
    }
}
