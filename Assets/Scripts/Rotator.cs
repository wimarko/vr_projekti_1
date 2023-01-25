using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Rotator : MonoBehaviour
{
    [SerializeField] Transform linkedDial;
    [SerializeField] private int snapRotationAmount = 25;
    [SerializeField] private float angleTolerance;
    [SerializeField] private GameObject LefthandModel;
    [SerializeField] private GameObject RighthandModel;
    private bool shouldUseDummyHands = false;

    private XRBaseInteractor interactor;
    private float startAngle;
    private bool requiresStartAngle = true;
    private bool shouldGetHandRotation = false;
    private XRGrabInteractable grabInteractor => GetComponent<XRGrabInteractable>();
    // Start is called before the first frame update
    private void OnEnable()
    {
        grabInteractor.selectEntered.AddListener(GrabbedBy);
        grabInteractor.selectExited.AddListener(GrabEnd);
    }

    private void OnDisable()
    {
        grabInteractor.selectEntered.RemoveListener(GrabbedBy);
        grabInteractor.selectExited.RemoveListener(GrabEnd);
    }

    private void GrabEnd(SelectExitEventArgs arg0)
    {
        shouldGetHandRotation= false;
        requiresStartAngle = true;
    }

    private void GrabbedBy(SelectEnterEventArgs arg0)
    {
        interactor = GetComponent<XRGrabInteractable>().selectingInteractor;
        interactor.GetComponent<XRDirectInteractor>().hideControllerOnSelect= true; //ei tarvii tätä?

        shouldGetHandRotation= true;
        startAngle= 0;

        //HandMOdelVisibility(true);

        
    }
    private void HandModelVisibility(bool visibilityState)
    {
        if(!shouldUseDummyHands)
        {
            return;
        }

        if (interactor.CompareTag("RightHand"))
        {
            RighthandModel.SetActive(visibilityState);
        }else
        {
            LefthandModel.SetActive(visibilityState);
        }
    }

    private void Update()
    {
        if(shouldGetHandRotation) {
            var rotationAngle = GetInteractorRotation(); //gets current controller angle
            GetRotationDistance(rotationAngle);
        }
    }

    public float GetInteractorRotation() => interactor.GetComponent < Transform>().eulerAngles.z;

    private void GetRotationDistance(float currentAngle)
    {
        if(!requiresStartAngle)
        {
            var angleDifference = Mathf.Abs(startAngle - currentAngle);

            if(angleDifference > angleTolerance) {
            if(angleDifference >270f)
                {
                    float angleCheck;
                    if(startAngle < currentAngle)
                    {
                        angleCheck = CheckAngle(currentAngle, startAngle);
                        if (angleCheck < angleTolerance)
                            return;
                        else 
                        {
                            RotateDialClockwise();
                            startAngle = currentAngle;
                        }
                    }
                    else if (startAngle > currentAngle)
                    { 
                        angleCheck = CheckAngle(currentAngle, startAngle);

                        if (angleCheck < angleTolerance)
                            return;
                        else
                        {
                            RotateDialClockwise();
                        }
                    }
                }
                    }
        }
    }

    private float CheckAngle(float currentAngle, float startAngle) => (360f - currentAngle) + startAngle;

    private void RotateDialClockwise()
    {
        linkedDial.localEulerAngles = new Vector3(
            linkedDial.localEulerAngles.x, 
            linkedDial.localEulerAngles.y, 
            linkedDial.localEulerAngles.z +snapRotationAmount);

        if (TryGetComponent<IDial>(out IDial dial))
            dial.DialChanged(linkedDial.localEulerAngles.z);
    }

    private void RoateDialAntiCLockwise()
    {
        linkedDial.localEulerAngles = 
            new Vector3(
                linkedDial.localEulerAngles.x,
                linkedDial.localEulerAngles.y, 
                linkedDial.localEulerAngles.z +snapRotationAmount);

        if (TryGetComponent<IDial>(out IDial dial))
            dial.DialChanged(linkedDial.localEulerAngles.z);
    }
}
