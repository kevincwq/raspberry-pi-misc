
using Iot.Device.SenseHat;
using Iot.Device.SenseHat.Extension;
using System.Drawing;

using SenseHat sh = new SenseHat();
var message = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

while (true)
{
    int speedInMs = 10;

    Console.WriteLine("Showing letters by ShowLetter()");
    foreach (var letter in message)
    {
        sh.LedMatrix.ShowLetter(letter);
        Thread.Sleep(speedInMs * 20);
    }

    Console.WriteLine("Showing letters by ShowMessage()");
    for (int i = 0; i < message.Length; i++)
    {
        var letter = message[i];
        sh.LedMatrix.ShowMessage(letter.ToString(), scrollDirection: (Direction)(i % 4)); // direction should have no effect
        Thread.Sleep(speedInMs * 20);
    }

    Console.WriteLine("Showing message right to left");

    sh.LedMatrix.ShowMessage(message, speedInMs, Color.Blue, Color.Black, Direction.Left);

    Console.WriteLine("Showing message left to right");

    sh.LedMatrix.ShowMessage(message, speedInMs, Color.Red, Color.Black, Direction.Right);

    Console.WriteLine("Showing message down to up");

    sh.LedMatrix.ShowMessage(message, speedInMs, Color.Green, Color.Black, Direction.Up);

    Console.WriteLine("Showing message up to down");

    sh.LedMatrix.ShowMessage(message, speedInMs, Color.Yellow, Color.Black, Direction.Down);
}
