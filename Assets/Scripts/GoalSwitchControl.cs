using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoalSwitchControl : MonoBehaviour
{
    public InputActionReference switchReference = null;
    [SerializeField] GameObject goalPanel;

    [SerializeField] GameObject buttonSphere;

    private float buttonDownDistance = 0.025f;
    private float buttonReturnSpeed = 0.001f;
    private float buttonOriginalX;

    //private float hitAgainTime = 1f;
    //private float canHitAgain;
    private bool buttonHit = false;
    private bool active = false;

    void Start()
    {
        buttonOriginalX = buttonSphere.transform.position.x;
    }


    void Update()
    {
        if (buttonHit == true)
        {
            //buttonSphere.transform.position =
            //new Vector3(
            //buttonSphere.transform.position.x + buttonDownDistance,
            //buttonSphere.transform.position.y,
            //buttonSphere.transform.position.z);


            //Maaliteksti näkyviin..
            //active = true;
            goalPanel.SetActive(true);
        }



        if (buttonSphere.transform.position.x > buttonOriginalX)
        {
            buttonSphere.transform.position -= new Vector3(buttonReturnSpeed, 0, 0);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHand") && !buttonHit)
        {
            buttonHit = true;
        }
    }


}
