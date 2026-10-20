using UnityEngine;

public class ProjectileCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Portal")) Debug.Log("Portail touché " + name);
        Destroy(gameObject);
    }
}
