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
        private GuiGenerator guiGenerator = new GuiGenerator();
        private GameContext context;

        private string nameInput;
        private bool isEditing = false;

        public MainWindow()
        {
            InitializeComponent();
            context = new GameContext();
            WriteNamesToListBox();
        }

        /// <summary>
        /// Kod för debug syfte
        /// </summary>
        private void WriteNamesToListBox()
        {

            // Kod för debug syfte så man ser
            //vilka spelare som finns i databasen

            var playerQuearyData = (from x in context.Levels
                                    select x.Players.Select(y => y.Name)).ToList();



            foreach (var val in playerQuearyData)
            {
                foreach (var val2 in val)
                {
                    ListBoxPlayer.Items.Add(val2);
                }

            }



        }



        private void TextBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string name = TextBoxName.Text;




                // Om empty vissa messagebox
                if (!string.IsNullOrEmpty(name))
                {

                    
                    List<Level> levelsPlayerHavePlayed = GetInfoFromDB.GetListOfLevelsPlayerHasPlayed(context, name);




                    // Om spelare finns skriv all info till listbox
                    if (levelsPlayerHavePlayed.Count > 0)
                    {
                        guiGenerator.GenerateListData(ref ListBoxStatsInfo, levelsPlayerHavePlayed,name);
                    }
                    else
                    {
                        // Om ej finns skapa ny spelare
                        // Med det namnet
                        AddNewPlayer(name);

                        List<Level> getInfoAboutNewPlayer = GetInfoFromDB.GetListOfLevelsPlayerHasPlayed(context, name);

                        guiGenerator.GenerateListData(ref ListBoxStatsInfo, getInfoAboutNewPlayer,name);

                    }

                    TextBoxName.Text = "";

                }
                else
                {
                    //
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

            ListBoxPlayer.Items.Add(p.Name);



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

        private void ListBoxPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ListBoxPlayer.SelectedItem;

            List<Level> temp = GetInfoFromDB.GetListOfLevelsPlayerHasPlayed(context, item.ToString());

            guiGenerator.GenerateListData(ref ListBoxStatsInfo, temp, item.ToString());


        }

        private void TextBoxLevelName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string levelName = TextBoxLevelName.Text;

                if (!string.IsNullOrEmpty(TextBoxLevelName.Text))
                {
                    var playerQuearyData = from p in context.Players
                                           where nameInput == p.Name
                                           select p.Name;

                    Level level = new Level() { Name = levelName, AmountOfMoves = 6, Players = new List<Player>() };

                    Player player = new Player() { Name = nameInput, Scores = new List<Score>() };

                    Score score = new Score() { Levels = level, AmountOfMovesUsed = 0 };

                    level.Players.Add(player);
                    player.Scores.Add(score);
                    context.Levels.Add(level);
                    context.SaveChanges();
                }
            }
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(!isEditing)
            {
                TextBoxLevelId.IsEnabled = true;
                TextBoxMoves.IsEnabled = true;
                ButtonUpdate.Content = "DONE";
                isEditing = true;
            }
            else if(isEditing)
            {
                TextBoxLevelId.IsEnabled = false;
                TextBoxMoves.IsEnabled = false;
                ButtonUpdate.Content = "UPDATE";
                isEditing = false;

                var query = from score in context.Scores
                            where score.Levels.Players.All(y => y.Name == nameInput && y.Scores.All(x => x.ScoreId == y.PlayerId))
                            select score;

                foreach (var x in query)
                    x.AmountOfMovesUsed = int.Parse(TextBoxMoves.Text);

                TextBoxLevelId.Clear();
                TextBoxMoves.Clear();

                context.SaveChanges();
            }
        }
    }
}

