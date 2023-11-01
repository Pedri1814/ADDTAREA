using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;

namespace Capa_Datos
{
    public class CD_Pedido
    {
        public List<Pedido> Listar()
        {
            List<Pedido> lista = new List<Pedido>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select IdPedido,Fecha,NombreCliente,MontoPedido,Distrito from PEDIDO");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Pedido()
                            {
                                IdPedido = Convert.ToInt32(dr["IdPedido"]),
                                Fecha = Convert.ToDateTime(dr["Fecha"]),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                MontoPedido = Convert.ToInt32(dr["MontoPedido"]),
                                Distrito = dr["Distrito"].ToString(),
                            });
                            
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Pedido>();
                }
            }
            return lista;
        }
        public int Registrar(Pedido obj, out string Mensaje)
        {
            int idPedidogenerado = 0; 
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {



                    SqlCommand cmd = new SqlCommand("SP_RegistrarPedido", oconexion);
                    cmd.Parameters.AddWithValue("Fecha", obj.Fecha);
                    cmd.Parameters.AddWithValue("NombreCliente", obj.NombreCliente);
                    cmd.Parameters.AddWithValue("MontoPedido", obj.MontoPedido);
                    cmd.Parameters.AddWithValue("Distrito", obj.Distrito);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    idPedidogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idPedidogenerado = 0;
                Mensaje = ex.Message;
            }



            return idPedidogenerado;
        }
    }
}
