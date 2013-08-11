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
    public partial class NewGame : Form
    {
        private GraphicsUI GUI;

        public NewGame(GraphicsUI gui)
        {
            GUI = gui;
            InitializeComponent();
            WhiteNameBox.Text = "Computer White";
            BlackNameBox.Text = "Computer Black";
            WhiteTypeCBox.SelectedIndex = 0;
            BlackTypeCBox.SelectedIndex = 0;
            WhiteDifficultyCBox.SelectedIndex = 0;
            BlackDifficultyCBox.SelectedIndex = 0;

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
            GUI.Manager.NewGame(WhiteNameBox.Text, BlackNameBox.Text, WhiteTypeCBox.SelectedIndex, BlackTypeCBox.SelectedIndex,
                                WhiteDifficultyCBox.SelectedIndex, BlackDifficultyCBox.SelectedIndex);
            Close();
        }

        private void StornoButton_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
