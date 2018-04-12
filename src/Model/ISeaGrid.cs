using System;
using System.Collections;
using System.Collections.Generic;
public interface ISeaGrid {

	int Width { get; }

	int Height { get; }

	event EventHandler Changed;
	
	TileView this[int row, int column] { get; }
	
	AttackResult HitTile(int row, int col);
}