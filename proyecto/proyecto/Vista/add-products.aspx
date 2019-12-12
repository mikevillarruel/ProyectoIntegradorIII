<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add-products.aspx.cs" Inherits="proyecto.Vista.add_products" %>

<!DOCTYPE html>

<html lang="en">
<!-- Basic -->

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <!-- Mobile Metas -->
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Site Metas -->
    <title>CheckOut - Siproe</title>
    <meta name="keywords" content="">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Site Icons -->
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon">
    <link rel="apple-touch-icon" href="images/apple-touch-icon.png">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <!-- Site CSS -->
    <link rel="stylesheet" href="css/style.css">
    <!-- Responsive CSS -->
    <link rel="stylesheet" href="css/responsive.css">
    <!-- Custom CSS -->
    <link rel="stylesheet" href="css/custom.css">

    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

    <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 0px;
        }
    </style>

</head>

<body>
    <!-- Start Main Top -->
    <div class="main-top">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    
                    <!--
					<div class="custom-select-box">
                        <select id="basic" class="selectpicker show-tick form-control" data-placeholder="$ USD">
							<option>¥ JPY</option>
							<option>$ USD</option>
							<option>€ EUR</option>
						</select>
                    </div>
                    -->
                    <!--
                    <div class="right-phone-box">
                        <p>Call US :- <a href="#"> +11 900 800 100</a></p>
                    </div>
                    -->
                    <div class="our-link">
                        <ul>
                            <li><a href="my-account.aspx"><i class="fa fa-user s_color"></i> My Account</a></li>
                            <!--
                            <li><a href="#"><i class="fas fa-location-arrow"></i> Our location</a></li>
                            -->
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End Main Top -->

    <!-- Start Main Top -->
    <header class="main-header">
        <!-- Start Navigation -->
        <nav class="navbar navbar-expand-lg navbar-light bg-light navbar-default bootsnav">
            <div class="container">
                <!-- Start Header Navigation -->
                <div class="navbar-header">
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbar-menu" aria-controls="navbars-rs-food" aria-expanded="false" aria-label="Toggle navigation">
                    <i class="fa fa-bars"></i>
                </button>
                    <a class="navbar-brand" href="indexP.aspx"><img src="images/logo.png" class="logo" alt="" style="width:150px;height:100px;"></a>
                </div>
                <!-- End Header Navigation -->

                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="navbar-menu">
                    <ul class="nav navbar-nav ml-auto" data-in="fadeInDown" data-out="fadeOutUp">

                        <li class="nav-item"><a class="nav-link" href="indexP.aspx">Home</a></li>
                        
                        <li class="nav-item active"><a class="nav-link" href="add-products.aspx">Add Products</a></li>
                        
                        <li class="nav-item"><a class="nav-link" href="my-products.aspx">My Products</a></li>

                        <li class="nav-item"><a class="nav-link" href="pending-orders.aspx">Pending Orders</a></li>

                        <!--
                        <li class="nav-item"><a class="nav-link" href="gallery.html">Gallery</a></li>
                        <li class="nav-item"><a class="nav-link" href="contact-us.html">Contact Us</a></li>
                        -->
                    </ul>
                </div>
                <!-- /.navbar-collapse -->


            </div>

        </nav>
        <!-- End Navigation -->
    </header>
    <!-- End Main Top -->

    <!-- Start Top Search -->
    <div class="top-search">
        <div class="container">
            <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-search"></i></span>
                <input type="text" class="form-control" placeholder="Search">
                <span class="input-group-addon close-search"><i class="fa fa-times"></i></span>
            </div>
        </div>
    </div>
    <!-- End Top Search -->

    <!-- Start All Title Box -->
    <div class="all-title-box">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <h2>Add new product</h2>
                </div>
            </div>
        </div>
    </div>
    <!-- End All Title Box -->

    <!-- Start Cart  -->
    <div class="cart-box-main">
        <div class="container">

            <div class="row">
                <div class="col-sm-6 col-lg-6 mb-3">
                    <div class="checkout-address">
                        <div class="title-left">
                            <h3>Producto</h3>
                        </div>
                        <form class="needs-validation" novalidate runat="server">
                            <div class="mb-3">
                                <label for="username">Nombre del producto *</label>
                                <div class="input-group">
                                    <input runat="server" type="text" class="form-control" id="nombreP" required />
                                    <div class="invalid-feedback" style="width: 100%;"> Your username is required. </div>
                                </div>
                            </div>
                            <div class="mb-3">
                                <label for="email">Descripcion *</label>
                                <input runat="server" type="text" class="form-control" id="descripcionP" required />
                                <div class="invalid-feedback"> Please enter a valid email address for shipping updates. </div>
                            </div>
                            <div class="mb-3">
                                <label for="address">Precio *</label>
                                <input runat="server" type="text" class="form-control" id="precioP" required />
                                <div class="invalid-feedback"> Please enter your shipping address. </div>
                            </div>

                            <div class="mb-3">
                                <label for="address2">Categoria *</label>
                                <asp:DropDownList ID="categorias" runat="server">
                                    <asp:ListItem>Ropa</asp:ListItem>
                                    <asp:ListItem>Maquillaje</asp:ListItem>
                                    <asp:ListItem>Utensillos de cocina</asp:ListItem>
                                    <asp:ListItem>Libros</asp:ListItem>
                                    <asp:ListItem>Computadoras</asp:ListItem>
                                    <asp:ListItem>Salud</asp:ListItem>
                                    <asp:ListItem>Joyeria</asp:ListItem>
                                    <asp:ListItem>Musica</asp:ListItem>
                                    <asp:ListItem>Juegos</asp:ListItem>
                                </asp:DropDownList>
                                <!--
                                <label for="address2">Categoria *</label>
                                <input type="text" class="form-control" id="address2" placeholder="">-->
                            </div>
                            <!--
                            <div class="mb-3">
                                <label for="address">Imagen *</label>
                                <input runat="server" type="text" class="form-control" id="imagenP" required />
                                <div class="invalid-feedback"> Please enter your shipping address. </div>
                            </div>
                            -->
                            <div class="mb-3">
                                <label for="address">Imagen *</label>
                                <asp:FileUpload ID="imagen" accept=".jpg" runat="server" CssClass="form-control"/>
                                <div class="invalid-feedback"> Please enter your shipping address. </div>
                            </div>

                            <hr class="mb-1">

                            <asp:Button runat="server" ID="btnIngresar" class="ml-auto btn hvr-hover" type="submit" Text="Ingresar" OnClick="btnIngresar_Click1"></asp:Button>
					        <div class="ml-auto btn hvr-hover">
						        <a href="   Upload-Products.aspx" class="txt3">
							        Cargar Archivo
						        </a>
					        </div>                               

                        </form>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- End Cart -->





    <!-- Start copyright  -->
    <div class="footer-copyright">
        <p class="footer-company">All Rights Reserved. &copy; 2018 <a href="#">ThewayShop</a> Design By :
            <a href="https://html.design/">html design</a></p>
    </div>
    <!-- End copyright  -->

    <a href="#" id="back-to-top" title="Back to top" style="display: none;">&uarr;</a>

    <!-- ALL JS FILES -->
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <!-- ALL PLUGINS -->
    <script src="js/jquery.superslides.min.js"></script>
    <script src="js/bootstrap-select.js"></script>
    <script src="js/inewsticker.js"></script>
    <script src="js/bootsnav.js."></script>
    <script src="js/images-loded.min.js"></script>
    <script src="js/isotope.min.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script src="js/baguetteBox.min.js"></script>
    <script src="js/form-validator.min.js"></script>
    <script src="js/contact-form-script.js"></script>
    <script src="js/custom.js"></script>
</body>

</html>
