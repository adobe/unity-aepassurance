/*
Copyright 2020 Adobe
All Rights Reserved.
NOTICE: Adobe permits you to use, modify, and distribute this file in
accordance with the terms of the Adobe license agreement accompanying
it. If you have received this file from a source other than Adobe,
then your use, modification, or distribution of it requires the prior
written permission of Adobe. (See LICENSE-MIT for details)
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using com.adobe.marketing.mobile;
using AOT;

public class AssuranceScene : MonoBehaviour
{
    private const string LOG_TAG = "AssuranceScene:: ";
    private const string APP_ID = "";
    //UI Fields
    public Text resultText; //For Testing purpose.
    public Button btnAssuranceStartSession;
    public Button btnAssuranceExtensionVersion;

    // Core callbacks
    [MonoPInvokeCallback(typeof(AdobeStartCallback))]
    public static void HandleStartAdobeCallback()
    { 
        print(LOG_TAG + "HandleStartAdobeCallback");
        ACPCore.ConfigureWithAppID(APP_ID);    
    }

    // Start is called before the first frame update
    void Start()
    {
        print(LOG_TAG + "Start called");
        if (Application.platform == RuntimePlatform.Android)
        {
            ACPCore.SetApplication();
        }

        ACPCore.SetWrapperType();
        bool hasRegistered = AEPAssurance.RegisterExtension();
        resultText.text = "Assurance Registered:: " + hasRegistered.ToString();
        ACPCore.Start(HandleStartAdobeCallback);
        
        btnAssuranceStartSession.onClick.AddListener(startAssuranceSession);
        btnAssuranceExtensionVersion.onClick.AddListener(getAssuranceExtensionVersion);

    }

    //Assurance plugin methods.
    public void startAssuranceSession()
    {
        const string url = "";
        AEPAssurance.StartSession(url);
    }

    public void getAssuranceExtensionVersion()
    {
        string version = AEPAssurance.ExtensionVersion();
        print(LOG_TAG + "Assurance version: "+version);
        resultText.text = "Assurance Version: " + version;
    }
}
