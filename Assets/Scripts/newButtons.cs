using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newButtons : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isClicked = false;
    public Material m_Material;

    // Start is called before the first frame update
    void Start() { 
        //renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update() { }

    // private void OnCollisionEnter(Collision other) {

    // }

    private void OnTriggerEnter(Collider other)
    {
        print("in trigger function on " + gameObject.name);
        if (other.gameObject.tag == "Player" && !isClicked)
        {
            print("button triggered " + gameObject.name);
            GameObject.FindWithTag("Manager").GetComponent<newManager>().clickButton();
            isClicked = true;
            SetAdditionalMaterial(m_Material);
        }
    }

    public void SetAdditionalMaterial(Material newMaterial)
    {
        Material[] materialsArray = new Material[(this.GetComponent<Renderer>().materials.Length +1)];
        this.GetComponent<Renderer>().materials.CopyTo(materialsArray,0);
        materialsArray[materialsArray.Length - 1] = newMaterial;
        this.GetComponent<Renderer>().materials = materialsArray;
    }
}
