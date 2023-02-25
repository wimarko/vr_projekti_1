using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoalSwitchControl : MonoBehaviour
{
    public InputActionReference switchReference = null;
    [SerializeField] GameObject goalPanel;

    [SerializeField] GameObject buttonSphere;

    //private AudioSource audioSource;
    

    
    private bool buttonHit = false;
    //private bool active = false;

    void Start()
    {
        //audioSource= GetComponent<AudioSource>();

        //if (audioSource == null)
        //{
        //    Debug.LogError("AudioSource is NuLL!");
        //}
    }


    void Update()
    {
        if (buttonHit == true)
        {
            goalPanel.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHand") && !buttonHit)
        {
            buttonHit = true;
            //audioSource.Play();
        }
    }
}
