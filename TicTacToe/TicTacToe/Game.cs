using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Game
    {
        private readonly CellContent[,] table;
        private CellContent nextCellContent = CellContent.X;
        private Ranking rank = new Ranking("scores.bin");
        private Player player1 = new Player();
        private Player player2 = new Player();



		
		public long TableDimension
        {
            get
            {
                return 3;
            }
        }
        public CellContent[,] Table
        {
            get
            {
                return table;
            }
        }

		public bool Done { get; set; }
        public CellContent Winner { get; set; }

        public CellContent NextCellContent
        {
            get
            {
                return nextCellContent;
            }
        }

		internal Ranking Rank { get => rank; set => rank = value; }
		internal Player Player1 { get => player1; set => player1 = value; }
		internal Player Player2 { get => player2; set => player2 = value; }

		public Game()
        {
            table = new CellContent[TableDimension, TableDimension];
            Done = false;      
            InitializeTable(TableDimension);
        }

        public void CheckIsGameOver()
        {
            if (CheckDiagonalValues() || CheckRowValues() || CheckColValues())
            {
                Done = true;

            }
            else
            {
                Done = false;
            }
        }

        private bool CheckColValues()
        {

            int counterX = 0, counterY = 0;

            for (int j = 0; j < TableDimension; ++j)
            {
                counterX = 0;
                counterY = 0;

                for (int i = 0; i < TableDimension; ++i)
                {

                    if (Table[i, j] == CellContent.X)
                    {
                        counterX++;
                    }
                    else if (Table[i, j] == CellContent.O)
                    {
                        counterY++;
                    }
                }

                if (counterX >= TableDimension)
                {
                    Winner = CellContent.X;
                    return true;

                }
                else if (counterY >= TableDimension)
                {
                    Winner = CellContent.O;
                    return true;
                }
            }

            return false;
        }

        private bool CheckRowValues()
        {

            int counterX = 0, counterY = 0;

            for (int i = 0; i < TableDimension; ++i)
            {
                counterX = 0;
                counterY = 0;
                for (int j = 0; j < TableDimension; ++j)
                {

                    if (Table[i, j] == CellContent.X)
                    {
                        counterX++;
                    }
                    else if (Table[i, j] == CellContent.O)
                    {
                        counterY++;
                    }
                }

                if (counterX >= TableDimension)
                {
                    Winner = CellContent.X;
                    return true;

                }
                else if (counterY >= TableDimension)
                {
                    Winner = CellContent.O;
                    return true;
                }
            }

            return false;
        }

        private bool CheckDiagonalValues()
        {
            int counterX = 0, counterY = 0;

            for (int i = 0; i < TableDimension; ++i)
            {
                for (int j = 0; j < TableDimension; ++j)
                {
                    if (i != j) continue;

                    if (Table[i, j] == CellContent.X)
                    {
                        counterX++;
                    }
                    else if (Table[i, j] == CellContent.O)
                    {
                        counterY++;
                    }
                }
            }

            if (counterX >= TableDimension)
            {
                Winner = CellContent.X;
                return true;

            }
            else if (counterY >= TableDimension)
            {
                Winner = CellContent.O;
                return true;
            }

            return false;
        }



        public bool WriteCellContent(CellContent cellContent, int x, int y)
        {
            if (x > TableDimension - 1 || y > TableDimension - 1 || table[x, y] != CellContent.empty)
            {
                return false;
            }

            table[x, y] = cellContent;
            UpdateNextCellContent();

            return true;
        }

        private void UpdateNextCellContent()
        {
            nextCellContent = nextCellContent == CellContent.X ? CellContent.O : CellContent.X;
        }

        private void InitializeTable(long dimension)
        {
            for (int i = 0; i < dimension; ++i)
            {
                for (int j = 0; j < dimension; ++j)
                {
                    table[i, j] = CellContent.empty;
                }
            }
        }


    }
}
