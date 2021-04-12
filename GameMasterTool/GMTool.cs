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
        public GMTool()
        {
            InitializeComponent();
            buttonOffset = 6;
            FormBorderStyle = FormBorderStyle.Fixed3D; // Sizable None Fixed3D //
            //WindowState = FormWindowState.Maximized; //Maximized Minimized Normal //

            //**Ikona programu**//
            this.Icon = new Icon("Resources/favicon.ico");
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
        // Zmiana wysokości przyciskow
        private int getNewButtonHeight()
        {
            return ((this.Height-90) / 7) - buttonOffset;
        }

        private void mainButtonSession_Click(object sender, EventArgs e)
        {
            DoceRollsPanel.Visible = false;
        }
        private void mainButtonDiceRolls_Click(object sender, EventArgs e)
        {
            DoceRollsPanel.Visible = true;
        }

        /*private void DontSaveExit_button(object sender, EventArgs e)
{
string message = "Do you want to quit without saving?";
string title = "Quit";
MessageBoxButtons buttons = MessageBoxButtons.YesNo;
DialogResult result = MessageBox.Show(message, title, buttons);
if (result == DialogResult.Yes)
{
this.Close();
}
}*/
    }
}
