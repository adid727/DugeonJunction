using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DugeonJunction
{
    class Program
    {
        /*
         * test
         */
        public static int k = 0;
        /*
         * test
         */
        public static string weapon = "none";
        public static int playerLevel = 1;
        public static int score = 0;
        public static int money = 100;
        public static int Health = 100;
        public static string name;
        public static Player player = new Player();
        public static Random random = new Random();
        public static int numberOfEnemies = random.Next(1, 4);
        public static int totalEnemies = numberOfEnemies;
        // create 1-4 enemies
        public static Enemy[] enemyNumber = new Enemy[numberOfEnemies];
        static void Main(string[] args)
        {
            // Play Music
            //play game music
            System.Media.SoundPlayer mediaPlayer = new System.Media.SoundPlayer();
            mediaPlayer.SoundLocation = "StarCommander1.wav";
            mediaPlayer.PlayLooping();
            // run game
            game();
        }
        public static void game(){
            var r = new Func<string>(() => Console.ReadLine());
            r();
            string c = "y";
            // create a player object or load save file 
            if (new FileInfo("save.txt").Length == 0)
            {
                Console.Clear();
                // set Heallth
                Health = player.setHealth(playerLevel);
                c = "";
                Console.WriteLine("Hello Traveler What do you call youself?");
                name = Console.ReadLine();
                // empty
                player = new Player(name, weapon, playerLevel, money, score);

                Console.WriteLine("{0}! What a wonderful name! Maybe I should name my goldfish {0}! Anyhow... (enter to continue)", name, name);
                Console.Read();
                Console.WriteLine("These are some dangerous woods you are travelling in…");
                Console.Read();
                Console.WriteLine("Don’t tell me you are here to venture into the dungeon of doom!!! (play game y/n)?");
                c = Console.ReadLine();
                while (c != "y" && c != "n")
                {
                    Console.WriteLine("I am sorry i did not quite catch that, could you repeat please (play game y/n)?");
                    c = Console.ReadLine();
                }
                if (c == "n")
                {
                    Console.WriteLine("I knew it. Good Bye!");
                    System.Threading.Thread.Sleep(825);
                    Environment.Exit(0);
                }
            }
            else
            {
                // load save file
                string line;
                string file = "save.txt";
                StreamReader save = new StreamReader(file);
                int i = 0;
                while (!save.EndOfStream)
                {
                    if (i == 0)
                    name = save.ReadLine();
                    else if (i == 1)
                    score = Convert.ToInt32(save.ReadLine());
                    else if (i == 2)
                    {
                        playerLevel = Convert.ToInt32(save.ReadLine());
                    }
                    else if (i == 3)
                        weapon = save.ReadLine();
                    else if (i == 4)
                        Health = Convert.ToInt32(save.ReadLine());
                    else if (i == 5)
                        money = Convert.ToInt32(save.ReadLine());
                    i++;
                    //Console.WriteLine(line);
                }
                save.Close();
            }
            
            //clear console
            Console.Clear();

            // Game loop
            while (c == "y")
            {
                // save game
                save();
               // store current level
                int currentLevel = playerLevel;
                // check if player has leveled up
                    playerLevel = player.getLevel(playerLevel, score);
                // set health if player has leveled up
                if (currentLevel != playerLevel)
                {
                    Health = player.setHealth(playerLevel);
                }
                //call menu
                Console.WriteLine("Where do you wanna go?");
                int choice = Menu();
                switch (choice)
                {
                    case 1: if (weapon == "none")
                        {
                            Console.Clear();
                            Console.WriteLine("Don't be absurd! you can't fight without a weapon. Please go to shop and buy a weapon first");
                        }
                        //****************** ELSE FIGHT **********************
                        else
                        {
                            // initialize enemies
                            int h = 0;
                        //test
                            numberOfEnemies = random.Next(1, 4);
                            totalEnemies = numberOfEnemies;
                            enemyNumber = new Enemy[numberOfEnemies];
                        //test
                            //totalEnemies = numberOfEnemies;
                            do
                            {
                                enemyNumber[h] = new Enemy(playerLevel);
                                h++;
                                System.Threading.Thread.Sleep(25);
                            } while (h != numberOfEnemies);
                            // clear Console
                            Console.Clear();
                            Dugeon();
                        }
                        break;
                    case 2: Shop();
                        break;
                    case 3: player.setStats(score, playerLevel, weapon);
                            player.viewStats(Health, money, name);
                        break;
                    case 4: // save then exit
                        save();
                        Environment.Exit(0);
                        break;
                    case 5:
                        string CS = "no";
                        
                            Console.WriteLine("Are you sure you want to delete your save file? Your record will be deleted forever! (y/n)");
                            CS = Console.ReadLine();
                        while(CS != "y" && CS != "n"){
                            Console.WriteLine("I did not get that. Delete save file? (y/n)?");
                            CS = Console.ReadLine();
                        }
                        if (CS == "y"){
                        deleteSave();
                        game();
                        }
                        break;
                // clear console
                        Console.Clear();
                // set Health
                Health = player.setHealth(playerLevel);
                c = "";
                Console.WriteLine("Hello Traveler What do you call youself?");
                name = Console.ReadLine();
                // empty
                player = new Player(name, weapon, playerLevel, money, score);

                Console.WriteLine("{0}! What a wonderful name! Maybe I should name my goldfish {0}! Anyhow... (enter to continue)", name, name);
                Console.Read();
                Console.WriteLine("These are some dangerous woods you are travelling in…");
                Console.Read();
                Console.WriteLine("Don’t tell me you are here to venture into the dungeon of doom!!! (play game y/n)?");
                c = Console.ReadLine();
                while (c != "y" && c != "n")
                {
                    Console.WriteLine("I am sorry i did not quite catch that, could you repeat please (play game y/n)?");
                    c = Console.ReadLine();
                }
                if (c == "n")
                {
                    Console.WriteLine("I knew it. Good Bye!");
                    System.Threading.Thread.Sleep(825);
                    Environment.Exit(0);
                }
                        // clear Console
                        Console.Clear();
                        break;
                        
                }
            }
        }
        // menu function
        public static int Menu()
        {
            // check if player has leveled up
            playerLevel = player.getLevel(playerLevel, score);
            string choice = "";
            int select = 4;
            Console.WriteLine("1- Go to Dungeon");
            Console.WriteLine("2- Go to Shop");
            Console.WriteLine("3- View Player stats");
            Console.WriteLine("4- Quit");
            Console.WriteLine("5- Delete Save File");
            Console.Out.Flush();
            try
                  {
                     do
                    {
                    
                        choice = Console.ReadLine();
                        select = int.Parse(choice);
                    } while (select < 1 || select > 5);
            } catch
                    {
                        choice = "";
                        select = 0;
                        Console.Clear();
                        Console.WriteLine("Wrong input");
                        Console.WriteLine("Where do you wanna go?");
                        Menu();
                    }
            
            
            return select;
        }
        // Shop
        public static void Shop()
        {
            // clear Console
            Console.Clear();
            string choice = "";
            string input;
            int[] price1 = {100, 250, 400, 500, 750, 1000, 40, 100};
            Console.WriteLine("Your Current Wallet has {0}", money);
            Console.WriteLine("*********************************************");
            Console.WriteLine("What do you want to buy? (b to go back to main menu)");
            Console.WriteLine("*****************Weapons*********************");
            Console.WriteLine("1- Wooden Sword $100");
            Console.WriteLine("2- Katana $250");
            Console.WriteLine("3- Night's Sword $400");
            Console.WriteLine("4- Fire Sword $500");
            Console.WriteLine("5- Titanium Sword $750");
            Console.WriteLine("6- Stardoom Sword $1000");
            Console.WriteLine("****************Postions*********************");
            Console.WriteLine("7- Postion $120");
            Console.WriteLine("8- Super Postion $250");
            do
            {
                input = Console.ReadLine();
            } while (input != "8" && input != "7" && input != "6" && input != "5" && input != "4" && input != "3" && input != "2" && input != "1" && input != "b");
            if (input != "b")
            {
                if (money < price1[Int32.Parse(input)-1])
                {
                    if (Int32.Parse(input) < 6)
                        Console.WriteLine("You do not have the money to buy that weapon! (enter to continue)");
                    else
                        Console.WriteLine("Not Enough Money! (enter to continue)");
                    Console.ReadLine();
                    Shop();
                }
                else if (money >= price1[Int32.Parse(input) - 1])
                { 
                    money -= price1[Int32.Parse(input) - 1];
                    switch (input)
                    {
                        case "1": weapon = "Wooden Sword";
                            break;
                        case "2": weapon = "Katana";
                            break;
                        case "3": weapon = "Night's Sword";
                            break;
                        case "4": weapon = "Fire Sword";
                            break;
                        case "5": weapon = "Titanium Sword";
                            break;
                        case "6": weapon = "Stardoom Sword";
                            break;
                        case "7": Health += 30;
                            break;
                        case "8": Health += 80;
                            break;
                    }
                    Console.WriteLine("You bought a {0} for {1}! You have now ${2} remaining", weapon, price1[Int32.Parse(input) - 1], money);
                    Console.ReadLine();
                }
            }
            
            //clear console
            Console.Clear();
        }

        public static void Dugeon(){
            // check to see if the player inputed the right name
            bool check = false;
            // int i to store enemies during the loop
            int i = 0;
            int enemies = numberOfEnemies;
            // Create the fight screen
            Console.Clear();
            while (enemies > 0)
            {
                //test
                k = 0;
                //test
                Console.WriteLine(enemyNumber[i].Name);
                Console.WriteLine("level: {0}", enemyNumber[i].Level);
                Console.WriteLine("Power: {0}", enemyNumber[i].Power);
                Console.WriteLine("Health: {0}", enemyNumber[i].Ehealth);
                i++;
                enemies--;
            }
            i--;
            bool iterate = true;
            while (totalEnemies > 0)
            {
            Console.WriteLine("Enter the name of the enemy you want to attack:");
            string eName = Console.ReadLine();
            int A = 0;
            bool full = false;
            while (!full)
            {
                A = 0;
                foreach (object str in enemyNumber)
                {
                    if (eName == enemyNumber[A].Name)
                    {
                        full = true;
                    }
                    A++;
                }
                if (!full)
                {
                    Console.WriteLine("You typed the Wrong Enemy Name! Please Try again");
                    eName = Console.ReadLine();
                    // Clear the last question only
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    ClearCurrentConsoleLine();
                }
            }

            //check if the player has inputed the right name
            //numberOfEnemies++;
            //enemies++;
            int x = 0;
            // bool to make sure the player attacks only one enemy at a time
            bool one = false;
            while (x != enemyNumber.Length && one== false)
            {
                if (eName == enemyNumber[enemies].Name)
                {
                    // attack
                    player.weaponPower(weapon);
                    int damage = player.attack();
                    enemyNumber[enemies].Ehealth -= damage;
                    Console.WriteLine("Player {0} attacked for {1} damage!", name, damage);
                    // enemy already took damage and turn is done
                    one = true;
                    if (enemyNumber[enemies].Ehealth <= 0)
                    {

                        Console.WriteLine("Enemy {0} is dead! Press enter to continue...", eName);
                        numberOfEnemies--;
                        Console.ReadLine();
                        // Clear the battle log only
                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                        //increase score
                        score++;
                        // increase money
                        money += 5;
                        enemyNumber = RemoveIndices(enemyNumber, enemies);
                        // max enemies is one less now
                        totalEnemies--;
                        enemies = numberOfEnemies;
                        iterate = false;
                    }
                    check = true;
                }
                x++;
                if (iterate == true)
                {
                    enemies++;
                    i--;
                }
                /*
                if (i < 0 && !check)
                {
                    Console.WriteLine("You typed the Wrong Enemy Name! Please Try again");
                    i = enemies;
                    enemies = 0;
                }
                 */
            }
            // enemy attack
            int v = 0;
            while (v != enemyNumber.Length)
            {
                if (enemyNumber[v].Ehealth > 0)
                {
                    Health -= enemyNumber[v].attack();
                    Console.WriteLine("enemy {0} attacked for {1} damage!", enemyNumber[v].Name, enemyNumber[v].Power);
                    player.viewHealth(enemyNumber[v], Health, name);
                    Console.WriteLine("(enter to continue)");
                    Console.ReadLine();
                    // Clear the battle log only
                    Console.SetCursorPosition(0, Console.CursorTop - 5);
                    ClearCurrentConsoleLine();
                }
                v++;
            }
                // see if there are still enemies left
           // bool left = false;
            v = 0;
            while (v != enemyNumber.Length)
            {
                if (enemyNumber[v].Ehealth > 0)
                {
                    //left = true;
                    Dugeon();
                }
            }

            // clear Console
            Console.Clear();
            }
            /*
            if (totalEnemies == 0 && k == 1)
            {
                Console.WriteLine("Done: {0}", k);
             */
                Array.Clear(enemyNumber, 0, enemyNumber.Length);
            /*
                numberOfEnemies = random.Next(1, 4);
                totalEnemies = numberOfEnemies;
                enemyNumber = new Enemy[numberOfEnemies];
             */
            //}
        }

        // test remove at
        public static Enemy[] RemoveIndices(Enemy[] IndicesArray, int RemoveAt)
        {
            Enemy[] newIndicesArray = new Enemy[IndicesArray.Length - 1];

            int i = 0;
            int j = 0;
            while (i < IndicesArray.Length)
            {
                if (i != RemoveAt)
                {
                    newIndicesArray[j] = IndicesArray[i];
                    j++;
                }

                i++;
            }

            return newIndicesArray;
        }
        public static void save(){
                        string file = "save.txt";
                        StreamWriter save = new StreamWriter(file, false);
                        save.WriteLine(name);
                        save.WriteLine(score);
                        save.WriteLine(playerLevel);
                        save.WriteLine(weapon);
                        save.WriteLine(Health);
                        save.WriteLine(money);
                        save.Close();
        }
        public static void deleteSave()
        {
                        name = "";
                        weapon = "none";
                        playerLevel = 1;
                        money = 100;
                        score = 0;
                        player = new Player(name, weapon, playerLevel, money, score);
                        File.WriteAllText(@"save.txt", String.Empty);
                        //System.IO.File.WriteAllBytes("save.txt", new byte[0]);
        }
        // clear only the battle log function
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
