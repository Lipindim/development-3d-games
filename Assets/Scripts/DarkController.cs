using UnityEngine;

public class DarkController : IUpdatable
{
    private const float COLOR_CANGE_VALUE = 0.01f;

    private GameObject _player;
    private GameObject[] _enemies;
    private float _distance = 15.0f;
    private float _square_distance;

    public DarkController()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        _square_distance = _distance * _distance;
    }

    public void UpdateTick()
    {
        if (IsPlayerInEnemyZone())
            MakeItDarker();
        else
        {
            MakeItLighter();
        }
    }

    private static void MakeItDarker()
    {
        Color currentColor = RenderSettings.ambientLight;
        if (currentColor.r != 0)
        {
            Color darkerColor = new Color(currentColor.r - COLOR_CANGE_VALUE,
                currentColor.g - COLOR_CANGE_VALUE,
                currentColor.b - COLOR_CANGE_VALUE,
                1);
            RenderSettings.ambientLight = darkerColor;
        }
    }

    private static void MakeItLighter()
    {
        Color currentColor = RenderSettings.ambientLight;
        if (currentColor.r < 0.2f)
        {
            Color lighterColor = new Color(currentColor.r + COLOR_CANGE_VALUE,
                currentColor.g + COLOR_CANGE_VALUE,
                currentColor.b + COLOR_CANGE_VALUE,
                1);
            RenderSettings.ambientLight = lighterColor;
        }
    }

    private bool IsPlayerInEnemyZone()
    {
        foreach (var enemy in _enemies)
        {
            Vector3 directionToPlayer = _player.transform.position - enemy.transform.position;
            if (directionToPlayer.sqrMagnitude < _square_distance)
                return true;
        }

        return false;
    }
}
