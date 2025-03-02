using System;

class Player {
    private int health = 150;
    private int maxHealth = 150;
    private int attackDamage = 15;
    private int healingCapacity = 10;

    public void SpawnPlayer()
    {
        Console.WriteLine("=================================");
        Console.WriteLine("\t  DOUGH MASTER: GUARDIAN OF THE GOLDEN CRUST");
        Console.WriteLine("=================================\n");
        Console.WriteLine("Dough Master: That scoundrel won't escape with my creation\n");
    }
    
    public int Health
    {
        get
        {
            return health;
        }
        
        private set
        {
            if(value < 0)
            {
                health = 0;
            }
            else if(value > maxHealth)
            {
                health = maxHealth;
            }
            else {
                health = value;
            }
        }
    }
    
    public Player()
    {
        SpawnPlayer();
    }
    
    private int generateRandomNumberInRange(int min, int max)
    {
        Random rand = new Random();
        int randomNumber = rand.Next(min, max+1);
        return randomNumber;
    }
    
    public int CalculateTotalDamage()
    {
        int additionalDamage = generateRandomNumberInRange(3,12);
        int totalDamage = attackDamage + additionalDamage;
        return totalDamage;
    }
    
    public void ShowAttackDamage(int totalDamage)
    {
        Console.WriteLine("BATTLE");
        Console.WriteLine("Dough Master dealt " +totalDamage+ " damage to Crust Bandit");
        Console.WriteLine("----------------------------------");
    }
    
    public void TakeDamage(int damageRecieved) => Health -= damageRecieved;
    
    public int CalculateTotalHeal()
    {
        int additionalHeal = generateRandomNumberInRange(3,12);
        int totalHeal = additionalHeal + healingCapacity;
        return totalHeal;
    }
    
    public void Heal(int healAmount) => Health += healAmount;
    
    public void ShowHeal(int totalHeal)
    {
        if(Health >= maxHealth)
        {
            Console.WriteLine("Dough Master is at max health and is ready for anything!");
            Console.WriteLine("-----------------------------------");
        }
        else {
            Console.WriteLine("Heal!");
            Console.WriteLine("Dough Master healed for " +totalHeal+ " health");
            Console.WriteLine("-----------------------------------");
        }
    }
    
    public void DisplayPlayerStats()
    {
        Console.WriteLine("DOUGH MASTER STATS");
        Console.WriteLine("Health: "+Health +"/" + maxHealth);
        Console.WriteLine("Dough Slapper: " +attackDamage);
        Console.WriteLine("Espresso Shot: " +healingCapacity);
        Console.WriteLine("Dough Slapper Boost: 3 to 12");
        Console.WriteLine("Espresso Shot boost: 3 to 12");
    }
}

class Enemy 
{
    private int health = 150;
    private int attackDamage = 15;
    private int maxHealth = 150;
    
    public int Health
    {
        get
        {
            return health;
        }
        
        private set
        {
            if(value < 0)
            {
                health = 0;
            }
            else if(value > maxHealth)
            {
                health = maxHealth;
            }
            else {
                health = value;
            }
        }
    }
    
    public void SpawnEnemy()
    {
        Console.WriteLine("=================================");
        Console.WriteLine("\t  CRUST BANDIT: NEMESIS OF ITALIAN CUISINE");
        Console.WriteLine("=================================\n");
        Console.WriteLine("Crust Bandit: You'll neevr catch me flour face!\n");
    }
    
    public Enemy()
    {
        SpawnEnemy();
    }
    
    private int generateRandomNumberInRange(int min, int max)
    {
        Random rand = new Random();
        int randomNumber = rand.Next(min, max+1);
        return randomNumber;
    }
    
    public int CalculateTotalDamage()
    {
        int additionalDamage = generateRandomNumberInRange(3,12);
        int totalDamage = attackDamage + additionalDamage;
        return totalDamage;
    }
    
    public void ShowAttackDamage(int totalDamage)
    {
        Console.WriteLine("BATTLE");
        Console.WriteLine("Crust Bandit dealt " +totalDamage+ " damage to Dough Master!");
        Console.WriteLine("----------------------------------");
    }
    
    public void TakeDamage(int damageRecieved) => Health -= damageRecieved;
    
    public void DisplayEnemyStats()
    {
        Console.WriteLine("CRUST BANDIT STATS");
        Console.WriteLine("Health: "+Health+ "/" +maxHealth);
        Console.WriteLine("Sneaky Jab: "+attackDamage);
        Console.WriteLine("Sneaky Jab Boost: 3 to 12");
    }
}

class Game
{
    Player player;
    Enemy enemy;
    bool IsGameExited = false;
    
    private void DisplayGameStory()
    {
        Console.Clear();
        Console.WriteLine("==================================");
        Console.WriteLine("\t MIDNIGHT PIZZA FIGHT");
        Console.WriteLine("==================================\n");

        Console.WriteLine("In a bustling pizzeria of a busy friday night...");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("You, the Dough Master, created your magnum opus - \n the perfect pizza. Suddenly, a sneaky Crust Bandit \n snatches your masterpiece!");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Fueled by passion for your craft, you give chase...");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Through winding alleys and crowded streets, you \n pursue the pizza pilferer. Finally, the thief is \n cornered in dead-end alley. Its time to recover \n your stolen slice!");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("\t\tFight!\n");
    }
    
    private void SpawnCharacters()
    {
        player = new Player();
        enemy = new Enemy();
    }
    
    private void PlayerAttack()
    {
        int totalDamage = player.CalculateTotalDamage();
        enemy.TakeDamage(totalDamage);
        player.ShowAttackDamage(totalDamage);
    }
    
    private void PlayerHeal()
    {
        int totalHeal = player.CalculateTotalHeal();
        player.Heal(totalHeal);
        player.ShowHeal(totalHeal);
    }
    
    private string GetInput()
    {
        string input = Console.ReadLine();
        return input.ToUpper();
    }
    
    private void InvalidInput()
    {
        Console.WriteLine("Invalid Input! , please give a valid input");
    }
    
    private void ShowBattleOptions()
    {
        Console.WriteLine("==================================");
        Console.WriteLine("PIZZA BATTLE OPTIONS");
        Console.WriteLine("==================================");
        Console.WriteLine("Choose your Action");
        Console.WriteLine("[A]: Attack the Crust Bandit");
        Console.WriteLine("[H]: Gulp an espresso shot");
        Console.WriteLine("==================================");
        Console.WriteLine("Your choice: ");
        
    }
    
    private void EnemyAttack()
    {
        int totalDamage = enemy.CalculateTotalDamage();
        player.TakeDamage(totalDamage);
        enemy.ShowAttackDamage(totalDamage);
    }
    
    private void DisplayCharacterStats()
    {
        player.DisplayPlayerStats();
        enemy.DisplayEnemyStats();
    }
    
    private void ShowGameWin()
    {
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine("PIZZA JUSTICE SERVED!");
        Console.WriteLine("=================================");
        Console.WriteLine("The Dough Master has defeated the Crust Bandit!");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("The perfect pizza has been reclaimed");
        Console.WriteLine("The honour of Italian cuisine has been restored!");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Bon appétit, and thanks for playing!");
        Console.WriteLine("=================================");
    }
    
    private void ShowGameLoose()
    {
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine("PIZZA TRAGEDY");
        Console.WriteLine("=================================");
        Console.WriteLine("The Dough Master has been outmanuevred");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("The Crust Bandit escapes with your masterpiece!");
        Console.WriteLine("Your pizzeria's reputation is in shambles");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Thanks for your valiant effort!");
        Console.WriteLine("Perhaps it's time to switch to calzones...");
        Console.WriteLine("=================================");
    }
    
    private bool CheckGameOver()
    {
        if(enemy.Health <= 0)
        {
            ShowGameWin();
            return true;
        }
        if(player.Health <= 0)
        {
            ShowGameLoose();
            return true;
        }
        return false;
    }
    
    private void ProcessBattleInput()
    {
        string PlayerInput = GetInput();
        Console.Clear();
        
        switch(PlayerInput)
        {
            case "A":
                PlayerAttack();
                if(CheckGameOver())
                {
                    break;
                }
                
                EnemyAttack();
                if(CheckGameOver())
                {
                    break;
                }
                
                DisplayCharacterStats();
                break;
                
            case "H":
                PlayerHeal();
                
                EnemyAttack();
                if(CheckGameOver())
                {
                    break;
                }
                
                DisplayCharacterStats();
                break;
                
            default:
                InvalidInput();
                break;
        }
        
    }
    
    private bool AreCharactersAlive()
    {
        return player.Health > 0 && enemy.Health > 0;
    }
    
    private void ProcessBattleLoop()
    {
        do {
            ShowBattleOptions();
            ProcessBattleInput();
        } while(AreCharactersAlive());
    }
    
    private void StartMenu()
    {
        Console.WriteLine("=================================");
        Console.WriteLine("Press S to Get Your Masterpiece BACK...");
        Console.WriteLine("Press any other key to exit the game.");
        Console.WriteLine("=================================");
        
        ProcessStartMenuInput();
    }
    
    private void ExitGame()
    {
        Console.Clear();
        Console.WriteLine("Thanks for playing Midnight Pizza Fight!😄");
        IsGameExited = true;
    }
    
    private void ProcessStartMenuInput()
    {
        string StartGame = GetInput();
        
        if(StartGame == "S")
        {
            Console.Clear();
            SpawnCharacters();
            ProcessBattleLoop();
        }
        else {
            ExitGame();
        }
    }
    
    private void ProcessRestartMenuInput()
    {
        string restartGame = GetInput();
        
        if (restartGame == "R")
        {
            IsGameExited = false;
        }
        else {
            ExitGame();
        }
    }
    
    private void RestartMenu()
    {
        Console.WriteLine("\n==================================================");
        Console.WriteLine("     Press R to Restart...     ");
        Console.WriteLine("     Press any other key to exit the game   ");
        Console.WriteLine("==================================================");

        ProcessRestartMenuInput();
    }
    
    public void GameLoop()
    {
        while(!IsGameExited)
        {
            DisplayGameStory();
            StartMenu();
            if(!IsGameExited)
            {
                RestartMenu();
            }
        }
    }
}

class Program {
    static void Main() 
    {
        Game game = new Game();
        game.GameLoop();
    }
}
