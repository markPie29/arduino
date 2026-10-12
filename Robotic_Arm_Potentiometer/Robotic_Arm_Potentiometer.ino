#include <Servo.h>

// ============================================================================
// 3-DOF ROBOTIC ARM - DIRECT POTENTIOMETER CONTROLLER
// Hardware configuration:
//   - 3 Servos: Base (D3), Shoulder (D6), Gripper (D9)
//   - 3 Potentiometers: Base (A0), Shoulder (A1), Gripper (A2)
//   - Anti-jitter deadband filtering & smooth motion damping
// ============================================================================

// ----------------------------------------------------------------------------
// PIN ASSIGNMENTS
// ----------------------------------------------------------------------------
// Servos (PWM Digital Pins)
const int PIN_SERVO_BASE     = 3; // Base Rotation (X-Axis)
const int PIN_SERVO_SHOULDER = 6; // Shoulder Elevation (Arm)
const int PIN_SERVO_GRIP     = 9; // Gripper / End-Effector Claw

// Potentiometers (Analog Pins)
const int PIN_POT_BASE     = A0; // Controls Base
const int PIN_POT_SHOULDER = A1; // Controls Shoulder
const int PIN_POT_GRIP     = A2; // Controls Gripper

// ----------------------------------------------------------------------------
// SERVO OBJECTS
// ----------------------------------------------------------------------------
Servo servoBase;
Servo servoShoulder;
Servo servoGrip;

// ----------------------------------------------------------------------------
// CALIBRATION & ANGLE LIMITS (Degrees: 0 to 180)
// Adjust these if your arm has physical mechanical boundaries
// ----------------------------------------------------------------------------
const int BASE_MIN_ANGLE     = 0;
const int BASE_MAX_ANGLE     = 180;

const int SHOULDER_MIN_ANGLE = 0;
const int SHOULDER_MAX_ANGLE = 180;

// Gripper range (e.g., 90° = fully open claw, 180° = tight closed claw)
// Adjust to match your claw's physical gear travel to avoid motor stall
const int GRIP_MIN_ANGLE     = 90;  // Open limit
const int GRIP_MAX_ANGLE     = 180; // Closed limit

// ----------------------------------------------------------------------------
// DIRECTION INVERSION FLAGS
// Set to 'true' if turning a potentiometer clockwise moves the joint backwards
// ----------------------------------------------------------------------------
const bool INVERT_BASE     = false;
const bool INVERT_SHOULDER = false;
const bool INVERT_GRIP     = false;

// ----------------------------------------------------------------------------
// ANTI-JITTER & MOTION TUNING
// ----------------------------------------------------------------------------
// Minimum angle change required to command the servo (prevents jitter/buzzing)
const int DEADBAND_DEG = 1;

// Smoothing factor for Exponential Moving Average (0.05 = heavy smooth, 0.4 = fast)
const float EMA_ALPHA = 0.25;

// Motion stepping delay (milliseconds). Lower = faster, higher = gentler
const int LOOP_DELAY_MS = 15;

// Telemetry print rate (milliseconds)
const unsigned long TELEMETRY_INTERVAL_MS = 250;
unsigned long lastTelemetryTime = 0;

// Filtered potentiometer readings
float filteredPotBase     = 512.0;
float filteredPotShoulder = 512.0;
float filteredPotGrip     = 512.0;

// Current & Target Angles
int targetBase     = 90;
int targetShoulder = 90;
int targetGrip     = 90;

int currentBase     = 90;
int currentShoulder = 90;
int currentGrip     = 90;

// Helper: Read and update EMA filter for an analog channel
float updateEMA(int pin, float currentFiltered) {
  int raw = analogRead(pin);
  return (EMA_ALPHA * raw) + ((1.0 - EMA_ALPHA) * currentFiltered);
}

void setup() {
  Serial.begin(115200);
  Serial.println(F("=================================================="));
  Serial.println(F(" 3-DOF Robotic Arm - Potentiometer Controller"));
  Serial.println(F(" Servos: Base D3 | Shoulder D6 | Gripper D9"));
  Serial.println(F(" Pots:   Base A0 | Shoulder A1 | Gripper A2"));
  Serial.println(F("=================================================="));

  // Initialize filtered values from current physical knob positions
  filteredPotBase     = analogRead(PIN_POT_BASE);
  filteredPotShoulder = analogRead(PIN_POT_SHOULDER);
  filteredPotGrip     = analogRead(PIN_POT_GRIP);

  // Pre-calculate initial target angles
  targetBase     = mapPotToAngle(filteredPotBase, BASE_MIN_ANGLE, BASE_MAX_ANGLE, INVERT_BASE);
  targetShoulder = mapPotToAngle(filteredPotShoulder, SHOULDER_MIN_ANGLE, SHOULDER_MAX_ANGLE, INVERT_SHOULDER);
  targetGrip     = mapPotToAngle(filteredPotGrip, GRIP_MIN_ANGLE, GRIP_MAX_ANGLE, INVERT_GRIP);

  currentBase     = targetBase;
  currentShoulder = targetShoulder;
  currentGrip     = targetGrip;

  // Attach servos and drive to initial potentiometer angles
  servoBase.attach(PIN_SERVO_BASE);
  servoShoulder.attach(PIN_SERVO_SHOULDER);
  servoGrip.attach(PIN_SERVO_GRIP);

  servoBase.write(currentBase);
  servoShoulder.write(currentShoulder);
  servoGrip.write(currentGrip);

  delay(500); // Allow servos time to reach initial positions
  Serial.println(F("READY: Servos synchronized with potentiometers."));
}

void loop() {
  // 1. Read & filter all 3 potentiometers
  filteredPotBase     = updateEMA(PIN_POT_BASE, filteredPotBase);
  filteredPotShoulder = updateEMA(PIN_POT_SHOULDER, filteredPotShoulder);
  filteredPotGrip     = updateEMA(PIN_POT_GRIP, filteredPotGrip);

  // 2. Map potentiometer readings to angle limits
  int newTargetBase     = mapPotToAngle(filteredPotBase, BASE_MIN_ANGLE, BASE_MAX_ANGLE, INVERT_BASE);
  int newTargetShoulder = mapPotToAngle(filteredPotShoulder, SHOULDER_MIN_ANGLE, SHOULDER_MAX_ANGLE, INVERT_SHOULDER);
  int newTargetGrip     = mapPotToAngle(filteredPotGrip, GRIP_MIN_ANGLE, GRIP_MAX_ANGLE, INVERT_GRIP);

  // 3. Apply Deadband: Only change target if movement exceeds threshold
  if (abs(newTargetBase - targetBase) >= DEADBAND_DEG) {
    targetBase = newTargetBase;
  }
  if (abs(newTargetShoulder - targetShoulder) >= DEADBAND_DEG) {
    targetShoulder = newTargetShoulder;
  }
  if (abs(newTargetGrip - targetGrip) >= DEADBAND_DEG) {
    targetGrip = newTargetGrip;
  }

  // 4. Smooth stepping towards target (prevents jerking / high peak current)
  if (currentBase < targetBase) currentBase++;
  else if (currentBase > targetBase) currentBase--;

  if (currentShoulder < targetShoulder) currentShoulder++;
  else if (currentShoulder > targetShoulder) currentShoulder--;

  if (currentGrip < targetGrip) currentGrip++;
  else if (currentGrip > targetGrip) currentGrip--;

  // 5. Update servo positions
  servoBase.write(currentBase);
  servoShoulder.write(currentShoulder);
  servoGrip.write(currentGrip);

  // 6. Serial Debug Telemetry (viewable in Arduino Serial Monitor at 115200 baud)
  unsigned long now = millis();
  if (now - lastTelemetryTime >= TELEMETRY_INTERVAL_MS) {
    lastTelemetryTime = now;
    printTelemetry();
  }

  delay(LOOP_DELAY_MS);
}

// Map 0-1023 analog value to degrees, respecting inversion and boundaries
int mapPotToAngle(float potVal, int minAngle, int maxAngle, bool invert) {
  int angle;
  if (invert) {
    angle = map((int)potVal, 0, 1023, maxAngle, minAngle);
  } else {
    angle = map((int)potVal, 0, 1023, minAngle, maxAngle);
  }
  return constrain(angle, minAngle, maxAngle);
}

// Print formatted telemetry for monitoring
void printTelemetry() {
  Serial.print(F("BASE [A0->D3]: "));
  Serial.print(currentBase);
  Serial.print(F("° | SHOULDER [A1->D6]: "));
  Serial.print(currentShoulder);
  Serial.print(F("° | GRIP [A2->D9]: "));
  Serial.print(currentGrip);
  Serial.println(F("°"));
}
