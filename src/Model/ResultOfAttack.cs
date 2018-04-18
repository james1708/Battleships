/*<summary>
*The result of an attack.
*</summary>
*/
namespace BattleShip
{
    public enum ResultOfAttack
    {
        Hit,			//the player hit something
        Miss,			//the player missed
        Destroyed,		//the player destroyed a ship
        ShotAlready,	//the location was already shot
        GameOver		//the player killed all of the opponents ships
    }
}
