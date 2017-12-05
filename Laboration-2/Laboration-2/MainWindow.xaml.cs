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
        private GuiHandeler guiHandeler = new GuiHandeler();
        private DataHandeler dataHandeler = new DataHandeler();

        private bool isAddingLevel = false;
        private bool isEditingScore = false;

        public MainWindow()
        {

            //dataHandeler.ClearDataBas();

            InitializeComponent();

            WriteNamesAndLevelsToListBoxesForDebugPurpes();


        }


        private void WriteNamesAndLevelsToListBoxesForDebugPurpes()
        {
            ListBoxPlayersDebugPurpose.Items.Clear();
            ListBoxLevelsDebugPurpose.Items.Clear();

            guiHandeler.WriteOutPlayersToListbox(dataHandeler.GetPlayers(), ref ListBoxPlayersDebugPurpose);
            guiHandeler.WriteOutLevelsToListbox(dataHandeler.GetLevels(), ref ListBoxLevelsDebugPurpose);
        }



        /*
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

            ListBoxPlayersDebugPurpose.Items.Add(p.Name);



            s.Levels = l;
            s.AmountOfMovesUsed = 0;

            l.Players.Add(p);
            p.Scores.Add(s);

            context.Levels.Add(l);
            context.SaveChanges();
        }
        */



        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!isEditingScore)
            {
                TextBoxLevelId.IsEnabled = true;
                TextBoxMoves.IsEnabled = true;
                TextBoxName.IsEnabled = true;


                ButtonAddLevel.IsEnabled = false;
                ButtonFindOrAddPlayer.IsEnabled = false;

                ButtonUpdate.Content = "DONE";
                isEditingScore = true;
            }
            else if (isEditingScore)
            {





                string nameInput = TextBoxName.Text;
                int levelIdInput;
                int scoreInput;

                if (int.TryParse(TextBoxMoves.Text, out scoreInput))
                {
                    if (int.TryParse(TextBoxLevelId.Text, out levelIdInput))
                    {

                        Level getLevel = dataHandeler.GetLevelById(levelIdInput);

                        if (getLevel != null)
                        {

                            Player getPlayer = dataHandeler.GetPlayerByName(nameInput);

                            if (getPlayer != null)
                            {
                                Score getScore = dataHandeler.GetScore(getPlayer, getLevel);

                                if (getScore != null)
                                {
                                    // Spelare har spelat bannan
                                    dataHandeler.SetPlayerScore(getPlayer, getLevel, getScore, scoreInput);
                                }
                                else
                                {
                                    // Spelaren har inte spelat bannan
                                    dataHandeler.AddNewMapToPlayerAndScore(getPlayer, getLevel, scoreInput);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Player finns ej");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Leveln finns ej skriv in annat id");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Du skrev inte in ett level id");
                    }
                }
                else
                {
                    MessageBox.Show("Du skrev inte in ett score");
                }



                ButtonFindOrAddPlayer.IsEnabled = true;
                ButtonAddLevel.IsEnabled = true;

                TextBoxLevelId.IsEnabled = false;
                TextBoxLevelId.Clear();

                TextBoxMoves.IsEnabled = false;
                TextBoxMoves.Clear();

                ButtonUpdate.Content = "UPDATE";
                isEditingScore = false;

            }


        }

        private void ButtonAddLevel_Click(object sender, RoutedEventArgs e)
        {
            if (!isAddingLevel)
            {

                TextBoxName.IsEnabled = false;

                TextBoxLevelName.IsEnabled = true;
                TextBoxMaxMovesForNewMap.IsEnabled = true;


                ButtonUpdate.IsEnabled = false;
                ButtonFindOrAddPlayer.IsEnabled = false;

                ButtonAddLevel.Content = "Done";

                isAddingLevel = true;
            }
            else
            {
                isAddingLevel = false;
                string levelName = TextBoxLevelName.Text;
                int maxMoves;

                // string.IsNullOrEmpty(TextBoxMaxMovesForNewMap.Text) && 
                if (int.TryParse(TextBoxMaxMovesForNewMap.Text, out maxMoves))
                {


                    if (!string.IsNullOrEmpty(levelName))
                    {
                        dataHandeler.AddNewMap(levelName, maxMoves);

                        // För debug
                        WriteNamesAndLevelsToListBoxesForDebugPurpes();
                    }
                    else
                    {
                        MessageBox.Show("Du angav inget level name");
                    }


                }
                else
                {
                    MessageBox.Show("Du skrev inte in max moves för den ny leveln");
                }


                ButtonAddLevel.Content = "Add level";
                TextBoxMoves.IsEnabled = false;

                TextBoxLevelName.IsEnabled = false;
                TextBoxLevelName.Clear();


                TextBoxMaxMovesForNewMap.IsEnabled = false;
                TextBoxMaxMovesForNewMap.Clear();

                ButtonUpdate.IsEnabled = true;
                ButtonFindOrAddPlayer.IsEnabled = true;

                TextBoxName.IsEnabled = true;

            }
        }

        private void ButtonFindOrAddPlayer_Click(object sender, RoutedEventArgs e)
        {

            string name = TextBoxName.Text;

            // Om empty vissa messagebox
            if (!string.IsNullOrEmpty(name))
            {


                Player getPlayer = dataHandeler.GetPlayerByName(name);


                // Om spelare finns skriv all info till listbox
                if (getPlayer != null)
                {
                    guiHandeler.GenerateListData(ref ListBoxStatsInfo, getPlayer);
                }
                else
                {
                    // Om ej finns skapa ny spelare
                    dataHandeler.AddNewPlayer(name);

                    // For Debug
                    WriteNamesAndLevelsToListBoxesForDebugPurpes();

                    MessageBox.Show("La till spelare " + name);

                }

                TextBoxName.Clear();

            }
            else
            {
                MessageBox.Show("Du angav inget namn!");
            }



        }

        private void ListBoxShowPlayersDebugPurpose_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxPlayersDebugPurpose.SelectedItem == null)
            {
                return;
            }
            var item = ListBoxPlayersDebugPurpose.SelectedItem;

            Player temp = dataHandeler.GetPlayerByName(item.ToString());

            if (temp != null)
                guiHandeler.GenerateListData(ref ListBoxStatsInfo, temp);

        }

        private void TextBoxMaxMovesForNewMap_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

