import RPi.GPIO as GPIO
import time
import signal
import sys

# use Raspberry Pi board pin numbers
GPIO.setmode(GPIO.BCM)

# set GPIO Pins
pinTrigger = 18
pinEcho = 24
greenLED = 3
redLED = 7

GPIO.setup(greenLED, GPIO.OUT)  # green LED
GPIO.setup(redLED, GPIO.OUT)  # red LED


def close(signal, frame):
    print("\nTurning off ultrasonic distance detection...\n")
    GPIO.cleanup()
    sys.exit(0)


signal.signal(signal.SIGINT, close)

# set GPIO input and output channels
GPIO.setup(pinTrigger, GPIO.OUT)
GPIO.setup(pinEcho, GPIO.IN)

while True:
    # set Trigger to HIGH
    GPIO.output(pinTrigger, True)
    # set Trigger after 0.01ms to LOW
    time.sleep(0.00001)
    GPIO.output(pinTrigger, False)

    startTime = time.time()
    stopTime = time.time()

    # save start time
    while 0 == GPIO.input(pinEcho):
        startTime = time.time()

    # save time of arrival
    while 1 == GPIO.input(pinEcho):
        stopTime = time.time()

    # time difference between start and arrival
    TimeElapsed = stopTime - startTime
    # multiply with the sonic speed (34300 cm/s)
    # and divide by 2, because there and back
    distance = (TimeElapsed * 34300) / 2

    if (distance < 10):
        GPIO.output(redLED, GPIO.LOW)
        GPIO.output(greenLED, GPIO.HIGH)
        print("PERSON DETECTED! Distance: %.1f cm" % distance)
    else:
        GPIO.output(greenLED, GPIO.LOW)
        GPIO.output(redLED, GPIO.HIGH)
        print("PERSON NOT DETECTED! Distance: %.1f cm" % distance)

    time.sleep(1)
