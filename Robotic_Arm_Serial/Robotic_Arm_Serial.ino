#include <Servo.h>

// ==========================================
// SERVO OBJECT DECLARATIONS
// ==========================================
Servo Servo_X;     // Base / Horizontal Axis (Pin 3)
Servo Servo_Y;     // Arm / Vertical Axis (Pin 5)
Servo Servo_Grip;  // End-Effector / Gripper (Pin 6)

// ==========================================
// PIN DEFINITIONS
// ==========================================
#define SERVO_X_PIN 3
#define SERVO_Y_PIN 5
#define SERVO_GRIP_PIN 6

// ==========================================
// SPEED REGULATOR (TURTLE PACE)
// Higher delay = Slower, gentler motion
// ==========================================
const int STEP_DELAY_MS = 15; // 15ms per degree = smooth and responsive

// Current positions
int posX = 90;
int posY = 90;
int posGrip = 90;

// Target positions received from VB.NET App
int targetX = 90;
int targetY = 90;
int targetGrip = 90;

// Serial reception buffer
String inputString = "";
boolean stringComplete = false;

void setup()
{
  Serial.begin(115200);
  inputString.reserve(64);

  Servo_X.attach(SERVO_X_PIN);
  Servo_Y.attach(SERVO_Y_PIN);
  Servo_Grip.attach(SERVO_GRIP_PIN);

  // Set default initial positions
  Servo_X.write(posX);
  Servo_Y.write(posY);
  Servo_Grip.write(posGrip);

  Serial.println("READY:Robotic Arm Serial Controller Initialized");
}

void loop()
{
  // 1. Process incoming serial commands
  if (stringComplete) {
    processCommand(inputString);
    inputString = "";
    stringComplete = false;
  }

  // 2. Smoothly step Servo X toward target
  if (posX < targetX) {
    posX++;
    Servo_X.write(posX);
  } else if (posX > targetX) {
    posX--;
    Servo_X.write(posX);
  }

  // 3. Smoothly step Servo Y toward target
  if (posY < targetY) {
    posY++;
    Servo_Y.write(posY);
  } else if (posY > targetY) {
    posY--;
    Servo_Y.write(posY);
  }

  // 4. Smoothly step Gripper toward target
  if (posGrip < targetGrip) {
    posGrip++;
    Servo_Grip.write(posGrip);
  } else if (posGrip > targetGrip) {
    posGrip--;
    Servo_Grip.write(posGrip);
  }

  delay(STEP_DELAY_MS);
}

// Read serial data character by character
void serialEvent()
{
  while (Serial.available()) {
    char inChar = (char)Serial.read();
    if (inChar == '\n' || inChar == '\r') {
      if (inputString.length() > 0) {
        stringComplete = true;
      }
    } else {
      inputString += inChar;
    }
  }
}

// Parse commands like "X:120", "Y:45", "G:150", or "HOME"
void processCommand(String cmd)
{
  cmd.trim();
  if (cmd.length() == 0) return;

  if (cmd.equalsIgnoreCase("HOME")) {
    targetX = 90;
    targetY = 90;
    targetGrip = 90;
    Serial.println("ACK:HOME");
    return;
  }

  int colonIndex = cmd.indexOf(':');
  if (colonIndex > 0) {
    char axis = toupper(cmd.charAt(0));
    int angle = cmd.substring(colonIndex + 1).toInt();
    angle = constrain(angle, 0, 180);

    switch (axis) {
      case 'X':
        targetX = angle;
        Serial.print("ACK:X=");
        Serial.println(targetX);
        break;
      case 'Y':
        targetY = angle;
        Serial.print("ACK:Y=");
        Serial.println(targetY);
        break;
      case 'G':
        targetGrip = angle;
        Serial.print("ACK:G=");
        Serial.println(targetGrip);
        break;
      default:
        Serial.println("ERR:Unknown Axis");
        break;
    }
  }
}
