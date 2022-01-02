namespace Iot.Device.SenseHat.Extension;

internal static class MiscExtensions
{
    public static string Reverse(this string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static void Transpose<T>(this T[] array, int edgeLen)
    {
        _ = array ?? throw new ArgumentNullException(nameof(array));
        if (array.Length != edgeLen * edgeLen)
            throw new ArgumentOutOfRangeException(nameof(array), "size of array doesn't match edgeLen*edgeLen");
        int i, j;
        for (i = 1; i < edgeLen; i++)
        {
            for (j = 0; j < i; j++)
            {
                Swap(ref array[j * edgeLen + i], ref array[i * edgeLen + j]);
            }
        }
    }

    public static void FlipUpDown<T>(this T[] array, int edgeLen)
    {
        _ = array ?? throw new ArgumentNullException(nameof(array));
        if (array.Length != edgeLen * edgeLen)
            throw new ArgumentOutOfRangeException(nameof(array), "size of array doesn't match edgeLen*edgeLen");
        int i, j;
        for (i = 1; i < edgeLen; i++)
        {
            for (j = 0; j < edgeLen / 2; j++)
            {
                Swap(ref array[j * edgeLen + i], ref array[(edgeLen - 1 - j) * edgeLen + i]);
            }
        }
    }

    public static void FlipLeftRight<T>(this T[] array, int edgeLen)
    {
        _ = array ?? throw new ArgumentNullException(nameof(array));
        if (array.Length != edgeLen * edgeLen)
            throw new ArgumentOutOfRangeException(nameof(array), "size of array doesn't match edgeLen*edgeLen");
        int i, j;
        for (i = 1; i < edgeLen / 2; i++)
        {
            for (j = 0; j < edgeLen; j++)
            {
                Swap(ref array[j * edgeLen + i], ref array[j * edgeLen + (edgeLen - 1 - i)]);
            }
        }
    }

    public static void Rotate<T>(this T[] array, int edgeLen, Rotation rotation)
    {
        switch (rotation)
        {
            case Rotation.Rotate0:
                break;
            case Rotation.Rotate90:
                Rotate90(array, edgeLen);
                break;
            case Rotation.Rotate180:
                Rotate180(array, edgeLen);
                break;
            case Rotation.Rotate270:
                Rotate270(array, edgeLen);
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

    private static void Rotate90<T>(T[] array, int edgeLen)
    {
        _ = array ?? throw new ArgumentNullException(nameof(array));
        if (array.Length != edgeLen * edgeLen)
            throw new ArgumentOutOfRangeException(nameof(array), "size of array doesn't match edgeLen*edgeLen");

        //REVERSE every col 
        array.FlipUpDown(edgeLen);
        // Performing Transpose
        array.Transpose(edgeLen);
    }

    private static void Rotate180<T>(T[] array, int edgeLen)
    {
        _ = array ?? throw new ArgumentNullException(nameof(array));
        if (array.Length != edgeLen * edgeLen)
            throw new ArgumentOutOfRangeException(nameof(array), "size of array doesn't match edgeLen*edgeLen");
        int i, j;
        for (i = 1; i < edgeLen; i++)
        {
            for (j = 0; j < i; j++)
            {
                Swap(ref array[j * edgeLen + i], ref array[(edgeLen - 1 - i) * edgeLen + (edgeLen - 1 - j)]);
            }
        }
    }

    private static void Rotate270<T>(T[] array, int edgeLen)
    {
        _ = array ?? throw new ArgumentNullException(nameof(array));
        if (array.Length != edgeLen * edgeLen)
            throw new ArgumentOutOfRangeException(nameof(array), "size of array doesn't match edgeLen*edgeLen");

        //REVERSE every row 
        array.FlipLeftRight(edgeLen);
        // Performing Transpose
        array.Transpose(edgeLen);
    }
}
