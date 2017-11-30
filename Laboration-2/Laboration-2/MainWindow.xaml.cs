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
        GuiGenerator guiGenerator = new GuiGenerator();

        public MainWindow()
        {
            InitializeComponent();
            
            
                        GameContext context = new GameContext();
            //AddItems(context);

            var query = from x in context.Players
                        select x.Name;

            foreach (var y in query)
                playerListbox.Items.Add(y);
            
            LoadPlayerListBox();
        }

        private void LoadPlayerListBox()
        {

        }

        private void ListBoxPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            guiGenerator.GenerateListBoxScore(ListBoxPlayer.SelectedIndex, allData, ref ListBoxScore);
        }



        private void TextBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                if (TextBoxName.Text.Length != 0)
                {


                    int nameIndex = allData.gameData.FindIndex(x => x.Name.ToLower() == TextBoxName.Text.ToLower());

                    if (nameIndex != -1)
                    {

                        guiGenerator.GenerateListBoxScore(nameIndex, allData, ref ListBoxScore);
                    }
                    else
                    {
                        allData.gameData.Add(new Player(TextBoxName.Text));
                        ListBoxPlayer.Items.Add(TextBoxName.Text);
                        ListBoxScore.Items.Clear();
                    }

                }
                else
                {
                    MessageBox.Show("Du angav inget namn!");
                }


            }

            
        }

        private void ListBoxScore_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


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

