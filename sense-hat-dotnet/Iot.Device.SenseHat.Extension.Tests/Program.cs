
using Iot.Device.SenseHat;
using Iot.Device.SenseHat.Extension;
using System.Drawing;

using SenseHat sh = new SenseHat();
var message = " 0123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZ ΔΘΠΣΦΨΩαβζ ~!@#$%^&*()_+ ";
int speedInMs = 10;

foreach (var rotation in Enum.GetValues<Rotation>())
{
    Console.WriteLine("Showing letters by ShowLetter() - {0}", rotation);
    foreach (var letter in message)
    {
        sh.LedMatrix.ShowLetter(letter, Color.Blue, Color.Black, rotation);
        Thread.Sleep(speedInMs * 10);
    }
}

foreach (var rotation in Enum.GetValues<Rotation>())
{
    Console.WriteLine("Showing letters by ShowMessage()- {0}", rotation);
    foreach (var letter in message)
    {
        sh.LedMatrix.ShowMessage(letter.ToString(), foreColor: Color.Blue, rotation: rotation);
        Thread.Sleep(speedInMs * 10);
    }
}

foreach (var rotation in Enum.GetValues<Rotation>())
{
    Console.WriteLine("Scrolling message to left- {0}", rotation);

    sh.LedMatrix.ShowMessage(message, speedInMs, Color.Blue, Color.Black, rotation, Direction.Left);
}

foreach (var rotation in Enum.GetValues<Rotation>())
{
    Console.WriteLine("Scrolling messageto right- {0}", rotation);

    sh.LedMatrix.ShowMessage(message, speedInMs, Color.Red, Color.Black, rotation, Direction.Right);
}

foreach (var rotation in Enum.GetValues<Rotation>())
{
    Console.WriteLine("Scrolling message to up- {0}", rotation);

    sh.LedMatrix.ShowMessage(message, speedInMs, Color.Green, Color.Black, rotation, Direction.Up);
}

foreach (var rotation in Enum.GetValues<Rotation>())
{
    Console.WriteLine("Scrolling message to down- {0}", rotation);

    sh.LedMatrix.ShowMessage(message, speedInMs, Color.Yellow, Color.Black, rotation, Direction.Down);
}
