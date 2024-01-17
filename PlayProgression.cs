using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPT230RPGWithClasses
{
    /*
     * Brett Fowler
     * Course CPT-230-W37
     * Coding Assignnent 11 - RPG (Final)
     * 2023 Summer
     */
    internal class PlayProgression
    {

        // Player character values
        public int[] playerLocation;
        public int playerKeyInv;

        // Dungeon state values
        // chest values
        public int[,] chestLocations;
        public string[] chestContents;
        // lever values
        public int[,] leverLocations;
        public int[,] leverTargets;
        public bool[] leverActivated;
        // portal values
        public int[,] portalLocations;
        public int[,] portalDestinations;

        // Dungeon map values
        // room space values
        public string[,,] roomSpaces;
        // world map value
        public int[,] worldRoomLocations;


        // Battle mode value
        public string battleMode = "random";

        // PlayProgression constructor
        public PlayProgression()
        {
            this.playerLocation = new int[] { 6, 3, 6 };
            this.playerKeyInv = 0;

            this.chestLocations = new int[,] { { 8, 1, 11 }, { 1, 1, 1 }, { 3, 3, 6 }, { 6, 1, 1 } };
            this.chestContents = new string[] { "key", "key", "Treasure", "Sword" };

            this.leverLocations = new int[,] { { 2, 3, 5 } };
            this.leverTargets = new int[,] { { 5, 0, 8 } };
            this.leverActivated = new bool[] { false };

            this.portalLocations = new int[,] {
            { 1,4,12 }, { 2,3,12 }, { 3,6,5 }, { 4,0,5 }, { 4,4,0 }, { 4,1,12 }, { 4,6,8 }, { 5,0,8 },
            { 5,6,6 }, { 6,0,6 }, { 6,6,6 }, { 6,3,0 }, { 6,3,12 }, { 7,0,6 }, { 8,1,0 }, { 9,3,0 } 
            };
            this.portalDestinations = new int[,] {
            { 4,4,1 }, { 6,3,1 }, { 4,1,5 }, { 3,5,5 }, { 1,4,11 }, { 8,1,1 }, { 5,1,8 }, { 4,5,8 },
            { 6,1,6 }, { 5,5,6 }, { 7,1,6 }, { 2,3,11 }, { 9,3,1 }, { 6,5,6 }, { 4,1,11}, { 6,3,11 }
            };

            this.roomSpaces = new string[,,] {
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
                    { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
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
                    { "W", "#", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
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
                    { "W", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "W" },
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

            this.worldRoomLocations = new int[,] {
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 3, 0, 0, 0 },
                { 0, 0, 1, 4, 8, 0, 0 },
                { 0, 0, 0, 5, 0, 0, 0 },
                { 0, 0, 2, 6, 9, 0, 0 },
                { 0, 0, 0, 7, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 }
            };
        }

        // PlayProgression constructor with variables
        public PlayProgression(int[] playerLocation, int playerKeyInv, int[,] chestLocations,
                               string[] chestContents, int[,] leverLocations, int[,] leverTargets,
                               bool[] leverActivated, int[,] portalLocations, int[,] portalDestinations,
                               string[,,] roomSpaces, int[,] worldRoomLocations)
        {

            this.playerLocation[0] = playerLocation[0];
            this.playerLocation[1] = playerLocation[1];
            this.playerLocation[2] = playerLocation[2];
            this.playerKeyInv = playerKeyInv;

            this.chestLocations = chestLocations;
            this.chestContents = chestContents;

            this.leverLocations = leverLocations;
            this.leverTargets = leverTargets;
            this.leverActivated = leverActivated;

            this.portalLocations = portalLocations;
            this.portalDestinations = portalDestinations;
            
            this.roomSpaces = roomSpaces;
            this.worldRoomLocations = worldRoomLocations;
        }

        // BattleMode property
        public string BattleMode
        {
            get { return battleMode; }
            set { battleMode = value; }
        }

        // ChestLocations property
        public int[,] ChestLocations
        {
            get { return chestLocations; }
            set { chestLocations = value; }
        }

        // ChestContents property
        public string[] ChestContents
        {
            get { return chestContents; }
            set { chestContents = value; }
        }

        // LeverLocations property
        public int[,] LeverLocations
        {
            get { return leverLocations; }
            set { leverLocations = value; }
        }

        // LeverTargets property
        public int[,] LeverTargets
        {
            get { return leverTargets; }
            set { leverTargets = value; }
        }

        // LeverActivated property
        public bool[] LeverActivated
        {
            get { return leverActivated; }
            set { leverActivated = value; }
        }

        // PlayerKeyInv property
        public int PlayerKeyInv
        {
            get { return playerKeyInv; }
            set { playerKeyInv = value; }
        }

        // PlayerLocation property
        public int[] PlayerLocation
        {
            get { return playerLocation; }
            set { playerLocation = value; }
        }

        // PortalLocations property
        public int[,] PortalLocations
        {
            get { return portalLocations; }
            set { portalLocations = value; }
        }

        // PortalDestinations property
        public int[,] PortalDestinations
        {
            get { return portalDestinations; }
            set { portalDestinations = value; }
        }

        // RoomSpaces property
        public string[,,] RoomSpaces
        {
            get { return roomSpaces; }
            set { roomSpaces = value; }
        }

        // WorldRoomLocations property
        public int[,] WorldRoomLocations
        {
            get { return worldRoomLocations; }
            set { worldRoomLocations = value; }
        }
    }
}
