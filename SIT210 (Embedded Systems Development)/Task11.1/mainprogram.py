import RPi.GPIO as GPIO
import time
import signal
import sys
# Libaries for email: 
import smtplib
from email.mime.multipart import MIMEMultipart
from email.mime.text import MIMEText
from email.mime.base import MIMEBase
from email import encoders
# libaraies for the cmaera
from picamera import PiCamera
from time import sleep
# library to get current date, time
from datetime import datetime, date
import pytz

# Email addresses
fromaddr = "rasp.pi.adhikara@gmail.com"
toaddr = "requiemknight99@gmail.com"

# set all SMTP-related
server = smtplib.SMTP('smtp.gmail.com', 587)
server.starttls()
server.login(fromaddr, "Admin0109")

# set the camera
camera = PiCamera()

# use Raspberry Pi board pin numbers
GPIO.setmode(GPIO.BCM)

# set GPIO Pins
pinTrigger = 18
pinEcho = 24
inpMotion = 14
greenLED = 15
redLED = 4

detected = False

GPIO.setup(greenLED, GPIO.OUT)  # green LED
GPIO.setup(redLED, GPIO.OUT)  # red LED
GPIO.setup(inpMotion, GPIO.IN)


def close(signal, frame):
    print("\nTurning off ultrasonic distance detection...\n")
    GPIO.cleanup()
    sys.exit(0)


signal.signal(signal.SIGINT, close)

# set GPIO input and output channels
GPIO.setup(pinTrigger, GPIO.OUT)
GPIO.setup(pinEcho, GPIO.IN)

while True:

    # create the message
    msg = MIMEMultipart()
    msg['From'] = fromaddr
    msg['To'] = toaddr
    msg['Subject'] = "Smart Doorbel Alert (Person Detected!)"
    tz_au = pytz.timezone('Australia/Melbourne')
    today = date.today()
    now = datetime.now(tz_au)
    current_time = now.strftime("%H:%M:%S")
    d2 = today.strftime("%B %d, %Y")
    body = "Someone is in fromt of your house! \nDate: " + d2 + "\nTime: " + current_time

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
    if (distance < 20 and GPIO.input(inpMotion) == 1):
        GPIO.output(redLED, GPIO.LOW)
        GPIO.output(greenLED, GPIO.HIGH)
        print("PERSON DETECTED! Distance: %.1f cm" % distance)
	
	# if a person detected, capmera capture the person
	camera.start_preview(alpha=192)
	sleep(1)
	camera.capture("/home/pi/219548135/Task11.1/main_program/pic.jpg")
	camera.stop_preview()
	
	# and email the picture
	#  - get the picture
	filename = "pic.jpg"
	attachment = open("/home/pi/219548135/Task11.1/main_program/pic.jpg", "rb")
	#  - Attach the picture	
	part = MIMEBase('application', 'octet-stream')
	part.set_payload((attachment).read())
	encoders.encode_base64(part)
	part.add_header('Content-Disposition', "attachment; filename= {}".format(filename))
	msg.attach(part)
	msg.attach(MIMEText(body, 'plain'))
	#  - send the email
	text = msg.as_string()
	server.sendmail(fromaddr, toaddr, text)

    else:
        GPIO.output(greenLED, GPIO.LOW)
        GPIO.output(redLED, GPIO.HIGH)
        print("PERSON NOT DETECTED! Distance: %.1f cm" % distance)

    time.sleep(1)

