using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Game
    {
        private readonly CellContent[,] table;
        private CellContent nextCellContent = CellContent.X;
        public long TableDimension
        {
            get
            {
                return table.GetLongLength(0);
            }
        }
        public CellContent[,] Table
        {
            get
            {
                return table;
            }
        }
        public bool Done
        {
            get
            {
                return Winner != CellContent.empty;
            }
        }
        public CellContent Winner
        {
            get
            {
                return CellContent.empty;
            }
        }
        public CellContent NextCellContent
        {
            get
            {
                return nextCellContent;
            }
        }

        public Game(long dimension)
        {
            if (dimension < 3) throw new Exception("Dimension must be greater or equal to 3!");
            table = new CellContent[dimension, dimension];
            InitializeTable(dimension);
        }

        public void WriteCellContent(CellContent cellContent, int x, int y)
        {
            table[x, y] = cellContent;
            UpdateNextCellContent();
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
