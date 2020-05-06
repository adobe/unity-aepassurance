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
    public Text versionNameText;
    public Button _btnGriffonStartSession;
    public Button _btnGriffonExtensionVersion;

    // Core callbacks
    [MonoPInvokeCallback(typeof(AdobeStartCallback))]
    public static void HandleStartAdobeCallback()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            print(LOG_TAG + "HandleStartAdobeCallback Android");
            ACPCore.ConfigureWithAppID("94f571f308d5/00fc543a60e1/launch-c861fab912f7-development");
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            print("HandleStartAdobeCallback iphone");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        print(LOG_TAG + "Start called");
        if (Application.platform == RuntimePlatform.Android)
        {
            ACPCore.SetApplication();
        }
        
        bool hasRegistered = ACPGriffon.GriffonRegisterExtension();
        print(LOG_TAG + "Griffon Extension Registration" + (hasRegistered ? "Successful" : "Failed"));
        ACPCore.Start(HandleStartAdobeCallback);
        
        _btnGriffonStartSession.onClick.AddListener(startGriffonSession);
        _btnGriffonExtensionVersion.onClick.AddListener(getGriffonExtensionVersion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Griffon plugin methods.
    public void startGriffonSession()
    {
        const string url = "grifflab://shtomar-griffon?adb_validation_sessionid=a7cad5ab-d8df-4883-9bd4-42dc5725e228";
        ACPGriffon.StartSession(url);
    }


    public void getGriffonExtensionVersion()
    {
        string version = ACPGriffon.GriffonExtensionVersion();
        print(LOG_TAG + "Griffon version: "+version);
        versionNameText.text = "Griffone Version: " + version;
    }
}
