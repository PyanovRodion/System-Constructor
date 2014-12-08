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

namespace System_Constructor
{
    public partial class FormSystemConstructor : Form
    {
        public Database_Computer_PartsDataSet dbc;
        public Configuration Config;
        public FormSystemConstructor()
        {

            InitializeComponent();  
            //dbc=new Database_Computer_PartsDataSet();
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
            RefreshDataGridView();

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

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        BindingSource motherBoardBindingSource = new BindingSource();

        public void RefreshDataGridView()
        {
            dataGridViewProcessor.DataSource = dbc.Процессоры;

            var request = dbc.Материнские_платы.Where(m => m.Socket.Equals(Config.CPU.Socket) || Config.CPU.Socket == "").ToList(); ;
            motherBoardBindingSource.DataSource = request;
            dataGridViewMotherboard.DataSource = motherBoardBindingSource;

            //dataGridViewCooler.DataSource = 
            //dataGridViewHardDisk.DataSource = HarddrivesTable;
            //dataGridViewPowerUnit.DataSource = BlockpitTable;
            //dataGridViewSCard.DataSource = ZvukKartaTable;
            //dataGridViewVCard.DataSource = VideoKardsTable;
        }

        private void dataGridViewROM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            //RefreshDataGridView();
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
         }
    }
}
