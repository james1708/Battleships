Public Interface ISeaGrid

    ReadOnly Property Width() As Integer

    ReadOnly Property Height() As Integer

    Event Changed As EventHandler

    ReadOnly Property Item(ByVal row As Integer, ByVal column As Integer) As TileView

    Function HitTile(ByVal row As Integer, ByVal col As Integer) As AttackResult
End Interface
