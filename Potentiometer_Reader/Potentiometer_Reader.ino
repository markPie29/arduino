void setup() {
  // Initialize serial communication at 9600 bits per second:
  Serial.begin(9600);
}

void loop() {
  // Read the input on analog pin 0 (A0):
  int sensorValue = analogRead(A0);
  
  // Print out the value you read:
  Serial.println(sensorValue);
  
  // Delay a little bit to improve stability and avoid flooding the serial port:
  delay(100);
}
