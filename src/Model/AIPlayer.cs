using System;
using System.Collections;
using System.Collections.Generic;
using SwinGameSDK;

public abstract class AIPlayer : Player
{
	protected class Location
	{
		private int _Row;

		private int _Column;

		//row property
		public int Row
		{
			get
			{
				return _Row;
			}
			set
			{
				_Row = value;
			}
		}

		//col property
		public int Column
		{
			get
			{
				return _Column;
			}
			set
			{
				_Column = value;
			}
		}

		public Location (int row, int column)
		{
			_Column = column;
			_Row = row;
		}

		//might be @this as opposed to *this, double check
		public static bool operator== (Location @this, Location other)
		{
			//ReferenceEquals is checking if two things are equal
			return 	(@this != null) &&
					(other != null) &&
					(@this.Row == other.Row	) &&
					(@this.Column == other.Column);
		}

		public static bool operator!= (Location @this, Location other)
		{
			return 	(@this == null) ||
					(other == null) ||
					(@this.Row != other.Row) ||
					(@this.Column != other.Column);
		}
	}

	public AIPlayer (BattleShipsGame game) : base (game)
	{ }

	protected abstract void GenerateCoords (ref int row, ref int column);

	protected abstract void ProcessShot (int row, int col, AttackResult result);

	public override AttackResult Attack ()
	{
		AttackResult result;
		int row = 0;
		int column = 0;

		do {
			Delay ();

			GenerateCoords (ref row, ref column);
			result = _game.Shoot (row, column);
			ProcessShot (row, column, result);
		} while (result.Value != ResultOfAttack.Miss && result.Value != ResultOfAttack.GameOver && !SwinGame.WindowCloseRequested ());

		return result;
	}

	private void Delay ()
	{
		for (int i = 0; i <= 150; i++) {
			if (SwinGame.WindowCloseRequested ()) return;

			SwinGame.Delay (5);
			SwinGame.ProcessEvents ();
			SwinGame.RefreshScreen ();
		}
	}
}