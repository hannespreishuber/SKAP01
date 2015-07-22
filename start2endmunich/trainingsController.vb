Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description

Namespace start2endmunich
    Public Class trainingsController
        Inherits System.Web.Http.ApiController

        Private db As New Model1

        ' GET: api/trainings
        Function Gettraining() As IQueryable(Of training)
            Return db.training
        End Function

        ' GET: api/trainings/5
        <ResponseType(GetType(training))>
        Function Gettraining(ByVal id As Integer) As IHttpActionResult
            Dim training As training = db.training.Find(id)
            If IsNothing(training) Then
                Return NotFound()
            End If

            Return Ok(training)
        End Function

        ' PUT: api/trainings/5
        <ResponseType(GetType(Void))>
        Function Puttraining(ByVal id As Integer, ByVal training As training) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = training.Id Then
                Return BadRequest()
            End If

            db.Entry(training).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (trainingExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/trainings
        <ResponseType(GetType(training))>
        Function Posttraining(ByVal training As training) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.training.Add(training)
            db.SaveChanges()
            MyHub1.updateTrainings(training)
            Return CreatedAtRoute("DefaultApi", New With {.id = training.Id}, training)
        End Function

        ' DELETE: api/trainings/5
        <ResponseType(GetType(training))>
        Function Deletetraining(ByVal id As Integer) As IHttpActionResult
            Dim training As training = db.training.Find(id)
            If IsNothing(training) Then
                Return NotFound()
            End If

            db.training.Remove(training)
            db.SaveChanges()

            Return Ok(training)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function trainingExists(ByVal id As Integer) As Boolean
            Return db.training.Count(Function(e) e.Id = id) > 0
        End Function
    End Class
End Namespace