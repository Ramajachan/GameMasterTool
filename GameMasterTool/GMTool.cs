using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameMasterTool
{
    public partial class GMTool : Form
    {
        int buttonOffset;
        bool diceReset = false;
        string modChar;
        public GMTool()
        {
            InitializeComponent();
            buttonOffset = 6;
            //FormBorderStyle = FormBorderStyle.Fixed3D; // Sizable None Fixed3D //
            //WindowState = FormWindowState.Maximized; //Maximized Minimized Normal //

            //**Ikona programu**//
            this.Icon = new Icon("Resources/images/favicon.ico");

            diceRollsResults.ReadOnly = true;
            diceRollsResults.ScrollBars = ScrollBars.Vertical;
        }

        private void GMTool_Resize(object sender, EventArgs e)
        {
            // **Rozszerzanie sie przyciskow**//
            mainButtonSession.Height = getNewButtonHeight();
            // Pozycje przyciskow //
            mainButtonDiceRolls.Height = getNewButtonHeight();
            mainButtonDiceRolls.Location = new Point(mainButtonDiceRolls.Location.X, mainButtonSession.Height + buttonOffset + 51);

            mainButtonMaps.Height = getNewButtonHeight();
            mainButtonMaps.Location = new Point(mainButtonMaps.Location.X, (2 * (mainButtonSession.Height + buttonOffset)) + 51);

            mainButtonMindMap.Height = getNewButtonHeight();
            mainButtonMindMap.Location = new Point(mainButtonMindMap.Location.X, (3 * (mainButtonSession.Height + buttonOffset)) + 51);

            mainButtonAudio.Height = getNewButtonHeight();
            mainButtonAudio.Location = new Point(mainButtonAudio.Location.X, (4 * (mainButtonSession.Height + buttonOffset)) + 51);

            mainButtonSettings.Height = getNewButtonHeight();
            mainButtonSettings.Location = new Point(mainButtonSettings.Location.X, (5 * (mainButtonSession.Height + buttonOffset)) + 51);

            mainButtonExit.Height = getNewButtonHeight();
            mainButtonExit.Location = new Point(mainButtonExit.Location.X, (6 * (mainButtonSession.Height + buttonOffset)) + 51);
        }

        private void mainButtonSession_Click(object sender, EventArgs e)
        {
            diceRollsPanel.Visible = false;
            exitPanel.Visible = false;
        }
        private void mainButtonDiceRolls_Click(object sender, EventArgs e)
        {
            diceRollsPanel.Visible = true;
            exitPanel.Visible = false;
        }
        private void mainButtonExit_Click(object sender, EventArgs e)
        {
            diceRollsPanel.Visible = false;
            exitPanel.Visible = true;


        }

        //** Losowanie rzutow **//
        private void dicesRollButton_Click(object sender, EventArgs e)
        {
            if ((!diceReset) && ((k4qty.Value != 0) || (k6qty.Value != 0) || (k8qty.Value != 0) | (k10qty.Value != 0) || (k12qty.Value != 0) || (k20qty.Value != 0) || (k100qty.Value != 0)))
            {
                diceRollsResults.Text += "Your rolls:" + Environment.NewLine;
            }

            diceReset = false;

            //** k4 dice **//
            if(k4qty.Value != 0)
            {
                generateNumbers(Decimal.ToInt32(k4qty.Value), 4, k4modDown.Checked, Decimal.ToInt32(k4modVal.Value));
            }
            //** k6 dice **//
            if (k6qty.Value != 0)
            {
                generateNumbers(Decimal.ToInt32(k6qty.Value), 6, k6modDown.Checked, Decimal.ToInt32(k6modVal.Value));
            }
            //** k8 dice **//
            if (k8qty.Value != 0)
            {
                generateNumbers(Decimal.ToInt32(k8qty.Value), 8, k8modDown.Checked, Decimal.ToInt32(k8modVal.Value));
            }
            //** k10 dice **//
            if (k10qty.Value != 0)
            {
                generateNumbers(Decimal.ToInt32(k10qty.Value), 10, k10modDown.Checked, Decimal.ToInt32(k10modVal.Value));
            }
            //** k12 dice **//
            if (k12qty.Value != 0)
            {
                generateNumbers(Decimal.ToInt32(k12qty.Value), 12, k12modDown.Checked, Decimal.ToInt32(k12modVal.Value));
            }
            //** k20 dice **//
            if (k20qty.Value != 0)
            {
                generateNumbers(Decimal.ToInt32(k20qty.Value), 20, k20modDown.Checked, Decimal.ToInt32(k20modVal.Value));
            }
            //** k100 dice **//
            if (k100qty.Value != 0)
            {
                generateNumbers(Decimal.ToInt32(k100qty.Value), 100, k100modDown.Checked, Decimal.ToInt32(k100modVal.Value));
            }

            if ((k4qty.Value != 0) || (k6qty.Value != 0) || (k8qty.Value != 0) || (k10qty.Value != 0) || (k12qty.Value != 0) || (k20qty.Value != 0) || (k100qty.Value != 0))
            {
                diceRollsResults.Text += "--------------------------------------------";
            }
        }

        //** Resetowanie rzutow **//
        private void dicesResetButton_Click(object sender, EventArgs e)
        {
            diceReset = true;
            foreach (Control control in dicesGrid.Controls)
            {
                if (control is NumericUpDown)
                {
                    (control as NumericUpDown).Value = 0;
                }

                if (control is CheckBox)
                {
                    (control as CheckBox).Checked = false;
                }

                if (control is TextBox)
                {
                    (control as TextBox).Text = "";
                }
            }
        }

        //** Losowanie kosci **//
        private void generateNumbers(int nr, int range, bool modifier, int modifierVal)
        {
            int sum = 0,
                randomNr;
            Random r = new Random();

            diceRollsResults.Text += Environment.NewLine + nr + "k" + range;
            if (modifierVal != 0)
            {
                modChar = modifier == true ? " - " : " + ";
                diceRollsResults.Text += modChar + modifierVal + Environment.NewLine;
            }
            else
            {
                diceRollsResults.Text += Environment.NewLine;
            }
            for (int i = 0; i < nr; i++)
            {
                
                randomNr = r.Next(1, range);
                diceRollsResults.Text += randomNr;
                sum += randomNr;
                if (i != nr - 1)
                {
                    diceRollsResults.Text += ", ";
                }
            }

            if (modifier != true)
            {
                sum += modifierVal;
            }
            else
                sum -= modifierVal;

            diceRollsResults.Text += Environment.NewLine + "Sum: " + sum + Environment.NewLine;
        }

        //** Zmiana wysokości przyciskow **//
        private int getNewButtonHeight()
        {
            return ((Height - 90) / 7) - buttonOffset;
        }

        //** Wyjscie z programu **//
        private void dontSaveExit_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void GMTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Display a MsgBox asking the user to save changes or abort.
            if (MessageBox.Show("Do you want to quit without saving?", "Quit", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

    }
}
