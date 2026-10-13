using Unity.VisualScripting;
using UnityEngine;

public class NPCDetection : MonoBehaviour
{
    private GameObject npc;
    private Material material;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        npc = transform.parent.gameObject;
        material = npc.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision started");
            material.color = Color.green;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision stopped");
            material.color = Color.red;
        }
        
    }
}
