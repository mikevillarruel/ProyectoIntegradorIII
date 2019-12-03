<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroProveedor.aspx.cs" Inherits="ProyectoIII.Vista.RegistroProveedor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <script type="text/javascript"
        src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.js"></script>
    <title>Formulario de Registro</title>
</head>

<body class="bg-light">
    <div class="container" style="max-width: 480px">
        <div class="py-5 text-center">
            <h2>Registro de Proveedor</h2>
        </div>

        <div>
            <form id="insertSellerForm" runat="server" class="needs-validation">

                <div class="mb-3">
                    <label for="firstName">Nombre</label>
                    <input runat="server" type="text" pattern="[A-Z][A-Za-z]{1,32}" class="form-control" id="nombre" required />
                </div>

                <div class="mb-3">
                    <label for="usuario">Usuario</label>
                    <div class="input-group">
                        <input runat="server" type="text" pattern="[A-Za-z0-9-_]{4,32}" class="form-control" id="usuario" required />
                    </div>
                </div>

                <div class="mb-3">
                    <label for="password">Contraseña</label>
                    <div class="input-group">
                        <input runat="server" type="password" pattern="[A-Za-z0-9-_]{4,32}" class="form-control" id="contrasenia" required />
                    </div>
                </div>

                <div class="mb-3">
                    <label for="telephone">Teléfono</label>
                    <input runat="server" type="text" pattern="[0][9][0-9]{8,}" class="form-control" id="telefono" maxlength="10" required />
                </div>

                <div class="mb-3">
                    <label for="ciudad">Ciudad</label>
                    <input runat="server" type="text" class="form-control" id="ciudad" required />
                </div>

                <div class="mb-3">
                    <label for="address">Dirección</label>
                    <input runat="server" type="text" class="form-control" id="direccion" placeholder="1234 Main St" required />
                </div>

                <div class="mb-3">
                    <label for="email">Email</label>
                    <input runat="server" type="email" class="form-control" id="email" placeholder="you@example.com" required />
                </div>

                <asp:Button runat="server" ID="btnRegistrar" class="btn btn-success btn-lg btn-block" type="submit" Text="Registrar" OnClick="btnRegistrar_Click"></asp:Button>
            </form>
        </div>
    </div>
</body>

</html>
