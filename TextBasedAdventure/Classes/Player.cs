using System;
namespace TextBasedAdventure
{
    class Player
    {
        public int oneHandedBonus { get; set; } = 0;
        public int twoHandedBonus { get; set; } = 0;
        public int rangedBonus { get; set; } = 0;
        public int magicalBonus { get; set; } = 0;
        public int physicalAttack { get; set; } = 0;
        public int physicalDefence { get; set; } = 0;
        public int magicalAttack { get; set; } = 0;
        public int magicalDefence { get; set; } = 0;
        public string name { get; set; } = null;
        public string gender { get; set; } = null;
        public string race { get; set; } = null;
        public string oneHandedWeapon { get; set; } = null;
        public string twoHandedWeapon { get; set; } = null;
        public string shield { get; set; } = null;
        public string rangedWeapon { get; set; } = null;
        public string magicalWeapon { get; set; } = null;
        public string defaultWeapon { get; set; } = null;
        public string defaultShield { get; set; } = null;
        public string className { get; set; } = null;
        public string primaryWeapon { get; set; } = null;
        public string primaryShield { get; set; } = null;

        public Player()
        {
            //CONSTRUCTOR IGNORE!
        }

    }
}
