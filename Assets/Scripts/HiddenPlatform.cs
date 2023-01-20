using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchActive()
    {
        GameObject[] children = GetComponentsInChildren<GameObject>();
        foreach (GameObject child in children)
        {
            child.SetActive(!gameObject.activeInHierarchy);
        }
    }
}
