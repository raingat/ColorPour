using UnityEngine;
using UnityEngine.Splines;

[RequireComponent(typeof(MoveAlongSpline))]
public class Liquid : MonoBehaviour
{
    private MoveAlongSpline _moveAlongSpline;

    public void Initialize()
    {
        _moveAlongSpline = GetComponent<MoveAlongSpline>();
    }

    public void Move(SplineContainer splineContainer)
    {
        _moveAlongSpline.SetSplineContainer(splineContainer);
        _moveAlongSpline.Move();
    }
}