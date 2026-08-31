// Arduino Bluetooth Controlled Car (L298N Driver)
// Compatible with Andi.Co Bluetooth RC Car App

// --- Pin Definitions for L298N ---
const int IN1 = 10;  // Left motors forward
const int IN2 = 11;  // Left motors backward
const int IN3 = 12;  // Right motors forward
const int IN4 = 13;  // Right motors backward

char command;

void setup() {
  Serial.begin(9600); // Bluetooth baud rate

  // Set motor pins as outputs
  pinMode(IN1, OUTPUT);
  pinMode(IN2, OUTPUT);
  pinMode(IN3, OUTPUT);
  pinMode(IN4, OUTPUT);

  Stop(); // Ensure car is stopped on startup
}

void loop() {
  if (Serial.available() > 0) {
    command = Serial.read();

    switch (command) {
      case 'F': // Forward
        forward();
        break;

      case 'B': // Backward
        back();
        break;

      case 'L': // Spin Left
        left();
        break;

      case 'R': // Spin Right
        right();
        break;

      case 'G': // Forward Left
        forwardLeft();
        break;

      case 'I': // Forward Right
        forwardRight();
        break;

      case 'H': // Back Left
        backLeft();
        break;

      case 'J': // Back Right
        backRight();
        break;

      case 'S': // Stop
      case 'D': // Stop all
        Stop();
        break;
    }
  }
}

void forward() {
  digitalWrite(IN1, HIGH);
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, HIGH);
  digitalWrite(IN4, LOW);
}

void back() {
  digitalWrite(IN1, LOW);
  digitalWrite(IN2, HIGH);
  digitalWrite(IN3, LOW);
  digitalWrite(IN4, HIGH);
}

void left() {
  // Spin Left: Left side reverse, Right side forward
  digitalWrite(IN1, LOW);
  digitalWrite(IN2, HIGH);
  digitalWrite(IN3, HIGH);
  digitalWrite(IN4, LOW);
}

void right() {
  // Spin Right: Left side forward, Right side reverse
  digitalWrite(IN1, HIGH);
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, LOW);
  digitalWrite(IN4, HIGH);
}

void forwardLeft() {
  // Turn Left while moving forward: Left stopped, Right forward
  digitalWrite(IN1, LOW);
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, HIGH);
  digitalWrite(IN4, LOW);
}

void forwardRight() {
  // Turn Right while moving forward: Left forward, Right stopped
  digitalWrite(IN1, HIGH);
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, LOW);
  digitalWrite(IN4, LOW);
}

void backLeft() {
  // Turn Left while reversing: Left stopped, Right backward
  digitalWrite(IN1, LOW);
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, LOW);
  digitalWrite(IN4, HIGH);
}

void backRight() {
  // Turn Right while reversing: Left backward, Right stopped
  digitalWrite(IN1, LOW);
  digitalWrite(IN2, HIGH);
  digitalWrite(IN3, LOW);
  digitalWrite(IN4, LOW);
}

void Stop() {
  digitalWrite(IN1, LOW);
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, LOW);
  digitalWrite(IN4, LOW);
}

