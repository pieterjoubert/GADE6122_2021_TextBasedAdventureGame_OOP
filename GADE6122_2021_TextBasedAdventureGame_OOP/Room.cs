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

        const int MAX_ENTRIES = 4;
        const int MAX_ITEMS = 6;

        //Methods
        public Room()
        {
            nextRooms = new Room[MAX_ENTRIES];
            EntryCommands = new string[MAX_ENTRIES];
            items = new Item[MAX_ITEMS];
        }

        public string ExecuteCommand(string command, Character character)
        {
            string response = "Command not understood.";
            //check if command is an entry command
            for(int i = 0; i < MAX_ENTRIES; i ++)
            {
                if(EntryCommands[i] != null && command.ToLower() == EntryCommands[i].ToLower())
                {
                    nextRoomNumber = i;
                    response = "Entering next room.";
                }
            }

            //check if command is a pickup command
            for(int i = 0; i < MAX_ITEMS; i ++)
            {
                if(items[i] != null && command.ToLower() == "pickup " + items[i].Name.ToLower())
                {
                    //Make player pickup item
                    character.Pickup(items[i]);
                    response = "You picked up the " + items[i].Name;

                    //remove item from room
                    items[i] = null;
                }
            }

            //check if command is the character
            if (command.ToLower() == "char")
            {
                response = character.DisplayCharacterInformation();
            }

            return response;
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
