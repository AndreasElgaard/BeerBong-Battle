#!/bin/bash

#Bluetooth del
bluetoothctl agent off
bluetoothctl power on
bluetoothctl discoverable on
bluetoothctl pairable on
bluetoothctl agent NoInputNoOutput
#bluetoothctl deafult-agent

echo "Bluetooth booted"

sudo killall pulseaudio
sleep 1
pulseaudio --start


sdptool add sp

while true
do
sudo rfcomm listen hci0
done
