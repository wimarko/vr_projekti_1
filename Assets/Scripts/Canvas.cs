using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Canvas : MonoBehaviour
{

    [SerializeField] GameObject lController;
    [SerializeField] TextMeshProUGUI textLRotation;

    [SerializeField] GameObject controllerR;
    [SerializeField] TextMeshProUGUI textRotationR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //otetaan objektin rotaatio
        float rotationZ = lController.transform.rotation.z;
        //p‰ivitet‰‰n UI:n teksti
        textLRotation.text= "Z " +  rotationZ.ToString("F2")+"\n"
            + "X " + lController.transform.rotation.x.ToString("F2") + "\n"
            +"Y " + lController.transform.rotation.y.ToString("F2");

        //p‰ivitet‰‰n UI:n teksti
        textRotationR.text = "Z " + controllerR.transform.rotation.z.ToString("F2") + "\n"
            + "X " + controllerR.transform.rotation.x.ToString("F2") + "\n"
            + "Y " + controllerR.transform.rotation.y.ToString("F2") + "\n";


    }
}

