using UnityEngine;
using UnityEngine.Splines;

[RequireComponent(typeof(MoveAlongSpline))]
public class Liquid : MonoBehaviour
{
    [SerializeField] private VarietiesColors _color;

    private MoveAlongSpline _moveAlongSpline;

    public VarietiesColors Color => _color;

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