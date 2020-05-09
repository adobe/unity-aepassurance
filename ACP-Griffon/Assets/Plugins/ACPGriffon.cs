/*
Unity Plug-in v: 0.0.1
ACPGriffon.cs

Copyright 2020 Adobe. All rights reserved.
This file is licensed to you under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License. You may obtain a copy
of the License at http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under
the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR REPRESENTATIONS
OF ANY KIND, either express or implied. See the License for the specific language
governing permissions and limitations under the License.
*/

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace com.adobe.marketing.mobile
{
    public class ACPGriffon
    {
        /* ===================================================================
        * Static Helper objects for our JNI access
        * =================================================================== */
    #if UNITY_ANDROID

        static AndroidJavaClass griffon =
            new AndroidJavaClass("com.adobe.marketing.mobile.Griffon");

    #endif

        /* ===================================================================
        * extern declarations for iOS Methods
        * =================================================================== */
    #if UNITY_IPHONE

            [DllImport ("__Internal")]
            private static extern bool acp_RegisterExtension();

            [DllImport ("__Internal")]
            private static extern void acp_StartSession(string url);

            [DllImport ("__Internal")]
            private static extern System.IntPtr acp_GriffonExtensionVersion();
            
    #endif

        /*--------------------------------------------------------
        * Methods
        *----------------------------------------------------------------------*/

        public static bool RegisterExtension()
        {
            #if UNITY_IPHONE && !UNITY_EDITOR
                return acp_RegisterExtension();

            #elif UNITY_ANDROID && !UNITY_EDITOR
                if(AndroidJNI.AttachCurrentThread() >= 0){
                    return griffon.CallStatic<bool> ("registerExtension");
                }
                return false;
            #else
                return false;
            #endif
        }

        public static void StartSession(string url)
        {
            #if UNITY_IPHONE && !UNITY_EDITOR
                acp_StartSession(url);
            #elif UNITY_ANDROID && !UNITY_EDITOR
                if(AndroidJNI.AttachCurrentThread() >= 0){
                    griffon.CallStatic("startSession", url);    
                }
            #endif
        }

        public static string ExtensionVersion()
        {    
            #if UNITY_IPHONE && !UNITY_EDITOR
                return Marshal.PtrToStringAnsi(acp_GriffonExtensionVersion());
            #elif UNITY_ANDROID && !UNITY_EDITOR
                if(AndroidJNI.AttachCurrentThread() >= 0){
                    return griffon.CallStatic<string> ("extensionVersion");   
                }
                return "";
            #else
                return "";
            #endif
        }                        
    }
}