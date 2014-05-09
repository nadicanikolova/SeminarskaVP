using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZbirIgri
{
    public partial class Form1 : Form
    {
        string Ime;
        List<Igrach> igrachiZmija, igrachiMilioner, igrachiPovtoruvanje, igrachiRPS;
        public Form1()
        {
            InitializeComponent();
            Ime = "Player";
            igrachiZmija = new List<Igrach>();
            igrachiMilioner = new List<Igrach>();
            igrachiPovtoruvanje = new List<Igrach>();
            igrachiRPS = new List<Igrach>();
        }

        private void simon_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("\tПовторување е игра во која компјутерот ви покажува која боја треба да ја кликнете. Ако ја кликнете точната боја во секоја следна итерација се додава уште една боја на низата од бои. Секој круг има повеќе и повеќе бои за повторување. Ако згрешите една боја во низата, играта е завршена.\n\nДали сакате да ја играте играта?", "Повторување", MessageBoxButtons.YesNo);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                SimonForm simon = new SimonForm(Ime);
                simon.ShowDialog();
                if (simon.player != null)
                {
                    igrachiPovtoruvanje.Add(simon.player);
                }
            }
        }


        private void milioner_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("\tФИНКИ Милионер е верзија на познатиот квиз Кој сака да биде милионер, но направена за студентите на Финки.Можеби токму ти си следниот ФИНКИ Милионер.\n\nДали сакате да ја играте играта?", "Милионер", MessageBoxButtons.YesNo);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                MilionerForm mil = new MilionerForm(Ime);
                mil.ShowDialog();
                if (mil.igrac != null)
                {
                    igrachiMilioner.Add(mil.igrac);
                }
            
            }
        }

        private void snake_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("\tЗмија е игра која се управува со стрелките од тастатурата. Низ ограничен дел од екранот се движи една змија која јаде крофни. Со секоја изедена крофна змијата расте во должина. Ако змијата се гризне самата себе или удри во ѕидот, играта завршува.\n\nДали сакате да ја играте играта?", "Змија", MessageBoxButtons.YesNo);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                ZmijaForm zmija = new ZmijaForm(Ime);
                zmija.ShowDialog();
                if (zmija.player != null)
                {
                    igrachiZmija.Add(zmija.player);
                }
                
            }
        }

        private void rps_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("\tКамен, лист, ножици е игра што секој треба да ја знае. Играчи сте вие и компјутерот. Вие и компјутерот одбирате меѓу камен, ножици и лист. Правилата се следниве: Каменот ги крши ножиците, ножиците го сечат листот, а хартијата го покрива каменот.\n\nДали сакате да ја играте играта?", "Повторување", MessageBoxButtons.YesNo);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {
                RPSForm rps = new RPSForm(Ime);
                rps.ShowDialog();
                if (rps.player != null)
                {
                    igrachiRPS.Add(rps.player);
                }
            
            }
        }


        private void txtIme_TextChanged(object sender, EventArgs e)
        {
            if (txtIme.Text.Trim().Length == 0)
            {
                txtIme.Text = "Player";
            }
            else if (txtIme.Text.Trim().Length>=1 && txtIme.Text!="Player")
            {
                txtIme.Text=txtIme.Text.Replace("Player", "");
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ime = txtIme.Text;
        }

        private void btnIgrachi_Click(object sender, EventArgs e)
        {
            igrachiZmija = igrachiZmija.OrderByDescending(x => x.Poeni).ToList();
            igrachiPovtoruvanje = igrachiPovtoruvanje.OrderByDescending(x => x.Poeni).ToList();
            igrachiMilioner = igrachiMilioner.OrderByDescending(x => x.Poeni).ToList();
            igrachiRPS = igrachiRPS.OrderByDescending(x => x.Poeni).ToList();
            IgraciLista listIgraci = new IgraciLista(igrachiPovtoruvanje,igrachiMilioner,igrachiZmija,igrachiRPS);
            listIgraci.ShowDialog();
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Дали сакате да го затворите прозорецот?","Затвори",MessageBoxButtons.YesNo);
            if (r == System.Windows.Forms.DialogResult.Yes)
            {
               
                Close();
            }
        }
    }
}
