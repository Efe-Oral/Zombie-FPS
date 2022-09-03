using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void PlayAgain()
    {
        Debug.Log("RESTART!");
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Debug.Log("QUITING");
        print("QUIT!");
    }
}
