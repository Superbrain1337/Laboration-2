using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        AllData allData = new AllData();
        GuiGenerator guiGenerator = new GuiGenerator();

        public MainWindow()
        {
            InitializeComponent();

            allData.gameData.Add(new Player("Linus"));
            allData.gameData.Add(new Player("André"));

            allData.gameData[0].AddNewScore(new Score(10), new Level("Level 1", 10));
            allData.gameData[0].AddNewScore(new Score(6), new Level("Level 2", 6));

            allData.gameData[1].AddNewScore(new Score(5), new Level("Level 1", 10));
            allData.gameData[1].AddNewScore(new Score(3), new Level("Level 2", 6));

            LoadPlayerListBox();
        }

        private void LoadPlayerListBox()
        {
            for (int i = 0; i != allData.gameData.Count; i++)
            {

                ListBoxPlayer.Items.Add(allData.gameData[i].Name);
            }

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
                    //
                    MessageBox.Show("Du angav inget namn!");
                }


            }

            
        }

        private void ListBoxScore_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

