using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour {

    private Color mouseOverColor = Color.blue;
    private Color originalColor= Color.red;
    private bool dragging = false;
    private float distance;
    float positionX;
    float positionZ;
    GameObject cubeNumber;

    public int magicNumber;

    //void OnMouseEnter()
    //{
    //    renderer.material.color = mouseOverColor;
    //}

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }
    void OnMouseUp()
    {
        dragging = false;

        //if (this.transform.position.x < -2) { positionX = -2.0f; }
        //else if (this.transform.position.x > 2) { positionX = 2.0f; }
        //else { positionX = 0.0f; }

        //if (this.transform.position.z < -2) { positionZ = -2.0f; }
        //else if (this.transform.position.z > 2) { positionZ = 2.0f; }
        //else { positionZ = 0.0f; }

        this.transform.position = new Vector3(this.transform.position.x, 0.0f, this.transform.position.z);
    }
	// Use this for initialization
	void Start () {
        //cubeNumber = transform.Find("Number").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
        this.transform.rotation= Quaternion.Euler(0,0,0);
	}


}
