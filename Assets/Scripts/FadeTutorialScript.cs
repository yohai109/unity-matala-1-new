using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using Gravitons.UI.Modal;

public class FadeTutorialScript : MonoBehaviour
{
    public Text helltext;
    public GameObject hellPanel;
    public float fadeSpeed = 5;
    public bool enterance = false;

    // Start is called before the first frame update
    void Start()
    {
        helltext.color = Color.clear;
        // GameObject.FindGameObjectWithTag("Gate").GetComponent<Animation>().Play("idle");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterance = true;
            //ModalManager.Show("Modal Title", "Show your message here", new[] { new ModalButton() { Text = "OK" } });
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterance = false;
            // GameObject.FindGameObjectWithTag("DoorRight").GetComponent<Animation>().Play();
            print("trigger");
            GameObject gate = GameObject.FindGameObjectWithTag("Gate");
            gate.GetComponent<Animator>().SetTrigger("open");
            

            // foreach (GameObject item in GameObject.FindGameObjectsWithTag("DoorRight"))
            // {
            //     item.GetComponent<Animator>().SetTrigger("open");
            // }

            // foreach (GameObject item in GameObject.FindGameObjectsWithTag("DoorLeft"))
            // {
            //     item.GetComponent<Animator>().SetTrigger("open");
            // }
            // GameObject
            //     .FindGameObjectsWithTag("DoorLeft")
            //     .GetComponent<Animator>()
            //     .SetTrigger("open");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();
    }

    private void ColorChange()
    {
        if (enterance)
        {
            helltext.color = Color.Lerp(helltext.color, Color.white, fadeSpeed * Time.deltaTime);
            hellPanel.SetActive(true);
        }
        else
        {
            helltext.color = Color.Lerp(helltext.color, Color.clear, fadeSpeed * Time.deltaTime);
            hellPanel.SetActive(false);
        }
    }
}
