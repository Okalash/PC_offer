using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_offer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Powered by Sanya_Kalash";
        }


        decimal timeValue;
        private void Button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value !=0 )
            {
                timeValue = numericUpDown1.Value* 60 ;  // * 60 to minute
                progressBar1.Maximum = Decimal.ToInt32(timeValue);
                timer1.Enabled = !timer1.Enabled;
                label2.Text = "Время выключения: " + (DateTime.Now.AddSeconds( Decimal.ToInt32(timeValue)));
            }
            else
            {
                MessageBox.Show("Значение должно быть больше 0");
                
            }

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (timeValue != 0)
            {
                timeValue--;
                progressBar1.Value++;
            }
            else
            {
                timer1.Enabled = false;
                System.Diagnostics.Process.Start("cmd", "/c shutdown -s -f -t 00");  // power off in cmd
                //MessageBox.Show("BADABOOM!"); // need to power off pc
                this.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            progressBar1.Value = default;
            label2.Text = "";
            numericUpDown1.Value = default;
        }

    }
}
