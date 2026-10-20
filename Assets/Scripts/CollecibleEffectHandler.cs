using UnityEngine;

public class CollecibleEffectHandler : MonoBehaviour
{
    private float y0;
    void Start()
    {
        transform.Rotate(new Vector3(0, 0, 15));
        y0 = transform.position.y;
    }

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 0.12f);
        Vector3 newPos = transform.position;
        newPos.y = 0.12f * Mathf.Sin(Time.time) + y0;
        transform.position = newPos;
    }
}
