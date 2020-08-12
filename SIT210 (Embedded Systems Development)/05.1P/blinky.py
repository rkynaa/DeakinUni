import RPi.GPIO as GPIO
import time

# declaring pin number standard
GPIO.setmode(GPIO.BOARD)

# set the pin that connect to the LED
GPIO.setup(3, GPIO.OUT) # Yellow LED
GPIO.setup(5, GPIO.OUT) # Red LED
GPIO.setup(10, GPIO.OUT) # Blue LED

# turn on the LED
# GPIO.output(10, GPIO.HIGH)

# set delay
# time.sleep(1)

try:
    while 1:
        GPIO.output(10, GPIO.HIGH)
	time.sleep(0.25)
	GPIO.output(10, GPIO.LOW)
	time.sleep(0.25)
        GPIO.output(3, GPIO.HIGH)
	time.sleep(0.25)
	GPIO.output(3, GPIO.LOW)
	time.sleep(0.25)
        GPIO.output(5, GPIO.HIGH)
	time.sleep(0.25)
	GPIO.output(5, GPIO.LOW)
	time.sleep(0.25)
except KeyboardInterrupt:
	GPIO.cleanup()


