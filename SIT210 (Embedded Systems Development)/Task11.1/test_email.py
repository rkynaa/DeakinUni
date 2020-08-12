import smtplib

server = smtplib.SMTP('smtp.gmail.com', 587)
server.starttls()
server.login("rasp.pi.adhikara@gmail.com", "Admin0109")
msg = "This is a simple email test!"
server.sendmail("rasp.pi.adhikara@gmail.com", "requiemknight99@gmail.com", msg)
server.quit()
