<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Web.master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Gh.Presentation.Web.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #map {
            width: 350px;
            height: 250px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
            </ol>

            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <img src="Sources/hotel-demo-1.jpg" />
                </div>

                <div class="item">
                    <img src="Sources/hotel-demo-2.jpg" />
                </div>

                <div class="item">
                    <img src="Sources/hotel-demo-3.jpg" />
                </div>
            </div>

            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
        <!-- Jumbotron -->
        <br />
        <a name="acercade"></a>
        <div class="jumbotron" >
            <h1>Acerca de Hotel Ejemplo</h1>
            <p class="lead">Un hotel familiar cerca del mar, con espléndidas vistas al mar o a la muralla romana de la parte posterior.</p>
            <p><a class="btn btn-lg btn-success" href="#" role="button">¡Haz tu reserva!</a></p>
        </div>

        <!-- Example row of columns -->
        <a name="contacto"></a>
        <div class="row">
            <div class="col-lg-4">
                <h2>¿Dónde estamos?</h2>
                <div id="map"></div>
                <script>
                    function initMap() {
                        var mapDiv = document.getElementById('map');
                        var map = new google.maps.Map(mapDiv, {
                            center: { lat: 41.12, lng: 1.27 },
                            zoom: 12
                        });
                    }
                </script>
                <script src="https://maps.googleapis.com/maps/api/js?callback=initMap"
                    async defer></script>
            </div>
            <div class="col-lg-4">
                <h2>Contacto</h2>
                <p>Puede contactar con nosotros vía: </p>
                <ul>
                    <li><b>Email:</b> <a href="mailto:ejemplo@hotel.es">ejemplo@hotel.es</a></li>
                    <li><b>Teléfono:</b> +34 977 777 777</li>
                </ul>
                <p><a class="btn btn-primary" href="#" role="button">Formulario de contacto »</a></p>
            </div>
            <div class="col-lg-4">
                <h2>Itinerarios</h2>
                <p>Puede consultar los contenidos y horarios de nuestros itinerarios. ¡Visite cada rincón de historia de Tarragona!</p>
                <p><a class="btn btn-primary" href="#" role="button">Ver itinerarios »</a></p>
            </div>
        </div>
    </div>
</asp:Content>
