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
        public void GenerateListBoxScore(int selecstionIndex, AllData allData, ref ListBox inputListBox)
        {
            if (allData.gameData[selecstionIndex].levelList.Count != 0)
            {
                if (selecstionIndex != -1)
                {

                    int nummberOfMovesDone = 0;
                    int nummberOfMovesAccepted = 0;

                    inputListBox.Items.Clear();
                    Player tempPlayer = allData.gameData[selecstionIndex];

                    for (int i = 0; i != tempPlayer.levelList.Count; i++)
                    {

                        ItemsControl tempItemControlLevelData = new ItemsControl();

                        tempItemControlLevelData.Height = 70;
                        tempItemControlLevelData.Width = 135;

                        Label tempInfoLabelData = new Label();

                        nummberOfMovesDone += tempPlayer.scoreList[i].PlayerSore;
                        nummberOfMovesAccepted += tempPlayer.levelList[i].MaxMoves;

                        tempInfoLabelData.Content = "Level : " + tempPlayer.levelList[i].Name + "\r\n";
                        tempInfoLabelData.Content += "Moves made : " + tempPlayer.scoreList[i].PlayerSore + "\r\n";
                        tempInfoLabelData.Content += "Moves left : " + (tempPlayer.levelList[i].MaxMoves - tempPlayer.scoreList[i].PlayerSore) + "\r\n";
                        tempInfoLabelData.Content += "Moves available : " + tempPlayer.levelList[i].MaxMoves + "\r\n";
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
            else
            {
                inputListBox.Items.Clear();
            }

        }
    }
}
