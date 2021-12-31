from sense_hat import SenseHat
from time import sleep

sense = SenseHat()

e = (0, 0, 0)
w = (255, 255, 255)

sense.clear()

while True:
  for event in sense.stick.get_events():
    print(event.direction, event.action)
    # check if the joystick was pressed
    if event.action == "pressed":
      # check which direction
      if event.direction == "up":
        sense.show_letter("U")
      if event.direction == "down":
        sense.show_letter("D")
      if event.direction == "left":
        sense.show_letter("L")
      if event.direction == "right":
        sense.show_letter("R")
      if event.direction == "middle":
        sense.show_letter("M")
    elif event.action == "released":
      sense.clear()
