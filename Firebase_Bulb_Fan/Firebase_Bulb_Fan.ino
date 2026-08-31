/*
 =====================================================================================
   PROJECT: ESP8266 IoT Smart Home Automation (Bulb & Fan Control via Firebase)
   BOARD  : NodeMCU 1.0 (ESP-12E Module) / ESP8266
 =====================================================================================

 -------------------------------------------------------------------------------------
  1. REQUIRED LIBRARIES (Install in Arduino IDE):
 -------------------------------------------------------------------------------------
  - "Firebase ESP8266 Client" by Mobizt
    * Go to: Sketch > Include Library > Manage Libraries... (or Ctrl + Shift + I)
    * Search: "Firebase ESP8266 Client"
    * Author: Mobizt
    * Click Install.
    
  - "ESP8266WiFi" (Built-in with ESP8266 Board Core)
    * Under File > Preferences > Additional Boards Manager URLs, add:
      http://arduino.esp8266.com/stable/package_esp8266com_index.json
    * Under Tools > Board > Boards Manager, install "esp8266 by ESP8266 Community".
    * Select: Tools > Board > ESP8266 Boards > NodeMCU 1.0 (ESP-12E Module)

 -------------------------------------------------------------------------------------
  2. HARDWARE WIRING GUIDE (Dual-LED Breadboard Setup):
 -------------------------------------------------------------------------------------
  [COMPONENTS]:
    - 1x ESP8266 NodeMCU Development Board
    - 1x LED 1 (e.g. Red / Yellow) -> Simulating Bulb
    - 1x LED 2 (e.g. Green / Blue) -> Simulating Fan
    - 2x 220 Ohm Resistors (Color: Red - Red - Brown)
    - Jumper Wires & Breadboard

  [CONNECTIONS]:
    * LED 1 (Bulb):
        - Long Leg (+) [Anode]   ---> 220 Ohm Resistor ---> NodeMCU Pin D2 (GPIO 4)
        - Short Leg (-) [Cathode] ---> NodeMCU Pin GND (Shared Ground)
        
    * LED 2 (Fan):
        - Long Leg (+) [Anode]   ---> 220 Ohm Resistor ---> NodeMCU Pin D1 (GPIO 5)
        - Short Leg (-) [Cathode] ---> NodeMCU Pin GND (Shared Ground)

  * NOTE: Both LEDs share the same common Ground (GND) on the breadboard rail.

 -------------------------------------------------------------------------------------
  3. FIREBASE REALTIME DATABASE CONFIGURATION:
 -------------------------------------------------------------------------------------
  - Database URL  : https://esp8266-home-automation-f7f7d-default-rtdb.asia-southeast1.firebasedatabase.app
  - Database Keys :
      "LED_STATUS" : 0 (OFF) or 1 (ON)
      "FAN_STATUS" : 0 (OFF) or 1 (ON)
 =====================================================================================
*/

#include <ESP8266WiFi.h>
#include <FirebaseESP8266.h>

// =====================================================================================
// 1. FIREBASE CREDENTIALS
// =====================================================================================
#define FIREBASE_HOST "https://esp8266-home-automation-f7f7d-default-rtdb.asia-southeast1.firebasedatabase.app"
#define FIREBASE_AUTH "jaGKPQ0qdQ2AzxLZv3zwtjbkrU7R2I2ILpw7vJb6"

// =====================================================================================
// 2. WI-FI CREDENTIALS (2.4 GHz Only - ESP8266 does not support 5GHz)
// =====================================================================================
#define WIFI_SSID "coengoffice"
#define WIFI_PASSWORD "0987654321"

// =====================================================================================
// 3. PIN DEFINITIONS
// =====================================================================================
#define BULB_PIN D2  // NodeMCU Pin D2 (GPIO 4) -> LED 1 (Bulb) via 220Ω Resistor
#define FAN_PIN  D1  // NodeMCU Pin D1 (GPIO 5) -> LED 2 (Fan)  via 220Ω Resistor

// =====================================================================================
// 4. FIREBASE DATA & CONFIG OBJECTS
// =====================================================================================
FirebaseData fbdo;
FirebaseAuth auth;
FirebaseConfig config;

// State tracking variables to avoid repetitive serial prints
int lastLed = -1;
int lastFan = -1;

void setup() {
  // Initialize Serial Monitor for debugging at 115200 baud
  Serial.begin(115200);
  delay(1000); // Allow serial port to stabilize

  Serial.println("\n\n====================================");
  Serial.println("   ESP8266 SMART HOME AUTOMATION    ");
  Serial.println("====================================");

  // Initialize GPIO pins as OUTPUT
  pinMode(BULB_PIN, OUTPUT);
  pinMode(FAN_PIN, OUTPUT);

  // --- HARDWARE SELF-TEST ON BOOT ---
  // Briefly lights up both LEDs for 1 second on power-up to confirm physical wiring
  Serial.println("Running LED Self-Test...");
  digitalWrite(BULB_PIN, HIGH);
  digitalWrite(FAN_PIN, HIGH);
  delay(1000);
  digitalWrite(BULB_PIN, LOW);
  digitalWrite(FAN_PIN, LOW);
  Serial.println("Self-test complete.");

  // --- CONNECT TO WI-FI ---
  Serial.print("Connecting to Wi-Fi [");
  Serial.print(WIFI_SSID);
  Serial.print("]");
  
  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    delay(500);
  }
  
  Serial.println("\n>>> Wi-Fi Connected Successfully! <<<");
  Serial.print("IP Address: ");
  Serial.println(WiFi.localIP());

  // --- CONFIGURE FIREBASE ---
  config.database_url = FIREBASE_HOST;
  config.signer.tokens.legacy_token = FIREBASE_AUTH;

  Firebase.begin(&config, &auth);
  Firebase.reconnectWiFi(true); // Auto-reconnect to Wi-Fi if connection drops

  Serial.println(">>> Firebase Initialized & Listening! <<<\n");
}

void loop() {
  // ===================================================================================
  // 1. CONTROL BULB (LED 1 on Pin D2)
  // ===================================================================================
  if (Firebase.getInt(fbdo, "/LED_STATUS")) {
    int ledStatus = fbdo.intData();
    if (ledStatus != lastLed) {
      lastLed = ledStatus;
      if (ledStatus == 1) {
        digitalWrite(BULB_PIN, HIGH); // Turn Bulb LED ON
        Serial.println("-> Bulb / LED: ON");
      } else {
        digitalWrite(BULB_PIN, LOW);  // Turn Bulb LED OFF
        Serial.println("-> Bulb / LED: OFF");
      }
    }
  }

  // ===================================================================================
  // 2. CONTROL FAN (LED 2 on Pin D1)
  // ===================================================================================
  if (Firebase.getInt(fbdo, "/FAN_STATUS")) {
    int fanStatus = fbdo.intData();
    if (fanStatus != lastFan) {
      lastFan = fanStatus;
      if (fanStatus == 1) {
        digitalWrite(FAN_PIN, HIGH); // Turn Fan LED ON
        Serial.println("-> Fan: ON");
      } else {
        digitalWrite(FAN_PIN, LOW);  // Turn Fan LED OFF
        Serial.println("-> Fan: OFF");
      }
    }
  }

  // Small delay to prevent network congestion and watchdog timer resets
  delay(200);
}
