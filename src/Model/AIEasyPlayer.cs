using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleShip
{
    public class AIEasyPlayer : AIPlayer
    {
        /* <summary>
		* Private enumarator for AI states. currently there is one state,
		* the AI can be searching for a ship and fire randomly
		* </summary>
		*/
        private enum AIStates
        {
            Searching
        }

        private AIStates _CurrentState = AIStates.Searching;

        private Stack<Location> _Targets = new Stack<Location>();
        public AIEasyPlayer(BattleShipsGame controller) : base(controller)
        { }

        /* <summary>
		* GenerateCoordinates should generate random shooting coordinates
		* only and shoot those places.
		* needs new shooting coordinates
        * switch is there to catch an exception if one occurs
		* </summary>
		* <param name="row">the generated row</param>
		* <param name="column">the generated column</param>
		*/
        protected override void GenerateCoords(ref int row, ref int column)
        {
            do
            {
                switch (_CurrentState)
                {
                    case AIStates.Searching:
                        SearchCoords(ref row, ref column);
                        break;
                    default:
                        throw new ApplicationException("AI has gone in a invalid state");
                }
            } while ((row < 0 || column < 0 || row >= EnemyGrid.Height || column >= EnemyGrid.Width || EnemyGrid[row, column] != TileView.Sea));
        }

        /* <summary>
		* SearchCoords will randomly generate shots within the grid as long as its not hit that tile already
		* </summary>
		* <param name="row">the generated row</param>
		* <param name="column">the generated column</param>
		*/
        private void SearchCoords(ref int row, ref int column)
        {
            row = _Random.Next(0, EnemyGrid.Height);
            column = _Random.Next(0, EnemyGrid.Width);
        }

        /* <summary>
        * ProcessShot will be called uppon when a ship is found.
        * It will continue to shoot randomly around the board.
        * </summary>
        * <param name="row">the row it needs to process</param>
        * <param name="col">the column it needs to process</param>
        * <param name="result">the result og the last shot (should be hit)</param>
        */
        protected override void ProcessShot(int row, int col, AttackResult result)
        {
            if (result.Value == ResultOfAttack.Hit)
            {
                _CurrentState = AIStates.Searching;
            }
            else if (result.Value == ResultOfAttack.ShotAlready)
            {
                throw new ApplicationException("Error in AI");
            }
        }

        /* <summary>
        * AddTarget will add the targets it will shoot onto a stack
        * </summary>
        * <param name="row">the row of the targets location</param>
        * <param name="column">the column of the targets location</param>
        */
        private void AddTarget(int row, int column)
        {
            if (row >= 0 && column >= 0 && row < EnemyGrid.Height && column < EnemyGrid.Width && EnemyGrid[row, column] == TileView.Sea)
            {
                _Targets.Push(new Location(row, column));
            }
        }
    }
}
