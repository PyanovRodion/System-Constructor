using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Constructor
{
    public class Configuration
    {
        public Processor CPU { get; set; }
        public VCard VideoCard { get; set; }
        public SCard SoundCard { get; set; }
        public Motherboard MBoard { get; set; }
        public PowerUnit Power { get; set; }
        public Cooler Cooler { get; set; }
        public ROM ROM { get; set; }
        public HardDisk HardDisk { get; set; }
        public int PCINumber { get; set; }
    }
}
