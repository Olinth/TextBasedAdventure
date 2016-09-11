using System;
namespace TextBasedAdventure
{
    class Player
    {
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

        public enum GenderType
        {
            Male, Female
        }

        public Player()
        {
            //CONSTRUCTOR IGNORE!
        }

    }
}
