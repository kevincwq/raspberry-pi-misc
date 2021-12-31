from sense_hat import SenseHat
sense = SenseHat()

black = (0, 0, 0)
yellow = (255, 255, 0)

try:
  while True:
    sense.show_message("Astro Pi is awesome!", text_colour=yellow, back_colour=black, scroll_speed=0.2)
except KeyboardInterrupt:
  sense.clear()
  pass
