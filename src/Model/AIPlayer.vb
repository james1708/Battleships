Public MustInherit Class AIPlayer : Inherits Player

    Protected Class Location
        Private _Row As Integer
        Private _Column As Integer

        Public Property Row() As Integer
            Get
                Return _Row
            End Get
            Set(ByVal value As Integer)
                _Row = value
            End Set
        End Property

        Public Property Column() As Integer
            Get
                Return _Column
            End Get
            Set(ByVal value As Integer)
                _Column = value
            End Set
        End Property

        Public Sub New(ByVal row As Integer, ByVal column As Integer)
            _Column = column
            _Row = row
        End Sub

        Public Shared Operator =(ByVal this As Location, ByVal other As Location) As Boolean
            Return this IsNot Nothing AndAlso other IsNot Nothing AndAlso this.Row = other.Row AndAlso this.Column = other.Column
        End Operator

        Public Shared Operator <>(ByVal this As Location, ByVal other As Location) As Boolean
            Return this Is Nothing OrElse other Is Nothing OrElse this.Row <> other.Row OrElse this.Column <> other.Column
        End Operator
    End Class


    Public Sub New(ByVal game As BattleShipsGame)
        MyBase.New(game)
    End Sub

    Protected MustOverride Sub GenerateCoords(ByRef row As Integer, ByRef column As Integer)

    protected mustoverride sub ProcessShot(row as integer, col as integer, result as AttackResult)

    Public Overrides Function Attack() As AttackResult
        Dim result As AttackResult
        Dim row As Integer = 0
        Dim column As Integer = 0

        Do
            Delay()

            GenerateCoords(row, column)
            result = _game.Shoot(row, column) 
            ProcessShot(row, column, result)
        Loop While result.Value <> ResultOfAttack.Miss AndAlso result.Value <> ResultOfAttack.GameOver AndAlso Not SwinGame.WindowCloseRequested

        Return result
    End Function

    Private Sub Delay()
        Dim i as Integer
For i  = 0 To 150
            If SwinGame.WindowCloseRequested Then Return

            SwinGame.Delay(5)
            SwinGame.ProcessEvents()
            SwinGame.RefreshScreen()
        Next
    End Sub
End Class
