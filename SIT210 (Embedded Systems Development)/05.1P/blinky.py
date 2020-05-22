import RPi.GPIO as GPIO
import time

# declaring pin number standard
GPIO.setmode(GPIO.BOARD)

# set the pin that connect to the LED
GPIO.setup(10, GPIO.OUT)

# turn on the LED
# GPIO.output(10, GPIO.HIGH)

# set delay
# time.sleep(1)

# turn off the LED
# GPIO.output(10, GPIO.LOW)

try:
    while 1:
        GPIO.output(10, GPIO.HIGH)
	time.sleep(1)
except KeyboardInterrupt:
	GPIO.output(10, GPIO.LOW)
