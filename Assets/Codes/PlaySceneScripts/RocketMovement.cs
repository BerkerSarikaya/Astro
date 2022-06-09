using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketMovement : MonoBehaviour
{
    public GameObject rocket;
    public GameObject asteroid;
    public GameObject energyCell;
    public GameObject Element;
    public GameObject Astro;
    public Image healthBar; 

    //These vectors define for giving a movement the object that we select as a main.
    Vector3 zDirection = new Vector3();
    Vector3 xPositiveDirection = new Vector3();
    Vector3 xNegativeDirection = new Vector3();

    float speed;
    float maxX;
    float minX;

    int counter;
    int counterEnergy;
    int counterElement;
    int counterAstro;


    void Start()
    {
        speed = 0.5f;
        zDirection = Vector3.up  * speed;
        xPositiveDirection = new Vector3(-0.1f, 0f, 0f);
        xNegativeDirection = new Vector3(+0.1f, 0f, 0f);
        minX = -4f;
        maxX = +4f;

        //Instantiate is using for obtaining clone object from main object.
        //Random value is given for randomly disappear on the xPosition
        //Counter variables using for control the distance between to clones.
        #region MeteorClone

        for (int i = 0; i < 10; i++)
        {
            float rndClone = Random.Range(4, -4);
            counter += 40;
            Instantiate(asteroid, new Vector3(rndClone, transform.position.y, transform.position.z - counter), Quaternion.identity);
        }
        #endregion
        #region EnergyCellClone

        for ( int i = 0; i <2; i ++)
        {
            float rndEnrgy = Random.Range(-4, 4);
            counterEnergy += 107;
            Instantiate(energyCell, new Vector3(rndEnrgy, energyCell.transform.position.y , energyCell.transform.position.z - counterEnergy), Quaternion.identity);
        }
        #endregion
        #region ElementClone;

        for (int i = 0; i < 5; i++)
        {
            float rndElement = Random.Range(-4, 4);
            counterElement += 93;
            Instantiate(Element, new Vector3(rndElement, transform.position.y, transform.position.z - counterElement), Quaternion.identity);
        }
        #endregion
        #region AstroClone

        for (int i = 0; i < 2; i++)
        {
            float rndAstro = Random.Range(-4, 4);
            counterAstro += 97;
            Instantiate(Astro, new Vector3(rndAstro, transform.position.y, transform.position.z - counterAstro), Quaternion.identity);
        }
        #endregion
    }

    void Update()
    {
        //Object needs infinite movement in zDirection so that use transfrom.Translete
        #region MovemontInZDirection

        rocket.transform.Translate(zDirection);
        #endregion

        //Object needs horizontal movement in xDirection so that we define two cross vectors in Start functions.
        //There is an input from users,The main object moves the direction that the users give.
        #region MovementInXdirection
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rocket.transform.position += xNegativeDirection;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rocket.transform.position += xPositiveDirection;
        }
        #endregion

        //There is a limited plane so that put the plane limits to hold object on the plane.
        #region BorderControl
        float xPos = Mathf.Clamp(rocket.transform.position.x, minX, maxX);
        rocket.transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        #endregion

        //When Health bar equals 0,The main object's movement should stop.
        #region SpeedControlinHealthBar
        if (healthBar.fillAmount == 0)
        {
            speed = 0f;
            zDirection= zDirection = Vector3.up * Time.deltaTime * speed;
            xPositiveDirection = new Vector3(0f, 0f, 0f);
            xNegativeDirection = new Vector3(0f, 0f, 0f);
        }
        #endregion


    }
}