namespace TextBasedAdventure
{
    class ClassType
    {
        private string ClassName;
        private string OneHandedWeapon;
        private string TwoHandedWeapon;
        private string Shield;
        private string RangedWeapon;
        private string MagicalWeapon;
        private string DefaultWeapon;
        private string DefaultShield;
        private int OneHandedBonus;
        private int TwoHandedBonus;
        private int RangedBonus;
        private int MagicalBonus;

        public string className { get; set; }
        public string oneHandedWeapon { get; set; }
        public string twoHandedWeapon { get; set; }
        public string shield { get; set; }
        public string rangedWeapon { get; set; }
        public string magicalWeapon { get; set; }
        public string defaultWeapon { get; set; }
        public string defaultShield { get; set; }
        public int oneHandedBonus { get; set; }
        public int twoHandedBonus { get; set; }
        public int rangedBonus { get; set; }
        public int magicalBonus { get; set; }

        public ClassType()
        {
            //CONSTRUCTOR IGNORE!
        }
    }
}
