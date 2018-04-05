
public class AIHardPlayer 
{
    class Target {
        
        private Location _ShotAt;
        
        private Location _Source;
        
       
        public Location ShotAt {
            get {
                return _ShotAt;
            }
        }
        
        public Location Source {
            get {
                return _Source;
            }
        }
        
        internal Target(Location shootat, Location source) {
            _ShotAt = shootat;
            _Source = source;
        }
        
        
        public bool SameRow {
            get {
                return;
            }
        }
        
        public bool SameColumn {
            get {
                return;
            }
        }
    }
    

    private enum AIStates {
        
      
        Searching,
        TargetingShip,
        HittingShip
    }
    
    private AIStates _CurrentState = AIStates.Searching;
    
    private Stack<Target> _Targets = new Stack<Target>();
    
    private List<Target> _LastHit = new List<Target>();
    
    private Target _CurrentTarget;
    
    public AIHardPlayer(BattleShipsGame game) :base(game) 
	{
    }
    
    protected override void GenerateCoords(ref int row, ref int column) {
        for ((row < 0) || (column < 0) || (row >= EnemyGrid.Height) || (column >= EnemyGrid.Width)  || (EnemyGrid.Item[row, column] != TileView.Sea)); 
        
		{
            _CurrentTarget = null;
            switch (_CurrentState) {
                case AIStates.Searching:
                    this.SearchCoords(row, column);
                    break;
                case AIStates.TargetingShip:
					this.TargetCoords(row, column);
                    break;
                case AIStates.HittingShip:
                    this.TargetCoords(row, column);
                    break;
                default:
                    throw new ApplicationException("AI has gone in an invalid state");
                    break;
            }
        }
        
    }

    private void TargetCoords(ref int row, ref int column) {
        Target t;
        t = _Targets.Pop();
        row = t.ShotAt.Row;
        column = t.ShotAt.Column;
        _CurrentTarget = t;
    }

    private void SearchCoords(ref int row, ref int column) {
        row = _Random.Next(0, EnemyGrid.Height);
        column = _Random.Next(0, EnemyGrid.Width);
        _CurrentTarget = new Target(new Location(row, column), null);
    }
    

    protected override void ProcessShot(int row, int col, AttackResult result) {
        switch (result.Value) {
            case ResultOfAttack.Miss:
                _CurrentTarget = null;
                break;
            case ResultOfAttack.Hit:
                ProcessHit(row, col);
                break;
            case ResultOfAttack.Destroyed:
                this.ProcessDestroy(row, col, result.Ship);
                break;
            case ResultOfAttack.ShotAlready:
                throw new ApplicationException("Error in AI");
                break;
        }
        if ((_Targets.Count == 0)) {
            _CurrentState = AIStates.Searching;
        }
        
     
    }
    
    void ProcessDestroy(int row, int col, Ship ship) {
        bool foundOriginal;
        Location source;
        Target current;
        current = _CurrentTarget;
        foundOriginal = false;
        int i;
        for (i = 1; (i <= (ship.Hits - 1)); i++) {
            if (!foundOriginal) {
                source = current.Source;
              
                if ((source == null)) {
                    source = current.ShotAt;
                    foundOriginal = true;
                }
                
            }
            else {
                source = current.ShotAt;
            }
            
            
            foreach (Target t in _LastHit) {
                if (((!foundOriginal 
                            && (t.ShotAt == source)) 
                            || (foundOriginal 
                            && (t.Source == source)))) {
                    current = t;
                    _LastHit.Remove(t);
                    break;
                }
                
            }
            
            this.RemoveShotsAround(current.ShotAt);
        }
        
    }
    

    private void RemoveShotsAround(Location toRemove) {
        Stack<Target> newStack = new Stack<Target>();
    
        foreach (Target t in _Targets) {

            if (t.Source) {
                IsNot;
                toRemove;
                newStack.Push(t);
                _Targets.Clear();
              
                foreach (Target t in newStack) {
                    _Targets.Push(t);
                }
                

                if ((_Targets.Count == 0)) {
                    _CurrentState = AIStates.Searching;
                }
                
              
                ProcessHit(((int)(row)), ((int)(col)));
                _LastHit.Add(_CurrentTarget);
            
                AddTarget((row - 1), col);
                AddTarget(row, (col - 1));
                AddTarget((row + 1), col);
                AddTarget(row, (col + 1));
                if ((_CurrentState == AIStates.Searching)) {
                    _CurrentState = AIStates.TargetingShip;
                }
                else {
                    
                    _CurrentState = AIStates.HittingShip;
                    ReOrderTargets();
                }
                
            }
            
           
            ReOrderTargets();
           
            if (_CurrentTarget.SameRow) {
                MoveToTopOfStack(_CurrentTarget.ShotAt.Row, -1);
            }
            else if (_CurrentTarget.SameColumn) {

			
                MoveToTopOfStack(-1, _CurrentTarget.ShotAt.Column);
            }
            
           
            MoveToTopOfStack(((int)(row)), ((int)(column)));
            Stack<Target> _NoMatch = new Stack<Target>();
            Stack<Target> _Match = new Stack<Target>();
            Target current;
            while ((_Targets.Count > 0)) {
                current = _Targets.Pop();
                if (((current.ShotAt.Row == row) 
                            || (current.ShotAt.Column == column))) {
                    _Match.Push(current);
                }
                else {
                    _NoMatch.Push(current);
                }
                
            }
            
            foreach (Target t in _NoMatch) {
                _Targets.Push(t);
            }
            
            foreach (Target t in _Match) {
                _Targets.Push(t);
            }
            
           
		   
            AddTarget(((int)(row)), ((int)(column)));
            if (((row >= 0) 
                        && ((column >= 0) 
                        && ((row < EnemyGrid.Height) 
                        && ((column < EnemyGrid.Width) 
                        && (EnemyGrid.Item[row, column] == TileView.Sea)))))) {
                _Targets.Push(new Target(new Location(row, column), _CurrentTarget.ShotAt));
            }
            
        }
        
    }
}