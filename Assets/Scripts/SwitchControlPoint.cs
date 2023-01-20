using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchControlPoint : MonoBehaviour
{
    public InputActionReference switchReference = null;
    public HiddenPlatform hiddenPlatform = null;
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
        hiddenPlatform.SwitchActive();
    }
}
