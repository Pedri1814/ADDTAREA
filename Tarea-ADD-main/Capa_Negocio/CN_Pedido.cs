using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class CN_Pedido
    {
        private CD_Pedido objcd_Pedido = new CD_Pedido();
        public List<Pedido> Listar()
        {
            return objcd_Pedido.Listar();
        }

        public int Registrar(Pedido obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.NombreCliente == "")
            {
                Mensaje += "Es necesario ingresar el nombre completo del Cliente\n";
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
