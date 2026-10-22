using UnityEngine;

public class PortalEffectHandler : MonoBehaviour
{
    public float rotationSpeed = 1;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }
}
