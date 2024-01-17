using CPT230RPG2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace CPT230RPGWithClasses
{
    /*
     * Brett Fowler
     * Course CPT-230-W37
     * Coding Assignnent 11 - RPG (Final)
     * 2023 Summer
     */
    public partial class Dungeon : Form
    {
        //PlayProgression playProgression = new PlayProgression();

        // Create startingTime variable
        private DateTime startingTime;

        // Set map char values -- 0 = empty, P = player, W = wall, \ = lever(inactive),/ = lever(active),
        //                        # = chest, : = door, ! = save
        char[] mapChars = { '0', 'P', 'W', '\\', '/', '#', ':', '-', '!' };
        Color[] mapCharColors = { Color.Black, Color.Blue, Color.Black, Color.Yellow, Color.Yellow,
            Color.Gold, Color.Gold, Color.SandyBrown, Color.RoyalBlue };
        Color[] mapBackColors = { Color.SandyBrown, Color.SandyBrown, Color.Black, Color.Red, Color.Green,
            Color.SaddleBrown, Color.RosyBrown, Color.SandyBrown, Color.SandyBrown };

        // Set movement values
        int vert = 1;
        int hor = 2;

        // Initiate random object for dungeon events
        Random random = new Random();

        // Set chest locations
        int[,] chestLocations = { { 8, 1, 11 }, { 1, 1, 1 }, { 3, 3, 6 }, { 6, 1, 1 } };
        // Set chest contents
        string[] chestContents = { "key", "key", "Treasure", "Sword" };

        // Set lever locations
        int[,] leverLocations = { { 2, 3, 5 } };
        // Set lever activation target
        int[,] leverTarget = { { 5, 0, 8 } };
        // Lever activation check values
        bool[] leverActivated = { false };

        // Set player char values
        int[] playerLocation = { 6, 3, 6 };
        // Set player picture location
        public int playerMapX = 286;
        public int playerMapY = 177;
        // Player inventory of keys
        int playerKeyInv = 0;

        // Variable for thief meeting
        bool meetThief = false;
        // Boss defeated variable
        public bool bossDefeated = false;

        // Variable for game load file type
        public string loadSave;

        // Method to reset start values for player and objects in the maze
        private void SetStartValues()
        {
            roomSpaces[playerLocation[0], playerLocation[1], playerLocation[2]] = "0";
            playerLocation[0] = 6;
            playerLocation[1] = 3;
            playerLocation[2] = 6;
            pbxMapPlayer.Location = new Point(286, 177);
            playerKeyInv = 0;
            txtKeyInv.Text = $"Keys: {playerKeyInv}";
            cbxInventory.Items.Remove("Treasure");
            leverActivated[0] = false;
            chestContents[0] = "key";
            chestContents[1] = "key";
            chestContents[2] = "Treasure";
            chestContents[3] = "Sword";
            roomSpaces[4, 0, 5] = ":";
            roomSpaces[2, 3, 5] = "\\";
            roomSpaces[5, 0, 8] = "W";
            roomSpaces[7, 5, 11] = "-";
            meetThief = false;
            bossDefeated = false;
            txtOutput.Clear();
            SetPlayerLoc();
            DisplayMap(playerLocation[0]);
            DisplayWorldMap();
            startingTime = DateTime.Now;
        }

        // Set portal locations
        int[,] portalLocations =
        {
            { 1,4,12 }, { 2,3,12 }, { 3,6,5 }, { 4,0,5 }, { 4,4,0 }, { 4,1,12 }, { 4,6,8 }, { 5,0,8 },
            { 5,6,6 }, { 6,0,6 }, { 6,6,6 }, { 6,3,0 }, { 6,3,12 }, { 7,0,6 }, { 8,1,0 }, { 9,3,0 }
        };
        // Set portal destinations
        int[,] portalDestinations =
        {
            { 4,4,1 }, { 6,3,1 }, { 4,1,5 }, { 3,5,5 }, { 1,4,11 }, { 8,1,1 }, { 5,1,8 }, { 4,5,8 },
            { 6,1,6 }, { 5,5,6 }, { 7,1,6 }, { 2,3,11 }, { 9,3,1 }, { 6,5,6 }, { 4,1,11}, { 6,3,11 }
        };


        // Set room map array
        string[,,] roomSpaces =
        {
            // default room
            {
                { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W" }
            },

            // room 1
            {
                { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W" },
                { "W", "#", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W" }
            },

            //room 2
            {
                { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "\\", "0", "0", "0", "0", "0", "0", "0" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W" }
            },

            // room 3
            {
                { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "#", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "W", "W", "W", "W", "0", "W", "W", "W", "W", "W", "W", "W" }
            },

            // room 4
            {
                { "W", "W", "W", "W", "W", ":", "W", "W", "W", "W", "W", "W", "W" },
                { "W", "0", "0", "!", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "W", "W", "W", "W", "W", "W", "W", "0", "W", "W", "W", "W" }
            },

            // room 5                                     > <
            {
                { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "W", "W", "W", "W", "W", "0", "W", "W", "W", "W", "W", "W" }
            },

            // Starting room 6
            {
                { "W", "W", "W", "W", "W", "W", "0", "W", "W", "W", "W", "W", "W" },
                { "W", "#", "0", "0", "0", "0", "0", "0", "0", "0", "0", "!", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "W", "W", "W", "W", "W", "0", "W", "W", "W", "W", "W", "W" }
            },

            // room 7
            {
                { "W", "W", "W", "W", "W", "W", "0", "W", "W", "W", "W", "W", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "-", "W" },
                { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W" }
            },

            //room 8
            {
                { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W" },
                { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "#", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W" }
            },

            //room 9
            {
                { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
                { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W" }
            }
        };

        // Set world map array
        int[,] worldRoomLocations =
        {
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 3, 0, 0, 0 },
            { 0, 0, 1, 4, 8, 0, 0 },
            { 0, 0, 0, 5, 0, 0, 0 },
            { 0, 0, 2, 6, 9, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 }
        };

        // Method to change color of elements in room
        private void ApplyCharColor(char character, Color charColor, Color backColor)
        {
            for (int i = 0; i < rtxOutputRoom.Text.Length; i++)
            {
                if (rtxOutputRoom.Text[i] == character)
                {
                    rtxOutputRoom.SelectionStart = i;
                    rtxOutputRoom.SelectionLength = 1;
                    rtxOutputRoom.SelectionColor = charColor;
                    rtxOutputRoom.SelectionBackColor = backColor;
                }
            }
        }

        // Method to apply colors to map characters
        private void ApplyMapColors()
        {
            for (int i = 0; i < mapChars.Length; i++)
            {
                ApplyCharColor(mapChars[i], mapCharColors[i], mapBackColors[i]);
            }
        }

        // Method to display the room map
        private void DisplayMap(int room)
        {
            if (playerLocation[0] == 7 && meetThief == false)
            {
                pbxMapThief.Visible = true;
            }
            else if (playerLocation[0] == 7 && meetThief == true)
            {
                pbxMapThief.Visible = false;
                roomSpaces[7, 5, 11] = "0";
            }
            rtxOutputRoom.Clear();
            for (int i = 0; i < roomSpaces.GetLength(1); i++)
            {
                for (int j = 0; j < roomSpaces.GetLength(2); j++)
                {
                    rtxOutputRoom.Text += roomSpaces[room, i, j].ToString();
                }
                rtxOutputRoom.Text += "\r\n";
            }
            ApplyMapColors();
            
        }

        // Method to display world map
        private void DisplayWorldMap()
        {
            txtMiniMap.Clear();
            for (int i = 0; i < worldRoomLocations.GetLength(0); i++)
            {
                for (int j = 0; j < worldRoomLocations.GetLength(1); j++)
                {
                    if (worldRoomLocations[i, j] == 0)
                    {
                        txtMiniMap.Text += " ";
                    }
                    else if (worldRoomLocations[i, j] == playerLocation[0])
                    {
                        txtMiniMap.Text += "\u25D8";
                    }
                    else
                    {
                        txtMiniMap.Text += "\u2588";
                    }
                }
                txtMiniMap.Text += "\r\n";
            }
        }

        // Method to activate lever
        private void LeverActivate(int[] location, int leverIndex)
        {
            // Check if lever is deactivated and activate
            if (leverActivated[leverIndex] == false)
            {
                leverActivated[leverIndex] = true;
                roomSpaces[leverTarget[leverIndex, 0], leverTarget[leverIndex, 1], leverTarget[leverIndex, 2]] = "0";
                roomSpaces[location[0], location[1], location[2]] = "/";
                DisplayMap(playerLocation[0]);
                txtOutput.Text = $"You pull the lever and hear a click echo elsewhere.\r\n{txtOutput.Text}";
            }
            // Check if lever is activated and deactivate
            else if (leverActivated[leverIndex] == true)
            {
                leverActivated[leverIndex] = false;
                roomSpaces[leverTarget[leverIndex, 0], leverTarget[leverIndex, 1], leverTarget[leverIndex, 2]] = "W";
                roomSpaces[location[0], location[1], location[2]] = "\\";
                DisplayMap(playerLocation[0]);
                txtOutput.Text = $"You pull the lever and hear a thud echo elsewhere.\r\n{txtOutput.Text}";
            }
        }

        // Method to move player position within roomSpaces
        private void MovePlayer(int dir, int move, int room)
        {
            int[] nextPlayerLoc = { 0, 0 };
            nextPlayerLoc[0] = playerLocation[1];
            nextPlayerLoc[1] = playerLocation[2];
            nextPlayerLoc[dir - 1] += move;
            if (roomSpaces[playerLocation[0], nextPlayerLoc[0], nextPlayerLoc[1]] == "0")
            {
                roomSpaces[playerLocation[0], playerLocation[1], playerLocation[2]] = "0";
                playerLocation[dir] += move;
                SetPlayerLoc();
                if (dir == 1)
                {
                    if (move == 1)
                    {
                        pbxMapPlayer.Image = Properties.Resources.BlackMage_Front;
                    }
                    else if (move == -1)
                    {
                        pbxMapPlayer.Image = Properties.Resources.BlackMage_Back;
                    }
                    // Change location of player picturebox
                    pbxMapPlayer.Location = new Point(pbxMapPlayer.Location.X, pbxMapPlayer.Location.Y + (48 * move));
                    playerMapX = pbxMapPlayer.Location.X;
                    playerMapY = pbxMapPlayer.Location.Y;
                }
                else if (dir == 2)
                {
                    if (move == -1)
                    {
                        pbxMapPlayer.Image = Properties.Resources.BlackMage_Left;
                    }
                    else if (move == 1)
                    {
                        pbxMapPlayer.Image = Properties.Resources.BlackMage_Left;
                        pbxMapPlayer.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    }
                    // Change location of player picturebox
                    pbxMapPlayer.Location = new Point(pbxMapPlayer.Location.X + (21 * move), pbxMapPlayer.Location.Y);
                    playerMapX = pbxMapPlayer.Location.X;
                    playerMapY = pbxMapPlayer.Location.Y;
                }
                DisplayMap(room);
            }
        }

        // Method to activate portal and move player
        private void PortalActivate()
        {
            // build portaldestination
            for (int i = 0; i < portalLocations.GetLength(0); i++)
            {
                if (portalLocations[i, 0] == playerLocation[0]
                    && portalLocations[i, 1] == playerLocation[1]
                    && portalLocations[i, 2] == playerLocation[2])
                {
                    roomSpaces[playerLocation[0], playerLocation[1], playerLocation[2]] = "0";
                    playerLocation[0] = portalDestinations[i, 0];
                    playerLocation[1] = portalDestinations[i, 1];
                    playerLocation[2] = portalDestinations[i, 2];
                    pbxMapPlayer.Location = new Point(181 + 21 * (portalDestinations[i, 2] - 1), 80 + 48 * (portalDestinations[i, 1] - 1));
                    playerMapX = pbxMapPlayer.Location.X;
                    playerMapY = pbxMapPlayer.Location.Y;
                }
            }
            SetPlayerLoc();
            DisplayMap(playerLocation[0]);
            DisplayWorldMap();
            // Auto save data on room change
            SaveData("Auto");
        }

        // Method for checking for objects and interacting with objects
        private void ObjectInteract()
        {
            for (int i = 0; i < roomSpaces.GetLength(1); i++)
            {
                for (int j = 0; j < roomSpaces.GetLength(2); j++)
                {
                    // Check if lever is in close enough proximity to activate
                    if (roomSpaces[playerLocation[0], i, j] == "\\" || roomSpaces[playerLocation[0], i, j] == "/")
                    {
                        if (((playerLocation[2] - 1 == j || playerLocation[2] + 1 == j) && playerLocation[1] == i) ||
                            ((playerLocation[1] - 1 == i || playerLocation[1] + 1 == i) && playerLocation[2] == j))
                        {
                            int[] leverLoc = { playerLocation[0], i, j };
                            LeverActivate(leverLoc, 0);
                        }
                    }
                    // Check if chest is in close enough proximity to access
                    else if (roomSpaces[playerLocation[0], i, j] == "#")
                    {
                        if (((playerLocation[2] - 1 == j || playerLocation[2] + 1 == j) && playerLocation[1] == i) ||
                            ((playerLocation[1] - 1 == i || playerLocation[1] + 1 == i) && playerLocation[2] == j))
                        {
                            int[] chestLoc = { playerLocation[0], i, j };
                            RetrieveChestItem(chestLoc);

                        }
                    }
                    // Check if door is in close enough proximity to open
                    else if (roomSpaces[playerLocation[0], i, j] == ":")
                    {
                        if (((playerLocation[2] - 1 == j || playerLocation[2] + 1 == j) && playerLocation[1] == i) ||
                            ((playerLocation[1] - 1 == i || playerLocation[1] + 1 == i) && playerLocation[2] == j))
                        {
                            if (playerKeyInv > 0)
                            {
                                roomSpaces[playerLocation[0], i, j] = "0";
                                playerKeyInv -= 1;
                                txtKeyInv.Text = $"Keys: {playerKeyInv.ToString()}";
                                DisplayMap(playerLocation[0]);
                                txtOutput.Text = $"You used a key to open the door.\r\n{txtOutput.Text}";
                            }
                            else
                            {
                                txtOutput.Text = $"This door is locked.\r\n{txtOutput.Text}";
                            }

                        }
                    }
                    // Check if thief is in close enough proximity to interact with
                    else if (roomSpaces[playerLocation[0], i, j] == "-")
                    {
                        if (((playerLocation[2] - 1 == j || playerLocation[2] + 1 == j) && playerLocation[1] == i) ||
                            ((playerLocation[1] - 1 == i || playerLocation[1] + 1 == i) && playerLocation[2] == j))
                        {
                            txtOutput.Text = $"You encounter a thief.\r\n{txtOutput.Text}";
                            txtOutput.Text = $"The thief steals an item from your inventory and escapes.\r\n{txtOutput.Text}";
                            int steal = random.Next(0, cbxInventory.Items.Count - 1);
                            cbxInventory.Items.RemoveAt(steal);
                            pbxMapThief.Visible = false;
                            meetThief = true;
                            roomSpaces[7, 5, 11] = "0";
                            DisplayMap(playerLocation[0]);
                        }

                    }
                    // check if save point is in close enough proximity to activate
                    else if (roomSpaces[playerLocation[0], i, j] == "!")
                    {
                        if (((playerLocation[2] - 1 == j || playerLocation[2] + 1 == j) && playerLocation[1] == i) ||
                            ((playerLocation[1] - 1 == i || playerLocation[1] + 1 == i) && playerLocation[2] == j))
                        {
                            DialogResult d = MessageBox.Show($"Would you like to record your progress?",
                                "Save Game", MessageBoxButtons.YesNo);
                            // Save game on "Yes"
                            if (d == DialogResult.Yes)
                            {
                                SaveData("PlaySave");
                                MessageBox.Show("Your progress has been saved.", "Game Saved");
                            }
                            // Cancel game saving on "No"
                            else
                            {
                                MessageBox.Show("Progress has not been saved.", "Save Cancelled");
                            }
                        }
                    }
                }
            }
        }

        // Method to retrieve chest item
        private void RetrieveChestItem(int[] location)
        {
            for (int i = 0; i < chestLocations.GetLength(0); i++)
            {
                if (location[0] == chestLocations[i, 0] &&
                    location[1] == chestLocations[i, 1] && location[2] == chestLocations[i, 2])
                {
                    if (chestContents[i] == "0")
                    {
                        txtOutput.Text = $"This chest is empty.\r\n{txtOutput.Text}";
                    }
                    else if (chestContents[i] == "key")
                    {
                        playerKeyInv += 1;
                        txtKeyInv.Text = $"Keys: {playerKeyInv.ToString()}";
                        txtOutput.Text = $"You retrieved a key from the chest.\r\n{txtOutput.Text}";
                        chestContents[i] = "0";
                    }
                    else
                    {
                        cbxInventory.Items.Add(chestContents[i]);
                        txtOutput.Text = $"You found {chestContents[i]} in the chest.\r\n{txtOutput.Text}";
                        txtOutput.Text = $"You placed {chestContents[i]} into your inventory.\r\n{txtOutput.Text}";
                        chestContents[i] = "0";
                        if (cbxInventory.Items.Contains("Treasure"))
                        {
                            // Set timespan of game run
                            TimeSpan time = DateTime.Now - startingTime;
                            //Display end of run dialog box
                            DialogResult d = MessageBox.Show($"You plundered the treasure in {time:hh\\:mm\\:ss}!\r\nWould you like to play again?",
                                "You Win!", MessageBoxButtons.YesNo);
                            // Reset game on "Yes"
                            if (d == DialogResult.Yes)
                            {
                                SetStartValues();
                            }
                            // "Game Over" on "No" and close program after "OK"
                            else
                            {
                                MessageBox.Show("You have chosen to end the game.", "Game Over");
                                Application.Exit();
                            }
                        }
                    }
                }
            }
        }

        // Method to set player position within roomSpaces
        private void SetPlayerLoc()
        {
            roomSpaces[playerLocation[0], playerLocation[1], playerLocation[2]] = mapChars[1].ToString();
        }


        // Method to determine and generate random battle
        private void RandomBattle()
        {
            if (playerLocation[0] == 3 && playerLocation[1] == 4 && bossDefeated == false)
            {
                Battle battle = new Battle();
                battle.dungeon = this;
                battle.battleMode = "boss";
                if (meetThief == true)
                {
                    battle.bonusAttack = 1;
                }
                battle.Show();
                this.Hide();
            }
            else if (random.Next(1, 21) > 17)
            {
                Battle battle = new Battle();
                battle.dungeon = this;
                battle.battleMode = "random";
                battle.Show();
                this.Hide();
            }
        }

        private void MoveNorth()
        {
            // Check if player moving to an open space
            if (playerLocation[1] > 0)
            {
                MovePlayer(vert, -1, playerLocation[0]);
                RandomBattle();
            }
            // Check if player ends in a portal space
            if (playerLocation[1] == 0)
            {
                PortalActivate();
            }
        }

        private void MoveSouth()
        {
            // Check if player moving to an open space
            if (playerLocation[1] < roomSpaces.GetLength(1) - 1)
            {
                MovePlayer(vert, 1, playerLocation[0]);
                RandomBattle();
            }
            // Check if player ends in a portal space
            if (playerLocation[1] == 6)
            {
                PortalActivate();
            }
        }

        private void MoveEast()
        {
            // Check if player moving to an open space
            if (playerLocation[2] < roomSpaces.GetLength(2) - 1)
            {
                MovePlayer(hor, 1, playerLocation[0]);
                RandomBattle();
            }
            // Check if player ends in a portal space
            if (playerLocation[2] == 12)
            {
                PortalActivate();
            }
        }

        private void MoveWest()
        {
            // Check if player moving to an open space
            if (playerLocation[2] > 0)
            {
                MovePlayer(hor, -1, playerLocation[0]);
                RandomBattle();
            }
            // Check if player ends in a portal space
            if (playerLocation[2] == 0)
            {
                PortalActivate();
            }
        }

        public Dungeon()
        {
            InitializeComponent();
            
        }

        // method to save data to continue later
        private void SaveData(string file)
        {
            string dir = @"C:\C#\Fowler\";
            string binaryFile = file;

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            using BinaryWriter binaryWriter = new BinaryWriter(new FileStream(dir + binaryFile, FileMode.OpenOrCreate, FileAccess.Write));
            binaryWriter.Write(playerLocation[0]);
            binaryWriter.Write(playerLocation[1]);
            binaryWriter.Write(playerLocation[2]);
            binaryWriter.Write(playerKeyInv);
            binaryWriter.Write(playerMapX);
            binaryWriter.Write(playerMapY);
            binaryWriter.Write(leverActivated[0]);
            binaryWriter.Write(chestContents[0]);
            binaryWriter.Write(chestContents[1]);
            binaryWriter.Write(chestContents[2]);
            binaryWriter.Write(chestContents[3]);
            binaryWriter.Write(roomSpaces[4, 0, 5]);
            binaryWriter.Write(roomSpaces[2, 3, 5]);
            binaryWriter.Write(roomSpaces[5, 0, 8]);
            binaryWriter.Write(roomSpaces[7, 5, 11]);
            binaryWriter.Write(meetThief);
            binaryWriter.Write(bossDefeated);
        }

        // method to load data to continue from saved game state
        private void ReadData(string file)
        {
            string dir = @"C:\C#\Fowler\";
            string binaryFile = file;

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (File.Exists(dir + binaryFile))
            {
                using BinaryReader binaryReader = new BinaryReader(new FileStream(dir + binaryFile, FileMode.OpenOrCreate, FileAccess.Read));
                playerLocation[0] = binaryReader.ReadInt32();
                playerLocation[1] = binaryReader.ReadInt32();
                playerLocation[2] = binaryReader.ReadInt32();
                playerKeyInv = binaryReader.ReadInt32();
                playerMapX = binaryReader.ReadInt32();
                playerMapY = binaryReader.ReadInt32();
                leverActivated[0] = binaryReader.ReadBoolean();
                chestContents[0] = binaryReader.ReadString();
                chestContents[1] = binaryReader.ReadString();
                chestContents[2] = binaryReader.ReadString();
                chestContents[3] = binaryReader.ReadString();
                roomSpaces[4, 0, 5] = binaryReader.ReadString();
                roomSpaces[2, 3, 5] = binaryReader.ReadString();
                roomSpaces[5, 0, 8] = binaryReader.ReadString();
                roomSpaces[7, 5, 11] = binaryReader.ReadString();
                meetThief = binaryReader.ReadBoolean();
                bossDefeated = binaryReader.ReadBoolean();
            }
            else
            {
                MessageBox.Show("Save game not found!", "Warning");
            }
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            // If walk is checked, move once. Move thrice for sprint
            if (rdoWalk.Checked)
            {
                MoveNorth();
            }
            else if (rdoSprint.Checked)
            {
                MoveNorth();
                MoveNorth();
                MoveNorth();
            }
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            // If walk is checked, move once. Move thrice for sprint
            if (rdoWalk.Checked)
            {
                MoveSouth();
            }
            else if (rdoSprint.Checked)
            {
                MoveSouth();
                MoveSouth();
                MoveSouth();
            }
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            // If walk is checked, move once. Move thrice for sprint
            if (rdoWalk.Checked)
            {
                MoveEast();
            }
            else if (rdoSprint.Checked)
            {
                MoveEast();
                MoveEast();
                MoveEast();
            }
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            // If walk is checked, move once. Move thrice for sprint
            if (rdoWalk.Checked)
            {
                MoveWest();
            }
            else if (rdoSprint.Checked)
            {
                MoveWest();
                MoveWest();
                MoveWest();
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            ObjectInteract();
        }

        private void btnUseItem_Click(object sender, EventArgs e)
        {
            //Check if inventory item can be used
            //Add "Sword" to "Equipped" list box or output text for unusable item
            if (cbxInventory.GetItemText(cbxInventory.SelectedItem) == "Sword")
            {
                lstEquipped.Items.Add(cbxInventory.SelectedItem);
                cbxInventory.Items.Remove(cbxInventory.SelectedItem);
            }
            else
            {
                txtOutput.Text = $"This item cannot be used here.\r\n{txtOutput.Text}";
            }
        }

        private void Dungeon_Load(object sender, EventArgs e)
        {
            // Set key inventory
            if (loadSave == "Auto")
            {
                ReadData("Auto");
            }
            else if (loadSave == "PlaySave")
            {
                ReadData("PlaySave");
            }

            pbxMapPlayer.Location = new Point(playerMapX, playerMapY);
            txtKeyInv.Text = $"Keys: {playerKeyInv}";
            // Set player location and display maps
            SetPlayerLoc();
            DisplayMap(playerLocation[0]);
            DisplayWorldMap();
            // Set start time
            startingTime = DateTime.Now;
        }
    }
}
