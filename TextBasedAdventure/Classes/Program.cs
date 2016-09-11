using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace TextBasedAdventure
{
    class Program
    {
        //---------
        //VARIABLES
        //---------

        //Strings
        public string playerDescription { get; set; }
        public string loadout { get; set; }

        //Boolean
        public bool nameCheck { get; set; }
        public bool genderCheck { get; set; }
        public bool raceCheck { get; set; }
        public bool classCheck { get; set; }

        static void Main(string[] args)
        {
            //------------------
            //CHARACTER CREATION
            //------------------

            //Lists
                //Not sure if this is needed yet!
            List<string> inventory = new List<string>();

            //Classes
            Program main = new Program();
            Random random = new Random();
            Player player = new Player();
            ClassType classType = new ClassType();
            Weapon primaryWeapon = new Weapon();

            //Choose name
            Console.Write("Please choose a name: ");
            player.name = Console.ReadLine();
            Console.Clear();

            //Male or Female
            do
            {
                Console.WriteLine("Male/Female");
                Console.Write("Please choose a gender: ");
                player.gender = Console.ReadLine().ToUpper();

                if (player.gender == "MALE" || player.gender == "FEMALE")
                {
                    main.genderCheck = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("ERROR! Please try again.");
                }
            } while (main.genderCheck == false);
            Console.Clear();

            //Race creation
            do
            {
                Console.WriteLine("Human/Dwarf/Elf/Orc");
                Console.Write("Please choose a race: ");
                player.race = Console.ReadLine().ToUpper();

                if (player.race == "HUMAN" || player.race == "DWARF" || player.race == "ELF" || player.race == "ORC")
                {
                    Console.Clear();
                    main.raceCheck = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("ERROR! Please try again.");
                }
            } while (main.raceCheck == false);
            Console.Clear();

            //Class creation
            do
            {
                Console.WriteLine("Warrior/Hunter/Mage/Assassin");
                Console.Write("Please choose a class: ");
                player.className = Console.ReadLine().ToUpper();

                if (player.className == "WARRIOR" || player.className == "HUNTER" || player.className == "MAGE" || player.className == "ASSASSIN")
                {
                    main.classCheck = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("ERROR! Please try again.");
                }
            } while (main.classCheck == false);
            Console.Clear();

            //Assigns bonuses and inventory
            classInfoToPlayer(ref player);

            //Final message
            displayFinalMessage(ref player);
        }

        static void classInfoToPlayer(ref Player player)
        {
            string jsonString;

            //Gets the location of the required JSON file for the class chosen
            jsonString = getJsonLocation("Class", player.race, player.className);
            //Deserializes the JSON file and then assigns the class info to the player class
            ClassType file = JsonConvert.DeserializeObject<ClassType>(jsonString);

            player.className = file.className;
            player.primaryShield = file.defaultShield;
            player.primaryWeapon = file.defaultWeapon;
            player.oneHandedWeapon = file.oneHandedWeapon;
            player.twoHandedWeapon = file.twoHandedWeapon;
            player.shield = file.shield;
            player.rangedWeapon = file.rangedWeapon;
            player.magicalWeapon = file.magicalWeapon;
            player.oneHandedBonus = file.oneHandedBonus;
            player.twoHandedBonus = file.twoHandedBonus;
            player.rangedBonus = file.rangedBonus;
            player.magicalBonus = file.magicalBonus;
        }

        static void displayFinalMessage(ref Player player)
        {
            string loadout;
            string playerDescription;

            Console.Write("Name: ");
            Console.WriteLine(player.name);
            Console.WriteLine();
            Console.Write("Gender: ");
            Console.WriteLine(player.gender);
            Console.WriteLine();
            Console.Write("Race: ");
            Console.WriteLine(player.race);
            Console.WriteLine();
            Console.Write("Class: ");
            Console.WriteLine(player.className);
            Console.WriteLine();
            Console.WriteLine("Your character has the following items:");
            //loadout is the string that contains a string that displays the hero's items
            loadout = getItemDescription(player.oneHandedWeapon, player.twoHandedWeapon, player.shield, player.rangedWeapon, player.magicalWeapon);
            Console.WriteLine(loadout);
            Console.WriteLine();
            Console.WriteLine("Your character has the following bonuses:");
            //playerDescription is the string that contains a string that displays the hero's race and class stat bonuses
            playerDescription = getPlayerDescription(player.oneHandedBonus, player.twoHandedBonus, player.rangedBonus, player.magicalBonus);
            Console.WriteLine(playerDescription);
            Console.WriteLine();
            Console.WriteLine("Please press enter to start our journey...");
            Console.ReadLine();
            Console.Clear();

            quest(player.name);
        }


        //--------------------------
        //CHARACTER CREATION METHODS
        //--------------------------
        public static string getPlayerDescription(int playerOneHanded, int playerTwoHanded, int playerRanged, int playerMagic)
        {
            //Formats the player's items into a readable string
            string flavourText;
            flavourText = string.Format("One Handed Weapons: {0} points\nTwo Handed Weapons: {1} points\nRanged Weapons: {2} points\nMagical Weapons: {3} points", playerOneHanded, playerTwoHanded, playerRanged, playerMagic);
            return flavourText;
        }

        public static string getItemDescription(string playerOneHandWeapon, string playerTwoHandWeapon, string playerShield, string playerRangedWeapon, string playerMagicWeapon1)
        {
            //Formats the player's race and class stat bonuses into a readable string
            string flavourText;
            flavourText = string.Format("One Handed Weapon: {0}\nTwo Handed Weapon: {1}\nShield: {2}\nRanged Weapon: {3}\nMagical Weapon: {4}", playerOneHandWeapon, playerTwoHandWeapon, playerShield, playerRangedWeapon, playerMagicWeapon1);
            return flavourText;
        }



        //----------------------------
        //RANDOM QUEST GENERATOR
        //----------------------------

        static void quest(string name)
        {
            //---------
            //VARIABLES
            //---------
            string firstNameLocation = @"Names\PeopleNames\FirstNames.Txt";
            string secondNameLocation = @"Names\PeopleNames\SecondNames.Txt";
            string fullName;
            string monsterName;
            string questDescription;

            int levelDifficulty;
            int loot = 0;

            //Calculates the quest info
            fullName = getFullName(firstNameLocation, secondNameLocation);
            levelDifficulty = getLevelDifficulty();
            loot = getLoot(levelDifficulty);
            monsterName = getMonsterName(levelDifficulty);
            questDescription = getQuestDesciption(levelDifficulty, loot, monsterName, name);

            //Prints quest info
            Console.Write("Name: ");
            Console.WriteLine(fullName);
            Console.Write("Quest Difficulty: ");
            Console.WriteLine(levelDifficulty);
            Console.Write("Gold and Experience: ");
            Console.WriteLine(loot);
            Console.Write("Monster: ");
            Console.WriteLine(monsterName);
            Console.Write("Quest Description: ");
            Console.WriteLine(questDescription);
            Console.ReadLine();
        }



        //------------------------------
        //RANDOM QUEST GENERATOR METHODS
        //------------------------------

        public static int getLevelDifficulty()
        {
            //Works out a probabilty and from that it assigns a quest difficulty

            int levelDifficulty = 0;
            int probability;

            Random random = new Random();
            probability = random.Next(0, 100);

            if (probability < 41.875)
            {
                levelDifficulty = 1;
            }
            else if (probability >= 41.875 && probability < 71.875)
            {
                levelDifficulty = 2;
            }
            else if (probability >= 71.875 && probability < 86.875)
            {
                levelDifficulty = 3;
            }
            else if (probability >= 86.875 && probability < 94.375)
            {
                levelDifficulty = 4;
            }
            else if (probability >= 94.375 && probability < 98.125)
            {
                levelDifficulty = 5;
            }
            else if (probability >= 98.125 && probability < 100)
            {
                levelDifficulty = 6;
            }

            return levelDifficulty;
        }

        public static string getFullName(string firstNameLocation, string secondNameLocation)
        {
            //Generates a random name based off a text file of first names and second names

            string fullName = null;

            Random random = new Random();

            fullName = File.ReadLines(firstNameLocation).Skip(random.Next(0, 160)).First() + " " + File.ReadLines(secondNameLocation).Skip(random.Next(0, 160)).First();
            return fullName;
        }

        public static int getLoot(int levelDifficulty)
        {
            //Works out a random loot based off level difficulty

            int loot = 0;

            Random random = new Random();

            if (levelDifficulty == 1)
            {
                loot = random.Next(10, 30);
            }
            else if (levelDifficulty == 2)
            {
                loot = levelDifficulty * random.Next(50, 100);
            }
            else if (levelDifficulty == 3)
            {
                loot = levelDifficulty * random.Next(100, 200);
            }
            else if (levelDifficulty == 4)
            {
                loot = levelDifficulty * random.Next(400, 600);
            }
            else if (levelDifficulty == 5)
            {
                loot = levelDifficulty * random.Next(1000, 2000);
            }
            else
            {
                loot = 20000;
            }

            return loot;
        }

        public static string getMonsterName(int levelDifficulty)
        {
            //Returns a random monster based off level difficulty

            Random random = new Random();

            string location = string.Format(@"Names\MonsterNames\tier{0}.txt", levelDifficulty);
            string monsterName = File.ReadLines(location).Skip(random.Next(0, 4)).First();

            return monsterName;
        }

        public static string getQuestDesciption(int levelDifficulty, int loot, string monsterName, string name)
        {
            //Returns the quest description based off the level difficulty, loot received, monster name and name of your character

            string questDescription = "";
            string location = string.Format(@"QuestTemplates\Tier{0}\Story1.txt", levelDifficulty);

            if (levelDifficulty == 1)
            {
                questDescription = string.Format(File.ReadAllText(location), monsterName, loot);
            }
            else if (levelDifficulty == 2)
            {
                questDescription = string.Format(File.ReadAllText(location), loot);
            }
            else if (levelDifficulty == 3)
            {
                questDescription = string.Format(File.ReadAllText(location), monsterName, loot);
            }
            else if (levelDifficulty == 4)
            {
                questDescription = string.Format(File.ReadAllText(location), name, monsterName, loot);
            }
            else if (levelDifficulty == 5)
            {
                questDescription = string.Format(File.ReadAllText(location), monsterName, loot);
            }
            else if (levelDifficulty == 6)
            {
                questDescription = string.Format(File.ReadAllText(location), monsterName, loot);
            }

            return questDescription;
        }



        //------------------------
        //IMPORTANT GLOBAL METHODS
        //------------------------

        public static string getJsonLocation(string fileType, string race, string classType)
        {
            //IMPORTANT METHOD!
            //Based off which sort of JSON file is being read, eg. Class or Weapon, will find the file location
            //It then reads all of the text from that JSON file and returns it as a string

            string location = "";
            string value;

            //Changes the file location based off which sort of JSON file is needing to be read
            if(fileType == "Class")
            {
                location = string.Format(@"StartingClasses\{0}.json", race + " " + classType);
            }

            //Reads all of the JSON file
            value = File.ReadAllText(location);

            return value;
        }
    }
}
