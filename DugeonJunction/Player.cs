using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DugeonJunction
{
    class Player
    {
        double currentLevel;
        string Weapon;
        string Name;
        int Score;
        int Health;
        int Money;
        int wPower;
        // public variable that stores the level of the player
        public int Level;
        public Player()
        {

        }
        public Player(string name, string weapon, int level, int money, int score)
        {
            Score = score;
            weaponPower(weapon);
            Money = money;
            Level = level;
            Name = name;
            Weapon = weapon;
        }
        // set stats
        public void setStats(int score, int level, string weapon)
        {
            Weapon = weapon;
            Score = score;
            Level = getLevel(level, score);
        }
        // view player stats
        public void viewStats(int health, int money, string name)
        {
            Money = money;
            // clear Console
            Console.Clear();
            string quit;
            Health = health;
            do
            {
            Console.WriteLine("Player name: {0}", name);
            Console.WriteLine("Player score: {0}", Score);
            Console.WriteLine("Player level: {0}", Level);
            Console.WriteLine("Player Weapon: {0}", Weapon);
            Console.WriteLine("Current Health: {0}", health);
            Console.WriteLine("Wallet: {0}", Money);
            Console.WriteLine("Press 'b' to go back");
                quit = Console.ReadLine();
            }while( quit != "b");
            Console.Clear();
        }
        // View Player health During battle
        public void viewHealth(Enemy enemy, int health, string name)
        {
            Health = health;
            Console.WriteLine("{0}'s took damage for {1}", name, enemy.Power);
            Console.WriteLine("{0}'s Current Health: {1}", name, health);
        }
        //check if player has leveled up
        public int getLevel(double current, int score){
            Level = Convert.ToInt32(current);
            currentLevel = Math.Pow(score, 0.5);
            if ((currentLevel - 1) > Level)
            {
                Level++;
                Health += 25;
                Money += 100;
                Console.WriteLine("Congratulation! You have leveled up to level {0}", Level);
            }
            return Level;
        }
        // setHealth Depending on the player level
        public int setHealth(int level)
        {
            Health = 80 + (level * 10);
            return Health;
        }

        // check the weapon power
        public void weaponPower(string weapon)
        {
            switch (weapon)
            {
                case "Wooden Sword": wPower = 6;
                    break;
                case "Katana": wPower = 12;
                    break;
                case "Night's Sword": wPower = 18;
                    break;
                case "Fire Sword": wPower = 26;
                    break;
                case "Titanium Sword": wPower = 35;
                    break;
                case "Stardoom Sword": wPower = 50;
                    break;
            }
        }
        public int attack()
        {
            return wPower;
        }
    }
}