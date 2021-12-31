from sense_hat import SenseHat
from time import sleep

sense = SenseHat()
sense.clear()

while True:
  pressure = sense.get_pressure()
  print(pressure)
  sleep(1)
