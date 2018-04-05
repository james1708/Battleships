public class BattleShipsGame {
    

    public delegate void AttackCompletedHandler(object sender, AttackResult result);
    
    public event AttackCompletedHandler AttackCompleted;
    
    private int _playerIndex = 0;
    

    public Player Player {
        get {
            return _players(_playerIndex);
        }
    }
    
    public void AddDeployedPlayer(Player p) {
        if ((_players(0) == null)) {
            _players(0) = p;
        }
        else if ((_players(1) == null)) {
            _players(1) = p;
            this.CompleteDeployment();
        }
        else {
            throw new ApplicationException("You cannot add another player, the game already has two players.");
        }
        
    }
    
  
    private void CompleteDeployment() {
        _players(0).Enemy = new SeaGridAdapter(_players(1).PlayerGrid);
        _players(1).Enemy = new SeaGridAdapter(_players(0).PlayerGrid);
    }
    

    public AttackResult Shoot(int row, int col) {
        AttackResult newAttack;
        int otherPlayer = ((_playerIndex + 1) 
                    % 2);
        newAttack = Player.Shoot(row, col);
      
	  
        if (_players(otherPlayer).IsDestroyed) {
            newAttack = new AttackResult(ResultOfAttack.GameOver, newAttack.Ship, newAttack.Text, row, col);
        }
        
        AttackCompleted(this, newAttack);
        
		
        if ((newAttack.Value == ResultOfAttack.Miss)) {
            _playerIndex = otherPlayer;
        }
        
        return newAttack;
    }
}