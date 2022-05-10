using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

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
        GameObject.FindWithTag("Ball").GetComponent<Renderer>().enabled = false;
        GameObject.FindWithTag("Ball").GetComponent<Rigidbody>().mass = 0;
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
        GameObject.FindWithTag("finishCamera").GetComponent<Camera>().enabled = true;
        GameObject.FindWithTag("MainCamera").GetComponent<Camera>().enabled = false;
        new WaitForSeconds(10);
        anchors = GameObject.FindGameObjectsWithTag("Anchor");
        foreach (GameObject anchor in anchors)
        {
            //anchor.SetActive(true);
            anchor.GetComponent<Renderer>().enabled = true;
            anchor.GetComponent<Rigidbody>().mass = 1;
        }
        
        GameObject.FindWithTag("Ball").GetComponent<Renderer>().enabled = true;
        GameObject.FindWithTag("Ball").GetComponent<Rigidbody>().mass = 1;
        
    }

     IEnumerator Stay()
    {
        yield return new WaitForSeconds(3);
    }
 

    public void PatrolTouchedPlayer()
    {
        GameObject.FindWithTag("MainCamera").GetComponent<Camera>().enabled = false;
        GameObject.FindWithTag("Player").GetComponent<RigidbodyFirstPersonController>().mouseLook.lockCursor = false;
        GameObject.FindWithTag("finishCamera").GetComponent<Camera>().enabled = false;
        Destroy(GameObject.FindWithTag("Player"));
        Cursor.lockState = CursorLockMode.None;
        // GameObject.FindGameObjectWithTag("Player").GetComponent("MouseLook").enable = false;
        print("player touched");
        SceneManager.LoadScene("LosingMenu");
    }

    public void Win() {
        GameObject.FindWithTag("MainCamera").GetComponent<Camera>().enabled = false;
        GameObject.FindWithTag("Player").GetComponent<RigidbodyFirstPersonController>().mouseLook.lockCursor = false;
        GameObject.FindWithTag("finishCamera").GetComponent<Camera>().enabled = false;
        Destroy(GameObject.FindWithTag("Player"));
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("WIningMenu");
    }
}
