/*<summary>
*the different AI levels
*</summary>
*/
namespace BattleShip
{
    public enum AIOption
    {
        Easy,	//Easy, total random shooting
        Medium,	//medium, marks squards around hits
        Hard	//as medium, but removes shots once it misses
    }
}