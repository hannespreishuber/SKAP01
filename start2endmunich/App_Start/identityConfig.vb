Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin

' Konfigurieren des in dieser Anwendung verwendeten Anwendungsbenutzer-Managers. UserManager wird in ASP.NET Identity definiert und von der Anwendung verwendet.
Public Class ApplicationUserManager
    Inherits UserManager(Of ApplicationUser)

    Public Sub New(store As IUserStore(Of ApplicationUser))
        MyBase.New(store)
    End Sub

    Public Shared Function Create(options As IdentityFactoryOptions(Of ApplicationUserManager), context As IOwinContext)
        Dim manager = New ApplicationUserManager(New UserStore(Of ApplicationUser)(context.Get(Of ApplicationDbContext)()))

        ' Konfigurieren der Überprüfungslogik für Benutzernamen.
        manager.UserValidator = New UserValidator(Of ApplicationUser)(manager) With {
            .AllowOnlyAlphanumericUserNames = False,
            .RequireUniqueEmail = True
        }

        ' Konfigurieren der Überprüfungslogik für Kennwörter.
        manager.PasswordValidator = New PasswordValidator With {
            .RequiredLength = 6,
            .RequireNonLetterOrDigit = True,
            .RequireDigit = True,
            .RequireLowercase = True,
            .RequireUppercase = True
        }

        Dim dataProtectionProvider = options.DataProtectionProvider
        If (dataProtectionProvider IsNot Nothing) Then
            manager.UserTokenProvider = New DataProtectorTokenProvider(Of ApplicationUser)(dataProtectionProvider.Create("ASP.NET Identity"))
        End If

        Return manager
    End Function
End Class
