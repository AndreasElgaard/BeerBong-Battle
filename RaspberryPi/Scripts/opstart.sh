#!/bin/bash

#Bluetooth del
bluetoothctl agent off
bluetoothctl power on
bluetoothctl discoverable on
bluetoothctl pairable on
bluetoothctl agent NoInputNoOutput
#bluetoothctl deafult-agent

echo "Bluetooth booted"

sdptool add sp

while true
do
sudo rfcomm listen hci0
done
