using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TextBasedAdventure
{
    internal class Program
    {
        //Strings
        public static string PlayerDescription { get; set; }
        public static string Loadout { get; set; }

        //Boolean
        public static bool NameCheck { get; set; }
        public static bool GenderCheck { get; set; }
        public static bool RaceCheck { get; set; }
        public static bool ClassCheck { get; set; }

        private static void Main()
        {
            //Lists
            //Not sure if this is needed yet!
            var inventory = new List<string>();

            //Classes
            var player = new Player();
            var primaryWeapon = new Weapon();
            ChooseName(player);
            ChooseGender(player);
            ChooseRace(player);
            ChooseClass(player);

            //Assigns bonuses and inventory
            ClassInfoToPlayer(ref player);

            //Final message
            DisplayFinalMessage(ref player);
        }

        //Character creation methods.
        private static void ChooseName(Player player)
        {
            //Choose name
            var nameCheck = false;

            do
            {
<<<<<<< HEAD
                try
                {
                    Console.Write("Please choose a name: ");
                    player.Name = Console.ReadLine();
                    Console.Clear();

                    if (player.Name == null)
                        throw new Exception();
                    nameCheck = true;
                }
                catch
                {
                    Console.WriteLine("That was not a valid name!");
=======
                Console.WriteLine("Male/Female");
                Console.Write("Please choose a gender: ");
                player.gender = Console.ReadLine().ToUpper();

                if (player.gender == "MALE" || player.gender == "FEMALE")
                {
                    main.genderCheck = true;
>>>>>>> origin/George
                }
            } while (nameCheck == false);
        }

        private static void ChooseGender(Player player)
        {
            //Male or Female
            do
            {
                Console.WriteLine("Male [1] / Female [2]");
                Console.Write("Please choose a gender: ");
                var genderInput = Console.ReadLine();
                switch (genderInput)
                {
                    case "1":
                        player.Gender = Player.GenderType.Male;
                        GenderCheck = true;
                        break;
                    case "2":
                        player.Gender = Player.GenderType.Female;
                        GenderCheck = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("ERROR! Please try again.");
                        break;
                }
<<<<<<< HEAD
            } while (GenderCheck == false);

=======
            } while (main.genderCheck == false);
>>>>>>> origin/George
            Console.Clear();
        }

        private static void ChooseRace(Player player)
        {
            //Race creation
            do
            {
                RaceCheck = true;
                Console.WriteLine("Human [1] / Dwarf [2] / Elf [3] / Orc [4]");
                Console.Write("Please choose a race: ");
                var raceInput = Console.ReadLine()?.ToUpper();

                switch (raceInput)
                {
                    case "1":
                        player.Race = Player.RaceType.Human;
                        Console.Clear();
                        break;
                    case "2":
                        player.Race = Player.RaceType.Dwarf;
                        Console.Clear();
                        break;
                    case "3":
                        player.Race = Player.RaceType.Elf;
                        Console.Clear();
                        break;
                    case "4":
                        player.Race = Player.RaceType.Orc;
                        Console.Clear();
                        break;
                    default:
                        RaceCheck = false;
                        Console.Clear();
                        Console.WriteLine("ERROR! Please try again.");
                        break;
                }
            } while (RaceCheck == false);

            Console.Clear();
        }

        private static void ChooseClass(Player player)
        {
            //Class creation
            do
            {
                Console.WriteLine("Warrior/Hunter/Mage/Assassin");
                Console.Write("Please choose a class: ");
                player.ClassName = Console.ReadLine()?.ToUpper();

                if ((player.ClassName == "WARRIOR") || (player.ClassName == "HUNTER") || (player.ClassName == "MAGE") ||
                    (player.ClassName == "ASSASSIN"))
                {
                    ClassCheck = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("ERROR! Please try again.");
                }
            } while (ClassCheck == false);
            Console.Clear();
        }

        private static void ClassInfoToPlayer(ref Player player)
        {
            //Gets the location of the required JSON file for the class chosen
            var jsonString = GetJsonLocation("Class", player.Race, player.ClassName);
            //Deserializes the JSON file and then assigns the class info to the player class
            var file = JsonConvert.DeserializeObject<ClassType>(jsonString);

            player.ClassName = file.className;
            player.PrimaryShield = file.defaultShield;
            player.PrimaryWeapon = file.defaultWeapon;
            player.OneHandedWeapon = file.oneHandedWeapon;
            player.TwoHandedWeapon = file.twoHandedWeapon;
            player.Shield = file.shield;
            player.RangedWeapon = file.rangedWeapon;
            player.MagicalWeapon = file.magicalWeapon;
            player.OneHandedBonus = file.oneHandedBonus;
            player.TwoHandedBonus = file.twoHandedBonus;
            player.RangedBonus = file.rangedBonus;
            player.MagicalBonus = file.magicalBonus;
        }

        private static void DisplayFinalMessage(ref Player player)
        {
            Console.Write("Name: ");
            Console.WriteLine(player.Name);
            Console.WriteLine();
            Console.Write("Gender: ");
            Console.WriteLine(player.Gender);
            Console.WriteLine();
            Console.Write("Race: ");
            Console.WriteLine(player.Race);
            Console.WriteLine();
            Console.Write("Class: ");
            Console.WriteLine(player.ClassName);
            Console.WriteLine();
            Console.WriteLine("Your character has the following items:");
            //loadout is the string that contains a string that displays the hero's items
            var loadout = GetItemDescription(player.OneHandedWeapon, player.TwoHandedWeapon, player.Shield,
                player.RangedWeapon, player.MagicalWeapon);
            Console.WriteLine(loadout);
            Console.WriteLine();
            Console.WriteLine("Your character has the following bonuses:");
            //playerDescription is the string that contains a string that displays the hero's race and class stat bonuses
            var playerDescription = GetPlayerDescription(player.OneHandedBonus, player.TwoHandedBonus,
                player.RangedBonus, player.MagicalBonus);
            Console.WriteLine(playerDescription);
            Console.WriteLine();
            Console.WriteLine("Please press enter to start our journey...");
            Console.ReadLine();
            Console.Clear();

            Quest(player.Name);
        }


        public static string GetPlayerDescription(int playerOneHanded, int playerTwoHanded, int playerRanged,
            int playerMagic)
        {
            //Formats the player's items into a readable string
            var flavourText =
                $"One Handed Weapons: {playerOneHanded} points\n" +
                $"Two Handed Weapons: {playerTwoHanded} points\n" +
                $"Ranged Weapons: {playerRanged} points\n" +
                $"Magical Weapons: {playerMagic} points";
            return flavourText;
        }

        public static string GetItemDescription(string playerOneHandWeapon, string playerTwoHandWeapon,
            string playerShield, string playerRangedWeapon, string playerMagicWeapon1)
        {
            //Formats the player's race and class stat bonuses into a readable string
            var flavourText =
                string.Format(
                    "One Handed Weapon: {0}\nTwo Handed Weapon: {1}\nShield: {2}\nRanged Weapon: {3}\nMagical Weapon: {4}",
                    playerOneHandWeapon, playerTwoHandWeapon, playerShield, playerRangedWeapon, playerMagicWeapon1);
            return flavourText;
        }


        //RANDOM QUEST GENERATOR.
        private static void Quest(string name)
        {
            //---------
            //VARIABLES
            //---------
            var firstNameLocation = @"Names\PeopleNames\FirstNames.Txt";
            var secondNameLocation = @"Names\PeopleNames\SecondNames.Txt";

            //Calculates the quest info
            var fullName = GetFullName(firstNameLocation, secondNameLocation);
            var levelDifficulty = GetLevelDifficulty();
            var loot = GetLoot(levelDifficulty);
            var monsterName = GetMonsterName(levelDifficulty);
            var questDescription = GetQuestDesciption(levelDifficulty, loot, monsterName, name);

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

        //RANDOM QUEST GENERATOR METHODS.
        public static int GetLevelDifficulty()
        {
            //Works out a probabilty and from that it assigns a quest difficulty

            var levelDifficulty = 0;

            var random = new Random();
            var probability = random.Next(0, 100);

            if (probability < 41.875)
                levelDifficulty = 1;
            else if ((probability >= 41.875) && (probability < 71.875))
                levelDifficulty = 2;
            else if ((probability >= 71.875) && (probability < 86.875))
                levelDifficulty = 3;
            else if ((probability >= 86.875) && (probability < 94.375))
                levelDifficulty = 4;
            else if ((probability >= 94.375) && (probability < 98.125))
                levelDifficulty = 5;
            else if ((probability >= 98.125) && (probability < 100))
                levelDifficulty = 6;

            return levelDifficulty;
        }

        public static string GetFullName(string firstNameLocation, string secondNameLocation)
        {
            //Generates a random name based off a text file of first names and second names

            var random = new Random();

            var fullName = File.ReadLines(firstNameLocation).Skip(random.Next(0, 160)).First() + " " +
                           File.ReadLines(secondNameLocation).Skip(random.Next(0, 160)).First();
            return fullName;
        }

        public static int GetLoot(int levelDifficulty)
        {
            //Works out a random loot based off level difficulty

            int loot;

            var random = new Random();

            switch (levelDifficulty)
            {
                case 1:
                    loot = random.Next(10, 30);
                    break;
                case 2:
                    loot = levelDifficulty*random.Next(50, 100);
                    break;
                case 3:
                    loot = levelDifficulty*random.Next(100, 200);
                    break;
                case 4:
                    loot = levelDifficulty*random.Next(400, 600);
                    break;
                case 5:
                    loot = levelDifficulty*random.Next(1000, 2000);
                    break;
                default:
                    loot = 20000;
                    break;
            }

            return loot;
        }

        public static string GetMonsterName(int levelDifficulty)
        {
            //Returns a random monster based off level difficulty

            var random = new Random();

            var location = $@"Names\MonsterNames\tier{levelDifficulty}.txt";
            var monsterName = File.ReadLines(location).Skip(random.Next(0, 4)).First();

            return monsterName;
        }

        public static string GetQuestDesciption(int levelDifficulty, int loot, string monsterName, string name)
        {
            //Returns the quest description based off the level difficulty, loot received, monster name and name of your character

            var questDescription = "";
            var location = $@"QuestTemplates\Tier{levelDifficulty}\Story1.txt";

            if (levelDifficulty == 1)
                questDescription = string.Format(File.ReadAllText(location), monsterName, loot);
            else if (levelDifficulty == 2)
                questDescription = string.Format(File.ReadAllText(location), loot);
            else if (levelDifficulty == 3)
                questDescription = string.Format(File.ReadAllText(location), monsterName, loot);
            else if (levelDifficulty == 4)
                questDescription = string.Format(File.ReadAllText(location), name, monsterName, loot);
            else if (levelDifficulty == 5)
                questDescription = string.Format(File.ReadAllText(location), monsterName, loot);
            else if (levelDifficulty == 6)
                questDescription = string.Format(File.ReadAllText(location), monsterName, loot);

            return questDescription;
        }


        //IMPORTANT GLOBAL METHODS.
        public static string GetJsonLocation(string fileType, string race, string classType)
        {
            //IMPORTANT METHOD!
            //Based off which sort of JSON file is being read, eg. Class or Weapon, will find the file location
            //It then reads all of the text from that JSON file and returns it as a string

            var location = "";

            //Changes the file location based off which sort of JSON file is needing to be read
            if (fileType == "Class")
                location = $@"StartingClasses\{race + " " + classType}.json";

            //Reads all of the JSON file
            var value = File.ReadAllText(location);

            return value;
        }
    }
}