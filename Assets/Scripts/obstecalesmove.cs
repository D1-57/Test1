using UnityEngine;
using System.Collections;

public class obstecalesmove : MonoBehaviour
{
    float x ;
    float y ;
    float z ;
    public float newx ;
    public float newy ;
    public float newz ;
    public Vector3 original;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 2f;
    public float distance = 5f;
    public bool moveHorizontal = true;
    public bool movevertical = true;
    
    private Vector3 startPosition;
    private float direction = 1f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (moveHorizontal)
        {
            transform.position = startPosition + new Vector3(
                Mathf.PingPong(Time.time * speed, distance) * direction,
                0,
                0);
        }
        else if(movevertical){
            transform.position = startPosition + new Vector3(
                0,
                Mathf.PingPong(Time.time * speed, distance),
                0 * direction);
        }
        else
        {
            transform.position = startPosition + new Vector3(
                0,
                0,
                Mathf.PingPong(Time.time * speed, distance) * direction);
        }
        
    }
}
