using SwinGameSDK; //checked by David, all fine

static class EndingGameController
{
    public static void DrawEndOfGame()
    {
        Rectangle toDraw;
        string whatShouldIPrint;
		
        DrawField(ComputerPlayer.PlayerGrid, ComputerPlayer, true);
        DrawSmallField(HumanPlayer.PlayerGrid, HumanPlayer);
		
        toDraw.X = 0;
        toDraw.Y = 250;
        toDraw.Width = SwinGame.ScreenWidth();
        toDraw.Height = SwinGame.ScreenHeight();
		
        if (HumanPlayer.IsDestroyed)
        {
            whatShouldIPrint = "YOU LOSE!";
        }
        else
        {
            whatShouldIPrint = "-- WINNER --";
        }

        SwinGame.DrawTextLines(whatShouldIPrint, Color.White, Color.Transparent, GameResources.GameFont("ArialLarge"), FontAlignment.AlignCenter, toDraw);
    }

    public static void HandleEndOfGameInput()
    {
        if (SwinGame.MouseClicked(MouseButton.LeftButton) || SwinGame.KeyTyped(KeyCode.VK_RETURN) || SwinGame.KeyTyped(KeyCode.VK_ESCAPE))
        {
            ReadHighScore(HumanPlayer.Score);
            EndCurrentState();
        }
    }
}
