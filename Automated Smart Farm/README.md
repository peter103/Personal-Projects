# Automated Smart Farm
This project is aimed to reduce water consumption and maintain plant's health status during drought conditions by utilizing electronic sensors and computer hardware and software to mitigate this issue. 

## Conceptual Idea
The circuit will consist of the main microcontroller of Arduino UNO to perform computational tasks. The microcontroller will accept digital signals coming from the humidity and temperature sensor. And the soil sensor will transmit analogue signal to the 555 timer and utilize the integrated circuit to convert from analogue signal to digital signal and feed it to the arduino GPIO terminals. This will allow a consistent and reliable signal from the soil sensor. Then the microcontroller will determine based on the ambient temperature and humidity over time to trigger a ready to water status. Then the soil sensor will send data to determine soil status and two conditions must be met in order to trigger final signal from GPIO and going to one way diode into NPN222 transistor to allow the relay switch to be powered and switch on when it receives signal. Then the current will run from power supply to the water hose solenoid and within the watering time, it will determine soil status and humidity to trigger a stop on the solenoid. This will water the plants more efficiently to conserve water. 


### Required Electronic Components
- 9V Power Supply or Battery
- 12V Power Supply or Battery
- Arduino UNO or ATMEGA328P
- Diode 1N4001
- 12V water hose solenoid. 
- Arduino Soil Analogue Sensor. 
- DHT11 Humidity and Temperature Sensor
- NPN 2N2222 Transistor
- NE555 or 555 Timer
- Relay Switch 
- 16x2 LCD Display



