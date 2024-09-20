using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offsetPosition;

    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(0, target.transform.position.y, target.transform.position.z) + offsetPosition;
        transform.position = newPosition;
    }
}
