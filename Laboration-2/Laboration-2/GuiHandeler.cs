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
        public void GenerateListData(ref ListBox inputListBox, Player player,List<Player> playerList)
        {

            // Tar in alla levels en spelare har spelar på
            // Och skriv ut all info i en listbox

            int nummberOfMovesDone = 0;
            int nummberOfMovesAccepted = 0;

            inputListBox.Items.Clear();

            string playerName = "========  " + player.Name + "  ========";

            inputListBox.Items.Add(playerName);

            for (int i = 0; i != player.Scores.Count(); i++)
            {
                
                int indexBestPlayer = 0 ;
                int bestMoveCount = player.Scores[i].AmountOfMovesUsed;

                for (int x = 0; x != playerList.Count; x++)
                {
                    for (int z = 0; z != playerList[x].Scores.Count ; z++)
                    {
                        if(player.Scores[i].Levels == playerList[x].Scores[z].Levels)
                        {
                            if(bestMoveCount >= playerList[x].Scores[z].AmountOfMovesUsed)
                            {
                                indexBestPlayer = x;
                                bestMoveCount = playerList[x].Scores[z].AmountOfMovesUsed;
                            }
                        }
                    }
                }


                ItemsControl tempItemControlLevelData = new ItemsControl();

                tempItemControlLevelData.Height = 150;
                tempItemControlLevelData.Width = 221;

                nummberOfMovesDone += player.Scores[i].AmountOfMovesUsed;
                nummberOfMovesAccepted += player.Scores[i].Levels.AmountOfMoves;


                Label tempInfoLabelData = new Label();


                tempInfoLabelData.Content = "Level : " + player.Scores[i].Levels.Name + "\r\n";
                tempInfoLabelData.Content += "Moves made : " + player.Scores[i].AmountOfMovesUsed + "\r\n";
                tempInfoLabelData.Content += "Moves left : " + (player.Scores[i].Levels.AmountOfMoves - player.Scores[i].AmountOfMovesUsed) + "\r\n";
                tempInfoLabelData.Content += "Moves available : " + player.Scores[i].Levels.AmountOfMoves + "\r\n\r\n";
                tempInfoLabelData.Content += "Best Player : " + playerList[indexBestPlayer].Name + "\r\n";
                tempInfoLabelData.Content += "Best Moves : " + bestMoveCount + "\r\n";
                tempInfoLabelData.Content += "Best Player Moves Left : " + (player.Scores[i].Levels.AmountOfMoves - bestMoveCount) + "\r\n";
                tempInfoLabelData.Content += "-------------------------------";


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
                    listBox.Items.Add(val.Name + " Id : " + val.LevelId + " Max moves : " + val.AmountOfMoves);
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



