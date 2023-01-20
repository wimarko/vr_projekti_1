using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchControlPoint : MonoBehaviour
{
    public InputActionReference toggleReference = null;
    public GameObject hiddenPlatform = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchTheSwitch()
    {
        hiddenPlatform.SetActive(!gameObject.activeInHierarchy);
    }
}
