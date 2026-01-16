using UnityEngine;

public class Liquid : MonoBehaviour
{
    [SerializeField] private VarietiesColors _color;

    public VarietiesColors Color => _color;
}