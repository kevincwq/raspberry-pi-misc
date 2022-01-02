using System.Drawing;

namespace Iot.Device.SenseHat.Extension;

public static class LedMatrixExtension
{
    public static void ShowMessage(this SenseHatLedMatrix ledMatrix, string message, int speedInMs = 90, Color? foreColor = null, Color? backColor = null, Rotation rotation = Rotation.Rotate0, Direction scrollDirection = Direction.Left)
    {
        if (string.IsNullOrWhiteSpace(message))
            return; // nothing to display

        var isReversed = scrollDirection == Direction.Right || scrollDirection == Direction.Down;
        var msg = isReversed ? message.Reverse() : message;
        var pixels = Font8x8.GetPixels(msg!, foreColor ?? Color.White, backColor ?? Color.Black, rotation);
        var rowByRow = scrollDirection == Direction.Up || scrollDirection == Direction.Down;
        var pixelsPerStep = rowByRow ? SenseHatLedMatrix.NumberOfPixelsPerRow : SenseHatLedMatrix.NumberOfPixels / SenseHatLedMatrix.NumberOfPixelsPerRow;

        if (!rowByRow)
        {
            // colors are stored row by row in array from Font8x8.GetPixels()
            // transpose for scrolling col by col
            for (int i = 0; i < msg.Length; i++)
            {
                pixels.Transpose(pixelsPerStep, i * SenseHatLedMatrix.NumberOfPixels);
            }
        }

        // shift by 8 pixels per frame to scroll
        var steps = (pixels.Length - SenseHatLedMatrix.NumberOfPixels) / pixelsPerStep;
        var step = 0;
        do
        {
            var start = isReversed ? (pixels.Length - SenseHatLedMatrix.NumberOfPixels - step * pixelsPerStep) : step * pixelsPerStep;
            var frame = pixels.Skip(start).Take(SenseHatLedMatrix.NumberOfPixels).ToArray();
            if (!rowByRow) 
            {
                // transpose back for displaying row by row
                frame.Transpose(SenseHatLedMatrix.NumberOfPixelsPerRow);
            }
            ledMatrix.Write(frame);
            if (++step > steps)
                break;
            Thread.Sleep(speedInMs);
        } while (true);
    }

    public static void ShowLetter(this SenseHatLedMatrix ledMatrix, char letter, Color? foreColor = null, Color? backColor = null, Rotation rotation = Rotation.Rotate0)
    {
        var frame = Font8x8.GetPixels(letter.ToString(), foreColor ?? Color.White, backColor ?? Color.Black, rotation);
        ledMatrix.Write(frame);
    }

    public static void Clear(this SenseHatLedMatrix ledMatrix)
    {
        ledMatrix.Fill(Color.Black);
    }
}
