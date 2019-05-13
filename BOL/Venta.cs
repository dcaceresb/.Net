using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    [Serializable]
    public class Venta
    {
        public String Codigo { get; set; }
        public String Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int precioUnitario { get; set; }
        public int precioTotal { get; set; }

        public void CalculaPrecioTotal()
        {
            precioTotal = Cantidad * precioUnitario;
        }
    }
}
