using System.Text;

namespace Utils;

public static class ArrayUtils
{
    public static void InitializeWith(char[,] array, char fill)
    {
        for (var y = 0; y < array.GetLength(0); ++y)
        {
            for (var x = 0; x < array.GetLength(1); ++x)
            {
                array[y, x] = fill;
            }
        }
    }

    public static string ToString(char[,] array)
    {
        var paint = new StringBuilder();

        for (var y = 0; y < array.GetLength(0); ++y)
        {
            for (var x = 0; x < array.GetLength(1); ++x)
            {
                paint.Append(array[y,x]);
            }

            if (y < array.GetLength(0)-1)
            {
                paint.Append('\r').Append('\n');
            }
        }

        return paint.ToString();
    }
}
