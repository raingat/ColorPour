using System;
using System.Collections;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleLiquid;

    private Juice _juice;

    private VarietiesColors _requirementColor;

    public VarietiesColors RequirementColor => _requirementColor;

    public Action Filled;

    public void Initialize(VarietiesColors requirementColor)
    {
        _requirementColor = requirementColor;
    }

    public void Fill(Juice juice)
    {
        _juice = juice;

        _juice.transform.SetParent(transform);
        _juice.transform.localPosition = Vector3.zero;
        _juice.transform.localScale = _scaleLiquid;

        StartCoroutine(Filling());
    }

    private IEnumerator Filling()
    {
        _juice.UpLevel();

        while (enabled)
        {
            if (_juice.MaxLevel)
            {
                Filled?.Invoke();
                break;
            }

            yield return null;
        }
    }
}
