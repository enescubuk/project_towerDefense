using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public void NextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void RestartRun()
    {


        SceneManager.LoadScene(0);
    }

    public void TryAgain()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
