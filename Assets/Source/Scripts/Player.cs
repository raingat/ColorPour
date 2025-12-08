using UnityEngine;

public class Player : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _raycastHit;

    private void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(_ray, out _raycastHit))
        {
            if (_raycastHit.transform.TryGetComponent(out IActivatable activatable))
            {
                activatable.Activate();
            }
        }
    }
}
