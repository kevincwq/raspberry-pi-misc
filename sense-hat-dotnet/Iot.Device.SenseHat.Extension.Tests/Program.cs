
using Iot.Device.SenseHat;
using Iot.Device.SenseHat.Extension;
using System.Drawing;

using SenseHat sh = new SenseHat();
var message = "+-*/!\"#$><0123456789.=)(ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz?,;:|@%[&_']\\~";

while (!Console.KeyAvailable)
{
    sh.LedMatrix.ShowMessage(message, 100, Color.Blue, Color.Black, LedMatrixExtension.Direction.Left);

    sh.LedMatrix.ShowMessage(message, 100, Color.Red, Color.Black, LedMatrixExtension.Direction.Right);

    sh.LedMatrix.ShowMessage(message, 100, Color.Green, Color.Black, LedMatrixExtension.Direction.Up);

    sh.LedMatrix.ShowMessage(message, 100, Color.Yellow, Color.Black, LedMatrixExtension.Direction.Down);
}