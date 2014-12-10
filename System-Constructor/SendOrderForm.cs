using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace System_Constructor
{
    public partial class SendOrder : Form
    {
        public Configuration Config { get; set; }
        public int Price { get; set; }

        public SendOrder(Configuration cs, int p)
        {
            Config = cs;
            Price = p;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                try
                {
                    string request="";
                    if (Config.CPU !=null) {request += Config.CPU.Name + "\n";}
                    if (Config.VideoCard!=null) {request += Config.VideoCard.Name + "\n";}
                    if (Config.SoundCard != null) { request += Config.SoundCard.Name + "\n"; }
                    if (Config.MBoard != null) { request += Config.MBoard.Name + "\n"; }
                    if (Config.Power != null) { request += Config.Power.Name + "\n"; }
                    if (Config.Cooler != null) { request += Config.Cooler.Name + "\n"; }
                    if (Config.ROM != null) { request += Config.ROM.Name + "\n"; }
                    if (Config.HardDisk != null) { request += Config.HardDisk.Name + "\n"; }

                    request += "\n" + "\n" + "Итого: " + Price.ToString() + "\n" + "\n" + "Обратная связь: "+ textBox1.Text;
                    string subject = "NewProjectToBuild "+textBox1.Text;
                    MailMessage m1 = new MailMessage("scappuser@rambler.ru", "scappuser@rambler.ru", subject, request);

                    SmtpClient client = new SmtpClient("smtp.rambler.ru");
                    client.Port = 587;
                    string username = "scappuser@rambler.ru";
                    string pass = "ipsis1010";
                    client.Credentials = new System.Net.NetworkCredential(username, pass);
                    client.EnableSsl = true;
                    client.Send(m1);
                    MessageBox.Show("Запрос на сборку успешно отправлен в компанию System-Constructor. Спасибо, что воспользовались нашими услугами!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch { MessageBox.Show("Неверно указан почтовый адрес", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                this.Close();
        }

    }
}
