using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private InitializeGame _initializeConfig;

    [SerializeField] private LiquidSpawner _liquidSpawner;
    [SerializeField] private LiquidContainer _liquidContainer;

    private void Awake()
    {
        _liquidSpawner.Initialize(_initializeConfig.StartSpawnLiquid);
        _liquidContainer.Initialize(_initializeConfig.CountFillContainer);
    }
}
