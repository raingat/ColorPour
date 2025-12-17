using UnityEngine;

[CreateAssetMenu(fileName = "New ColorObject", menuName = "Create New ColorObject", order = 52)]
public class ColorObject : ScriptableObject
{
    [SerializeField] private VarietiesColors _colorName;
    [SerializeField] private Color _color;

    public VarietiesColors ColorName => _colorName;
    public Color Color => _color;
}
