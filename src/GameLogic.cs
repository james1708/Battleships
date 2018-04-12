using System;
using System.IO;
using SwinGameSDK;

namespace BattleShip
{
    public class GameMain
    {
    	public static void Main ()
		{
			SwinGame.OpenGraphicsWindow ("Battle Ships", 800, 600);
			GameResources.LoadResources();
			SwinGame.PlayMusic (GameResources.GameMusic("BackGround"));

			do {
				GameController.HandleUserInput ();
				GameController.DrawScreen ();
			}
			while (SwinGame.WindowCloseRequested () == false); //| CurrentState == GameState.Quitting);

			SwinGame.StopMusic ();
			GameResources.FreeResources ();
		}
    }
}