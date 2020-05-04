using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.adobe.marketing.mobile;

public class GriffonScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("---In Start---");
        Debug.Log("---Griffon Version--- "+ACPGriffon.GriffonExtensionVersion() );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
