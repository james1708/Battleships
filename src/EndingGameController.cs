using System;
using System.Collections;
using System.Collections.Generic;
using SwinGameSDK; //checked by David, all fine

namespace BattleShip
{

    static class EndingGameController
    {
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