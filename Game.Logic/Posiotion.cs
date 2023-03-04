using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Logic
{
    public class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public int Sum 
        { 
            get 
            { 
                return Row + Col; 
            } 
        }

        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public bool IsValid(int from = 0, int to = 10)
        {
            if (Row >= from && Row < to && Col >= from && Col < to)
                return true;

            return false;
        }

        public override string ToString()
        {
            return Row.ToString() + "_" + Col.ToString();
        }
    }
}
