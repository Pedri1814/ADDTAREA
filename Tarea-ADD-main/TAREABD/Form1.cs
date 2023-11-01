using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;

namespace TAREABD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtmonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtnombrecompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Pedido objcliente = new Pedido()
            {
                IdPedido = Convert.ToInt32(txtid.Text),
                Fecha = DateTime.Parse(dtpFecha.Text),
                NombreCliente = txtnombrecompleto.Text,
                MontoPedido = int.Parse(txtmonto.Text),
                Distrito = cbdistrito.Text,
            };

            if (objcliente.IdPedido == 0)
            {
                int idpedidogenerado = new CN_Pedido().Registrar(objcliente, out mensaje);

                    dgvdata.Rows.Add(new object[] {
                "",
                idpedidogenerado,
                dtpFecha.Text,
                txtnombrecompleto.Text,
                txtmonto.Text,
                cbdistrito.Text
                 });
                Limpiar();
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {

                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    dtpFecha.Value = Convert.ToDateTime(dgvdata.Rows[indice].Cells["Fecha"].Value);
                    txtnombrecompleto.Text = dgvdata.Rows[indice].Cells["NombreCliente"].Value.ToString();
                    txtmonto.Text = dgvdata.Rows[indice].Cells["MontoPedido"].Value.ToString();
                    cbdistrito.Text = dgvdata.Rows[indice].Cells["Distrito"].Value.ToString();

                    
                }

            }
        }
        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtnombrecompleto.Text = "";
            txtmonto.Text = "";
            cbdistrito.Text = "";

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            List<Pedido> lista = new CN_Pedido().Listar();

            foreach (Pedido item in lista)
            {
                dgvdata.Rows.Add(new object[] {"",item.IdPedido,item.Fecha,item.NombreCliente,item.MontoPedido,item.Distrito,                   
                });
            }
        }

        private void dgvdata_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                if (e.Value is DateTime)
                {
                    e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
