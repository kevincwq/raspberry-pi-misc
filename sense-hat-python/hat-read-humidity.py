from sense_hat import SenseHat
from time import sleep

sense = SenseHat()
sense.clear()

while True:
  humidity = sense.get_humidity()
  print(humidity)
  sleep(1)
