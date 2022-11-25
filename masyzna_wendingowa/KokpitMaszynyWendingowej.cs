using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt1_Małek51214_algorytmy_
{
    public partial class MaszynaWendingowa : Form
    {
        int KMIloscMonsterZielony;
        int KMIloscMonsterCzerwony;
        int KMIloscTigerDuzy;
        int KMIloscMonsterRozowy;
        int KMIloscTigerBlack;
        int KMIloscMonetONominale05;
        int KMIloscMonetONominale1;
        int KMIloscMonetONominale2;
        int KMIloscMonetONominale5;
        string[] KMKupioneArtykuly = new string[5];
        float KmDostepnaKwota;
        double KMKwotaPlatnosciKarta;
        float KMDzielnik;

        public MaszynaWendingowa()
        { InitializeComponent(); }

        private void KMcmbboxWybierzWalute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KMcmbboxWybierzWalute.SelectedIndex != -1)
            {
                if (KMcmbboxWybierzWalute.SelectedIndex == 0)
                {
                    KMDzielnik = 1;
                }
                else if (KMcmbboxWybierzWalute.SelectedIndex == 1)
                {
                    KMDzielnik = 3.5F;
                }
                else if (KMcmbboxWybierzWalute.SelectedIndex == 2)
                    KMDzielnik = 4.5F;

                KMbtnMonsterZielony.Text += "\n(" + Math.Round((6 / KMDzielnik), 2) + " " + KMcmbboxWybierzWalute.SelectedItem.ToString() + ")";
                KMbtnMonsterCzerwony.Text += "\n(" + Math.Round((6.5F / KMDzielnik), 2) + " " + KMcmbboxWybierzWalute.SelectedItem.ToString() + ")";
                KMbtnTigerDuzy.Text += "\n(" + Math.Round((4 / KMDzielnik), 2) + " " + KMcmbboxWybierzWalute.SelectedItem.ToString() + ")";
                KMbtnMonsterRozowy.Text += "\n(" + Math.Round((7 / KMDzielnik), 2) + " " + KMcmbboxWybierzWalute.SelectedItem.ToString() + ")";
                KMbtnTigerBlack.Text += "\n(" + Math.Round((2 / KMDzielnik), 2) + " " + KMcmbboxWybierzWalute.SelectedItem.ToString() + ")";

                KMcmbWybierzRodzajPlatnosci.Enabled = true;
                KMcmbboxWybierzWalute.Enabled = false;
                KMbtnAnuluj.Enabled = true;
            }
        }

        private void KMcmbWybierzRodzajPlatnosci_SelectedIndexChanged(object sender, EventArgs e)
        {
            Random KMLosowaKwota = new Random();
            if (KMcmbWybierzRodzajPlatnosci.SelectedIndex == 0)
            {
                KMIloscMonetONominale05 = KMLosowaKwota.Next(2, 10);
                KMIloscMonetONominale1 = KMLosowaKwota.Next(2, 10);
                KMIloscMonetONominale2 = KMLosowaKwota.Next(2, 10);
                KMIloscMonetONominale5 = KMLosowaKwota.Next(2, 10);
                KmDostepnaKwota = (float)(KMIloscMonetONominale05 * 0.5 + KMIloscMonetONominale1 + KMIloscMonetONominale2 * 2 + KMIloscMonetONominale5 * 5);
                KMlblDostepnaKwota.Text = "Kwota dostępna dla płatności gotówką to: " + KmDostepnaKwota + " " + KMcmbboxWybierzWalute.SelectedItem.ToString() + ", w tym:";
                KMlblIloscMonetONominale05.Text = KMIloscMonetONominale05 + " monet o wartości 0.5 " + KMcmbboxWybierzWalute.SelectedItem.ToString();
                KMlblIloscMonetONominale1.Text = KMIloscMonetONominale1 + " monet o wartości 1 " + KMcmbboxWybierzWalute.SelectedItem.ToString();
                KMlblIloscMonetONominale2.Text = KMIloscMonetONominale2 + " monet o wartości 2 " + KMcmbboxWybierzWalute.SelectedItem.ToString();
                KMlblIloscMonetONominale5.Text = KMIloscMonetONominale5 + " monet o wartości 5 " + KMcmbboxWybierzWalute.SelectedItem.ToString();
                KMbtnWrzuc050.Enabled = true;
                KMbtnWrzuc1.Enabled = true;
                KMbtnWrzuc2.Enabled = true;
                KMbtnWrzuc5.Enabled = true;
                KMbtnZaplacMonetami.Enabled = true;
            }
            else if (KMcmbWybierzRodzajPlatnosci.SelectedIndex == 1)
            {
                KMKwotaPlatnosciKarta = KMLosowaKwota.Next(50, 100);
                KMlblDostepnaKwota.Text = "Kwota dostępna dla płatności kartą: " + Math.Round(KMKwotaPlatnosciKarta, 2) + " " + KMcmbboxWybierzWalute.SelectedItem.ToString();
                KMbtnKarta.Enabled = true;
                KMbtnWrzuc050.Enabled = false;
                KMbtnWrzuc1.Enabled = false;
                KMbtnWrzuc2.Enabled = false;
                KMbtnWrzuc5.Enabled = false;
                KMbtnZaplacMonetami.Enabled = false;
            }

            KMcmbWybierzRodzajPlatnosci.Enabled = false;
            KMbtnMonsterZielony.Enabled = true;
            KMbtnMonsterCzerwony.Enabled = true;
            KMbtnTigerDuzy.Enabled = true;
            KMbtnMonsterRozowy.Enabled = true;
            KMbtnTigerBlack.Enabled = true;

        }
        private void KMObliczanieIlosciWrzuconychMonet(int KMIloscMonetODanymNominale, float KMNominal, Label KMlblIloscMonetODanymNominale, Button KMButtonDoWylaczenia)
        {
            errorProvider1.Dispose();
            float.TryParse(KMtxtboxWrzuconaIloscPieniedzy.Text, out float KMWrzuconaIloscPieniedzy);
            float.TryParse(KMtxtboxKwotaDoZaplaty.Text, out float KMDoZaplaty);
            if (KMtxtboxKwotaDoZaplaty.Text == "")
            {
                errorProvider1.SetError(KMtxtboxWrzuconaIloscPieniedzy, "Wybierz artykul");
                return;
            }
            if (KMDoZaplaty <= KMWrzuconaIloscPieniedzy)
            {
                errorProvider1.SetError(KMtxtboxWrzuconaIloscPieniedzy, "Wrzuciles wystarczajaca ilosc monet");
                return;
            }

            if (KMNominal == 0.5)
                KMIloscMonetONominale05--;
            else if (KMNominal == 1)
                KMIloscMonetONominale1--;
            else if (KMNominal == 2)
                KMIloscMonetONominale2--;
            else if (KMNominal == 5)
                KMIloscMonetONominale5--;
            KMIloscMonetODanymNominale--;

            KMtxtboxWrzuconaIloscPieniedzy.Text = (KMWrzuconaIloscPieniedzy + KMNominal).ToString();
            KmDostepnaKwota = (float)(KMIloscMonetONominale05 * 0.5 + KMIloscMonetONominale1 + KMIloscMonetONominale2 * 2 + KMIloscMonetONominale5 * 5);
            KMlblDostepnaKwota.Text = "Kwota dostępna dla płatności gotówką to: " + KmDostepnaKwota + " " + KMcmbboxWybierzWalute.SelectedItem.ToString() + ", w tym:";
            KMlblIloscMonetODanymNominale.Text = KMIloscMonetODanymNominale.ToString() + " monet o wartości " + KMNominal + " " + KMcmbboxWybierzWalute.SelectedItem.ToString();
            if (KMIloscMonetODanymNominale == 0)
            {
                KMButtonDoWylaczenia.Enabled = false;
                return;
            }
        }
        private void KMDodanieArtykulu(float KMCenaArtykulu, int KMIloscDanegoArtykulu, int KMIndexWTablicy)
        {
            float.TryParse(KMtxtboxKwotaDoZaplaty.Text, out float KMDoZaplaty);
            KMtxtboxKwotaDoZaplaty.Text = (Math.Round(KMDoZaplaty + (KMCenaArtykulu / KMDzielnik), 2)).ToString();
            if (KMIndexWTablicy == 0)
            {
                KMIloscMonsterZielony++;
                KMKupioneArtykuly[KMIndexWTablicy] = "Monster Zielony (" + (KMIloscDanegoArtykulu + 1) + ")";
            }
            else if (KMIndexWTablicy == 1)
            {
                KMIloscMonsterCzerwony++;
                KMKupioneArtykuly[KMIndexWTablicy] = "Monster Czerwony (" + (KMIloscDanegoArtykulu + 1) + ")";
            }
            else if (KMIndexWTablicy == 2)
            {
                KMIloscTigerDuzy++;
                KMKupioneArtykuly[KMIndexWTablicy] = "Tiger Duzy (" + (KMIloscDanegoArtykulu + 1) + ")";
            }
            else if (KMIndexWTablicy == 3)
            {
                KMIloscMonsterRozowy++;
                KMKupioneArtykuly[KMIndexWTablicy] = "Monster Rozowy (" + (KMIloscDanegoArtykulu + 1) + ")";
            }
            else if (KMIndexWTablicy == 4)
            {
                KMIloscTigerBlack++;
                KMKupioneArtykuly[KMIndexWTablicy] = "TIger Black (" + (KMIloscDanegoArtykulu + 1) + ")";
            }
        }
        private void KMKoszyk()
        {
            string KMZawartoscKoszyka = "";
            float.TryParse(KMtxtboxWrzuconaIloscPieniedzy.Text, out float KMWrzuconeMonety);
            float.TryParse(KMtxtboxKwotaDoZaplaty.Text, out float KMDoZaplaty);
            if (KMcmbWybierzRodzajPlatnosci.SelectedIndex == 0)
            {
                double KMReszta;
                for (int i = 0; i <= 3; i++)
                {
                    if (KMKupioneArtykuly[i] != null)
                        KMZawartoscKoszyka = KMZawartoscKoszyka + KMKupioneArtykuly[i] + "\n";
                }
                if (KMWrzuconeMonety < KMDoZaplaty)
                {
                    errorProvider1.SetError(KMtxtboxWrzuconaIloscPieniedzy, "Za mala ilosc wrzuconych monet");
                    return;
                }
                if (KMWrzuconeMonety > KMDoZaplaty)
                {
                    KMReszta = Math.Round(KMWrzuconeMonety - KMDoZaplaty, 2);
                    KMZawartoscKoszyka = KMZawartoscKoszyka + "\nTwoja reszta: " + KMReszta + " " + KMcmbboxWybierzWalute.SelectedItem.ToString();
                }
                if (KMZawartoscKoszyka != "")
                    KMZawartoscKoszyka = KMZawartoscKoszyka + "\nDziekuje, Milego dnia!";
            }
            else if (KMcmbWybierzRodzajPlatnosci.SelectedIndex == 1)
            {

                if (KMDoZaplaty > KMKwotaPlatnosciKarta)
                {
                    errorProvider1.SetError(KMbtnKarta, "Za malo pieniedzy na karcie");
                    return;
                }
                for (int i = 0; i <= 3; i++)
                {
                    if (KMKupioneArtykuly[i] != null)
                        KMZawartoscKoszyka = KMZawartoscKoszyka + KMKupioneArtykuly[i] + "\n";
                }
                if (KMZawartoscKoszyka != "")
                    KMZawartoscKoszyka = KMZawartoscKoszyka + "\nDziekuje, Milego dnia!";
            }
            if (KMZawartoscKoszyka == "")
            {
                MessageBox.Show("Nie wybrano artykulu, pieniadze nie zostały pobrane.", "Twoje artykuly", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show(KMZawartoscKoszyka, "Twoje artykuly", MessageBoxButtons.OK, MessageBoxIcon.Information);
            KMReset();
        }
        private void KMReset()
        {
            Array.Clear(KMKupioneArtykuly, 0, KMKupioneArtykuly.Length);
            errorProvider1.Dispose();
            KMcmbWybierzRodzajPlatnosci.SelectedIndex = -1;
            KMcmbboxWybierzWalute.SelectedIndex = -1;
            KMIloscMonsterZielony = 0;
            KMIloscMonsterCzerwony = 0;
            KMIloscTigerDuzy = 0;
            KMIloscMonsterRozowy = 0;
            KMIloscTigerBlack = 0;
            KMlblIloscMonetONominale05.Text = "";
            KMlblIloscMonetONominale1.Text = "";
            KMlblIloscMonetONominale2.Text = "";
            KMlblIloscMonetONominale5.Text = "";
            KMtxtboxWrzuconaIloscPieniedzy.Text = "";
            KMtxtboxKwotaDoZaplaty.Text = "";
            KMbtnMonsterZielony.Text = "";
            KMbtnMonsterCzerwony.Text = "";
            KMbtnTigerDuzy.Text = "";
            KMbtnMonsterRozowy.Text = "";
            KMcmbWybierzRodzajPlatnosci.Enabled = false;
            KMbtnZaplacMonetami.Enabled = false;
            KMbtnKarta.Enabled = false;
            KMcmbboxWybierzWalute.Enabled = true;
            KMbtnWrzuc050.Enabled = false;
            KMbtnWrzuc1.Enabled = false;
            KMbtnWrzuc2.Enabled = false;
            KMbtnWrzuc5.Enabled = false;
            KMbtnMonsterZielony.Enabled = false;
            KMbtnMonsterCzerwony.Enabled = false;
            KMbtnTigerDuzy.Enabled = false;
            KMbtnMonsterRozowy.Enabled = false;
            KMbtnTigerBlack.Enabled = false;
            KMbtnAnuluj.Enabled = false;
            KMlblDostepnaKwota.Visible = false;
        }

        private void KMbtnwrzuc050_Click(object sender, EventArgs e)
        {
            KMObliczanieIlosciWrzuconychMonet(KMIloscMonetONominale05, 0.5F, KMlblIloscMonetONominale05, KMbtnWrzuc050);
        }

        private void KMbtnWrzuc1_Click(object sender, EventArgs e)
        {
            KMObliczanieIlosciWrzuconychMonet(KMIloscMonetONominale1, 1, KMlblIloscMonetONominale1, KMbtnWrzuc1);
        }

        private void KMbtnWrzuc2_Click(object sender, EventArgs e)
        {
            KMObliczanieIlosciWrzuconychMonet(KMIloscMonetONominale2, 2, KMlblIloscMonetONominale2, KMbtnWrzuc2);
        }

        private void KMbtnWrzuc5_Click(object sender, EventArgs e)
        {
            KMObliczanieIlosciWrzuconychMonet(KMIloscMonetONominale5, 5, KMlblIloscMonetONominale5, KMbtnWrzuc5);
        }

        private void KMbtnMonsterZielony_Click(object sender, EventArgs e)
        {
            KMDodanieArtykulu(6, KMIloscMonsterZielony, 0);
        }

        private void KMbtnMonsterCzerwony_Click(object sender, EventArgs e)
        {
            KMDodanieArtykulu(6.5F, KMIloscMonsterCzerwony, 1);
        }

        private void KMbtnTigerDuzy_Click(object sender, EventArgs e)
        {
            KMDodanieArtykulu(4, KMIloscTigerDuzy, 2);
        }

        private void KMbtnMonsterRozowy_Click(object sender, EventArgs e)
        {
            KMDodanieArtykulu(7F, KMIloscMonsterRozowy, 3);
        }

        private void KMbtnBlack_Click(object sender, EventArgs e)
        {
            KMDodanieArtykulu(2, KMIloscTigerBlack, 4);
        }


        private void KMbtnKarta_Click(object sender, EventArgs e)
        {
            KMKoszyk();
        }

        private void KMbtnZaplacMonetami_Click(object sender, EventArgs e)
        {
            KMKoszyk();

        }

        private void KMbtnAnuluj_Click(object sender, EventArgs e)
        {
            KMReset();
        }
    }
}