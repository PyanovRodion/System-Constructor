﻿using System;
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
        public FormSystemConstructor()
        {

            InitializeComponent();  
            //dbc=new Database_Computer_PartsDataSet();
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
            //Some method
        }

        private void FormSystemConstructor_Load(object sender, EventArgs e)
        {
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
    }
}
