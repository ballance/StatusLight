using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Blynclight;

namespace StatusLight
{
    class Program
    {
        public static BlynclightController lightController = new BlynclightController();


        static void Main(string[] args)
        {
            lightController.InitBlyncDevices();

            var lightIndex = 0;
            Byte bySelectedFlashSpeed = 0x0f;
            Byte byLightControl = 0x00;

            do
            {
                while (!Console.KeyAvailable)
                {

                    for (int i = 0; i < 255; i++)
                    {
                        var lightByte = Convert.ToByte(i);
                        var fullByte = Convert.ToByte(255 - i);
                        lightController.TurnOnRGBLights(lightIndex, lightByte, fullByte, 0);
                        Thread.Sleep(10);
                    }
                    for (int i = 255; i >= 0; i--)
                    {
                        var lightByte = Convert.ToByte(i);
                        var fullByte = Convert.ToByte(255 - i);
                        lightController.TurnOnRGBLights(lightIndex, lightByte, fullByte, 0);
                        Thread.Sleep(10);
                    }    // Do something
                }
                Thread.Sleep(10);

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            lightController.TurnOnWhiteLight(lightIndex);
            Console.ReadKey();

        }


        //private void SearchAndListBlyncDevices()
        //{

        //    // Look for the Blync devices connected to the System
        //    // the nNumberOfBlyncDevices will be equal to the number 
        //    // of Blync devices connected to the System USB Ports
        //    int nNumberOfBlyncDevices = oBlynclightController.InitBlyncDevices();

        //    if (nNumberOfBlyncDevices > 0)
        //    {
        //        // Add the Blync devices detected to the combobox
        //        for (int i = 0; i < nNumberOfBlyncDevices; i++)
        //        {
        //            comboBoxDeviceList.Items.Insert(i, oBlynclightController.aoDevInfo[i].szDeviceName);

        //            if (oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_TENX_10 ||
        //                oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_TENX_20)
        //            {
        //                EnableUIComponentsForBlyncUsb1020Devices();
        //                DisableUIComponentsForBlyncUsb30Devices();
        //            }
        //            else if (oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30S ||
        //                oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_CHIPSET_V30 ||
        //                oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA110 ||
        //                oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_HEADSET_CHIPSET_V30_LUMENA120 ||
        //                oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_WIRELESS_CHIPSET_V30S ||
        //                oBlynclightController.aoDevInfo[i].byDeviceType == DEVICETYPE_BLYNC_MINI_CHIPSET_V30S)
        //            {
        //                EnableUIComponentsForBlyncUsb30Devices();
        //                DisableUIComponentsForBlyncUsb1020Devices();
        //            }
        //        }

        //        comboBoxDeviceList.SelectedIndex = 0;
        //        nSelectedDeviceIndex = 0;
        //    }
        //    else
        //    {
        //        MessageBox.Show("No Blync Devices Detected", "Information",
        //                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

        //        // If device is not present disable all UI components
        //        DisableUIComponentsForBlyncUsb1020Devices();
        //        DisableUIComponentsForBlyncUsb30Devices();
        //    }
        //}
    }
}
