#include <Adafruit_Fingerprint.h>


#if (defined(__AVR__) || defined(ESP8266)) && !defined(__AVR_ATmega2560__)
// For UNO and others without hardware serial, we must use software serial...
// pin #2 is IN from sensor (GREEN wire)
// pin #3 is OUT from arduino  (WHITE wire)
// Set up the serial port to use softwareserial..
SoftwareSerial mySerial(2, 3);

#else
// On Leonardo/M0/etc, others with hardware serial, use hardware serial!
// #0 is green wire, #1 is white
#define mySerial Serial1

#endif


Adafruit_Fingerprint finger = Adafruit_Fingerprint(&mySerial);

uint8_t id;
int action;

void setup()
{
  Serial.begin(9600);
  while (!Serial);  // For Yun/Leo/Micro/Zero/...
  delay(100);
  

  // set the data rate for the sensor serial port
  finger.begin(57600);

  if (finger.verifyPassword()) {
    Serial.println("Found fingerprint sensor!");
  } else {
    Serial.println("Did not find fingerprint sensor :(");
    while (1) { delay(1); }
  }

 // Serial.println(F("Reading sensor parameters"));
  finger.getParameters();
  //Serial.print(F("Status: 0x")); Serial.println(finger.status_reg, HEX);
  //Serial.print(F("Sys ID: 0x")); Serial.println(finger.system_id, HEX);
  //Serial.print(F("Capacity: ")); Serial.println(finger.capacity);
 // Serial.print(F("Security level: ")); Serial.println(finger.security_level);
  //Serial.print(F("Device address: ")); Serial.println(finger.device_addr, HEX);
  //Serial.print(F("Packet len: ")); Serial.println(finger.packet_len);
 // Serial.print(F("Baud rate: ")); Serial.println(finger.baud_rate);
}

uint8_t readnumber(void) {
  uint8_t num = 0;

  while (num == 0) {
    while (! Serial.available());
    num = Serial.parseInt();
  }
  return num;
}

 void loop_enroll(){                    // run over and over again{
 
  id = readnumber();
  if (id == 0) {// ID #0 not allowed, try again!
      Serial.println("zero th id doesn't exist");
      Serial.println("false");  }
  Serial.print("Enrolling ID #");
  Serial.println(id);

  while (!  getFingerprintEnroll() );
}

uint8_t getFingerprintEnroll() {

  int p = -1;
  Serial.print("Waiting for valid finger to enroll as #"); Serial.println(id);
  while (p != FINGERPRINT_OK) {
    p = finger.getImage();
    switch (p) {
    case FINGERPRINT_OK:
      Serial.println("Image taken");
      break;
    case FINGERPRINT_NOFINGER:
      Serial.println(".");
      break;
    case FINGERPRINT_PACKETRECIEVEERR:
      Serial.println("Communication error");
      Serial.println("false");       
      break;
    case FINGERPRINT_IMAGEFAIL:
      Serial.println("Imaging error");
      Serial.println("false"); 
      break;
    default:
      Serial.println("Unknown error");
      Serial.println("false"); 
      break;
    }
  }

  // OK success!

  p = finger.image2Tz(1);
  switch (p) {
    case FINGERPRINT_OK:
      Serial.println("Image converted");
      break;
    case FINGERPRINT_IMAGEMESS:
      Serial.println("Image too messy");
      Serial.println("false"); 
      return p;
    case FINGERPRINT_PACKETRECIEVEERR:
      Serial.println("Communication error");
      Serial.println("false"); 
      return p;
    case FINGERPRINT_FEATUREFAIL:
      Serial.println("Could not find fingerprint features");
      Serial.println("false"); 
      return p;
    case FINGERPRINT_INVALIDIMAGE:
      Serial.println("Could not find fingerprint features");
      Serial.println("false");       
      return p;
    default:
      Serial.println("Unknown error");
      Serial.println("false");       
      return p;
  }

  Serial.println("Remove finger");
  delay(2000);
  p = 0;
  while (p != FINGERPRINT_NOFINGER) {
    p = finger.getImage();
  }
  Serial.print("ID "); Serial.println(id);
  p = -1;
  Serial.println("Place same finger again");
  while (p != FINGERPRINT_OK) {
    p = finger.getImage();
    switch (p) {
    case FINGERPRINT_OK:
      Serial.println("Image taken");
      break;
    case FINGERPRINT_NOFINGER:
      Serial.print(".");
      break;
    case FINGERPRINT_PACKETRECIEVEERR:
      Serial.println("Communication error");
      Serial.println("false");       
      break;
    case FINGERPRINT_IMAGEFAIL:
      Serial.println("Imaging error");
      Serial.println("false"); 
      break;
    default:
      Serial.println("Unknown error");
      Serial.println("false"); 
      break;
    }
  }

  // OK success!

  p = finger.image2Tz(2);
  switch (p) {
    case FINGERPRINT_OK:
      Serial.println("Image converted");
      break;
    case FINGERPRINT_IMAGEMESS:
      Serial.println("Image too messy");
      Serial.println("false"); 
      return p;
    case FINGERPRINT_PACKETRECIEVEERR:
      Serial.println("Communication error");
      Serial.println("false"); 
      return p;
    case FINGERPRINT_FEATUREFAIL:
      Serial.println("Could not find fingerprint features");
      Serial.println("false"); 
      return p;
    case FINGERPRINT_INVALIDIMAGE:
      Serial.println("Could not find fingerprint features");
      Serial.println("false"); 
      return p;
    default:
      Serial.println("Unknown error");
      Serial.println("false"); 
      return p;
  }

  // OK converted!
  Serial.print("Creating model for #");  Serial.println(id);

  p = finger.createModel();
  if (p == FINGERPRINT_OK) {
    Serial.println("Prints matched!");
  } else if (p == FINGERPRINT_PACKETRECIEVEERR) {
    Serial.println("Communication error");
    Serial.println("false"); 
    return p;
  } else if (p == FINGERPRINT_ENROLLMISMATCH) {
    Serial.println("Fingerprints did not match");
    Serial.println("false");     
    return p;
  } else {
    Serial.println("Unknown error");
    Serial.println("false"); 
    return p;
  }

  Serial.print("ID "); Serial.println(id);
  p = finger.storeModel(id);
  if (p == FINGERPRINT_OK) {
    Serial.println("Stored!");
    Serial.println("true"); 
  } else if (p == FINGERPRINT_PACKETRECIEVEERR) {
    Serial.println("Communication error");
    Serial.println("false"); 
    return p;
  } else if (p == FINGERPRINT_BADLOCATION) {
    Serial.println("Could not store in that location");
    Serial.println("false"); 
    return p;
  } else if (p == FINGERPRINT_FLASHERR) {
    Serial.println("Error writing to flash");
    Serial.println("false"); 
    return p;
  } else {
    Serial.println("Unknown error");
    Serial.println("false"); 
    return p;
  }

  return true;
} 
void loop_delete()                     // run over and over again
{
  
  uint8_t id = readnumber();
  if (id == 0) {// ID #0 not allowed, try again!
     Serial.println("zero th id doesn't exist");
     Serial.println("false"); 
  }

  Serial.print("Deleting ID #");
  Serial.println(id);

  deleteFingerprint(id);
}

uint8_t deleteFingerprint(uint8_t id) {
  uint8_t p = -1;

  p = finger.deleteModel(id);

  if (p == FINGERPRINT_OK) {
    Serial.println("Deleted!");
    Serial.println("true"); 
  } else if (p == FINGERPRINT_PACKETRECIEVEERR) {
    Serial.println("Communication error");
    Serial.println("false"); 
  } else if (p == FINGERPRINT_BADLOCATION) {
    Serial.println("Could not delete in that location");
    Serial.println("false"); 
  } else if (p == FINGERPRINT_FLASHERR) {
    Serial.println("Error writing to flash");
    Serial.println("false"); 
  } else {
    Serial.print("Unknown error: 0x"); Serial.println(p, HEX);
    Serial.println("false"); 
  }

  return p;
}

uint8_t getFingerprintID() {
  id = readnumber();
  if (id == 0) {// ID #0 not allowed, try again!
      Serial.println("zero th id doesn't exist");
      Serial.println("false");  }

 
  int p = -1;

  while (p != FINGERPRINT_OK) {
    p = finger.getImage();
    switch (p) {
    case FINGERPRINT_OK:
      Serial.println("Image taken");
      break;
    case FINGERPRINT_NOFINGER:
      Serial.println(".");
      break;
    case FINGERPRINT_PACKETRECIEVEERR:
      Serial.println("Communication error");
      Serial.println("false");       
      break;
    case FINGERPRINT_IMAGEFAIL:
      Serial.println("Imaging error");
      Serial.println("false"); 
      break;
    default:
      Serial.println("Unknown error");
      Serial.println("false"); 
      break;
    }
  }

  // OK success!

  p = finger.image2Tz();
  switch (p) {
    case FINGERPRINT_OK:
      Serial.println("Image converted");
      break;
    case FINGERPRINT_IMAGEMESS:
      Serial.println("Image too messy");
      Serial.println("false");
      return p;
    case FINGERPRINT_PACKETRECIEVEERR:
      Serial.println("Communication error");
      Serial.println("false");
      return p;
    case FINGERPRINT_FEATUREFAIL:
      Serial.println("Could not find fingerprint features");
      Serial.println("false");
      return p;
    case FINGERPRINT_INVALIDIMAGE:
      Serial.println("Could not find fingerprint features");
      Serial.println("false");
      return p;
    default:
      Serial.println("Unknown error");
      Serial.println("false");
      return p;
  }

  // OK converted!
  p = finger.fingerSearch();
  if (p == FINGERPRINT_OK) {
    Serial.println("Found a print match!");
    Serial.println("true");
   
  } else if (p == FINGERPRINT_PACKETRECIEVEERR) {
    Serial.println("Communication error");
    Serial.println("false");
    return p;
  } else if (p == FINGERPRINT_NOTFOUND) {
    Serial.println("Did not find a match");
    Serial.println("false");
    return p;
  } else {
    Serial.println("Unknown error");
    Serial.println("false");
    return p;
  }
  Serial.print("Found ID #"); Serial.print(finger.fingerID);
  /*if(finger.fingerID==id){

    Serial.println("\n");
    Serial.println("true");
  }*/
  Serial.print(" with confidence of "); Serial.println(finger.confidence);

  return true;
}

 void loop_finger()                     // run over and over again
{
  while(! getFingerprintID());
  delay(50);            //don't ned to run this at full speed.
}
void loop() {
  // put your main code here, to run repeatedly:
while(Serial.available()==0){}
action=Serial.parseInt();
switch(action){
  case 1:
        loop_enroll();
        break;
  case 2:
        loop_finger();
        break;
  case 3:
        loop_delete();
        break;
 
}}





