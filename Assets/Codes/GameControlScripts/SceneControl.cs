using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneControl : AstroScoreControl
{
    //Made for play button,When you press it,Go through to play scene.
    #region PlayButton
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    #endregion

    //Made for quitting from the game.
    #region QuitButton
    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    //To Return Back To home screen
    #region HomeButton
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
    #endregion

    //In Update function called TimeStop function in Coroutine to trigger.
    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
    
    void Update()
    {

        // When complete succesfully,Normally goes to next level. But Next Levels haven't made yet.So same level again.
        #region AfterWinScene
        if (pointAstro.ToString() == "2" && pointCrystal.ToString() == "4")
        {
            StartCoroutine(TimeStop());
            
        }
        #endregion

        // When complete unsuccesfully,Normally goes to first level. But All Levels haven't made yet.So same level again.
        #region AfterLoseScene
        if (healthBar.fillAmount == 0)
        {
            StartCoroutine(TimeStop());
        }
        #endregion
    }
}
