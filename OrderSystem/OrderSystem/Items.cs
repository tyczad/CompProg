using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderSystem
{
    public partial class frm_items : Form
    {
        const double price_sisig = 70;
        const double price_spareribs = 85;
        const double price_porkchop = 60;
        const double price_tbone = 70;
        const double price_chicken = 60;
        const double price_liempo = 75;
        const double price_steak = 80;
        const double price_sausage = 80;
        public frm_items()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm you want to exit the system", "Ordering System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frm_items_Load(object sender, EventArgs e)
        {
            cmb_payment.Items.Add(" Cash ");
            cmb_payment.Items.Add(" GCash ");

            EnableTextBoxes();
        }

        private void EnableTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Enabled = false;
                    else
                        func(control.Controls);
            };
            func(Controls);
        }

        private void chk_sisig_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_sisig.Checked == true) 
            {
                txt_sisig.Enabled = true;
                txt_sisig.Text = "";
                txt_sisig.Focus();
            }
            else 
            {
                txt_sisig.Enabled = false;
                txt_sisig.Text = "0";
                txt_sisig.Focus();
            }
        }

        private void chk_spareribs_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_spareribs.Checked == true)
            {
                txt_spareribs.Enabled = true;
                txt_spareribs.Text = "";
                txt_spareribs.Focus();
            }
            else
            {
                txt_spareribs.Enabled= false;
                txt_spareribs.Text = "0";
            }
        }

        private void chk_porkchop_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_porkchop.Checked == true)
            {
                txt_porkchop.Enabled = true;
                txt_porkchop.Text = "";
                txt_porkchop.Focus();
            }
            else
            {
                txt_porkchop.Enabled = false;
                txt_porkchop.Text = "0";
            }
        }

        private void chk_tbone_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_tbone.Checked == true)
            {
                txt_tbone.Enabled = true;
                txt_tbone.Text = "";
                txt_tbone.Focus();
            }
            else
            {
                txt_tbone.Enabled = false;
                txt_tbone.Text = "0";
            }
        }

        private void chk_chicken_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_chicken.Checked == true)
            {
                txt_chicken.Enabled = true;
                txt_chicken.Text = "";
                txt_chicken.Focus();
            }
            else
            {
                txt_chicken.Enabled = false;
                txt_chicken.Text = "0";
            }
        }

        private void chk_liempo_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_liempo.Checked == true)
            {
                txt_liempo.Enabled = true;
                txt_liempo.Text = "";
                txt_liempo.Focus();
            }
            else
            {
                txt_liempo.Enabled = false;
                txt_liempo.Text = "0";
            }
        }

        private void chk_steak_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_steak.Checked == true)
            {
                txt_steak.Enabled = true;
                txt_steak.Text = "";
                txt_steak.Focus();
            }
            else
            {
                txt_steak.Enabled = false;
                txt_steak.Text = "0";
            }
        }

        private void chk_sausage_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_sausage.Checked == true)
            {
                txt_sausage.Enabled = true;
                txt_sausage.Text = "";
                txt_sausage.Focus();
            }
            else
            {
                txt_sausage.Enabled = false;
                txt_sausage.Text = "0";
            }
        }

        private void btn_total_Click(object sender, EventArgs e)
        {
            double[] itemcost = new double[100];
            double.TryParse(txt_sisig.Text, out double sisigQuantity);
            itemcost[0] = sisigQuantity * price_sisig;

            double.TryParse(txt_spareribs.Text, out double spareribsQuantity);
            itemcost[2] = spareribsQuantity * price_spareribs;

            double.TryParse(txt_porkchop.Text, out double porkchopQuantity);
            itemcost[3] = porkchopQuantity * price_porkchop;

            double.TryParse(txt_tbone.Text, out double tboneQuantity);
            itemcost[4] = tboneQuantity * price_tbone;

            double.TryParse(txt_chicken.Text, out double chickenQuantity);
            itemcost[5] = chickenQuantity * price_chicken;

            double.TryParse(txt_liempo.Text, out double liempoQuantity);
            itemcost[6] = liempoQuantity * price_liempo;

            double.TryParse(txt_steak.Text, out double steakQuantity);
            itemcost[7] = steakQuantity * price_steak;

            double.TryParse(txt_sausage.Text, out double sausageQuantity);
            itemcost[8] = sausageQuantity * price_sausage;

            double total, payment, cost;
            if (cmb_payment.Text == "Cash")
            {
                total = itemcost[0] + itemcost[2] + itemcost[3] + itemcost[4] + itemcost[5] + itemcost[6] + itemcost[7] + itemcost[8];

                lbl_result.Text = Convert.ToString(total);

                payment = Convert.ToInt32(txt_payment.Text);
                cost = payment - total;
            }
            else
            {
                total = itemcost[0] + itemcost[2] + itemcost[3] + itemcost[4] + itemcost[5] + itemcost[6] + itemcost[7] + itemcost[8];

                lbl_result.Text = Convert.ToString(total);
            }
        }

        private void cmb_payment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_payment.Text == "Cash")
            {
                txt_payment.Enabled = true;
                txt_payment.Text = "";
                txt_payment.Focus();
            }
            else if (cmb_payment.Text == "GCash")
            {
                txt_payment.Enabled = true;
                txt_payment.Text = "";
                txt_payment.Focus();
            }
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for choosing our Restaurant, We hope you enjoy your meal!");
            Application.Exit();
        }

        private void txt_payment_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
