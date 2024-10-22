using System;

class Program
{
    static void Main()
    {
        Game game = new Game();
        game.GameLoop();
    }
}

class Player
{
    private int health = 100;
    private int maxHealth = 100;
    private int attackPower = 20;
    private int healPower = 15;

    public Player()
    {
        SpwanPlayer();
    }

    private void SpwanPlayer()
    {
        Console.WriteLine("\n=================================================");
        Console.WriteLine("                               🍕 DOUGH MASTER: GUARDIAN OF THE GOLDEN CRUST 🍕     ");
        Console.WriteLine("\n=================================================");
        Console.WriteLine("Dough Master: That scoundrel won't escape with my creation!");
    }

    public void DisplayPlayerStats()
    {
        Console.WriteLine("------------------------------------------------------------------------------------");
        Console.WriteLine("              DOUGH MASTER'S STATS                ");
        Console.WriteLine("------------------------------------------------------------------------------------");
        Console.WriteLine("Health: " + health + "/" + maxHealth);
        Console.WriteLine("Dough Slapper: " + attackPower);
        Console.WriteLine("Dough Slapper: " + healPower);
        Console.WriteLine("Dough Slapper Boost 🌪️: 5 to 15");
        Console.WriteLine("Espresso Shot Boost ☕: 10 to 20");
    }

    public int Health
    {

        get
        {
            return health;
        }

        private set
        {

            if (value < 0)
                health = 0;

            else if (value > maxHealth)
            {
                health = maxHealth;
            }

            else
            {
                health = value;
            }
        }
    }

    private int generateRandomNumberInRange(int min, int max)
    {
        Random rand = new Random();
        int randomNumber = rand.Next(min, max + 1);
        return randomNumber;
    }

    public int CalculateTotalDamage()
    {
        int additionalDamage = generateRandomNumberInRange(5, 15);
        int totalDamage = attackPower + additionalDamage;

        return totalDamage;
    }

    public void ShowAttackTotalDamage(int totalDamage)
    {
        Console.WriteLine("                                     🍕 PIZZA BATTLE 🍕");
        Console.WriteLine("\n=================================================");
        Console.WriteLine("Dough Master's attack dealt" + totalDamage + "damage!! 🥊");
        Console.WriteLine("------------------------------------------------------------------------------------");

    }

    public void TakeDamage(int damageRecieved) => health -= damageRecieved;

    public void Heal(int healAmount) => health += healAmount;

    public int CalculateTotalHeal()
    {
        int additionalHeal = generateRandomNumberInRange(10, 20);
        int totalHeal = healPower + additionalHeal;
        return totalHeal;
    }

    public void ShowHeal(int healAmount)
    {
        if (health >= maxHealth)
        {
            Console.WriteLine("             🍕 PIZZA BATTLE 🍕                   ");
            Console.WriteLine("============================================");
            Console.WriteLine("     Dough Master is bursting with energy! 🚀    ");
            Console.WriteLine("--------------------------------------------");
        }
        else
        {
            Console.WriteLine("             🍕 PIZZA BATTLE 🍕                   ");
            Console.WriteLine("============================================");
            Console.WriteLine("Dough Master's heal restored " + healAmount + " hp! ☕");
            Console.WriteLine("--------------------------------------------");
        }
    }
}
class Enemy
{

    private int health = 150;
    private int attackPower = 15;
    private int maxHealth = 150;

    public int Health
    {
        //GETTER
        get
        {
            return health;
        }
        //SETTER
        private set
        {
            // If the value provided is negative, store zero instead
            if (value < 0)
                health = 0;
            // if the value exceeds maximum health
            else if (value > maxHealth)
            {
                health = maxHealth;
            }
            //set the provided value if both the conditions are false
            else
            {
                health = value;
            }
        }
    }

    public Enemy()
    {
        SpwanEnemy();
    }

    public void SpwanEnemy()
    {
        Console.WriteLine("\n=================================================");
        Console.WriteLine("                               🦹 CRUST BANDIT: NEMESIS OF ITALIAN CUISINE 🦹     ");
        Console.WriteLine("\n=================================================");
        Console.WriteLine("You'll never catch me, flour face!!");
    }

    private int generateRandomNumberInRange(int min, int max)
    {
        Random rand = new Random();
        int randomNumber = rand.Next(min, max + 1);
        return randomNumber;
    }

    public void TakeDamage(int damageRecieved) => health -= damageRecieved;

    public int CalculateTotalDamage()
    {
        int additionalDamage = generateRandomNumberInRange(5, 15);
        int totalDamage = attackPower + additionalDamage;

        return totalDamage;
    }

    public void ShowAttackTotalDamage(int totalDamage)
    {
        Console.WriteLine("                                     🍕 PIZZA BATTLE 🍕");
        Console.WriteLine("\n=================================================");
        Console.WriteLine("Crust Bandit's attack dealt" + totalDamage + "damage!! 🥊");
        Console.WriteLine("------------------------------------------------------------------------------------");

    }

    public void DisplayEnemyStats()
    {
        Console.WriteLine("------------------------------------------------------------------------------------");
        Console.WriteLine("              CRUST BANDIT'S STATS                ");
        Console.WriteLine("------------------------------------------------------------------------------------");
        Console.WriteLine("Health: " + health + "/" + maxHealth);
        Console.WriteLine("Bandit attack power: " + attackPower);
    }


}

class Game
{
    Player player;
    Enemy enemy;
    bool isGameExited = false;

    public void GameLoop()
    {
        while (!isGameExited)
        {
            DisplayGameStory();
            StartMenu();
            if (!isGameExited)
                RestartMenu();
        }

    }

    private void StartMenu()
    {
        Console.WriteLine("====================================================");
        Console.WriteLine("     Press S to Get Your Masterpiece BACK...     ");
        Console.WriteLine("     Press any other key to exit the game   ");
        Console.WriteLine("====================================================");

        ProcessStartMenuInput();
    }

    private void ProcessStartMenuInput()
    {
        string startGame = GetInput();

        if (startGame == "S")
        {
            Console.Clear();
            SpwanCharacters();
            ProcessBattleLoop();
        }
        else
        {
            ExitGame();
        }
    }

    private void ProcessRestartMenuInput()
    {
        string restartGame = GetInput();

        if (restartGame == "R")
        {
            isGameExited = false;
        }
        else
        {
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

    private void ExitGame()
    {
        Console.Clear();
        Console.WriteLine("Thanks for playing Midnight Pizza Fight!😄");
        isGameExited = true;
    }
    public void SpwanCharacters()
    {
        player = new Player();
        enemy = new Enemy();
    }

    public void DisplayGameStory()
    {
        Console.Clear();
        Console.WriteLine("\n=================================================");
        Console.WriteLine("                                  🍕MIDNIGHT PIZZA FIGHT🍕    ");
        Console.WriteLine("=================================================");
        Console.WriteLine("In a busting pizzeria on a busy Friday night...");
        Console.WriteLine("------------------------------------------------------------------------------------");
        Console.WriteLine("You, the Dough Master, created your Magnum opus - the Perfect pizza.");
        Console.WriteLine("Suddenly, a sneaky Crust Bandit snatches your masterpiece!");
        Console.WriteLine("------------------------------------------------------------------------------------");
        Console.WriteLine("Fueled by passion for your craft, you give a chase...");
        Console.WriteLine("------------------------------------------------------------------------------------");
        Console.WriteLine("Through winding alleys and crowded streets, you purse the pizza pilferer.\nFinally, the theif is cornered in a Dead-end alley.\nIt's time to recover your stolen slice!");
        Console.WriteLine("------------------------------------------------------------------------------------");
        Console.WriteLine("                                              🍕!!!FIGHT!!!🍕    ");
    }

    private void ShowBattleOptions()
    {
        Console.WriteLine("\n==================================================");
        Console.WriteLine("             🍕 PIZZA BATTLE OPTIONS 🍕             ");
        Console.WriteLine("==================================================");
        Console.WriteLine("  Choose your action:");
        Console.WriteLine("    [A] Attack the Crust Bandit 🥊");
        Console.WriteLine("    [H] Gulp an Espresso Shot ☕");
        Console.WriteLine("==================================================");
        Console.Write("  Your choice: ");
    }

    public void ProcessBattleLoop()
    {
        do
        {
            ShowBattleOptions();
            ProcessBattleInput();
        } while (AreCharactersAlive());
    }

    private bool AreCharactersAlive() => player.Health > 0 && enemy.Health > 0;

    private void ProcessBattleInput()
    {
        string playerChoice = GetInput();
        Console.Clear();

        switch (playerChoice)
        {
            case "A":
                PlayerAttack();
                if (CheckGameOver())
                    break;
                EnemyAttack();
                if (CheckGameOver())
                    break;
                DisplayCharacterStats();
                break;

            case "H":
                PlayerHeal();
                EnemyAttack();
                if (CheckGameOver())
                    break;
                DisplayCharacterStats();
                break;

            default:
                InvalidInput();
                break;
        }
    }

    private void InvalidInput() => Console.WriteLine("Invalid Input! , please give a valid input");

    private string GetInput()
    {
        string input = Console.ReadLine();
        return input.ToUpper();
    }

    private void PlayerAttack()
    {
        int totalDamage = player.CalculateTotalDamage();
        enemy.TakeDamage(totalDamage);
        player.ShowAttackTotalDamage(totalDamage);
    }

    private void PlayerHeal()
    {
        int totalHeal = player.CalculateTotalHeal();
        player.Heal(totalHeal);
        player.ShowHeal(totalHeal);
    }

    private void EnemyAttack()
    {
        int totalDamage = enemy.CalculateTotalDamage();
        player.TakeDamage(totalDamage);
        enemy.ShowAttackTotalDamage(totalDamage);
    }

    private void DisplayCharacterStats()
    {
        player.DisplayPlayerStats();
        enemy.DisplayEnemyStats();
    }

    private bool CheckGameOver()
    {
        if (enemy.Health <= 0)
        {
            ShowGameWin();
            return true;
        }
        if (player.Health <= 0)
        {
            ShowGameLose();
            return true;
        }
        return false;
    }

    private void ShowGameWin()
    {
        Console.Clear();
        Console.WriteLine("\n==================================================");
        Console.WriteLine("           🎉 PIZZA JUSTICE SERVED! 🎉              ");
        Console.WriteLine("==================================================");
        Console.WriteLine("The Dough Master has defeated the Crust Bandit!");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("The perfect pizza has been reclaimed 🍕           ");
        Console.WriteLine("The honor of Italian cuisine is restored!         ");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("    Bon appétit, and thanks for playing! 👨‍🍳        ");
        Console.WriteLine("====================================================");
    }

    private void ShowGameLose()
    {
        Console.Clear();
        Console.WriteLine("\n==================================================");
        Console.WriteLine("              😭 PIZZA TRAGEDY! 😭                ");
        Console.WriteLine("====================================================");
        Console.WriteLine("The Dough Master has been outmaneuvered!           ");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("The Crust Bandit escapes with your masterpiece 🏃‍♂️");
        Console.WriteLine("Your pizzeria's reputation is in shambles 📉     ");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("        Thanks for your valiant effort! 🎖️         ");
        Console.WriteLine("   Perhaps it's time to switch to calzones... 🥟   ");
        Console.WriteLine("====================================================");
    }

}

