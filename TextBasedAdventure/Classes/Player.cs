using System;
namespace TextBasedAdventure
{
    class Player
    {
<<<<<<< HEAD
        public int OneHandedBonus { get; set; }
        public int TwoHandedBonus { get; set; }
        public int RangedBonus { get; set; }
        public int MagicalBonus { get; set; }
        public int PhysicalAttack { get; set; }
        public int PhysicalDefence { get; set; }
        public int MagicalAttack { get; set; }
        public int MagicalDefence { get; set; }
        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public string Race { get; set; }
        public string OneHandedWeapon { get; set; }
        public string TwoHandedWeapon { get; set; }
        public string Shield { get; set; }
        public string RangedWeapon { get; set; }
        public string MagicalWeapon { get; set; }
        public string DefaultWeapon { get; set; }
        public string DefaultShield { get; set; }
        public string ClassName { get; set; }
        public string PrimaryWeapon { get; set; }
        public string PrimaryShield { get; set; }
=======
        public int oneHandedBonus { get; set; }
        public int twoHandedBonus { get; set; }
        public int rangedBonus { get; set; }
        public int magicalBonus { get; set; }
        public int physicalAttack { get; set; }
        public int physicalDefence { get; set; }
        public int magicalAttack { get; set; }
        public int magicalDefence { get; set; }
        public string name { get; set; } 
        public string race { get; set; }
        public string oneHandedWeapon { get; set; }
        public string twoHandedWeapon { get; set; }
        public string shield { get; set; }
        public string rangedWeapon { get; set; }
        public string magicalWeapon { get; set; }
        public string defaultWeapon { get; set; }
        public string defaultShield { get; set; }
        public string className { get; set; }
        public string primaryWeapon { get; set; }
        public string primaryShield { get; set; }
        public GenderType gender { get; set; }
>>>>>>> origin/George

        public enum GenderType
        {
            Male, Female
        }

<<<<<<< HEAD
        public static class RaceType
        {
            public static string Human { get; } = "HUMAN";
            public static string Dwarf { get; } = "DWARF";
            public static string Elf { get; } = "ELF";
            public static string Orc { get; } = "ORC";
        }
=======
>>>>>>> origin/George
        public Player()
        {
            //CONSTRUCTOR IGNORE!
        }

    }
}
