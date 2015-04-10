using Motorola.Snapi;
using System;

namespace Motorola.Test
{
    internal class Program
    {
        private static void Instance_DataReceived(object sender, BarcodeScanEventArgs e)
        {
            var d = e.Data;
        }

        private static void Main(string[] args)
        {
            BarcodeScannerManager.Instance.Open();

            BarcodeScannerManager.Instance.Attach();

            BarcodeScannerManager.Instance.Keyboard.EnableEmulation = false;

            foreach (var scanner in BarcodeScannerManager.Instance.GetDevices())
            {
                //((BarcodeScanner)scanner).EnableLeicaBarcodes();
                scanner.EnableDataMatrixBarcodes();
            }

            BarcodeScannerManager.Instance.DataReceived += Instance_DataReceived;

            Console.ReadLine();
        }
    }
}