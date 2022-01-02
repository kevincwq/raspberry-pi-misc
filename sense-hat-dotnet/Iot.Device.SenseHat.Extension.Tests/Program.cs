
using Iot.Device.SenseHat;
using Iot.Device.SenseHat.Extension;
using System.Drawing;

using SenseHat sh = new SenseHat();
var message = " 0123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZ ΔΘΠΣΦΨΩαβζ ~!@#$%^&*()_+ ";

foreach (var rotation in Enum.GetValues<Rotation>())
{
    int speedInMs = 10;

    Console.WriteLine("Showing letters by ShowLetter() - {0}", rotation);
    foreach (var letter in message)
    {
        sh.LedMatrix.ShowLetter(letter, rotation: rotation);
        Thread.Sleep(speedInMs * 10);
    }

    Console.WriteLine("Showing letters by ShowMessage()- {0}", rotation);
    for (int i = 0; i < message.Length; i++)
    {
        var letter = message[i];
        sh.LedMatrix.ShowMessage(letter.ToString(), rotation: rotation, scrollDirection: (Direction)(i % 4)); // direction should have no effect
        Thread.Sleep(speedInMs * 10);
    }

    Console.WriteLine("Scrolling message to left- {0}", rotation);

    sh.LedMatrix.ShowMessage(message, speedInMs, Color.LightBlue, Color.Black, rotation, Direction.Left);

    Console.WriteLine("Scrolling messageto right- {0}", rotation);

    sh.LedMatrix.ShowMessage(message, speedInMs, Color.LightPink, Color.Black, rotation, Direction.Right);

    Console.WriteLine("Scrolling message to up- {0}", rotation);

    sh.LedMatrix.ShowMessage(message, speedInMs, Color.LightGreen, Color.Black, rotation, Direction.Up);

    Console.WriteLine("Scrolling message to down- {0}", rotation);

    sh.LedMatrix.ShowMessage(message, speedInMs, Color.LightYellow, Color.Black, rotation, Direction.Down);
}
