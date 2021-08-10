﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_2021_TextBasedAdventureGame_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define items
            Item sword = new Item();
            sword.ID = 0;
            sword.Name = "Longsword + 1";
            sword.Description = "A finely crafted longsword";

            //Define rooms
            Room hallway = new Room();
            hallway.ID = 1;
            hallway.Name = "Dungeon Hallway";
            hallway.Description = " The Dungeon Hallway is barely lit from the light coming from the outside";

            Room entrance = new Room();
            entrance.ID = 0;
            entrance.Name = "Dungeon Entrace";
            entrance.Description = "The moss covered rocks hide away a entrance into the dungeon";

            //link rooms
            entrance.nextRooms[0] = hallway;
            entrance.EntryCommands[0] = "enter dungeon";
            
            hallway.nextRooms[0] = entrance;
            hallway.EntryCommands[0] = "exit dungeon";

            //add items
            hallway.items[0] = sword;

            Room currentRoom = entrance;

            //main game loop
            while(true)
            {
                Console.WriteLine(currentRoom.DisplayRoomInformation());
                string command = Console.ReadLine().ToLower();
                if(currentRoom.ExecuteCommand(command))
                {
                    currentRoom = currentRoom.GetNextRoom();
                }
                else
                {
                    Console.WriteLine("Command not recognized");
                }
            }

        }
    }
}
