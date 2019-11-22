using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Xamarin.Forms;


namespace TodoREST.Data
{
     
    
    class BlueToothService
    {
        private IAdapter adapter;
        private IBluetoothLE ble;
        ObservableCollection<IDevice> deviceList;

        public async Task BlueToothHandler()
        {
             ble = CrossBluetoothLE.Current;
             adapter = CrossBluetoothLE.Current.Adapter;

            
            deviceList = new ObservableCollection<IDevice>();

            
        }

        private async void btnclick(object sender, EventArgs e)
        {
            adapter.DeviceDiscovered += (s, a) => { deviceList.Add(a.Device); };

            await adapter.StartScanningForDevicesAsync();
        }

    }
}
