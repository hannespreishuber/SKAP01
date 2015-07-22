Imports System.Collections.Generic
Imports System.Linq
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.Cookies
Imports Microsoft.Owin.Security.Google
Imports Microsoft.Owin.Security.OAuth
Imports Owin

Public Partial Class Startup
    Private Shared _OAuthOptions As OAuthAuthorizationServerOptions
    Private Shared _PublicClientId As String

    Public Shared Property OAuthOptions() As OAuthAuthorizationServerOptions
        Get
            Return _OAuthOptions
        End Get
        Private Set
            _OAuthOptions = Value
        End Set
    End Property

    Public Shared Property PublicClientId() As String
        Get
            Return _PublicClientId
        End Get
        Private Set
            _PublicClientId = Value
        End Set
    End Property

    ' Weitere Informationen zum Konfigurieren der Authentifizierung finden Sie unter "http://go.microsoft.com/fwlink/?LinkId=301864".
    Public Sub ConfigureAuth(app As IAppBuilder)

        app.MapSignalR()


        ' db-Kontext und Benutzer-Manager für die Verwendung einer einzelnen Instanz pro Anforderung konfigurieren
        app.CreatePerOwinContext(AddressOf ApplicationDbContext.Create)
        app.CreatePerOwinContext(Of ApplicationUserManager)(AddressOf ApplicationUserManager.Create)

        ' Anwendung für die Verwendung eines Cookies zum Speichern von Informationen für den angemeldeten Benutzer aktivieren
        ' und ein Cookie zum vorübergehenden Speichern von Informationen zu einem Benutzer zu verwenden, der sich mit dem Anmeldeanbieter eines Drittanbieters anmeldet.
        app.UseCookieAuthentication(New CookieAuthenticationOptions())
        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie)

        ' Anwendung für auf OAuth basierenden Datenfluss konfigurieren
        PublicClientId = "self"
        OAuthOptions = New OAuthAuthorizationServerOptions() With {
          .TokenEndpointPath = New PathString("/Token"),
          .Provider = New ApplicationOAuthProvider(PublicClientId),
          .AuthorizeEndpointPath = New PathString("/api/Account/ExternalLogin"),
          .AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
          .AllowInsecureHttp = True
        }

        ' Anwendung für die Verwendung eines Trägertokens zum Authentifizieren von Benutzern aktivieren
        app.UseOAuthBearerTokens(OAuthOptions)

        ' Auskommentierung der folgenden Zeilen aufheben, um die Anmeldung mit Anmeldeanbietern von Drittanbietern zu ermöglichen
        'app.UseMicrosoftAccountAuthentication(
        '    clientId:="",
        '    clientSecret:="")

        'app.UseTwitterAuthentication(
        '    consumerKey:="",
        '    consumerSecret:="")

        'app.UseFacebookAuthentication(
        '    appId:="",
        '    appSecret:="")

        'app.UseGoogleAuthentication(New GoogleOAuth2AuthenticationOptions() With {
        '    .ClientId = "",
        '    .ClientSecret = ""})
    End Sub
End Class
