using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Constructor
{
    public class Processor
    {
        public string Developer;
        public string Name;
        public int Cost;

        public int Frequency;
        public int NumberOfCores;
        public string Socket;
        public string Core;
        public bool MultiplierAccess;
        public int CashL1;
        public int CashL2;
        public int CashL3;
        public int BusCash;
        public int MultiplierNumber;
        public int Temprature;

    }
    public class VCard
    {
        public string Developer;
        public string Name;
        public int Cost;

        public string TypeOfCard;
        public string TypeOfConnection;
        public string ProcessorName;
        public int NumberOfProcessors;
        public int MemoryFrequency;
        public int MemoryVolume;
        public string MemoryType;
        public int MonitorsConnected;
        public int DVIOut;
        public bool HDCP;
        public int HDMIOut;
        public string Resolution;
    }
    public class SCard
    {
        public string Developer;
        public string Name;
        public int Cost;

        public string Type;
        public string ConnectionType;
        public bool AdditionalPower;
        public int FrequencyACP;
        public int FrequencyCAP;
        public int MAXFrequencyCAP;
        public int InChanelsNumber;
    }
    public class Motherboard
    {
        public string Developer;
        public string Name;
        public int Cost;

        public string FormFactor;
        public string Socket;
        public string Chipset;
        public bool MultiProcessor;
        public string BIOS;
        public string CrossFire;
        public string SLI;
        public string MemoryType;
        public int MAXMemoryVolume;
        public string SATA;
        public string Sounds;
        public string Ethernet;
        public int PCINumber;
        public int PCIExpressNumber;
        public int USB;
        public int HDMI;
        public bool DVI;
    }
    public class PowerUnit
    {
        public string Developer;
        public string Name;
        public int Cost;

        public int Power;
        public string Sertificate80Plus ;
        public int CoolerSystem;
        public int CoolerSize;
        public int SeconderyCoolerSize;
        public string PFS;
        public string ATX12VVersion;
        public string MotherboardConnectionType;
        public bool SpecialCables;
        public bool Surge;
        public bool Overload;
        public bool ShortCircuit;
    }
    public class Cooler
    {
        public string Developer;
        public string Name;
        public int Cost;

        public string Usage;
        public bool WaterCool;
        public int NumberOfFans;
        public int FansSize;
        public string Socket;
    }
    public class ROM
    {
        public string Developer;
        public string Name;
        public int Cost;

        public string Type;
        public string FormFactor;
        public int NumberOfBlocks;
        public int BlockVolume;
    }
    public class HardDisk
    {
        public string Developer;
        public string Name;
        public int Cost;

        public int FormFactor;
        public int Volume;
        public string Type;
        public int SATAConnection;
        public bool IDE;
        public bool PCIEConnection;
        public int PCIType;
        public bool ZIF40Pin;
        public bool eSATA;
        public bool mSATA;
        public int SpinSpeed;
        public int ReadSpeed;
        public int WriteSpeed;
        public int BuferVolume;
    }
}
