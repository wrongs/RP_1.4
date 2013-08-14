using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RP_1._4.GUI
{
    public partial class GameSetings : Form
    {
        private GraphicsUI GUI;
        private bool IsNew;

        public GameSetings(GraphicsUI gui, bool isNew)
        {
            IsNew = isNew;
            GUI = gui;
            InitializeComponent();
            if (IsNew) InitializeNewGameDialog();
            else InitializeRemusingGameDialog();
        }

        private void InitializeNewGameDialog()
        {
            WhiteNameBox.Text = "Computer1";
            BlackNameBox.Text = "Computer2";
            WhiteTypeCBox.SelectedIndex = 0;
            BlackTypeCBox.SelectedIndex = 0;
            WhiteDifficultyCBox.SelectedIndex = 0;
            BlackDifficultyCBox.SelectedIndex = 0;
        }


        private void InitializeRemusingGameDialog()
        {
            WhiteNameBox.Text = GUI.Manager.P1.Name;
            BlackNameBox.Text = GUI.Manager.P2.Name;
            WhiteTypeCBox.SelectedIndex = GUI.Manager.P1.Type;
            BlackTypeCBox.SelectedIndex = GUI.Manager.P2.Type;
            WhiteDifficultyCBox.SelectedIndex = GUI.Manager.P1.Difficulty/2;
            BlackDifficultyCBox.SelectedIndex = GUI.Manager.P2.Difficulty/2;
        }

        private void WhiteTypeCBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (WhiteTypeCBox.SelectedIndex == 1)
            {
                WhiteDifficultyCBox.Enabled = false;
                WhiteShowCbox.Enabled = false;
            }
            else
            {
                WhiteDifficultyCBox.Enabled = true;
                WhiteShowCbox.Enabled = true;
            }
        }

        private void BlackTypeCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BlackTypeCBox.SelectedIndex == 1)
            {
                BlackDifficultyCBox.Enabled = false;
                BlackShowCBox.Enabled = false;                
            }
            else
            {
                BlackDifficultyCBox.Enabled = true;
                BlackShowCBox.Enabled = true;
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (IsNew) GUI.Manager.NewGame(WhiteNameBox.Text, BlackNameBox.Text, WhiteTypeCBox.SelectedIndex, BlackTypeCBox.SelectedIndex,
                                  WhiteDifficultyCBox.SelectedIndex, BlackDifficultyCBox.SelectedIndex);
            else GUI.Manager.ChangeSetings(WhiteNameBox.Text, BlackNameBox.Text, WhiteTypeCBox.SelectedIndex, BlackTypeCBox.SelectedIndex,
                                WhiteDifficultyCBox.SelectedIndex, BlackDifficultyCBox.SelectedIndex);
            Close();
        }

        private void StornoButton_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
