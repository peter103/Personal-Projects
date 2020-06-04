#include <LiquidCrystal_I2C.h>
#include <LCD.h>
#include <dht.h>

LiquidCrystal_I2C lcd(0x3F, 2, 1, 0, 4, 5, 6, 7, 3, POSITIVE);


dht DHT;

#define DHT11_PIN 7
#define BUZZER_PIN 8

void setup()
{
  lcd.begin(16, 2);
  pinMode(BUZZER_PIN, OUTPUT);
}

void loop()
{

  int chk = DHT.read11(DHT11_PIN);
  lcd.setCursor(0,0); 
  lcd.print("Temp: ");
  lcd.print((DHT.temperature*(1.8) + 32)); // DHT.temperature will only display celcius
  lcd.print((char)223);
  lcd.print("F");
  lcd.setCursor(0,1);
  lcd.print("Humidity: ");
  lcd.print(DHT.humidity);
  lcd.print("%");
  delay(1100);
  //buzz(BUZZER_PIN,false);

}

void buzz(int pin, bool x)
{
    if(x)
    {
      digitalWrite(pin, HIGH);
    }
    else if(!x)
    {
      digitalWrite(pin, LOW);
    }
}
