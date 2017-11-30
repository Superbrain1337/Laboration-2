using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laboration_2
{
    class GuiGenerator
    {
        public void GenerateListData(ref ListBox inputListBox, List<Level> listOfLevelsPlayerHasPlayed,string name)
        {

            // Tar in alla levels en spelare har spelar på
            // Och skriv ut all info i en listbox

            int nummberOfMovesDone = 0;
            int nummberOfMovesAccepted = 0;

            inputListBox.Items.Clear();


            string playerName = " ===  " + name + "  === " + "\r\n\r\n";


            for (int i = 0; i != listOfLevelsPlayerHasPlayed.Count(); i++)
            {



                ItemsControl tempItemControlLevelData = new ItemsControl();

                tempItemControlLevelData.Height = 70;
                tempItemControlLevelData.Width = 135;
                
                //nummberOfMovesDone += playerQuearyData[i].
                nummberOfMovesAccepted += listOfLevelsPlayerHasPlayed[i].AmountOfMoves;
                


                Label tempInfoLabelData = new Label();

                tempInfoLabelData.Content = playerName;
                tempInfoLabelData.Content += "Level : " + listOfLevelsPlayerHasPlayed[i].Name + "\r\n";
                tempInfoLabelData.Content += "Moves made : " + listOfLevelsPlayerHasPlayed[i].Players[0].Scores[0].AmountOfMovesUsed + "\r\n";
                tempInfoLabelData.Content += "Moves left : " + (listOfLevelsPlayerHasPlayed[i].AmountOfMoves - listOfLevelsPlayerHasPlayed[i].Players[0].Scores[0].AmountOfMovesUsed) + "\r\n";
                tempInfoLabelData.Content += "Moves available : " + listOfLevelsPlayerHasPlayed[i].AmountOfMoves + "\r\n";
                tempInfoLabelData.Content += "-----------------";


                tempItemControlLevelData.Items.Add(tempInfoLabelData);
                inputListBox.Items.Add(tempItemControlLevelData);

            }

            ItemsControl tempItemControlStats = new ItemsControl();

            tempItemControlStats.Height = 70;
            tempItemControlStats.Width = 150;

            Label tempInfoLabel = new Label();


            tempInfoLabel.Content += "Total moves made : " + nummberOfMovesDone + "\r\n";
            tempInfoLabel.Content += "Total moves left : " + (nummberOfMovesAccepted - nummberOfMovesDone) + "\r\n";
            tempInfoLabel.Content += "Total moves available : " + nummberOfMovesAccepted;


            tempItemControlStats.Items.Add(tempInfoLabel);
            inputListBox.Items.Add(tempItemControlStats);

        }
    }
}



