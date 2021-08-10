using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_2021_TextBasedAdventureGame_OOP
{
    class Room
    {
        //Fields
        public int ID;
        public string Name;
        public string Description;

        //other rooms to go to
        public Room[] nextRooms;        
        public string[] EntryCommands;
        public int nextRoomNumber = -1;

        //items inside the room
        public Item[] items;

        //Methods
        public Room()
        {
            nextRooms = new Room[4];
            EntryCommands = new string[4];
            items = new Item[4];
        }

        public bool ExecuteCommand(string command)
        {
            bool success = false;
            //check if command is an entry command
            for(int i = 0; i < 4; i ++)
            {
                if(EntryCommands[i] != null && command.ToLower() == EntryCommands[i].ToLower())
                {
                    nextRoomNumber = i;
                    success = true;
                }
            }

            //check if command is a pickup command
            for(int i = 0; i < 4; i ++)
            {
                if(items[i] != null && command.ToLower() == "pickup " + items[i].Name.ToLower())
                {
                    //give item to character
                    items[i] = null;
                    success = true;
                }
            }


            return success;
        }

        public Room GetNextRoom()
        {
            if(nextRoomNumber == -1)
            {
                return this;
            }
            else
            {
                return nextRooms[nextRoomNumber];
            }
        }

        public string DisplayRoomInformation()
        {
            string info = "";
            info += "===== " + Name + " =====\n";
            info += Description + "\n";
            info += "The room contains: ";

            for(int i = 0; i < 4; i++)
            {
                if(items[i] != null)
                    info += items[i].Name + " "; 
            }
            return info;
        }
    }
}
