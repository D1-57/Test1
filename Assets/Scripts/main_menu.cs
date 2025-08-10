using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
