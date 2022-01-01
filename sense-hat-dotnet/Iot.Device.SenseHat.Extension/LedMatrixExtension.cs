using System.Drawing;

namespace Iot.Device.SenseHat.Extension;

public enum Direction : byte
{
    Left,
    Right,
    Up,
    Down
}

public static class LedMatrixExtension
{
    public static void ShowMessage(this SenseHatLedMatrix ledMatrix, string message, int speedInMs = 90, Color? text_color = null, Color? back_color = null, Direction scrollDirection = Direction.Left)
    {
        if (string.IsNullOrWhiteSpace(message))
            return; // nothing to display

        Color t_color = text_color ?? Color.White;
        Color b_color = back_color ?? Color.Black;
        var rowByRow = scrollDirection == Direction.Up || scrollDirection == Direction.Down;
        var isReversed = scrollDirection == Direction.Right || scrollDirection == Direction.Down;
        var msg = isReversed ? message.Reverse() : message;
        var pixels = Font8x8.GetPixels(msg!, t_color, b_color, rowByRow);

        // shift by 8 pixels per frame to scroll
        var pixelsPerStep = rowByRow ? SenseHatLedMatrix.NumberOfPixelsPerRow : SenseHatLedMatrix.NumberOfPixels / SenseHatLedMatrix.NumberOfPixelsPerRow;
        var steps = (pixels.Length - SenseHatLedMatrix.NumberOfPixels) / pixelsPerStep;
        var step = 0;
        do
        {
            var start = isReversed ? (pixels.Length - SenseHatLedMatrix.NumberOfPixels - step * pixelsPerStep) : step * pixelsPerStep;
            var frame = pixels.Skip(start).Take(SenseHatLedMatrix.NumberOfPixels).ToArray();
            if (!rowByRow) // transpose
            {
                frame.Transpose(SenseHatLedMatrix.NumberOfPixelsPerRow);
            }
            ledMatrix.Write(frame);
            if (++step > steps)
                break;
            Thread.Sleep(speedInMs);
        } while (true);
    }

    public static void ShowLetter(this SenseHatLedMatrix ledMatrix, char letter, Color? text_color = null, Color? back_color = null)
    {
        Color t_color = text_color ?? Color.White;
        Color b_color = back_color ?? Color.Black;
        var pixels = Font8x8.GetPixels(letter.ToString(), t_color, b_color);
        ledMatrix.Write(pixels);
    }

    public static void Clear(this SenseHatLedMatrix ledMatrix)
    {
        ledMatrix.Fill(Color.Black);
    }

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
        T temp;
        for (int i = 1; i < edgeLen; i++)
        {
            for (int j = 0; j < i; j++)
            {
                temp = array[j * edgeLen + i];
                array[j * edgeLen + i] = array[i * edgeLen + j];
                array[i * edgeLen + j] = temp;
            }
        }
    }
}
