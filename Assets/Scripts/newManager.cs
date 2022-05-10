using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newManager : MonoBehaviour
{
    public int clickedButtons = 0;
    public float patrolSpeed = 5;

    private GameObject[] anchors;
    const int MAX_CLICKS = 3;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("finishCamera").GetComponent<Camera>().enabled = false;
        anchors = GameObject.FindGameObjectsWithTag("Anchor");
        foreach (GameObject anchor in anchors)
        {
            //anchor.SetActive(false);
            anchor.GetComponent<Renderer>().enabled = false;
            anchor.GetComponent<Rigidbody>().mass = 0;
        }
        GameObject.FindWithTag("ST_Axe").GetComponent<Renderer>().enabled = false;
        GameObject.FindWithTag("Axe").GetComponent<Rigidbody>().mass = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if (clickedButtons == 1)
        // {
        //     patrolSpeed = 10;
        // }
        // else if (clickedButtons == 2)
        // {
        //     patrolSpeed = 15;
        // }
        // else if (clickedButtons == 3)
        // {
        //     // TODO add "You win" screen
        // }
    }

    public void clickButton()
    {
        if (clickedButtons < MAX_CLICKS)
        {
            clickedButtons++;

            if (clickedButtons == 1)
            {
                patrolSpeed = 10;
            }
            else if (clickedButtons == 2)
            {
                patrolSpeed = 15;
            }
            else if (clickedButtons == 3)
            {
                GameObject.FindWithTag("Patrol").GetComponent<PatrolScript>().GoToFinish();
            }
            
            GameObject.FindWithTag("Patrol").GetComponent<PatrolScript>().setSpeed(patrolSpeed);
        }
    }

    public void PatrolAtFinishPoint()
    {
        anchors = GameObject.FindGameObjectsWithTag("Anchor");
        foreach (GameObject anchor in anchors)
        {
            //anchor.SetActive(true);
            anchor.GetComponent<Renderer>().enabled = true;
            anchor.GetComponent<Rigidbody>().mass = 1;
        }
        GameObject.FindWithTag("finishCamera").GetComponent<Camera>().enabled = true;
        GameObject.FindWithTag("MainCamera").GetComponent<Camera>().enabled = false;
        GameObject.FindWithTag("ST_Axe").GetComponent<Renderer>().enabled = true;
        GameObject.FindWithTag("Axe").GetComponent<Rigidbody>().mass = 12;
    }

    public void PatrolTouchedPlayer()
    {
        print("player touched");
        SceneManager.LoadScene("MainMenu");
    }
}
