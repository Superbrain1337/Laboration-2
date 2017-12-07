using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laboration_2
{
    class GuiHandeler
    {
        public void GenerateListData(ref ListBox inputListBox, Player player)
        {

            // Tar in alla levels en spelare har spelar på
            // Och skriv ut all info i en listbox

            int nummberOfMovesDone = 0;
            int nummberOfMovesAccepted = 0;

            inputListBox.Items.Clear();


            string playerName = "=====  " + player.Name + "  =====";

            inputListBox.Items.Add(playerName);

            for (int i = 0; i != player.Scores.Count(); i++)
            {




                ItemsControl tempItemControlLevelData = new ItemsControl();

                tempItemControlLevelData.Height = 70;
                tempItemControlLevelData.Width = 135;

                nummberOfMovesDone += player.Scores[i].AmountOfMovesUsed; 
                nummberOfMovesAccepted += player.Scores[i].Levels.AmountOfMoves;


                Label tempInfoLabelData = new Label();


                tempInfoLabelData.Content = "Level : " + player.Scores[i].Levels.Name + "\r\n";
                tempInfoLabelData.Content += "Moves made : " + player.Scores[i].AmountOfMovesUsed  + "\r\n";
                tempInfoLabelData.Content += "Moves left : " + (player.Scores[i].Levels.AmountOfMoves - player.Scores[i].AmountOfMovesUsed) + "\r\n";
                tempInfoLabelData.Content += "Moves available : " + player.Scores[i].Levels.AmountOfMoves + "\r\n";
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


        public void WriteOutLevelsToListbox(List<Level> temp, ref ListBox listBox)
        {
            if(temp.Count > 0)
            {
                foreach(Level val in temp)
                {
                    listBox.Items.Add(val.Name + " Id : " + val.LevelId);
                }
            }
        }

        public void WriteOutPlayersToListbox(List<Player> temp,ref ListBox listbox)
        {
            if(temp.Count > 0)
            {
                foreach(Player val in temp)
                {
                    listbox.Items.Add(val.Name);
                }
            }
        }


    }
}



