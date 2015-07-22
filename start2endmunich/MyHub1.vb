Imports Microsoft.AspNet.SignalR

Public Class MyHub1
    Inherits Hub

    Public Sub Hello()
        Clients.All.Hello()
    End Sub
    Public Shared Sub updateTrainings(t)
        Dim ctx = GlobalHost.ConnectionManager.GetHubContext(Of MyHub1)
        ctx.Clients.All.nachhausetelefonieren(t) ';
    End Sub

End Class
