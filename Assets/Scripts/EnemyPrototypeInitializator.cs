using UnityEngine;

public sealed class EnemyPrototypeInitializator
{
    public EnemyPrototypeInitializator(MainController mainController, EnemyPrototypeData enemyPrototypeData)
    {
        RenderSettings.ambientLight = Color.white;
        var spawnedEnemyPrototype = Object.Instantiate(enemyPrototypeData.EnemyPrototypeStruct.EnemyPrototype,
            enemyPrototypeData.EnemyPrototypeStruct.StartPosition,
            Quaternion.identity);
        

        var cubeStruct = enemyPrototypeData.EnemyPrototypeStruct;
        cubeStruct.EnemyPrototype = spawnedEnemyPrototype;

        var enemyPrototypeModel = new EnemyPrototypeModel(cubeStruct);
        mainController.AddUpdatable(new EnemyController(enemyPrototypeModel));
    }
}
