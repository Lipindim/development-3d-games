public sealed class InitializeController
{
    public InitializeController(MainController mainController, EnemyPrototypeData[] enemiesPrototypeData)
    {
        foreach (var enemyProrotypeData in enemiesPrototypeData)
            new EnemyPrototypeInitializator(mainController, enemyProrotypeData);
    }
}
