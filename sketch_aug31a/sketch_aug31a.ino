#include <Servo.h>

// ==========================================
// SERVO OBJECT DECLARATIONS
// ==========================================
Servo Servo_X;     // Base / Horizontal Axis (Left-Right)
Servo Servo_Y;     // Arm / Vertical Axis (Up-Down)
Servo Servo_Grip;  // End-Effector / Gripper (Claw)

// ==========================================
// PIN DEFINITIONS
// ==========================================
#define JOY_X A0      // Joystick X-Axis
#define JOY_Y A1      // Joystick Y-Axis
#define POT_GRIP A2   // Potentiometer for Gripper Claw

#define SERVO_X_PIN 3
#define SERVO_Y_PIN 5
#define SERVO_GRIP_PIN 6

// ==========================================
// DIRECTION & INVERSION SETTINGS
// ==========================================
const bool INVERT_X   = true;   // true = Reverse Left/Right direction
const bool INVERT_Y   = false;  // true = Reverse Up/Down direction
const bool INVERT_POT = true;   // true = Rotate to tighten, opposite to open

// ==========================================
// JOYSTICK DEADZONE & SPEED SETTINGS
// ==========================================
const int JOY_DEADZONE_LOW  = 400; // Below this = active move in one direction
const int JOY_DEADZONE_HIGH = 600; // Above this = active move in other direction

// Movement Speed: Higher delay = slower/gentler, Lower = faster
const int STEP_DELAY_MS = 20; // 20ms = ~50 degrees per second (smooth & controllable)

// ==========================================
// CUSTOM GRIPPER RANGE
// 90° = Neutral / Widest Open limit
// 180° = Maximum Tight Closed limit
// ==========================================
const int GRIP_MIN_ANGLE = 90;   // Neutral Open (will not over-open past 90°)
const int GRIP_MAX_ANGLE = 180;  // Fully Tightened Grip

// Current positions (persistent memory)
int posX = 90;
int posY = 90;
int posGrip = GRIP_MIN_ANGLE;
int targetGrip = GRIP_MIN_ANGLE;

void setup()
{
  Servo_X.attach(SERVO_X_PIN);
  Servo_Y.attach(SERVO_Y_PIN);
  Servo_Grip.attach(SERVO_GRIP_PIN);
  
  // Set initial gripper position based on the physical potentiometer position
  int initialPot = analogRead(POT_GRIP);
  if (INVERT_POT) {
    posGrip = map(initialPot, 0, 1023, GRIP_MAX_ANGLE, GRIP_MIN_ANGLE);
  } else {
    posGrip = map(initialPot, 0, 1023, GRIP_MIN_ANGLE, GRIP_MAX_ANGLE);
  }
  targetGrip = posGrip;

  // Set initial default positions
  Servo_X.write(posX);
  Servo_Y.write(posY);
  Servo_Grip.write(posGrip);
}

void loop()
{
  // 1. Read Joystick inputs
  int rawX = analogRead(JOY_X);
  int rawY = analogRead(JOY_Y);

  // -------------------------------------------------------------
  // 2. INCREMENTAL POSITION-HOLD (Servo X - Horizontal Base)
  // -------------------------------------------------------------
  if (rawX > JOY_DEADZONE_HIGH) {
    if (INVERT_X) {
      if (posX > 0) posX--;
    } else {
      if (posX < 180) posX++;
    }
    Servo_X.write(posX);
  } else if (rawX < JOY_DEADZONE_LOW) {
    if (INVERT_X) {
      if (posX < 180) posX++;
    } else {
      if (posX > 0) posX--;
    }
    Servo_X.write(posX);
  }
  // Position freezes when stick is released to center!

  // -----------------------------------------------------------
  // 3. INCREMENTAL POSITION-HOLD (Servo Y - Vertical Arm)
  // -----------------------------------------------------------
  if (rawY > JOY_DEADZONE_HIGH) {
    if (INVERT_Y) {
      if (posY > 0) posY--;
    } else {
      if (posY < 180) posY++;
    }
    Servo_Y.write(posY);
  } else if (rawY < JOY_DEADZONE_LOW) {
    if (INVERT_Y) {
      if (posY < 180) posY++;
    } else {
      if (posY > 0) posY--;
    }
    Servo_Y.write(posY);
  }
  // Position freezes when stick is released to center!

  // -----------------------------------------------------------
  // 4. POTENTIOMETER PROPORTIONAL CONTROL (Servo Grip - Claw)
  // -----------------------------------------------------------
  int rawPot = analogRead(POT_GRIP);
  
  // Map 0-1023 analog reading strictly between 90° (Neutral Open) and 180° (Tight Closed)
  if (INVERT_POT) {
    targetGrip = map(rawPot, 0, 1023, GRIP_MAX_ANGLE, GRIP_MIN_ANGLE);
  } else {
    targetGrip = map(rawPot, 0, 1023, GRIP_MIN_ANGLE, GRIP_MAX_ANGLE);
  }

  // Smoothly step Gripper to match potentiometer knob position
  if (posGrip < targetGrip) {
    posGrip++;
    Servo_Grip.write(posGrip);
  } else if (posGrip > targetGrip) {
    posGrip--;
    Servo_Grip.write(posGrip);
  }

  // Speed regulation delay
  delay(STEP_DELAY_MS);
}
