using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchControlPoint : MonoBehaviour
{
    public InputActionReference switchReference = null;
    public GameObject hiddenPlatform = null;

    [SerializeField] GameObject buttonSphere;

    private AudioSource audioSource;

    private float buttonDownDistance = 0.025f;
    private float buttonReturnSpeed = 0.001f;
    private float buttonOriginalX;

    private float hitAgainTime = 1f;
    private float canHitAgain;
    private bool buttonHit = false;
    private bool active = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        buttonOriginalX = buttonSphere.transform.position.x;
    }

    
    void Update()
    {
        if (buttonHit == true)
        {
            buttonHit = false;

            active = !active;
            if(active)
            {
                audioSource.Play();
            }

            buttonSphere.transform.position =
            new Vector3(
            buttonSphere.transform.position.x + buttonDownDistance,
            buttonSphere.transform.position.y,
            buttonSphere.transform.position.z);


            //hidden platform gets same active status as button
            //true/false  (jos toimii)
            hiddenPlatform.SetActive(active);
        }

        

        if(buttonSphere.transform.position.x > buttonOriginalX) {
            buttonSphere.transform.position -= new Vector3(buttonReturnSpeed, 0, 0);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("PlayerHand") && canHitAgain < Time.time)
        {
            canHitAgain = Time.time + hitAgainTime;
            buttonHit= true;
        }
    }

    
}
