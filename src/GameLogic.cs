static class GameLogic //checked by David, logic in while loop field might need some work
{
    public void Main()
    {
        SwinGame.OpenGraphicsWindow("Battle Ships", 800, 600);
        LoadResources();
        SwinGame.PlayMusic(GameMusic("Background"));
        do
        {
            HandleUserInput();
            DrawScreen();
        }
        while (SwinGame.WindowCloseRequested() == false | CurrentState == GameState.Quitting);
       
		SwinGame.StopMusic();
		
        FreeResources();
    }
}

