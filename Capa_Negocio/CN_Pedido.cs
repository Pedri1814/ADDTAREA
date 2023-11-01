using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLDatos;
using CLEntidad;

namespace Negocio
{
    public class CNPedido
    {
        private CDPedido objcd_Pedido = new CDPedido();
        public List<Pedido> Listar()
        {
            return objcd_Pedido.Listar();
        }

        public int Registrar(Pedido obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.NombreCliente == "")
            {
                Mensaje += "Es necesario ingresar el nombre completo\n";
            }
            if (obj.MontoPedido == 0)
            {
                Mensaje += "Es necesario ingresar un monto superior a 0\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Pedido.Registrar(obj, out Mensaje);
            }
        }
    }
}
