<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmUbicaciones.aspx.cs" Inherits="CrudMarcadores_ASP.frmUbicaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Control de ubicaciones</title>
   
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!--Bootstrap y jQuery -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
 
     <!--API GOOGLE MAPS -->
    <script type="text/javascript" src='https://maps.google.com/maps/api/js?key=AIzaSyD_q6OLpZbcqQd_xo3rs9CW6ABxpLJOHrg'></script>

   
    <!--Complementos de plugin -->
    <script src="js/locationpicker.jquery.js"></script>
   <link href="css/style.css" rel="stylesheet" />
    <script src="js/app.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-4">
                    <!--Ubicacion -->
                    <br />
                    <div class="form-group">
                        <br />
                        <label for="ubicacion">Ubicación</label>
                        <asp:HiddenField ID="txtID" runat="server" />
                        <asp:TextBox ID="txtUbicacion" CssClass="form-control" runat="server"></asp:TextBox>

                    </div>
                    <!--Ver Mapa -->
                    <div class="form-group">

                        <div id="VerMapa"></div>

                    </div>
                    <!--Latitud y Longitud -->
                    <div class="form-group">

                        <label for="lat">Lat:</label>
                        <asp:TextBox ID="txtLatitud" CssClass="form-control" Text="19.4199042" runat="server"></asp:TextBox>
                        <label for="lon">Lon:</label>
                        <asp:TextBox ID="txtLongitud" CssClass="form-control" Text="-99.169275" runat="server"></asp:TextBox>
                        <label for="placas">Placas:</label>
                        <asp:TextBox ID="txtPlacas" CssClass="form-control" Text="" runat="server"></asp:TextBox>
                    </div>
                    <!--Botones de Control CRUD -->
                    <div class="form-group">

                        <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-success" UseSubmitBehavior="false" runat="server" OnClick="AgregarRegistro" />
                        <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-danger" UseSubmitBehavior="false" Enabled="false" runat="server" OnClick="EliminarRegistro" />
                        <asp:Button Text="Modificar" ID="btnModificar" CssClass="btn btn-warning" UseSubmitBehavior="false" Enabled="false" runat="server" OnClick="ModificarRegistro" />
                        <asp:Button Text="Limpiar" ID="btnLimpiar" CssClass="btn btn-info" UseSubmitBehavior="false" runat="server" OnClick="Limpiar" />

                    </div>

                </div>
                <div class="col-md-8">
                    <br />
                    <h1>Ubicaciones</h1>
                    <asp:GridView ID="tablaUbicaciones" runat="server" CssClass="table-responsive table table-bordered" OnRowCommand="SelecionDeRegistro" >
                        <Columns>
                            <asp:ButtonField CommandName="btnSeleccionar" Text="Selecionar">
                            <ControlStyle CssClass="btn btn-primary" />
                            </asp:ButtonField>
                        </Columns>
                        </asp:GridView>
                    
                </div>
            </div>
        </div>

    <script>
        $('#VerMapa').locationpicker({
            radius: 0,
            location: {
                latitude: $('#<%=txtLatitud.ClientID%>').val(),
                longitude: $('#<%=txtLongitud.ClientID%>').val()
            },
            inputBinding: {
                latitudeInput: $('#<%=txtLatitud.ClientID%>'),
                longitudeInput: $('#<%=txtLongitud.ClientID%>'),
                
                locationNameInput: $('#<%=txtUbicacion.ClientID%>')
            },
            enableAutocomplete:true
        });
    </script>
    
    </form>

    </body>
</html>
