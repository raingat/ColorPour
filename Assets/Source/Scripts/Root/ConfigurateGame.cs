using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Configurate", menuName = "Create New Configurate", order = 51)]
public class ConfigurateGame : ScriptableObject
{
    [SerializeField] private List<VarietiesColors> _orderColors;

    public int CountObject => _orderColors.Count;

    public VarietiesColors GetColor(int index)
    {
        return _orderColors[index];
    }
}
