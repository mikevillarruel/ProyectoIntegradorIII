<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="proyectoweb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
                            <asp:GridView ID="tablaDetalle" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="Imagen" HeaderText="Imagen" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Descripción" HeaderText="Descripción" />
                                    <asp:BoundField DataField="Categoría" HeaderText="Categoría" />
                                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                    <asp:BoundField DataField="Modificar" HeaderText="Modificar" />
                                    <asp:BoundField DataField="Eliminar" HeaderText="Eliminar" />
                                </Columns>

                            </asp:GridView>

            <br />
            <br />
            <asp:Button ID="btnVerificar" runat="server" OnClick="btnVerificar_Click" Text="Verificar compra" />
            <br />
            <br />
            <br />
            <asp:Button ID="btnEnviar" runat="server" OnClick="Button1_Click" Text="Confirmar compra" />
            <br />
            <br />
            <asp:Label ID="alerta" runat="server">.</asp:Label>
        </div>
    </form>
</body>
</html>
