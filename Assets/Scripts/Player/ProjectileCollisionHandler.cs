using UnityEngine;

public class ProjectileCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
