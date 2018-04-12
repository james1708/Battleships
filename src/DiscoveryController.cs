using System;
using System.Collections;
using System.Collections.Generic;
using SwinGameSDK;

namespace BattleShip
{
    static class DiscoveryController
    {
        public static void HandleDiscoveryInput()
        {
            if (SwinGame.KeyTyped(KeyCode.vk_ESCAPE))
            {
                GameController.AddNewState(GameState.ViewingGameMenu);
            }

            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                DoAttack();
            }
        }

        private static void DoAttack()
        {
            Point2D mouse;
            mouse = SwinGame.MousePosition();
            int row, col;
            row = Convert.ToInt32(Math.Floor((mouse.Y - UtilityFunctions.FIELD_TOP) / (UtilityFunctions.CELL_HEIGHT + UtilityFunctions.CELL_GAP)));
            col = Convert.ToInt32(Math.Floor((mouse.X - UtilityFunctions.FIELD_LEFT) / (UtilityFunctions.CELL_WIDTH + UtilityFunctions.CELL_GAP)));
            if (row >= 0 & row < GameController.HumanPlayer.EnemyGrid.Height)
            {
                if (col >= 0 & col < GameController.HumanPlayer.EnemyGrid.Width)
                {
                    GameController.Attack(row, col);
                }
            }
        }

        public static void DrawDiscovery()
        {
            const int SCORES_LEFT = 172;
            const int SHOTS_TOP = 157;
            const int HITS_TOP = 206;
            const int SPLASH_TOP = 256;
            if ((SwinGame.KeyDown(KeyCode.vk_LSHIFT) | SwinGame.KeyDown(KeyCode.vk_RSHIFT)) & SwinGame.KeyDown(KeyCode.vk_c))
            {
                UtilityFunctions.DrawField(GameController.HumanPlayer.EnemyGrid, GameController.ComputerPlayer, true);
            }
            else
            {
                UtilityFunctions.DrawField(GameController.HumanPlayer.EnemyGrid, GameController.ComputerPlayer, false);
            }

            UtilityFunctions.DrawSmallField(GameController.HumanPlayer.PlayerGrid, GameController.HumanPlayer);
            UtilityFunctions.DrawMessage();
            SwinGame.DrawText(GameController.HumanPlayer.Shots.ToString(), Color.White, GameResources.GameFont("Menu"), SCORES_LEFT, SHOTS_TOP);
            SwinGame.DrawText(GameController.HumanPlayer.Hits.ToString(), Color.White, GameResources.GameFont("Menu"), SCORES_LEFT, HITS_TOP);
            SwinGame.DrawText(GameController.HumanPlayer.Missed.ToString(), Color.White, GameResources.GameFont("Menu"), SCORES_LEFT, SPLASH_TOP);
        }
    }
}
