#include <Servo.h>

// ==========================================
// SERVO OBJECT DECLARATIONS (3-DOF ARM)
// ==========================================
Servo Servo_X;         // Base / Horizontal Axis (Pin D3)
Servo Servo_Shoulder;  // Shoulder Joint (Pin D6)
Servo Servo_Grip;      // Gripper / Claw (Pin D9)

// ==========================================
// PIN DEFINITIONS
// ==========================================
#define SERVO_X_PIN        3
#define SERVO_SHOULDER_PIN 6
#define SERVO_GRIP_PIN     9

// ==========================================
// SPEED REGULATOR (SMOOTH PACE)
// Higher delay = Slower, gentler motion
// ==========================================
const int STEP_DELAY_MS = 15; // 15ms per degree = smooth and responsive

// Current positions
// All 3 joints default to 90 degrees center
int posX = 90;
int posShoulder = 90;
int posGrip = 90;

// Target positions received from Serial / App
int targetX = 90;
int targetShoulder = 90;
int targetGrip = 90;

// Serial reception buffer
String inputString = "";

// Forward declarations
void processCommand(String cmd);
void checkSerial();

void setup()
{
  Serial.begin(115200);
  inputString.reserve(64);

  // Attach 3 servos
  Servo_X.attach(SERVO_X_PIN);
  Servo_Shoulder.attach(SERVO_SHOULDER_PIN);
  Servo_Grip.attach(SERVO_GRIP_PIN);

  // Set all 3 servos to 90 degrees default center
  Servo_X.write(posX);
  Servo_Shoulder.write(posShoulder);
  Servo_Grip.write(posGrip);

  Serial.println("READY:Robotic Arm Serial Controller Initialized (3 Servos: Base D3, Shoulder D6, Grip D9)");
}

void loop()
{
  // 1. Process incoming serial characters & commands immediately
  checkSerial();

  // 2. Smoothly step Servo X toward target (Base)
  if (Servo_X.attached()) {
    if (posX < targetX) {
      posX++;
      Servo_X.write(posX);
    } else if (posX > targetX) {
      posX--;
      Servo_X.write(posX);
    }
  }

  // 3. Smoothly step Servo Shoulder toward target
  if (Servo_Shoulder.attached()) {
    if (posShoulder < targetShoulder) {
      posShoulder++;
      Servo_Shoulder.write(posShoulder);
    } else if (posShoulder > targetShoulder) {
      posShoulder--;
      Servo_Shoulder.write(posShoulder);
    }
  }

  // 4. Smoothly step Gripper / Claw toward target
  if (Servo_Grip.attached()) {
    if (posGrip < targetGrip) {
      posGrip++;
      Servo_Grip.write(posGrip);
    } else if (posGrip > targetGrip) {
      posGrip--;
      Servo_Grip.write(posGrip);
    }
  }

  delay(STEP_DELAY_MS);
}

// Non-blocking serial command reader
void checkSerial()
{
  while (Serial.available() > 0) {
    char inChar = (char)Serial.read();
    if (inChar == '\n' || inChar == '\r') {
      if (inputString.length() > 0) {
        processCommand(inputString);
        inputString = "";
      }
    } else {
      if (inputString.length() < 64) {
        inputString += inChar;
      }
    }
  }
}

// SerialEvent fallback for AVR compatibility
void serialEvent()
{
  checkSerial();
}

// Parse commands like "X:120", "S:90", "G:90", "HOME", "PING", "STATUS", "RELAX"
void processCommand(String cmd)
{
  cmd.trim();
  if (cmd.length() == 0) return;

  if (cmd.equalsIgnoreCase("PING")) {
    Serial.println("ACK:PONG");
    return;
  }

  if (cmd.equalsIgnoreCase("STATUS")) {
    Serial.print("STATUS:X=");
    Serial.print(posX);
    Serial.print(",S=");
    Serial.print(posShoulder);
    Serial.print(",G=");
    Serial.println(posGrip);
    return;
  }

  // Emergency relax / detach commands (stops PWM pulses to cool servos down)
  if (cmd.equalsIgnoreCase("RELAX") || cmd.equalsIgnoreCase("DETACH")) {
    Servo_X.detach();
    Servo_Shoulder.detach();
    Servo_Grip.detach();
    Serial.println("ACK:ALL_DETACHED");
    return;
  }

  if (cmd.equalsIgnoreCase("RELAX:G") || cmd.equalsIgnoreCase("DETACH:G")) {
    Servo_Grip.detach();
    Serial.println("ACK:GRIP_DETACHED");
    return;
  }

  if (cmd.equalsIgnoreCase("ATTACH:G")) {
    if (!Servo_Grip.attached()) Servo_Grip.attach(SERVO_GRIP_PIN);
    Serial.println("ACK:GRIP_ATTACHED");
    return;
  }

  // HOME resets all 3 joints to 90 degrees center
  if (cmd.equalsIgnoreCase("HOME")) {
    if (!Servo_X.attached()) Servo_X.attach(SERVO_X_PIN);
    if (!Servo_Shoulder.attached()) Servo_Shoulder.attach(SERVO_SHOULDER_PIN);
    if (!Servo_Grip.attached()) Servo_Grip.attach(SERVO_GRIP_PIN);

    targetX = 90;
    targetShoulder = 90;
    targetGrip = 90;
    Serial.println("ACK:HOME");
    return;
  }

  int colonIndex = cmd.indexOf(':');
  if (colonIndex > 0) {
    char axis = toupper(cmd.charAt(0));
    int angle = cmd.substring(colonIndex + 1).toInt();

    switch (axis) {
      case 'X':
        if (!Servo_X.attached()) Servo_X.attach(SERVO_X_PIN);
        angle = constrain(angle, 0, 180);
        targetX = angle;
        Serial.print("ACK:X=");
        Serial.println(targetX);
        break;
      case 'Y':
        // Pin D5 unmounted - ignored in 3-DOF mode
        Serial.println("ACK:Y=IGNORED");
        break;
      case 'S':
      case 'Z': // Shoulder / Z-axis
        if (!Servo_Shoulder.attached()) Servo_Shoulder.attach(SERVO_SHOULDER_PIN);
        angle = constrain(angle, 0, 180);
        targetShoulder = angle;
        Serial.print("ACK:S=");
        Serial.println(targetShoulder);
        break;
      case 'G':
      case 'C': // Gripper / Claw
        if (!Servo_Grip.attached()) Servo_Grip.attach(SERVO_GRIP_PIN);
        angle = constrain(angle, 0, 180);
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
