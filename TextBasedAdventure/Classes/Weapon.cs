namespace TextBasedAdventure
{
    class Weapon : Item
    {
        private string PhysicalAttack;
        private string MagicalAttack;
        private string PhysicalDefence;
        private string MagicalDefence;

        public string physicalAttack { get; set; }
        public string magicalAttack { get; set; }
        public string physicalDefence { get; set; }
        public string magicalDefence { get; set; }

        public Weapon()
        {
            //CONSTRUCTOR IGNORE!
        }
    }
}
