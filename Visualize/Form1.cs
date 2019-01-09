using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp1;

namespace Visualize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();
            Game game = new Game(100);
            game.InitWorld();
           
            pictureBox1.Image = game.FillBitmap();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
