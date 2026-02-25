using System.Collections.Generic;
using UnityEngine;

public class JuiceTransition : MonoBehaviour
{
    private Bar _bar;
    private Dispenser _dispenser;

    private void OnDisable()
    {
        _dispenser.JuiceCome -= TransportJuice;
    }

    public void Initialize(Bar bar, Dispenser dispenser)
    {
        _bar = bar;
        _dispenser = dispenser;

        _dispenser.JuiceCome += TransportJuice;
    }

    private void TransportJuice()
    {
        List<VarietiesColors> requirementColors = _bar.GetAllRequirementJuiceColor();
        List<VarietiesColors> availableColors = _dispenser.GetAllAvailableColors();

        List<VarietiesColors> resultMatches = GetMatches(requirementColors, availableColors);

        if (resultMatches.Count == 0)
            return;

        List<Juice> requirementJuice = _dispenser.GetJuice(resultMatches);
        _bar.TakeJuices(requirementJuice);
    }

    private List<VarietiesColors> GetMatches(List<VarietiesColors> requirementColors, List<VarietiesColors> availableColors)
    {
        List<VarietiesColors> result = new List<VarietiesColors>();
        Dictionary<VarietiesColors, int> availableCount = new Dictionary<VarietiesColors, int>();

        foreach (VarietiesColors color in availableColors)
        {
            if (availableCount.ContainsKey(color))
                availableCount[color]++;
            else
                availableCount[color] = 1;
        }

        foreach (VarietiesColors color in requirementColors)
        {
            if (availableCount.TryGetValue(color, out int count) && count > 0)
            {
                result.Add(color);
                availableCount[color]--;
            }
        }

        return result;
    }


}