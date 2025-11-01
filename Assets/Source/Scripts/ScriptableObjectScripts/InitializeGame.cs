using UnityEngine;

[CreateAssetMenu(fileName = "StartGameConfig", menuName = "Config", order = 51)]
public class InitializeGame : ScriptableObject
{
    [SerializeField] private int _startSpawnLiquid;
    [SerializeField] private int _startCountFillContainer;

    public int StartSpawnLiquid => _startSpawnLiquid;
    public int CountFillContainer => _startCountFillContainer;
}
