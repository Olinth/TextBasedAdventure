namespace TextBasedAdventure
{
    class ClassType
    {
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
