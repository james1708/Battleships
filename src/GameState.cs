/*
*<summary>
*the GameState represent the state of the Battleships game play.
*This is used to control the actions and view displayed to
*the players
*</summary>
*/
public enum GameState
{
    ViewingMainMenu,	//the player is view the main menu
    ViewingGameMenu,	//the player is viewing the game menu
    ViewingHighScores,	//the player is looking at the high scores
    AlteringSettings,	//the player is altering the game settings
    Deploying,			//player are deploying their ships
    Discovering,		//players are attempting to locate each others ships
    EndingGame,			//one player has won, showing the victory screen
    Quitting			//the player has quit. Showing ending credits and terminate the game
}
