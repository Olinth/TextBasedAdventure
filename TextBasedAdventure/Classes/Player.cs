using System;
namespace TextBasedAdventure
{
    class Player
    {
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

        public enum GenderType
        {
            Male, Female
        }

        public static class RaceType
        {
            public static string Human { get; } = "HUMAN";
            public static string Dwarf { get; } = "DWARF";
            public static string Elf { get; } = "ELF";
            public static string Orc { get; } = "ORC";
        }
        public Player()
        {
            //CONSTRUCTOR IGNORE!
        }

    }
}
