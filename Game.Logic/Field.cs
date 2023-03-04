namespace Game.Logic
{
    public class Field
    {
        public Field()
        {
            GenerateField();
        }

        public Checker?[,] CheckersField { get; private set; } = new Checker[10, 10];

        public void GenerateField()
        {
            for (var i = 0; i < CheckersField.GetLength(0); i++)
            {
                for (var j = 0; j < CheckersField.GetLength(1); j++)
                {
                    if (j % 2 == ((i + 1) % 2))
                        if (i < 4)
                            CheckersField[i, j] = new Checker(CheckerType.White, new Position(i, j));
                        else if (i > 5)
                            CheckersField[i, j] = new Checker(CheckerType.Black, new Position(i, j));
                }
            }
        }

        //If type will be null returns all checkers amount
        public int GetCheckersAmount(Nullable<CheckerType> type = null)
        {
            int amount = 0;

            for (var i = 0; i < CheckersField.GetLength(0); i++)
            {
                for (var j = 0; j < CheckersField.GetLength(1); j++)
                {
                    if (CheckersField[i, j] != null)
                    {
                        if (type == null)
                            amount++;
                        else if (CheckersField[i, j].Type == type)
                            amount++;
                    }
                }
            }

            return amount;
        }

        public List<Position> GetAvailableMovesFor(Checker checker)
        {
            if (CheckersField[checker.Position.Row, checker.Position.Col] == null)
                throw new ArgumentException("Chacker doesn't exist on the field.");

            var avaliableMoves = new List<Position>();

            if (checker.Type == CheckerType.White)
            {
                avaliableMoves.Add(new Position(checker.Position.Row + 1, checker.Position.Col + 1));
                avaliableMoves.Add(new Position(checker.Position.Row + 1, checker.Position.Col - 1));
            }
            else
            {
                avaliableMoves.Add(new Position(checker.Position.Row - 1, checker.Position.Col - 1));
                avaliableMoves.Add(new Position(checker.Position.Row - 1, checker.Position.Col + 1));
            }

            return avaliableMoves.Where(am => am.IsValid() && CheckersField[am.Row, am.Col] == null).ToList();
        }

        public void MoveChecker(Checker checker, int newRow, int newCol)
        {
            if (CheckersField[checker.Position.Row, checker.Position.Col] == null)
                throw new ArgumentException("Chacker doesn't exist on the field.");

            CheckersField[checker.Position.Row, checker.Position.Col] = null;
            CheckersField[newRow, newCol] = checker;
            checker.Position.Row = newRow;
            checker.Position.Col = newCol;
        }
    }
}
