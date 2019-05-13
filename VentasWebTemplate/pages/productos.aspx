<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Principal.master" AutoEventWireup="true" CodeFile="productos.aspx.cs" Inherits="pages_productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

         <div>
            <h1> Registro de productos </h1>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Codigo"></asp:Label>

                    </td>
                    <td>
                           <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>


                    </td>
                 

                </tr>

                     <tr>
                         <td>
                             <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>


                         </td>
                
                         <td>
                               <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>


                         </td>
                     
                     </tr>

                    <tr>
                        <td>   <asp:Label ID="Label3" runat="server" Text="Precio"></asp:Label></td>
                        <td>
                             <asp:TextBox ID="txtprecio" runat="server"></asp:TextBox>


                        </td>


                    </tr>



            </table>
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            <br />
            <table>
                <tr>
                    <td><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" /></td>
                    <td><asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" /></td>
                   
                    <td><asp:Button ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" /></td>
                    <td><asp:Button ID="BtnModificar" runat="server" Text="Modificar" OnClick="BtnModificar_Click" /></td>
                    <td><asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminar_Click" /></td>
            
                    </tr>
            
            
            </table>
            <div>
                <asp:gridview runat="server" ID="gridview1" OnSelectedIndexChanged="gridview1_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:gridview>

            </div>
            
        </div>
</asp:Content>

