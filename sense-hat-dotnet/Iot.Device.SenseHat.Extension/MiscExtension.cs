namespace Iot.Device.SenseHat.Extension;

public static class MiscExtension
{
    public static string Reverse(this string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static byte ReverseBits(this byte value)
    {
        return (byte)(((value * 0x80200802ul) & 0x0884422110ul) * 0x0101010101ul >> 32);
    }

    public static void Transpose<T>(this T[] array, int edgeLen, int startIndex = 0)
    {
        int i, j;
        for (i = 1; i < edgeLen; i++)
        {
            for (j = 0; j < i; j++)
            {
                Swap(ref array[startIndex + j * edgeLen + i], ref array[startIndex + i * edgeLen + j]);
            }
        }
    }

    public static void FlipUpDown<T>(this T[] array, int edgeLen, int startIndex = 0)
    {
        int i, j;
        for (i = 0; i < edgeLen; i++)
        {
            for (j = 0; j < edgeLen / 2; j++)
            {
                Swap(ref array[startIndex + j * edgeLen + i], ref array[startIndex + (edgeLen - 1 - j) * edgeLen + i]);
            }
        }
    }

    public static void FlipLeftRight<T>(this T[] array, int edgeLen, int startIndex = 0)
    {
        int i, j;
        for (i = 0; i < edgeLen / 2; i++)
        {
            for (j = 0; j < edgeLen; j++)
            {
                Swap(ref array[startIndex + j * edgeLen + i], ref array[startIndex + j * edgeLen + (edgeLen - 1 - i)]);
            }
        }
    }

    public static void Rotate<T>(this T[] array, int edgeLen, int startIndex = 0, Rotation rotation = Rotation.Rotate0)
    {
        switch (rotation)
        {
            case Rotation.Rotate0:
                break;
            case Rotation.Rotate90:
                Rotate90(array, edgeLen, startIndex);
                break;
            case Rotation.Rotate180:
                Rotate180(array, edgeLen, startIndex);
                break;
            case Rotation.Rotate270:
                Rotate270(array, edgeLen, startIndex);
                break;
            default:
                break;
        }
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T t = y;
        y = x;
        x = t;
    }

    private static void Rotate90<T>(T[] array, int edgeLen, int startIndex = 0)
    {
        //REVERSE every col 
        array.FlipUpDown(edgeLen, startIndex);
        // Performing Transpose
        array.Transpose(edgeLen, startIndex);
    }

    private static void Rotate180<T>(T[] array, int edgeLen, int startIndex = 0)
    {
        Array.Reverse(array, startIndex, edgeLen * edgeLen);
    }

    private static void Rotate270<T>(T[] array, int edgeLen, int startIndex = 0)
    {
        //REVERSE every row 
        array.FlipLeftRight(edgeLen, startIndex);
        // Performing Transpose
        array.Transpose(edgeLen, startIndex);
    }
}
