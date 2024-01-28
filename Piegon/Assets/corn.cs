using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the hammer object
        if (collision.gameObject.CompareTag("Hammer"))
        {
            // Disappear the object
            Disappear();
        }
    }

    void Disappear()
    {
        // Deactivate or destroy the object, or modify its visibility as needed
        gameObject.SetActive(false);

        // If you want to destroy the object completely, you can use:
        // Destroy(gameObject);
    }
}
