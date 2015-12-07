using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DugeonJunction
{
    class Enemy
    {
        public string Name;
        public int Level;
        public int Power;
        public int Ehealth;
        public Random random = new Random();
        public Enemy(int playerLevel)
        {
            enemyName();
            int minEnemyLvl = 1;
            string name = Name;
            if ((playerLevel - 5) > 1)
            {
                minEnemyLvl = playerLevel - 5;
            }
            // set enemy level
            System.Threading.Thread.Sleep(25);
            if (playerLevel < 10)
            {
                Level = random.Next(minEnemyLvl, 10);
            }
            else
            {
                Level = random.Next(minEnemyLvl, playerLevel);
            }
            // set enemy Power
            //Power = random.Next(minEnemyLvl, playerLevel);
            Power = Convert.ToInt32(Math.Pow(Convert.ToDouble(2 * (playerLevel + 10)), 0.5));
            //Power = Convert.ToInt32(20 * Level * Math.Pow(Convert.ToDouble(Level), 0.5));
            // set enemy Health
            //Ehealth = random.Next(minEnemyLvl, playerLevel);
            //Ehealth = Convert.ToInt32(20 * Level * Math.Pow(Convert.ToDouble(Level), 0.5));
            Ehealth = Convert.ToInt32(2 * Math.Pow(Convert.ToDouble(2 * (playerLevel + 10)), 0.5));
        }
        public void enemyName()
        {
            string[] enemyName = new string[]
	        {
	            "Skeleton",
	            "Demon",
	            "Corruptor",
	            "zombie",
	            "Red Devil",
	            "Viking"
	        };
            int index = random.Next(0, enemyName.Length);
            Name = enemyName[index];
        }
        // When enemy attacks
        public int attack(){
            return Power;
        }
    }
}
