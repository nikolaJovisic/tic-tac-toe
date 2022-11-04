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
	}
}
