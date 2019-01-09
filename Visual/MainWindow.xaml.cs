using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsoleApp1;
using Image = System.Windows.Controls.Image;

namespace Visual
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Game game = new Game(10);
            game.InitWorld();
            game.InitStartPoint();
            Bitmap image = new Bitmap(game.Size,game.Size);
            imageP.Source = image;
            
            InitializeComponent();
        }
    }
}
