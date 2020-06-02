# Adobe Experience Platform - Griffon package for Unity apps

- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Running Tests](#running-tests)
- [Sample App](#sample-app)
- [Contributing](#contributing)
- [Licensing](#licensing)

## Prerequisites

The `Unity Hub` application is required for development and testing. Inside of `Unity Hub`, you will be required to download the current version of the `Unity` app.

[Download the Unity Hub](http://unity3d.com/unity/download). The free version works for development and testing, but a Unity Pro license is required for distribution. See [Distribution](#distribution) below for details.

#### FOLDER STRUCTURE
Plugins for a Unity project use the following folder structure:

`{Project}/Assets/Plugins/{Platform}`

## Installation

- Download [ACPGriffon-0.0.1-Unity.zip](https://github.com/adobe/unity-acpgriffon/tree/master/bin/ACPGriffon-0.0.1-Unity.zip) 
- Unzip `ACPGriffon-0.0.1-Unity.zip`
- Import `ACPGriffon.unitypackage` via Assets-Import Package
> Note: Unity Griffon plugin needs ACP Core Plugin to work. Import [ACPCore.unitypackage](https://github.com/adobe/unity-acpcore#installation) to you project before using Griffon.

## Usage

### [Griffon](https://aep-sdks.gitbook.io/docs/beta/project-griffon)

#### Initialization

##### Registering the extension with ACPGriffon
> Note: It is required to initialize the SDK via native code inside your AppDelegate and MainApplication for iOS and Android respectively. For more information see how to initialize [Griffon](https://aep-sdks.gitbook.io/docs/beta/project-griffon/set-up-project-griffon#add-project-griffon-extension-to-your-app)
```
using com.adobe.marketing.mobile;
using AOT;

public class MainScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
      ACPGriffon.RegisterExtension();
    }
}
```

##### [Start the ACP Core and set the Wrapper Type](https://github.com/adobe/unity-acpcore/blob/master/README.md#core)

##### Getting the SDK version:
```cs
  string griffonVersion = ACPGriffon.ExtensionVersion();
```

##### Start Griffon session:
> Note: Refer [Griffon](https://aep-sdks.gitbook.io/docs/beta/project-griffon/set-up-project-griffon#add-project-griffon-extension-to-your-app) to learn more about Griffon session.
```cs
  ACPGriffon.StartSession(url);
```
> Note: Read more about [Griffon Session url](https://aep-sdks.gitbook.io/docs/beta/project-griffon/using-project-griffon#connecting-to-a-session)

#### Start Griffon session using [Deeplink](https://aep-sdks.gitbook.io/docs/beta/project-griffon/using-project-griffon#connecting-to-a-session)

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
> Note: Replace the scheme grifflab with your [scheme](https://aep-sdks.gitbook.io/docs/beta/project-griffon/using-project-griffon#creating-sessions).

##### iOS
Go to iOS Player setting and you scheme under supported URL scheme.

## Running Tests
Tests are located at at *unity-acpgriffon/ACP-Griffon/Assets/Scenes/Tests*.
> Note: Before running the tests ensure that you have Android or iOS phone/simulator connected.

1. Select platform Android/iOS in Build Settings and choose test phone/simulator.
1. Open Test Runner via __Window > General > Test Runner__
1. Select the tests to run and hit Run Tests.

## Sample App
Sample App is located at *unity-acpgriffon/ACP-Griffon/Assets/Scenes*.
To build demo app for specific platform follow the below instructions.

###### Add core plugin
- Download [ACPCore-0.0.1-Unity.zip](https://github.com/adobe/unity-acpcore/tree/master/bin/ACPCore-0.0.1-Unity.zip) 
- Unzip `ACPCore-0.0.1-Unity.zip`
- Import `ACPCore.unitypackage` via Assets->Import Package

###### Android
1. Make sure you have an Android device connected.
1. From the menu of the `Unity` app, select __File > Build Settings...__
1. Select `Android` from the __Platform__ window
1. If `Android` is not the active platform, hit the button that says __Switch Platform__ (it will only be available if you actually need to switch active platforms)
1. Press the __Build And Run__ button
1. You will be asked to provide a location to save the build. Make a new directory at *unity-acpgriffon/ACPGriffon/Builds* (this folder is in the .gitignore file)
1. Name build whatever you want and press __Save__
1. `Unity` will build an `apk` file and automatically deploy it to the connected device

###### iOS
1. From the menu of the `Unity` app, select __File > Build Settings...__
1. Select `iOS` from the __Platform__ window
1. If `iOS` is not the active platform, hit the button that says __Switch Platform__ (it will only be available if you actually need to switch active platforms)
1. Press the __Build And Run__ button
1. You will be asked to provide a location to save the build. Make a new directory at *unity-acpgriffon/ACPGriffon/Builds* (this folder is in the .gitignore file)
1. Name build whatever you want and press __Save__
1. `Unity` will create and open an `Xcode` project
1. From the Xcode project run the app on a simulator.
1. If you get an error `Symbol not found: _OBJC_CLASS_$_WKWebView`. Select the Unity-iPhone target -> Go to Build Phases tab -> Add `Webkit.Framework` to `Link Binary with Libraries`.


## Contributing

Looking to contribute to this project? Please review our [Contributing guidelines](.github/CONTRIBUTING.md) prior to opening a pull request.  

We look forward to working with you!

## Licensing
This project is licensed under the Apache V2 License. See [LICENSE](LICENSE) for more information.
