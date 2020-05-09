/*
Copyright 2020 Adobe
All Rights Reserved.

NOTICE: Adobe permits you to use, modify, and distribute this file in
accordance with the terms of the Adobe license agreement accompanying
it. If you have received this file from a source other than Adobe,
then your use, modification, or distribution of it requires the prior
written permission of Adobe.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using com.adobe.marketing.mobile;
using AOT;


public class GriffonScene : MonoBehaviour
{
    private const string LOG_TAG = "GriffonScene:: ";
    //UI Fields
    public Text resultText; //For Testing purpose.
    public Button btnGriffonStartSession;
    public Button btnGriffonExtensionVersion;

    // Core callbacks
    [MonoPInvokeCallback(typeof(AdobeStartCallback))]
    public static void HandleStartAdobeCallback()
    { 
        print(LOG_TAG + "HandleStartAdobeCallback");
        ACPCore.ConfigureWithAppID("94f571f308d5/00fc543a60e1/launch-c861fab912f7-development");    
    }

    // Start is called before the first frame update
    void Start()
    {
        print(LOG_TAG + "Start called");
        if (Application.platform == RuntimePlatform.Android)
        {
            ACPCore.SetApplication();
        }
        
        bool hasRegistered = ACPGriffon.RegisterExtension();
        resultText.text = "Griffon Registered:: " + hasRegistered.ToString();
        ACPCore.Start(HandleStartAdobeCallback);
        
        btnGriffonStartSession.onClick.AddListener(startGriffonSession);
        btnGriffonExtensionVersion.onClick.AddListener(getGriffonExtensionVersion);

    }

    //Griffon plugin methods.
    public void startGriffonSession()
    {
        const string url = "grifflab://shtomar-griffon?adb_validation_sessionid=a7cad5ab-d8df-4883-9bd4-42dc5725e228";
        ACPGriffon.StartSession(url);
    }

    public void getGriffonExtensionVersion()
    {
        string version = ACPGriffon.ExtensionVersion();
        print(LOG_TAG + "Griffon version: "+version);
        resultText.text = "Griffon Version: " + version;
    }
}
