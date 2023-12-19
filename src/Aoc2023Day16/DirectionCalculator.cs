namespace Aoc2023Day16;

public class DirectionCalculator
{
    public IEnumerable<Direction> Next(char tile, Direction goingTo)
    {
        if (tile == '.')
            return [goingTo];

        if (tile == '/')
        {
            switch (goingTo)
            {
                case Direction.East:
                    return [Direction.North];
                case Direction.West:
                    return [Direction.South];
                case Direction.North:
                    return [Direction.East];
                case Direction.South:
                    return [Direction.West];
            }
        }

        if (tile == '\\')
        {
            switch (goingTo)
            {
                case Direction.East:
                    return [Direction.South];
                case Direction.West:
                    return [Direction.North];
                case Direction.North:
                    return [Direction.West];
                case Direction.South:
                    return [Direction.East];
            }
        }

        if (tile == '|')
        {
            if (goingTo == Direction.North || goingTo == Direction.South)
            {
                return [goingTo];
            }

            return [Direction.North, Direction.South];
        }

        if (tile == '-')
        {
            if (goingTo == Direction.East || goingTo == Direction.West)
            {
                return [goingTo];
            }

            return [Direction.East, Direction.West];
        }

        throw new NotImplementedException();
    }
}
