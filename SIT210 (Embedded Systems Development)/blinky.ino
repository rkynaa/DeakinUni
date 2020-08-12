int mainLED = D7;

void setup() {
    pinMode(mainLED, OUTPUT);
}

void loop() {
    
    // MAKING PHOTON BLINKING 'RAKYAN' IN MORSE CODE
    
    // Letter R -> .-.
    digitalWrite(mainLED, HIGH);
    delay(250);
    digitalWrite(mainLED, LOW);
    delay(500);
    digitalWrite(mainLED, HIGH);
    delay(1000);
    digitalWrite(mainLED, LOW);
    delay(500);
    digitalWrite(mainLED, HIGH);
    delay(250);
    digitalWrite(mainLED, LOW);
    delay(500);
    
    delay(500);
    
    // Letter A -> .-
    digitalWrite(mainLED, HIGH);
    delay(250);
    digitalWrite(mainLED, LOW);
    delay(500);
    digitalWrite(mainLED, HIGH);
    delay(1000);
    digitalWrite(mainLED, LOW);
    delay(500);
    
    delay(500);
    
    // Letter K -> -.-
    digitalWrite(mainLED, HIGH);
    delay(1000);
    digitalWrite(mainLED, LOW);
    delay(500);
    digitalWrite(mainLED, HIGH);
    delay(250);
    digitalWrite(mainLED, LOW);
    delay(500);
    digitalWrite(mainLED, HIGH);
    delay(1000);
    digitalWrite(mainLED, LOW);
    delay(500);
    
    delay(500);
    
    // Letter Y -> -.--
    digitalWrite(mainLED, HIGH);
    delay(1000);
    digitalWrite(mainLED, LOW);
    delay(500);
    digitalWrite(mainLED, HIGH);
    delay(250);
    digitalWrite(mainLED, LOW);
    delay(500);
    digitalWrite(mainLED, HIGH);
    delay(1000);
    digitalWrite(mainLED, LOW);
    delay(500);
    digitalWrite(mainLED, HIGH);
    delay(1000);
    digitalWrite(mainLED, LOW);
    delay(500);
    
    
    delay(500);
    
    // Letter A -> .-
    digitalWrite(mainLED, HIGH);
    delay(250);
    digitalWrite(mainLED, LOW);
    delay(500);
    digitalWrite(mainLED, HIGH);
    delay(1000);
    digitalWrite(mainLED, LOW);
    delay(500);
    
    delay(500);
    
    // Letter N -> -.
    digitalWrite(mainLED, HIGH);
    delay(1000);
    digitalWrite(mainLED, LOW);
    delay(500);
    digitalWrite(mainLED, HIGH);
    delay(250);
    digitalWrite(mainLED, LOW);
    delay(500);
    
    
    delay(1000);
}