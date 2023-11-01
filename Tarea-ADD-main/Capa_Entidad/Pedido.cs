using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class Pedido
    {
        public int IdPedido {  get; set; }
        public DateTime Fecha { get; set; }
        public string NombreCliente {  get; set; }
        public int MontoPedido {  get; set; }
        public string Distrito {  get; set; }

    }
}
