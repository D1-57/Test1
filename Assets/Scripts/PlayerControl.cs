using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;

public class PlayerControl : MonoBehaviour
{
    public CharacterController Controller;
    public Transform player;
    public Animator anim;
    public float speed;
    float gravity = 14;
    public float jump;

    public Vector3 savedPostion;

    float verticalvelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = gameObject.transform;
        savedPostion = gameObject.transform.position;
        Controller = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");



        if (Controller.isGrounded)
        {
            verticalvelocity = -gravity * Time.deltaTime;
            if (Input.GetAxis("Jump") > 0)
                verticalvelocity = jump;
        }
        else
        {
            verticalvelocity -= gravity * Time.deltaTime;
        }


        Vector3 movedirection = new Vector3(horizontal, 0, vertical).normalized;

        if (Mathf.Abs(vertical) + Mathf.Abs(horizontal) > 0)
        {
            anim.SetFloat("speed", 1);
        }
        else
        {
            anim.SetFloat("speed", 0);
        }

        if (movedirection.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(movedirection.x, movedirection.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
        movedirection = Camera.main.transform.TransformDirection(new Vector3(movedirection.x, 0, movedirection.z));

        //Vector3 movedirection = new Vector3(horizontal*speed*speedrun, verticalvelocity, vertical*speed*speedrun);
        Controller.Move(new Vector3(movedirection.x * speed, verticalvelocity,
            movedirection.z * speed) * Time.deltaTime);

        if (Input.GetKey(KeyCode.P))
        {
            savedPostion = gameObject.transform.position;
        }

        if (Input.GetKey(KeyCode.R) || gameObject.transform.position.y < 0)
        {
            gameObject.transform.position = savedPostion;
        }
        if (player.position.y >= 10f)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadSceneAsync(2);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadSceneAsync(0);
            }
            
            // if (player.position.y >= 10f)
            // {

            //     if (SceneManager.GetActiveScene().buildIndex == 2)
            //     {
            //         SceneManager.LoadSceneAsync(0);
            //     }

            // }
            
        }




    }
    
}
