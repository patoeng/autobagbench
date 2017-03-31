using System;
using ModbusTCP;
using Xs156AutoBagPLC.Helper;

namespace AutoBagBench
{
    public class PlcCommandHelper
    {
        public static void ResetError(Master master)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 3, ModbusTcpHelper.WordArrayToByteArray(new int[] { 1 }, 1),ref dummy); 
        }

        public static void ResetSequenceStart(Master master)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 1, ModbusTcpHelper.WordArrayToByteArray(new int[] { 1 }, 1),ref dummy); 
        }
        public static void ResetSequenceComplete(Master master)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 1, ModbusTcpHelper.WordArrayToByteArray(new int[] { 0 }, 1), ref dummy);
        }
        public static void TellPlcHmiState(Master master, HmiState state)
        {
            byte[] dummy = new byte[] {};
            master.WriteSingleRegister(1, 1, 0, ModbusTcpHelper.WordArrayToByteArray(new int[] {Convert.ToInt32(state )}, 1), ref dummy);
        }
        public static void SetAccessories(Master master, AccessoriesType number)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 13, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(number) }, 1), ref dummy);
        }
        public static void SetBagType(Master master, BagType number)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 14, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(number) }, 1), ref dummy);
        }
        public static void SetOutputQty(Master master, int number)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 9, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(number) }, 1), ref dummy);
        }
        public static void SetRejectQty(Master master, int number)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 7, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(number) }, 1), ref dummy);
        }
        public static void SetTargetQty(Master master, int number)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 11, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(number) }, 1), ref dummy);
        }
        public static void IncreaseOutputQty(Master master, int number)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 15, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(number) }, 1), ref dummy);
        }
        public static void DecreaseOutputQty(Master master, int number)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 16, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(number) }, 1), ref dummy);
        }
        public static void EnableTraceabilityMode(Master master, bool number)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 17, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(number) }, 1), ref dummy);
        }
        public static void SetPlcMode(Master master, PlcMode number)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 2, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(number) }, 1), ref dummy);
        }
        public static void GetPlcRawData(Master master, int number, ref byte[] data)
        {
            master.ReadHoldingRegister(100, 1, 0, 25, ref data);
        }
        public static void SetAccessoriesM8Lamp(Master master, bool data)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 40, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(data) }, 1), ref dummy);
        }
        public static void SetAccessoriesM12Lamp(Master master, bool data)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 41, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(data) }, 1), ref dummy);
        }
        public static void SetAccessoriesM18Lamp(Master master, bool data)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 42, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(data) }, 1), ref dummy);
        }
        public static void SetAccessoriesM30Lamp(Master master, bool data)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 43, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(data) }, 1), ref dummy);
        }
        public static void SetTriggerSealer(Master master, bool data)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 44, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(data) }, 1), ref dummy);
        }
        public static void SetBuzzer(Master master, bool data)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 45, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(data) }, 1), ref dummy);
        }
        public static void SetAccessoriessM8GateOpen(Master master, bool data)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 46, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(data) }, 1), ref dummy);
        }
        public static void SetAccessoriessM12GateOpen(Master master, bool data)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 47, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(data) }, 1), ref dummy);
        }
        public static void SetAccessoriessM18GateOpen(Master master, bool data)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 48, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(data) }, 1), ref dummy);
        }
        public static void SetAccessoriessM30GateOpen(Master master, bool data)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 49, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(data) }, 1), ref dummy);
        }
        public static void MuteAlarm(Master master, bool data)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 50, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(data) }, 1), ref dummy);
        }
        public static void SetPlcUnMatchBarcodeAlarm(Master master)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 51, ModbusTcpHelper.WordArrayToByteArray(new int[] {1}, 1), ref dummy);
        }
        public static void IndividualBagPrinted(Master master,bool value)
        {
            byte[] dummy = new byte[] { };
            master.WriteSingleRegister(1, 1, 52, ModbusTcpHelper.WordArrayToByteArray(new int[] { Convert.ToInt32(value) }, 1), ref dummy);
        }
    }
}
