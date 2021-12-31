from sense_hat import SenseHat
sense = SenseHat()

# Define the colours red and green
red = (255, 0, 0)
green = (0, 255, 0)

try:
  while True:

    # Take readings from all three sensors
    t = sense.get_temperature()
    p = sense.get_pressure()
    h = sense.get_humidity()

    # Round the values to one decimal place
    t = round(t, 1)
    p = round(p, 1)
    h = round(h, 1)
  
    # Create the message
    # str() converts the value to a string so it can be concatenated
    message = "T: " + str(t) + " P: " + str(p) + " H: " + str(h)
  
    if t > 18 and t < 28:
      bg = green
    else:
      bg = red
  
    # Display the scrolling message
    sense.show_message(message, scroll_speed=0.1, back_colour=bg)
except KeyboardInterrupt:
  sense.clear()
  pass
