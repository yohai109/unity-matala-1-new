using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Characters.FirstPerson;
public class MainMenuScript : MonoBehaviour
{
    //public Canvas quitMenu;
    public Button starText;
    public Button exitText;
    MouseLook mouseLook;
    
    // Start is called before the first frame update
    void Start()
    {
        mouseLook = new MouseLook();
        mouseLook.lockCursor = false;
        Cursor.visible = true;
    }

    void Update() {
        Cursor.visible = true;
    }

    public void ExitPress() {
        //quitMenu.enabled = true;
        starText.enabled = false;
        exitText.enabled = false;
        
    }

public void NoPress() {
        // quitMenu.enabled = false;
        starText.enabled = true;
        exitText.enabled = true;
    }

    public void StartLevel () {
        SceneManager.LoadScene("Game");
    }


    public void ExitGame (){
        Application.Quit();
    }
}
