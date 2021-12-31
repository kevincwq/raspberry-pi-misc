from sense_hat import SenseHat

sense = SenseHat()

# sense.set_pixel(2, 2, (0, 0, 255))
# sense.set_pixel(4, 2, (0, 0, 255))
# sense.set_pixel(3, 4, (100, 0, 0))
# sense.set_pixel(1, 5, (255, 0, 0))
# sense.set_pixel(2, 6, (255, 0, 0))
# sense.set_pixel(3, 6, (255, 0, 0))
# sense.set_pixel(4, 6, (255, 0, 0))
# sense.set_pixel(5, 5, (255, 0, 0))

# Define some colours
B = (102, 51, 0)
b = (0, 0, 255)
S = (205,133,63)
W = (255, 255, 255)

# Set up where each colour will display
steve_pixels = [
    B, B, B, B, B, B, B, B,
    B, B, B, B, B, B, B, B,
    B, S, S, S, S, S, S, B,
    S, S, S, S, S, S, S, S,
    S, W, b, S, S, b, W, S,
    S, S, S, B, B, S, S, S,
    S, S, B, S, S, B, S, S,
    S, S, B, B, B, B, S, S
]

# Display these colours on the LED matrix
sense.set_pixels(steve_pixels)
