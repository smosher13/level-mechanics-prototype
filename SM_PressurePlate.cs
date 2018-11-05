using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_PressurePlate : MonoBehaviour {

    public int objNum = 0;
    public bool isPressed = false;
    public GameObject animator;
    private Animator doorAnim;

    // Use this for initialization
    void Start()
    {

        doorAnim = animator.GetComponent<Animator>();

    }

    void ToggleDoorAnim()
    {
        if (isPressed == true)
        {
            if (doorAnim.GetBool("toggleOpen") == false)
            {
                doorAnim.SetBool("toggleOpen", true);
            }
        }

        else
        {
            doorAnim.SetBool("toggleOpen", false);
        }

    }
        void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<GravityGun>()== null && other.name == "CubeGravNullObj")
        {

            objNum++;
            isPressed = true;
            Debug.Log("The plate is activated");
        }

    }

    void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<GravityGun>()== null && other.name == "CubeGravNullObj")
        {
            objNum--;

            if (objNum <= 0)
            {
                objNum = 0;
                isPressed = false;
                Debug.Log("The plate is no longer activated");
            }
        }
    }

    void Update()
    {
        ToggleDoorAnim();
    }


}
