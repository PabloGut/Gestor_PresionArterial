<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width-device-width, initial-scale=1, shrink-to-fit=no" />
    <meta http-equiv="x-ua-compatible" content="ie-edge" />
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css"/>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
</head>
<body>

    <form id="form2" runat="server" >
    <div class="container-fluid border contenedorMenu">

        <nav class="navbar navbar-expand-sm navbar-light bg-light col-xl-12">
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#opciones">
                <span class="navbar-toggler-icon"></span>
            </button>

            <!-- logo -->
            <a class="navbar-brand" href="#">
                <img src="http://www.tutorialesprogramacionya.com/imagenes/foto1.jpg" width="30" height="30" alt=""/>
            </a>

            <!-- enlaces -->
            <div class="collapse navbar-collapse" id="opciones">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" href="Login.aspx" runat="server" id="linkinicio">Login</a>
                    </li>
                     <li class="nav-item">
                        <asp:LinkButton ID="ConsultarHistoriaClinica" class="nav-link" runat="server" OnClick="" >Historia Clínica</asp:LinkButton>
                    </li>
                      <li class="nav-item">
                        <asp:LinkButton ID="CargaManual" class="nav-link" runat="server" OnClick="" >Carga Manual</asp:LinkButton>
                    </li>
                       <li class="nav-item">
                        <asp:LinkButton ID="CargaAutomatica" class="nav-link" runat="server" OnClick="" >Carga Automática</asp:LinkButton>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link" href="ConsultarHistoriaClinica.aspx">Historia Clínica</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="CargaManual.aspx">Carga Manual</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="CargaAutomatica.aspx">Carga Automática</a>
                    </li>
                </ul>
            </div>
        </nav>
    </div>
    </form>
    <div class="container-fluid">
        <div class="row border">
            <img class="img-fluid float-center" src="Images/Medicina.jpg" alt="Chania" width="100%">
        </div>
    </div>

    <div class="container-fluid">
        <div class="row funciones">
            <div class="col col-xs-12 border">
                <h2>Historia Clínica</h2>
                <p>Shiart posibilita al paciente visualizar la historia clínica</p>
            </div>

            <div class="col col-xs-12 border">
                <h2>Carga automática</h2>
                <p>Shiart permite la carga automática de mediciones desde un tensiometro digital</p>
            </div>

            <div class="col col-xs-12 border">
                <h2>Carga manual</h2>
                <p>Shiart permite la carga manual de mediciones</p>
            </div>
        </div>
    </div>




<script src="js/jquery-3.2.1.slim.min.js"></script>
<script src="popper.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</body>
</html>
