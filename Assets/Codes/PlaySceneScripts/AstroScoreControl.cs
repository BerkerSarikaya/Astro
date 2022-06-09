using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AstroScoreControl : MonoBehaviour
{
    public TextMeshProUGUI astroNumberCount;
    public TextMeshProUGUI elementNumberCount;
    public TextMeshProUGUI loseText;
    public GameObject astro;
    public GameObject Crystal;
    public GameObject energyCell;
    public GameObject asteroid;
    public GameObject rocket;
    public Image healthBar;

    public int pointAstro = 0;
    public int pointCrystal = 0;

    //Before we start,make false the situation of text because It should appear when we reach the end point.
    private void Awake()
    {
        loseText.gameObject.SetActive(false);
    }

    //This part have made to control of object disappear after collision
    #region OnCollisionEnter
    private void OnCollisionEnter(Collision collision)
    {
        //if collision happens,Astro number going up 1 and the astro that hit is disappeared.
        if(collision.gameObject.tag == "Astronaut")
        {
            pointAstro += 1;
            collision.gameObject.SetActive(false);
            astroNumberCount.text = pointAstro.ToString();
        }

        //When you collide the energy cell,Healht bar going up 0.5f.
        if(collision.gameObject.tag == "EnergyCell")
        {
            healthBar.fillAmount += 0.5f;
            collision.gameObject.SetActive(false);
        }

        //When Collision happens, Asteroid takes 0.25f health from your health bar.
        if(collision.gameObject.tag == "Asteroid")
        {
            healthBar.fillAmount -= 0.25f;
            collision.gameObject.SetActive(false);
            
        }

        //When Collision happens, Crystal number going up 1 score.
        if(collision.gameObject.tag == "Crystal")
        {
            pointCrystal += 1;
            collision.gameObject.SetActive(false);
            elementNumberCount.text = pointCrystal.ToString();
        }
        
    }
    #endregion

    void Update()
    {
        // when health bar is equal 0, Text turns true situation to let you know the result.
        #region loseTextHealthBarControl
        if ( healthBar.fillAmount == 0)
        {
            loseText.gameObject.SetActive(true);   
        }
        #endregion

        // When we obtain the number that we get,Text turns true situation to let you know the result.
        #region WinTextHealthBarControl
        if (pointAstro.ToString() == "2" && pointCrystal.ToString() =="4")
        {
            loseText.text = "YOU WIN";
            loseText.gameObject.SetActive(true);
        }
        #endregion



    }
}
