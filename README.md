# Adobe Experience Platform - Assurance package for Unity apps

## End of support

Effective March 30, 2022, support for Adobe Experience Platform Mobile SDKs on Unity is no longer active. While you may continue using our libraries, Adobe no longer plans to update, modify, or provide support for these libraries. Please contact your Adobe CSM for detail.

- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Running Tests](#running-tests)
- [Sample App](#sample-app)
- [Contributing](#contributing)
- [Licensing](#licensing)

## Prerequisites

The `Unity Hub` application is required for development and testing. Inside of `Unity Hub`, you will be required to download the `Unity` app. The AEPAssurance Unity package is built using Unity version 2019.4.

[Download the Unity Hub](http://unity3d.com/unity/download). The free version works for development and testing, but a Unity Pro license is required for distribution. See [Distribution](#distribution) below for details.

#### FOLDER STRUCTURE
Plugins for a Unity project use the following folder structure:

`{Project}/Assets/Plugins/{Platform}`

## Installation

#### Installing the ACPCore Unity Package
- Download [ACPCore-1.0.1-Unity.zip](https://github.com/adobe/unity-acpcore/tree/master/bin/ACPCore-1.0.1-Unity.zip) 
- Unzip `ACPCore-1.0.1-Unity.zip`
- Import `ACPCore.unitypackage` via Assets->Import Package

#### Installing the AEPAssurance Unity Package
- Download [AEPAssurance-1.0.0-Unity.zip](./bin/AEPAssurance-1.0.0-Unity.zip) 
- Unzip `AEPAssurance-1.0.0-Unity.zip`
- Import `AEPAssurance.unitypackage` via Assets-Import Package

#### Android installation
No additional steps are required for Android installation.

#### iOS installation
ACPCore 1.0.0 and above is shipped with XCFrameworks. Follow these steps to add them to the Xcode project generated when building and running for iOS platform in Unity.
1. Go to File -> Project Settings -> Build System and select `New Build System`.
2. [Download](https://github.com/Adobe-Marketing-Cloud/acp-sdks/tree/master/iOS/ACPCore) `ACPCore.xcframework`, `ACPIdentity.xcframework`, `ACPLifecycle.xcframework` and `ACPSignal.xcframework`.
3. [Download](https://github.com/Adobe-Marketing-Cloud/acp-sdks/tree/master/iOS/AEPAssurance) `AEPAssurance.xcframework`.
4. Select the UnityFramework target -> Go to Build Phases tab -> Add the XCFrameworks downloaded in Steps 2 and 3 to `Link Binary with Libraries`.
5. Select the Unity-iPhone target -> Go to Build Phases tab -> Add the XCFrameworks downloaded in Steps 2 and 3 to `Link Binary with Libraries` and `Embed Frameworks`. Alternatively, select `Unity-iPhone` target -> Go to `General` tab -> Add the XCFrameworks downloaded in Steps 2 and 3 to `Frameworks, Libraries, and Embedded Content` -> Select `Embed and sign` option.

## Usage

### [Assurance](https://aep-sdks.gitbook.io/docs/beta/project-assurance)

#### Initialization

##### Registering the extension with AEPAssurance
> Note: It is required to initialize the SDK via native code inside your AppDelegate and MainApplication for iOS and Android respectively. For more information see how to initialize [Assurance](https://aep-sdks.gitbook.io/docs/beta/project-assurance/set-up-project-assurance#add-project-assurance-extension-to-your-app)
```
using com.adobe.marketing.mobile;
using AOT;

public class MainScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
      AEPAssurance.RegisterExtension();
    }
}
```

##### [Start the ACP Core and set the Wrapper Type](https://github.com/adobe/unity-acpcore#core)

##### Getting the SDK version:
```cs
  string assuranceVersion = AEPAssurance.ExtensionVersion();
```

##### Start Assurance session:
> Note: Refer [Assurance](https://aep-sdks.gitbook.io/docs/beta/project-assurance/set-up-project-assurance#add-project-assurance-extension-to-your-app) to learn more about Assurance session.
```cs
  AEPAssurance.StartSession(url);
```
> Note: Read more about [Assurance Session url](https://aep-sdks.gitbook.io/docs/beta/project-assurance/using-project-assurance#connecting-to-a-session)

#### Start Assurance session using [Deeplink](https://aep-sdks.gitbook.io/docs/beta/project-assurance/using-project-assurance#connecting-to-a-session)

##### Android
Ensure that Assets/Plugin/Android/AndroidManifest.xml contains the following Intent-Filter in UnityPlayerActivity(or it's child class).
```xml
<activity android:name="com.unity3d.player.UnityPlayerActivity"
                  android:theme="@style/UnityThemeSelector">
    <intent-filter>
         <action android:name="android.intent.action.VIEW" />
         <category android:name="android.intent.category.DEFAULT" />
         <category android:name="android.intent.category.BROWSABLE" />
         <data android:scheme="grifflab" />
    </intent-filter>
</activity>    
```
> Note: Replace the scheme grifflab with your [scheme](https://aep-sdks.gitbook.io/docs/beta/project-assurance/using-project-assurance#creating-sessions).

##### iOS
Go to iOS Player setting and add your scheme under supported URL scheme.

## Running Tests
1. Open the demo app in Unity.
2. Open the test runner from `Window -> General -> TestRunner`.
3. Click on the `PlayMode` tab.
4. Connect an Android or iOS device as we run the tests on a device in play mode.
5. Select the platform for which the tests need to be run from `File -> Build Settings -> Platform`. 
5. Click `Run all in player (platform)` to run the tests.

## Sample App
Sample App is located at *unity-aepassurance/AEPAssurance/Assets/Scenes*.
To build demo app for specific platform follow the below instructions.

###### Add core plugin
- Download [ACPCore-1.0.0-Unity.zip](https://github.com/adobe/unity-acpcore/tree/master/bin/ACPCore-1.0.0-Unity.zip) 
- Unzip `ACPCore-1.0.0-Unity.zip`
- Import `ACPCore.unitypackage` via Assets->Import Package

###### Android
1. Make sure you have an Android device connected.
2. From the menu of the `Unity` app, select __File > Build Settings...__
3. Select `Android` from the __Platform__ window
4. If `Android` is not the active platform, hit the button that says __Switch Platform__ (it will only be available if you actually need to switch active platforms)
5. Press the __Build And Run__ button
6. You will be asked to provide a location to save the build. Make a new directory at *unity-aepassurance/AEP-Assurance/Builds* (this folder is in the .gitignore file)
7. Name build whatever you want and press __Save__
8. `Unity` will build an `apk` file and automatically deploy it to the connected device

###### iOS
1. From the menu of the `Unity` app, select __File > Build Settings...__
2. Select `iOS` from the __Platform__ window
3. If `iOS` is not the active platform, hit the button that says __Switch Platform__ (it will only be available if you actually need to switch active platforms)
4. Press the __Build And Run__ button
5. You will be asked to provide a location to save the build. Make a new directory at *unity-aepassurance/AEPAssurance/Builds* (this folder is in the .gitignore file)
6. Name build whatever you want and press __Save__
7. `Unity` will create and open an `Xcode` project
8. [Add XCFrameworks to the Xcode project](#ios-installation).
9. From the Xcode project run the app on a simulator.

## Additional Cordova Plugins

Below is a list of additional Unity plugins from the AEP SDK suite:

| Extension | GitHub | Unity Package |
|-----------|--------|-----|
| ACPCore | https://github.com/adobe/unity-acpcore | [ACPCore](https://github.com/adobe/unity-acpcore/blob/master/bin/ACPCore-1.0.1-Unity.zip)
| ACPAnalytics | https://github.com/adobe/unity-acpanalytics | [ACPAnalytics](https://github.com/adobe/unity-acpanalytics/blob/master/bin/ACPAnalytics-1.0.0-Unity.zip)
| ACPUserProfile | https://github.com/adobe/unity_acpuserprofile | [ACPUserProfile](https://github.com/adobe/unity_acpuserprofile/blob/master/bin/ACPUserProfile-1.0.0-Unity.zip)

## Contributing

Looking to contribute to this project? Please review our [Contributing guidelines](.github/CONTRIBUTING.md) prior to opening a pull request.  

We look forward to working with you!

## Licensing
This project is licensed under the Apache V2 License. See [LICENSE](LICENSE) for more information.
