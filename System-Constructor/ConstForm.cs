using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Mail;

namespace System_Constructor
{
    public partial class FormSystemConstructor : Form
    {
        public Database_Computer_PartsDataSet dbc;
        public Configuration Config;
        BindingSource motherBoardBindingSource = new BindingSource();
        BindingSource ProcessorBindingSource = new BindingSource();
        public int price { get; set; }

        public FormSystemConstructor()
        {

            InitializeComponent();  
            Config = new Configuration();
            dbc = database_Computer_PartsDataSet;

            DataTable ProcTable= dbc.Процессоры; 
            DataTable BlockpitTable = dbc.Блоки_питания;
            DataTable ZvukKartaTable = dbc.Звуковые_карты;
            DataTable VideoKardsTable = dbc.Видео_карты;
            DataTable HarddrivesTable = dbc.Жесткие_диски_и_сетевые_накопители;
            DataTable CoolerTable = dbc.Кулеры_и_системы_охлаждения;
            DataTable MotheRSTable = dbc.Материнские_платы;

            dataGridViewProcessor.DataSource = ProcTable;
            dataGridViewMotherboard.DataSource = MotheRSTable;
            dataGridViewCooler.DataSource=CoolerTable;
            dataGridViewHardDisk.DataSource = HarddrivesTable;
            dataGridViewPowerUnit.DataSource = BlockpitTable;
            dataGridViewSCard.DataSource = ZvukKartaTable;
            dataGridViewVCard.DataSource = VideoKardsTable;

        }



        private void FormSystemConstructor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database_Computer_PartsDataSet.Оперативная_память' table. You can move, or remove it, as needed.
            this.оперативная_памятьTableAdapter.Fill(this.database_Computer_PartsDataSet.Оперативная_память);
            // TODO: This line of code loads data into the 'database_Computer_PartsDataSet.Жесткие_диски_и_сетевые_накопители' table. You can move, or remove it, as needed.
            this.жесткие_диски_и_сетевые_накопителиTableAdapter.Fill(this.database_Computer_PartsDataSet.Жесткие_диски_и_сетевые_накопители);
            // TODO: This line of code loads data into the 'database_Computer_PartsDataSet.Ошибки_вставки' table. You can move, or remove it, as needed.
            this.ошибки_вставкиTableAdapter.Fill(this.database_Computer_PartsDataSet.Ошибки_вставки);
            // TODO: This line of code loads data into the 'database_Computer_PartsDataSet.Кулеры_и_системы_охлаждения' table. You can move, or remove it, as needed.
            this.кулеры_и_системы_охлажденияTableAdapter.Fill(this.database_Computer_PartsDataSet.Кулеры_и_системы_охлаждения);
            // TODO: This line of code loads data into the 'database_Computer_PartsDataSet.Блоки_питания' table. You can move, or remove it, as needed.
            this.блоки_питанияTableAdapter.Fill(this.database_Computer_PartsDataSet.Блоки_питания);
            // TODO: This line of code loads data into the 'database_Computer_PartsDataSet.Материнские_платы' table. You can move, or remove it, as needed.
            this.материнские_платыTableAdapter.Fill(this.database_Computer_PartsDataSet.Материнские_платы);
            // TODO: This line of code loads data into the 'database_Computer_PartsDataSet.Звуковые_карты' table. You can move, or remove it, as needed.
            this.звуковые_картыTableAdapter.Fill(this.database_Computer_PartsDataSet.Звуковые_карты);
            // TODO: This line of code loads data into the 'database_Computer_PartsDataSet.Процессоры' table. You can move, or remove it, as needed.
            this.процессорыTableAdapter.Fill(this.database_Computer_PartsDataSet.Процессоры);
            // TODO: This line of code loads data into the 'database_Computer_PartsDataSet.Процессоры' table. You can move, or remove it, as needed.
            this.процессорыTableAdapter.Fill(this.database_Computer_PartsDataSet.Процессоры);
            // TODO: This line of code loads data into the 'database_Computer_PartsDataSet.Видео_карты' table. You can move, or remove it, as needed.
            this.видео_картыTableAdapter.Fill(this.database_Computer_PartsDataSet.Видео_карты);

        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void RefreshDataGridView()
        {
            //dataGridViewProcessor.DataSource = dbc.Процессоры;
            if (Config.CPU == null)
            {
                dataGridViewMotherboard.DataSource = dbc.Материнские_платы.CopyToDataTable();
            }
            else
            {
                try
                {
                    //dataGridViewMotherboard.AutoGenerateColumns=true;
                    //var request = dbc.Материнские_платы.Where(m => m.Socket.Equals(Config.CPU.Socket));
                    //motherBoardBindingSource.DataSource = dbc.Материнские_платы.Where(m => m.Socket.Equals(Config.CPU.Socket) || Config.CPU == null);
                    //dataGridViewMotherboard.DataSource = motherBoardBindingSource;

                    dataGridViewMotherboard.DataSource = dbc.Материнские_платы.Where(m => (m.Socket.Equals(Config.CPU.Socket))).CopyToDataTable();
                }
                catch { }
            }
            if (Config.MBoard == null)
            {
                dataGridViewProcessor.DataSource = dbc.Процессоры.CopyToDataTable();
            }
            else
            {
                try
                {
                    //dataGridViewProcessor.AutoGenerateColumns = true;
                    //ProcessorBindingSource.DataSource = dbc.Процессоры.Where(p => p.Socket.Equals(Config.MBoard.Socket));
                    dataGridViewProcessor.DataSource = dbc.Процессоры.Where(p => p.Socket.Equals(Config.MBoard.Socket)).CopyToDataTable();
                }
                catch { }
            }
            //if (Config.MBoard == null)
            //{
            //    dataGridViewROM.DataSource = dbc.Оперативная_память.CopyToDataTable();
            //}
            //else
            //{
            //    dataGridViewROM.DataSource = dbc.Оперативная_память.Where(r => Config.MBoard.MemoryType.Contains(r.Тип)).CopyToDataTable();
            //}
            labelPrice.Text = price.ToString();
        }

        //------------------------------------------------------------------Selections 

        private void buttonSelectProc_Click(object sender, EventArgs e)
        {
            Processor proc = new Processor();
            proc.Developer = dataGridViewProcessor.SelectedRows[0].Cells[1].Value.ToString();
            proc.Name = dataGridViewProcessor.SelectedRows[0].Cells[2].Value.ToString();
            proc.Cost = int.Parse(dataGridViewProcessor.SelectedRows[0].Cells[3].Value.ToString());
            proc.Frequency = (int)dataGridViewProcessor.SelectedRows[0].Cells[4].Value;
            proc.NumberOfCores = (int)dataGridViewProcessor.SelectedRows[0].Cells[5].Value;
            proc.Socket = dataGridViewProcessor.SelectedRows[0].Cells[6].Value.ToString();
            proc.Core = dataGridViewProcessor.SelectedRows[0].Cells[7].Value.ToString();
            proc.MultiplierAccess = (bool)dataGridViewProcessor.SelectedRows[0].Cells[8].Value;
            proc.CashL1 = (int)dataGridViewProcessor.SelectedRows[0].Cells[9].Value;
            proc.CashL2 = (int)dataGridViewProcessor.SelectedRows[0].Cells[10].Value;
            proc.CashL3 = (int)dataGridViewProcessor.SelectedRows[0].Cells[11].Value;

            proc.MultiplierNumber = (int)dataGridViewProcessor.SelectedRows[0].Cells[13].Value;
            proc.Temprature = int.Parse(dataGridViewProcessor.SelectedRows[0].Cells[14].Value.ToString());
            Config.CPU = proc;
            labelProcessor.Text = proc.Name;
            RefreshPrice();
            RefreshDataGridView();

        }
        private void buttonSelectMotherboard_Click(object sender, EventArgs e)
        {            
            Motherboard mb = new Motherboard();
            mb.Developer = dataGridViewMotherboard.SelectedRows[0].Cells[1].Value.ToString();
            mb.Name = dataGridViewMotherboard.SelectedRows[0].Cells[2].Value.ToString();
            mb.Cost = int.Parse(dataGridViewMotherboard.SelectedRows[0].Cells[3].Value.ToString());
            mb.FormFactor = dataGridViewMotherboard.SelectedRows[0].Cells[4].Value.ToString();
            mb.Socket = dataGridViewMotherboard.SelectedRows[0].Cells[5].Value.ToString();
            mb.Chipset = dataGridViewMotherboard.SelectedRows[0].Cells[6].Value.ToString();
            mb.MultiProcessor = (bool)dataGridViewMotherboard.SelectedRows[0].Cells[7].Value;
            mb.BIOS = dataGridViewMotherboard.SelectedRows[0].Cells[8].Value.ToString();
            mb.CrossFire = dataGridViewMotherboard.SelectedRows[0].Cells[9].Value.ToString();
            mb.SLI = dataGridViewMotherboard.SelectedRows[0].Cells[10].Value.ToString();
            mb.MemoryType = dataGridViewMotherboard.SelectedRows[0].Cells[11].Value.ToString();
            mb.MAXMemoryVolume = int.Parse(dataGridViewMotherboard.SelectedRows[0].Cells[12].Value.ToString());
            mb.SATA = dataGridViewMotherboard.SelectedRows[0].Cells[13].Value.ToString();
            mb.Sounds = dataGridViewMotherboard.SelectedRows[0].Cells[14].Value.ToString();
            mb.Ethernet = dataGridViewMotherboard.SelectedRows[0].Cells[15].Value.ToString();
            mb.PCINumber = (int)dataGridViewMotherboard.SelectedRows[0].Cells[16].Value;
            mb.PCIExpressNumber = (int)dataGridViewMotherboard.SelectedRows[0].Cells[17].Value;
            mb.USB = (int)dataGridViewMotherboard.SelectedRows[0].Cells[18].Value;
            mb.HDMI = (int)dataGridViewMotherboard.SelectedRows[0].Cells[19].Value;
            mb.DVI = (bool)dataGridViewMotherboard.SelectedRows[0].Cells[20].Value;
            Config.MBoard = mb;
            labelMotherboard.Text = mb.Name;
            RefreshPrice();
            RefreshDataGridView();
        }
        private void buttonSelectVCard_Click(object sender, EventArgs e)
        {
            VCard vc = new VCard();
            vc.Developer = dataGridViewVCard.SelectedRows[0].Cells[1].Value.ToString();
            vc.Name = dataGridViewVCard.SelectedRows[0].Cells[2].Value.ToString();
            vc.Cost = int.Parse(dataGridViewVCard.SelectedRows[0].Cells[3].Value.ToString());
            vc.TypeOfCard = dataGridViewVCard.SelectedRows[0].Cells[4].Value.ToString();
            vc.TypeOfConnection = dataGridViewVCard.SelectedRows[0].Cells[5].Value.ToString();
            vc.ProcessorName = dataGridViewVCard.SelectedRows[0].Cells[6].Value.ToString();
            vc.NumberOfProcessors = (int)dataGridViewVCard.SelectedRows[0].Cells[7].Value;
            vc.MemoryFrequency = (int)dataGridViewVCard.SelectedRows[0].Cells[8].Value;
            vc.MemoryVolume = (int)dataGridViewVCard.SelectedRows[0].Cells[9].Value;
            vc.MemoryType = dataGridViewVCard.SelectedRows[0].Cells[10].Value.ToString();
            vc.MonitorsConnected = (int)dataGridViewVCard.SelectedRows[0].Cells[11].Value;
            vc.DVIOut = int.Parse(dataGridViewVCard.SelectedRows[0].Cells[12].Value.ToString());
            vc.HDCP = (bool)dataGridViewVCard.SelectedRows[0].Cells[13].Value;
            vc.HDMIOut = (int)dataGridViewVCard.SelectedRows[0].Cells[14].Value;
            vc.Resolution = dataGridViewVCard.SelectedRows[0].Cells[15].Value.ToString();
            Config.VideoCard = vc;
            labelVCard.Text = vc.Name;
            RefreshPrice();
            RefreshDataGridView();
        }
        private void buttonSelectSCard_Click(object sender, EventArgs e)
        {
            SCard sc = new SCard();
            sc.Developer = dataGridViewSCard.SelectedRows[0].Cells[1].Value.ToString();
            sc.Name = dataGridViewSCard.SelectedRows[0].Cells[2].Value.ToString();
            sc.Cost = int.Parse(dataGridViewSCard.SelectedRows[0].Cells[3].Value.ToString());
            sc.Type = dataGridViewSCard.SelectedRows[0].Cells[4].Value.ToString();
            sc.ConnectionType = dataGridViewSCard.SelectedRows[0].Cells[5].Value.ToString();
            sc.AdditionalPower = (bool)dataGridViewSCard.SelectedRows[0].Cells[6].Value;
            sc.FrequencyACP = (int)dataGridViewSCard.SelectedRows[0].Cells[7].Value;
            sc.FrequencyCAP = (int)dataGridViewSCard.SelectedRows[0].Cells[8].Value;
            sc.MAXFrequencyCAP = (int)dataGridViewSCard.SelectedRows[0].Cells[9].Value;
            sc.InChanelsNumber = (int)dataGridViewSCard.SelectedRows[0].Cells[10].Value;
            Config.SoundCard = sc;
            labelSCard.Text = sc.Name;
            RefreshPrice();
            RefreshDataGridView();
         }
        private void buttonSelectPowerUnit_Click(object sender, EventArgs e)
        {
            PowerUnit pu = new PowerUnit();
            pu.Developer = dataGridViewPowerUnit.SelectedRows[0].Cells[1].Value.ToString();
            pu.Name = dataGridViewPowerUnit.SelectedRows[0].Cells[2].Value.ToString();
            pu.Cost = int.Parse(dataGridViewPowerUnit.SelectedRows[0].Cells[3].Value.ToString());
            pu.Power = int.Parse(dataGridViewPowerUnit.SelectedRows[0].Cells[4].Value.ToString());
            pu.Sertificate80Plus = dataGridViewPowerUnit.SelectedRows[0].Cells[5].Value.ToString();
            pu.CoolerSystem = (int)dataGridViewPowerUnit.SelectedRows[0].Cells[6].Value;
            pu.CoolerSize = (int)dataGridViewPowerUnit.SelectedRows[0].Cells[7].Value;
            pu.SeconderyCoolerSize = (int)dataGridViewPowerUnit.SelectedRows[0].Cells[8].Value;
            pu.PFS = dataGridViewPowerUnit.SelectedRows[0].Cells[9].Value.ToString();
            pu.ATX12VVersion = dataGridViewPowerUnit.SelectedRows[0].Cells[10].Value.ToString();
            pu.MotherboardConnectionType = dataGridViewPowerUnit.SelectedRows[0].Cells[11].Value.ToString();
            pu.SpecialCables = (bool)dataGridViewPowerUnit.SelectedRows[0].Cells[12].Value;
            pu.Surge = (bool)dataGridViewPowerUnit.SelectedRows[0].Cells[13].Value;
            pu.ShortCircuit = (bool)dataGridViewPowerUnit.SelectedRows[0].Cells[14].Value;
            Config.Power = pu;
            labelPowerUnit.Text = pu.Name;
            RefreshPrice();
            RefreshDataGridView();
        }
        private void buttonSelectCooler_Click(object sender, EventArgs e)
        {
            Cooler c = new Cooler();
            c.Developer = dataGridViewCooler.SelectedRows[0].Cells[1].Value.ToString();
            c.Name = dataGridViewCooler.SelectedRows[0].Cells[2].Value.ToString();
            c.Cost = int.Parse(dataGridViewCooler.SelectedRows[0].Cells[3].Value.ToString());
            c.Usage = dataGridViewCooler.SelectedRows[0].Cells[4].Value.ToString();
            c.WaterCool = (bool)dataGridViewCooler.SelectedRows[0].Cells[5].Value;
            c.NumberOfFans = (int)dataGridViewCooler.SelectedRows[0].Cells[6].Value;
            c.FansSize = (int)dataGridViewCooler.SelectedRows[0].Cells[7].Value;
            c.Socket = dataGridViewCooler.SelectedRows[0].Cells[8].Value.ToString();
            Config.Cooler = c;
            labelCooler.Text = c.Name;
            RefreshPrice();
            RefreshDataGridView();
        }
        private void buttonSelectROM_Click(object sender, EventArgs e)
        {
            ROM r = new ROM();
            r.Developer = dataGridViewROM.SelectedRows[0].Cells[1].Value.ToString();
            r.Name = dataGridViewROM.SelectedRows[0].Cells[2].Value.ToString();
            r.Cost = int.Parse(dataGridViewROM.SelectedRows[0].Cells[3].Value.ToString());
            r.Type = dataGridViewROM.SelectedRows[0].Cells[4].Value.ToString();
            r.FormFactor = dataGridViewROM.SelectedRows[0].Cells[5].Value.ToString();
            r.NumberOfBlocks = int.Parse(dataGridViewROM.SelectedRows[0].Cells[6].Value.ToString());
            r.BlockVolume = int.Parse(dataGridViewROM.SelectedRows[0].Cells[7].Value.ToString());
            Config.ROM = r;
            RefreshPrice();
            labelROM.Text = r.Developer+" "+r.Name;
            RefreshDataGridView();
        }
        private void buttonSelectHardDisk_Click(object sender, EventArgs e)
        {
            HardDisk hd = new HardDisk();
            hd.Developer = dataGridViewHardDisk.SelectedRows[0].Cells[1].Value.ToString();
            hd.Name = dataGridViewHardDisk.SelectedRows[0].Cells[2].Value.ToString();
            hd.Cost = int.Parse(dataGridViewHardDisk.SelectedRows[0].Cells[3].Value.ToString());
            hd.FormFactor = double.Parse(dataGridViewHardDisk.SelectedRows[0].Cells[4].Value.ToString());
            hd.Volume = int.Parse(dataGridViewHardDisk.SelectedRows[0].Cells[5].Value.ToString());
            hd.Type = dataGridViewHardDisk.SelectedRows[0].Cells[6].Value.ToString();
            hd.SATAConnection = (int)dataGridViewHardDisk.SelectedRows[0].Cells[7].Value;
            hd.IDE = (bool)dataGridViewHardDisk.SelectedRows[0].Cells[8].Value;
            hd.PCIEConnection = (bool)dataGridViewHardDisk.SelectedRows[0].Cells[9].Value;
            int.TryParse(dataGridViewHardDisk.SelectedRows[0].Cells[10].Value.ToString(), out hd.PCIType);
            hd.ZIF40Pin = (bool)dataGridViewHardDisk.SelectedRows[0].Cells[11].Value;
            hd.eSATA = (bool)dataGridViewHardDisk.SelectedRows[0].Cells[12].Value;
            hd.mSATA = (bool)dataGridViewHardDisk.SelectedRows[0].Cells[13].Value;
            int.TryParse(dataGridViewHardDisk.SelectedRows[0].Cells[14].Value.ToString(), out hd.SpinSpeed);
            int.TryParse(dataGridViewHardDisk.SelectedRows[0].Cells[15].Value.ToString(), out hd.ReadSpeed);
            int.TryParse(dataGridViewHardDisk.SelectedRows[0].Cells[16].Value.ToString(), out hd.WriteSpeed);
            Config.HardDisk = hd;
            RefreshPrice();
            labelHardDisc.Text = hd.Developer + " " + hd.Name;
            RefreshDataGridView();
        }

        //------------------------------------------------------------------Cancellations

        private void buttonCancelProc_Click(object sender, EventArgs e)
        {
            Config.CPU = null;
            labelProcessor.Text = "Не выбрано";
            RefreshPrice();
            RefreshDataGridView();
        }
        private void buttonCancelVCard_Click(object sender, EventArgs e)
        {
            Config.VideoCard = null;
            labelVCard.Text = "Не выбрано";
            RefreshPrice();
            RefreshDataGridView();
        }
        private void buttonCancelSCard_Click(object sender, EventArgs e)
        {
            Config.SoundCard = null;
            labelSCard.Text = "Не выбрано";
            RefreshPrice();
            RefreshDataGridView();
        }
        private void buttonCancelMotherboard_Click(object sender, EventArgs e)
        {
            Config.MBoard = null;
            labelMotherboard.Text = "Не выбрано";
            RefreshPrice();
            RefreshDataGridView();
        }
        private void buttonCancelPowerUnit_Click(object sender, EventArgs e)
        {
            Config.Power = null;
            labelPowerUnit.Text = "Не выбрано";
            RefreshPrice();
            RefreshDataGridView();
        }
        private void buttonCancelCooler_Click(object sender, EventArgs e)
        {
            Config.Cooler = null;
            labelCooler.Text = "Не выбрано";
            RefreshPrice();
            RefreshDataGridView();
        }
        private void buttonCancelROM_Click(object sender, EventArgs e)
        {
            Config.ROM = null;
            labelROM.Text = "Не выбрано";
            RefreshPrice();
            RefreshDataGridView();
        }
        private void buttonCancelHardDisk_Click(object sender, EventArgs e)
        {
            Config.HardDisk = null;
            labelHardDisc.Text = "Не выбрано";
            RefreshPrice();
            RefreshDataGridView();
        }

        private void buttonSendOrder_Click(object sender, EventArgs e)
        {
            if ((Config.CPU != null) || (Config.MBoard != null) || (Config.Power != null) || (Config.ROM != null) || (Config.SoundCard != null) || (Config.VideoCard != null) || (Config.HardDisk != null) || (Config.Cooler != null))
            {
                SendOrder sof = new SendOrder(Config, price);
                sof.ShowDialog();      
           }
            else { MessageBox.Show("Не указан ни один из параметров комплектации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void RefreshPrice()
        {
            price = 0;
            if (Config.CPU != null) price += Config.CPU.Cost;
            if (Config.MBoard != null) price += Config.MBoard.Cost;
            if (Config.Power != null) price += Config.Power.Cost;
            if (Config.SoundCard != null) price += Config.SoundCard.Cost;
            if (Config.VideoCard != null) price += Config.VideoCard.Cost;
            if (Config.ROM != null) price += Config.ROM.Cost;
            if (Config.HardDisk != null) price += Config.HardDisk.Cost;
            if (Config.Cooler!= null) price += Config.Cooler.Cost;
        }
        
    }
}
