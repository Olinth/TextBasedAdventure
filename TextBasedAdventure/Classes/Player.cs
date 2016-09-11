using System;
namespace TextBasedAdventure
{
    class Player
    {
        private int OneHandedBonus = 0;
        private int TwoHandedBonus = 0;
        private int RangedBonus = 0;
        private int MagicalBonus = 0;
        private int PhysicalAttack = 0;
        private int PhysicalDefence = 0;
        private int MagicalAttack = 0;
        private int MagicalDefence = 0;
        private string Name = null;
        private string Gender = null;
        private string Race = null;
        private string OneHandedWeapon = null;
        private string TwoHandedWeapon = null;
        private string Shield = null;
        private string RangedWeapon = null;
        private string MagicalWeapon = null;
        private string DefaultWeapon = null;
        private string DefaultShield = null;
        private string ClassName = null;
        private string PrimaryWeapon = null;
        private string PrimaryShield = null;

        public int oneHandedBonus { get; set; }
        public int twoHandedBonus { get; set; }
        public int rangedBonus { get; set; }
        public int magicalBonus { get; set; }
        public int physicalAttack { get; set; }
        public int physicalDefence { get; set; }
        public int magicalAttack { get; set; }
        public int magicalDefence { get; set; }
        public string name { get; set; } 
        public string gender { get; set; }
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

        public Player()
        {
            //CONSTRUCTOR IGNORE!
        }

    }
}
