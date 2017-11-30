using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboration_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GameContext context = new GameContext();
            //AddItems(context);

            var query = from x in context.Players
                        select x.Name;

            foreach (var y in query)
                playerListbox.Items.Add(y);
        }

        private void AddItems(GameContext context)
        {
            Level l = new Level();
            l.Name = "Level 01";
            l.AmountOfMoves = 4;
            l.Players = new List<Player>();

            Player p = new Player();
            p.Name = "Linus";
            p.Scores = new List<Score>();

            Score s = new Score();
            s.Levels = l;
            s.AmountOfMovesUsed = 1;

            l.Players.Add(p);
            p.Scores.Add(s);

            context.Levels.Add(l);
            context.SaveChanges();
        }
    }
}
