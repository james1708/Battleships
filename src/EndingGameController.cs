using System;
using System.Collections;
using System.Collections.Generic;
using SwinGameSDK; //checked by David, all fine


/*<summary>
*The EndingGameController is responsible for managing the interactions at the end
*of a game.
*</summary>
*/
namespace BattleShip
{

    static class EndingGameController
    {
		/*<summary>
		*Draw the end of the game screen, shows the win/lose state
		*</summary>
		*/
        public static void DrawEndOfGame()
        {
            Rectangle toDraw = new Rectangle();
            string whatShouldIPrint;

            UtilityFunctions.DrawField(GameController.ComputerPlayer.PlayerGrid, GameController.ComputerPlayer, true);
            UtilityFunctions.DrawSmallField(GameController.HumanPlayer.PlayerGrid, GameController.HumanPlayer);

            toDraw.X = 0;
            toDraw.Y = 250;
            toDraw.Width = SwinGame.ScreenWidth();
            toDraw.Height = SwinGame.ScreenHeight();

            if (GameController.HumanPlayer.IsDestroyed)
            {
                whatShouldIPrint = "YOU LOSE!";
            }
            else
            {
                whatShouldIPrint = "-- WINNER --";
            }

            SwinGame.DrawTextLines(whatShouldIPrint, Color.White, Color.Transparent, GameResources.GameFont("ArialLarge"), FontAlignment.AlignCenter, toDraw);
        }
		
		/*<summary>
		*Handle the input during the end of the game, any interation
		*will result in it reading in the highSwinGame
		*</summary>
		*/
        public static void HandleEndOfGameInput()
        {
            if (SwinGame.MouseClicked(MouseButton.LeftButton) || SwinGame.KeyTyped(KeyCode.vk_RETURN) || SwinGame.KeyTyped(KeyCode.vk_ESCAPE))
            {
                HighScoreController.ReadHighScore(GameController.HumanPlayer.Score);
                GameController.EndCurrentState();
            }
        }
    }
}