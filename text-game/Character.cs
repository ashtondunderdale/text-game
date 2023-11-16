// Character.cs

namespace text_game
{
    internal class Character
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Level { get; private set; }
        public List<string> Inventory { get; private set; }
        private Weapon EquippedWeapon { get; set; } 

        public Character(string name, int health, int level, List<string> inventory)
        {
            Name = name;
            Health = health;
            Level = level;
            Inventory = inventory;
            EquippedWeapon = new Unequipped(); 
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }

        public int Attack()
        {
            return EquippedWeapon.AttackDamage;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public void EquipWeapon(Weapon weapon)
        {
            EquippedWeapon = weapon;
        }
    }
}
