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
            private static extern bool GriffonRegisterExtension();

            [DllImport ("__Internal")]
            private static extern void Griffon_StartSession(string url);

            [DLLImport ("__Internal")]
            private static extern System.IntPtr Griffon_ExtensionVersion();
            
        #endif

        /*--------------------------------------------------------
            * Methods
        *----------------------------------------------------------------------*/

        public static bool GriffonRegisterExtension()
        {
            #if UNITY_IPHONE && !UNITY_EDITOR
                return GriffonRegisterExtension();

            #elif UNITY_ANDROID && !UNITY_EDITOR
                if(AndroidJNI.AttachCurrentThread() >= 0){
                    bool hasRegistered = griffon.CallStatic<bool> ("registerExtension");
                    AndroidJNI.DetachCurrentThread();
                    return hasRegistered;
                }
                return false;
            #else
                return false;
            #endif
        }

        public static void StartSession(string url)
        {
            #if UNITY_IPHONE && !UNITY_EDITOR
                Griffon_StartSession(url);
            #elif UNITY_ANDROID && !UNITY_EDITOR
                if(AndroidJNI.AttachCurrentThread() >= 0){
                griffon.CallStatic("startSession", url);    
                AndroidJNI.DetachCurrentThread();
                }
            #endif
        }

        public static string GriffonExtensionVersion()
        {
            #if UNITY_IPHONE && !UNITY_EDITOR
                return Marshal.PtrToStringAnsi(Griffon_ExtensionVersion());
            #elif UNITY_ANDROID && !UNITY_EDITOR
                if(AndroidJNI.AttachCurrentThread() >= 0){
                string version = griffon.CallStatic<string> ("extensionVersion");   
                AndroidJNI.DetachCurrentThread();
                return version;
                }
                return "";
            #else
                return "";
            #endif
        }                        
    }
}