using System;
using System.IO;
using SwinGameSDK;

namespace BattleShip
{
    public class GameMain
    {
    	public static void Main ()
		{
			//opens a new graphics window
			SwinGame.OpenGraphicsWindow ("Battle Ships", 800, 600);
			//loads the game resources
			GameResources.LoadResources();
			SwinGame.PlayMusic (GameResources.GameMusic("BackGround"));

			//game music
			do {
				GameController.HandleUserInput ();
				GameController.DrawScreen ();
			}
			while (SwinGame.WindowCloseRequested () == false | CurrentState == GameState.Quitting);

			//free resources and close audio, to end the program
			SwinGame.StopMusic ();
			GameResources.FreeResources ();
		}
    }
}