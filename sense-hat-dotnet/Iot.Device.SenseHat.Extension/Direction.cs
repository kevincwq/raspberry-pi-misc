namespace Iot.Device.SenseHat.Extension;

/// <summary>
/// Specifies the direction to apply to scrolling.
/// </summary>
public enum Direction : byte
{
    /// <summary>
    /// Go toward left.
    /// </summary>
    Left,

    /// <summary>
    /// Go toward right.
    /// </summary>
    Right,

    /// <summary>
    /// Go toward up.
    /// </summary>
    Up,

    /// <summary>
    /// Go toward down.
    /// </summary>
    Down
}