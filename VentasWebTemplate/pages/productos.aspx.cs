using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_productos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BtnModificar.Enabled = false;
            BtnEliminar.Enabled = false;

        }

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Buscar();
    }

    public void Buscar()
    {
        List<BOL.Productos> prod = new List<BOL.Productos>();
        prod = DAL.DALProductos.ListarProductos();

        gridview1.DataSource = prod;
        gridview1.DataBind();
        BtnModificar.Enabled = false;
        BtnEliminar.Enabled = false;

    }

    protected void BtnGuardar_Click(object sender, EventArgs e)
    {

        string respuesta = "";
        BOL.Productos pr = new BOL.Productos();
        pr.Codigo = txtCodigo.Text;
        pr.Descripcion = txtDescripcion.Text;
        pr.Precio = int.Parse(txtprecio.Text);

        respuesta = DAL.DALProductos.IngresaProd(pr);

        if (respuesta == "ok")
        {
            Buscar();
            Limpiar();
            lblMensaje.Text = "Ingreso Correcto";

        }
        else
        {

            lblMensaje.Text = respuesta;
        }


    }

    protected void gridview1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row1 = gridview1.SelectedRow;


        int index = row1.RowIndex;

        txtCodigo.Text = gridview1.Rows[index].Cells[1].Text;
        txtDescripcion.Text = gridview1.Rows[index].Cells[2].Text;
        txtprecio.Text = gridview1.Rows[index].Cells[3].Text;

        BtnModificar.Enabled = true;
        BtnEliminar.Enabled = true;
        BtnGuardar.Enabled = false;


    }

    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        string respuesta = "";
        BOL.Productos pr = new BOL.Productos();
        pr.Codigo = txtCodigo.Text;
        pr.Descripcion = txtDescripcion.Text;
        pr.Precio = int.Parse(txtprecio.Text);

        respuesta = DAL.DALProductos.Modificar(pr);

        if (respuesta == "ok")
        {
            Buscar();
            lblMensaje.Text = "Modificacion Correcto";
            Limpiar();
        }
        else
        {

            lblMensaje.Text = respuesta;
        }

    }

    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        string respuesta = "";

        respuesta = DAL.DALProductos.Eliminar(txtCodigo.Text);

        if (respuesta == "ok")
        {
            Buscar();
            lblMensaje.Text = "Eliminacion Correcta";
            Limpiar();
        }
        else
        {

            lblMensaje.Text = respuesta;
        }
    }

    public void Limpiar()
    {
        txtCodigo.Text = "";
        txtDescripcion.Text = "";
        txtprecio.Text = "";
        BtnGuardar.Enabled = true;
        BtnModificar.Enabled = false;
        BtnEliminar.Enabled = false;
        lblMensaje.Text = "";

    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Limpiar();
    }
}