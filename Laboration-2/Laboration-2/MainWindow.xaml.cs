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
        GameContext context;


        public MainWindow()
        {
            InitializeComponent();
            context = new GameContext();
            WriteNamesToListBox();
        }


        private void WriteNamesToListBox()
        {
            // Hittar alla spelares namn och skriver ut i en
            // listbox som används i debug syfte för att se vilka namn
            // som finns i databasen
            var playerQuearyData = from x in context.Levels
                                   select x.Players.Select(y => y.Name).ToList();
            
        }

        private void TextBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string name = TextBoxName.Text;

                // Om empty vissa messagebox
                if (name.Length != 0)
                {


                    // Hittar alla levels som spelaren har kört på 
                    var playerQuearyData = (from x in context.Levels
                                            where x.Players.All(y => y.Name == name)
                                            select x).ToList();
                    
                    // Om spelare finns skriv all info till listbox
                    if(playerQuearyData.Count > 0)
                    {
                        guiGenerator.GenerateListData(ref ListBoxStatsInfo,playerQuearyData);
                    }
                    else
                    {
                        // Om ej finns skapa ny spelare
                        // Med det namnet
                        AddNewPlayer(name);
                    }


                }
                else
                {
                    MessageBox.Show("Du angav inget namn!");
                }


            }

            
        }




        private void AddNewPlayer(string name)
        {
            Level l = new Level();
            l.Name = "Level 01";
            l.AmountOfMoves = 4;
            l.Players = new List<Player>();

            Player p = new Player();
            p.Name = name;
            p.Scores = new List<Score>();

            Score s = new Score();



            s.Levels = l;
            s.AmountOfMovesUsed = 0;

            l.Players.Add(p);
            p.Scores.Add(s);

            context.Levels.Add(l);
            context.SaveChanges();
        }

        private void AddItems()
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

