<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Busqueda.aspx.cs" Inherits="ProyectoIII.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/> -->
    <title>SIPROE</title>
    <style>
        body {
            background-color: steelblue;
            background-repeat: no-repeat;
            background-attachment: fixed;
            background-size: cover;
        }

        .titulo {
            color: white;
            width: 100%;
            height: 100%;
            letter-spacing: 20px;
            font-size: 30px;
            text-shadow: 2px 2px black;
            font-family: 'Courier New', Courier, monospace;
        }

        .slogan {
            color: white;
            width: 100%;
            height: 30px;
            font-size: 15px;
            text-align: center;
            text-shadow: 1px 1px black;
            font-family: 'Courier New', Courier, monospace;
        }

        .navbar {
            background-color: steelblue;
            height: 38px;
            width: 100%;
        }

            .navbar a {
                font-family: 'Courier New', Courier, monospace;
                float: left;
                color: white;
                text-align: center;
                padding: 10px 30px;
                text-decoration: none;
                font-size: 15px;
            }

                .navbar a:hover {
                    background-color: #ddd;
                    color: black;
                    border-radius: 20px;
                }

            .navbar section {
                float: left;
            }

        .footerFinal {
            text-align: center;
            border-radius: 15px;
            clear: both;
            padding: 5px;
            font-family: 'Courier New', Courier, monospace;
            color: black;
            font-weight: bold;
        }

        #result {
            background-color: white;
            text-align: justify;
            padding: 15px 0px 15px 0px;
            width: 100%;
        }

            #result section {
                text-align: justify;
                margin: 15px 15% 15px 0px;
                width: 55%;
                height: 200px;
                float: left;
            }

            #result img {
                margin: 15px 0px 15px 15%;
                width: 15%;
                height: 200px;
                float: left;
            }

            #result hr {
                border: 0.4px solid steelblue;
                clear: both;
            }

        p {
            padding: 0px 20px;
        }

        ul {
            padding: 30px;
        }

        li {
            padding: 5px;
        }

            li:hover {
                color: blue;
            }

        .header {
            height: 50px;
            background-color: steelblue;
        }
    </style>
</head>
<body>
    <nav class="header">

        <img src="https://cdn3.iconfinder.com/data/icons/shopping-filled-outline-2/64/troli-512.png" style="width: 3%; height: 35px; float: left;" />
        <section class="titulo" style="float: left; width: 16%; margin-left: 1%;">
            <b>SIPROE</b>
        </section>

        <section style="float: left; width: 60%;">
            <input style="width: 100%; height: 30px; border-radius: 20px; border: none; text-indent: 20px; font-family: 'Courier New', Courier, monospace;" type="text" placeholder="Busca productos, marcas y más ..." />
        </section>

        <section class="slogan" style="float: left; width: 20%;">
            <b>Compra y vende, seguro y sin demoras.</b>
        </section>

    </nav>

    <nav class="navbar">
        <section style="width: 20%;">
            <a href="#inicio">Categorias</a>
        </section>
        <section style="width: 60%;">
            <a href="#comprar">Ingresa</a>
            <a href="#contactos">Contactos</a>
            <a href="#acerca">Acerca de Nosotros</a>
        </section>
        <section style="width: 20%;">
            <a href="#inicio">Crea tu cuenta</a>
        </section>
    </nav>

    <div id="result" runat="server">
        <img src="https://equiposlibres.pe/wp-content/uploads/2019/07/Mi9T-1.png" />
        <section>
            <h1>Xiaomi Mi 9T 64GB + 4GB RAM 6.39'' 48MP Triple Cámara LTE Desbloqueado de fábrica GSM Smartphone</h1>
            Xiomi (Versión Internacional)
            <br />
            <br />
            $104.5
        </section>
        <hr />

    </div>
    <form runat="server">
        <asp:Button ID="btnAumentar" runat="server" OnClick="btnAumentar_Click" Text="Aumetar"></asp:Button>
    </form>

    <footer class="footerFinal">
        ©2019, SIPROE.COM
    </footer>

</body>
</html>
