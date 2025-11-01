using UnityEngine;
using UnityEngine.Splines;

public class TestScene_StartLiquid : MonoBehaviour
{
    [SerializeField] private Liquid _liquid;
    [SerializeField] private SplineContainer _splineContainer;

    private void Awake()
    {
        _liquid.Initialize();
        _liquid.Move(_splineContainer);

        Invoke(nameof(CreateNewLiquid), 2.0f);
    }

    private void CreateNewLiquid()
    {
        Liquid liquid = Instantiate(_liquid, Vector3.zero, Quaternion.identity);

        liquid.Initialize();
        liquid.Move(_splineContainer);
    }
}
