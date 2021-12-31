from sense_hat import SenseHat
from time import sleep

sense = SenseHat()
sense.clear()

while True:
  # a short version: get_temerature()
  temp1 = sense.get_temperature_from_humidity()
  temp2 = sense.get_temperature_from_pressure()
  print("t_humidity: "+ str(temp1) + ", t_pressure: "+ str(temp2))
  sleep(1)

