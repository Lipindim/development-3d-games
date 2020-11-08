using UnityEngine;
using System.Collections.Generic;

public class MainController : MonoBehaviour
{
    [SerializeField] private EnemyPrototypeData[] _enemiesPrototypeData;
    [SerializeField] private LayerMask layerMask;

    private List<IUpdatable> _iIpdatables = new List<IUpdatable>();
    private DarkController _darkController;

    private void Start()
    {
        new InitializeController(this, _enemiesPrototypeData);
        _darkController = new DarkController();
        _iIpdatables.Add(_darkController);
    }

    private void Update()
    {
        for (int i = 0; i < _iIpdatables.Count; i++)
        {
            _iIpdatables[i].UpdateTick();
        }
    }

    public void AddUpdatable(IUpdatable iUpdatable)
    {
        _iIpdatables.Add(iUpdatable);
    }
}

