using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{

    public bool sceneLoad = false;

    [SerializeField] FadingPanel black;
    [SerializeField] FadingPanel white;

    private void Start()
    {
        black.FadeOut(1);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            NextLevel();
        }
        
    }
    public void NextLevel()
    {
        sceneLoad = true;

        StartCoroutine(NextLevelIE());
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void RestartRun()
    {

        sceneLoad = true;
        SceneManager.LoadScene(0);
    }

    public void TryAgain()
    {

        sceneLoad = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    IEnumerator NextLevelIE()
    {
        black.FadeIn(1);

        yield return new WaitForSecondsRealtime(1);
       
        Debug.Log(31);
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
