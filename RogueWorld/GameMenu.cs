﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RogueWorld
{
    public partial class GameMenu : Form
    {

        public GameMenu()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            GameScreen gameScreen = new GameScreen();

            gameScreen.Show();

        }

        private void btnStep_Click(object sender, EventArgs e)
        {

        }

    }
}
