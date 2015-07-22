Imports System.Net.Http
Imports System.Web.Http
Imports Microsoft.Owin.Security.OAuth
Imports Newtonsoft.Json.Serialization

Public Module WebApiConfig
    Public Sub Register(config As HttpConfiguration)
      ' Web-API-Konfiguration und -Dienste
      ' Web-API für die ausschließliche Verwendung von Trägertokenauthentifizierung konfigurieren.
      config.SuppressDefaultHostAuthentication()
      config.Filters.Add(New HostAuthenticationFilter(OAuthDefaults.AuthenticationType))

      ' Web-API-Routen
      config.MapHttpAttributeRoutes()

      config.Routes.MapHttpRoute(
          name:="DefaultApi",
          routeTemplate:="api/{controller}/{id}",
          defaults:=New With { .id = RouteParameter.Optional }
      )
    End Sub
End Module
