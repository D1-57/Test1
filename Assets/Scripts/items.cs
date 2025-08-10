using UnityEngine;
using System.Collections;

public class items : MonoBehaviour
{
    bool iscollectable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        iscollectable = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0.1f, 0);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!iscollectable)
            return;
        if (other.CompareTag("Player"))
        {

            Destroy(gameObject);



        }
    }

    
}
