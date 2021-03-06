using System;
using System.Collections;
using System.Collections.Generic;

/* <summary>
* A Ship has all the details about itself. For example the shipname,
* size, number of hits taken and the location. Its able to add tiles,
* remove, hits taken and if its deployed and destroyed.
* </summary>
* <remarks>
* Deployment information is supplied to allow ships to be drawn.
* </remarks>
*/
namespace BattleShip
{
    public class Ship
    {
        //declares Ship properties
        private ShipName _shipName;    //Ship name
        private int _sizeOfShip;        //Ship size
        private int _hitsTaken = 0;     //hits
        private List<Tile> _tiles;      //list of tiles taken by ship
        private int _row;               //location row
        private int _col;               //location column
        private Direction _direction;   //direction facing
		
		/* <summary>
		* The type of ship
		* </summary>
		* <value>The type of ship</value>
		* <returns>The type of ship</returns>
        */
		public string Name
        {
            get
            {
                if (_shipName == ShipName.AircraftCarrier)
                {
                    return "Aircraft Carrier";
                }

                return _shipName.ToString();
            }
        }
		
		/* <summary>
		* The number of cells that this ship occupies.
		* </summary>
		* <value>The number of hits the ship can take</value>
		* <returns>The number of hits the ship can take</returns>
        */
		public int Size
        {
            get
            {
                return _sizeOfShip;
            }
        }

		/* <summary>
		* The number of hits that the ship has taken.
		* </summary>
		* <value>The number of hits the ship has taken.</value>
		* <returns>The number of hits the ship has taken</returns>
		* <remarks>When this equals Size the ship is sunk</remarks>
        */
		public int Hits
        {
            get
            {
                return _hitsTaken;
            }
        }

		/* <summary>
		* The row location of the ship
		* </summary>
		* <value>The topmost location of the ship</value>
		* <returns>the row of the ship</returns>
        */
		public int Row
        {
            get
            {
                return _row;
            }
        }

        /* <summary>
        * The column location of the ship
        * </summary>
        * <value>The topmost location of the ship</value>
        * <returns>the column of the ship</returns>
        */
        public int Column
        {
            get
            {
                return _col;
            }
        }

        /* <summary>
        * The direction of the ships facing
        * </summary>
        * <value>The ships orientation</value>
        * <returns>Ships orientation</returns>
        */
        public Direction Direction
        {
            get
            {
                return _direction;
            }
        }

        /* <summary>
        * The properties of the ships initial location, name and size
        * </summary>
        * <value>The name of the ship</value>
        * <value>The tiles it occupies</value>
        * <value>the size of the ship</value>
        * <returns>information about the ship and its occupied tiles</returns>
        */

        public Ship(ShipName ship)
        {
            _shipName = ship;
            _tiles = new List<Tile>();
            _sizeOfShip = (int)_shipName;	//get the ship size from the enum
        }

		/* <summary>
		* Add tile adds the ship tile
		* </summary>
		* <param name="tile">one of the tiles the ship is on</param>
        */
		public void AddTile(Tile tile)
        {
            _tiles.Add(tile);
        }

		/* <summary>
		* Remove clears the tile back to a sea tile
		* </summary>
        */
		public void Remove()
        {
            foreach (Tile tile in _tiles)
            {
                tile.ClearShip();
            }

            _tiles.Clear();
        }

        /* <summary>
         * increments the number of hits taken by a given ship
         * </summary>
         */ 
        public void Hit()
        {
            _hitsTaken = _hitsTaken + 1;
        }

		/* <summary>
		* IsDeployed returns if the ships is deployed, if its deplyed it has more than
		* 0 tiles
		* </summary>
        */
		public bool IsDeployed
        {
            get
            {
                return _tiles.Count > 0;
            }
        }

        /* <summary>
         * IsDestroyed returns if the hits on a ship are equal to the ships size
         * </summary>
         */ 
        public bool IsDestroyed
        {
            get
            {
                return Hits == Size;
            }
        }
		
		/* <summary>
		* Record that the ship is now deployed.
		* </summary>
		* <param name="direction"></param>
		* <param name="row"></param>
		* <param name="col"></param>
        */
		internal void Deployed(Direction direction, int row, int col)
        {
            _row = row;
            _col = col;
            _direction = direction;
        }
    }
}