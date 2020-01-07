<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registerT.aspx.cs" Inherits="proyecto.Vista.registerT" %>

<!DOCTYPE html>

<html lang="en">
<head>
	<title>Registro - SIPROE</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="imagesl/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendorl/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fontsl/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fontsl/Linearicons-Free-v1.0.0/icon-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendorl/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendorl/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendorl/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendorl/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendorl/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="cssl/util.css">
	<link rel="stylesheet" type="text/css" href="cssl/main.css">
<!--===============================================================================================-->
</head>
<body>


	
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<form class="login100-form validate-form" runat="server">

					<span class="login100-form-title p-b-34">
						Registro
					</span>
					

					<div class="w-full text-center p-t-27 p-b-239">
					    <div class="w-full text-center">
						    <a href="   RegistroAdmin.aspx" class="login100-form-btn">
							    Administrador
						    </a>
					    </div>

					    <div class="w-full text-center">
						    <a href="   RegistroComprador.aspx" class="login100-form-btn">
							    Comprador
						    </a>
					    </div>

					    <div class="w-full text-center">
						    <a href="   RegistroProveedor.aspx" class="login100-form-btn">
							    Proveedor
						    </a>
					    </div>

					</div>                                                      
				</form>

				<div class="login100-more" style="background-image: url('imagesl/bg-01.jpg');"></div>
			</div>
		</div>
	</div>
	
	

	<div id="dropDownSelect1"></div>
	
<!--===============================================================================================-->
	<script src="vendorl/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="vendorl/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="vendorl/bootstrap/js/popper.js"></script>
	<script src="vendorl/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="vendorl/select2/select2.min.js"></script>
	<script>
		$(".selection-2").select2({
			minimumResultsForSearch: 20,
			dropdownParent: $('#dropDownSelect1')
		});
	</script>
<!--===============================================================================================-->
	<script src="vendorl/daterangepicker/moment.min.js"></script>
	<script src="vendorl/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="vendorl/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="jsl/main.js"></script>

</body>
</html>
