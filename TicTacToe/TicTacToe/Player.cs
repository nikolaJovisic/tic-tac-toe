using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
	internal class Player
	{
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private CellContent shape;

		public CellContent Shape
		{
			get { return shape; }
			set { shape = value; }
		}

		private PlayerScore score;

		public PlayerScore Score
		{
			get { return score; }
			set { score = value; }
		}

		public Player(string name, CellContent shape, PlayerScore score)
		{
			Name = name;
			Shape = shape;
			Score = score;
		}

		public Player()
		{

		}
	}
}
