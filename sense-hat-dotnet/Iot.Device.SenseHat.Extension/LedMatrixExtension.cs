using System.Drawing;

namespace Iot.Device.SenseHat.Extension;

public static class LedMatrixExtension
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    public static void ShowMessage(this SenseHatLedMatrix ledMatrix, string message, int speedInMs = 90, Color? text_color = null, Color? back_color = null, Direction scrollDirection = Direction.Left)
    {
        Color t_color = text_color ?? Color.White;
        Color b_color = back_color ?? Color.Black;
        var msg = " " + message + " "; // padding
        var isVertical = scrollDirection == Direction.Up || scrollDirection == Direction.Down;
        var pixels = Font8x8.GetPixels(msg, t_color, b_color, isVertical);

        // Shift right/bottom by 8 pixels per frame to scroll
        var scroll_length = pixels.Length / 8 - 8;
        for (int i = 0; i < scroll_length; i++)
        {
            var start = (scrollDirection == Direction.Left || scrollDirection == Direction.Up) ? i * 8 : pixels.Length - (i + 8) * 8;
            ledMatrix.Write(pixels.Skip(start).Take(64).ToArray());
            Thread.Sleep(speedInMs);
        }
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
}