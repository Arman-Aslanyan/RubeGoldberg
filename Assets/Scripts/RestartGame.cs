using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    //Upon collision will set the current active Scene to the End/Restart Scene
    void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(1);
    }

    //Upon clicking the button the active scene shall change back to the game
    public void Restart()
    {
        SceneManager.LoadScene(0);
        PlayerConroller.hasStart = false;
    }
}
