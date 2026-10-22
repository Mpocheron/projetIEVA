using UnityEngine;

public class AudioProjectileDeletion : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject, 2);
    }

}
