using UnityEngine;
using UnityEngine.Splines;

[RequireComponent(typeof(MoveAlongSpline))]
public class Liquid : MonoBehaviour
{
    private MoveAlongSpline _movementLogic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out Liquid _))
            _movementLogic.Stop();
    }

    public void Initialize()
    {
        _movementLogic = GetComponent<MoveAlongSpline>();
    }

    public void Move(SplineContainer splineContainer)
    {
        _movementLogic.SetSplineContainer(splineContainer);
        _movementLogic.Move();
    }
}