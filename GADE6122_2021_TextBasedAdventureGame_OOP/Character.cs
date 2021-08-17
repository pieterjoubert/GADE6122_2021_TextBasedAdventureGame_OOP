using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_2021_TextBasedAdventureGame_OOP
{
    class Character
    {
        public string Name;
        public int HP;
        public int Damage;

        public Item[] inventory;
        public Item[] equipment;

        const int MAX_INVENTORY_SIZE = 8;
        const int MAX_EQUIPMENT_SIZE = 4;

        int inventorySize = 0;
        int equipmentSize = 0;

        public Character()
        {
            inventory = new Item[MAX_INVENTORY_SIZE];
            equipment = new Item[MAX_EQUIPMENT_SIZE];
        }

        public bool Pickup(Item item)
        {
            if(inventorySize < MAX_EQUIPMENT_SIZE - 1)
            {
                inventory[inventorySize] = item;
                inventorySize++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public string DisplayCharacterInformation()
        {
            string info = "";
            info += "===== " + Name + " =====\n";
            info += "Inventory: ";

            for(int i = 0; i < inventorySize; i++)
            {
                if(inventory[i] != null)
                    info += inventory[i].Name + " "; 
            }
            return info;
        }

    }
}
