using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace com.adobe.marketing.mobile
{
    public class ACPGriffon
    {
        /* ===================================================================
        * Static Helper objects for JNI access to Griffon.java
        * =================================================================== */
#if UNITY_ANDROID

       static AndroidJavaClass griffon =
            new AndroidJavaClass("com.adobe.marketing.mobile.Griffon");

        private static AndroidJavaObject GetHashMapFromDictionary(Dictionary<string, object> dict)
		{
			// quick out if nothing in the dict param
			if (dict == null || dict.Count <= 0) 
			{
				return null;
			}
			
			AndroidJavaObject hashMap = new AndroidJavaObject ("java.util.HashMap");
			IntPtr putMethod = AndroidJNIHelper.GetMethodID(hashMap.GetRawClass(), "put", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
			object[] args = new object[2];
			foreach (KeyValuePair<string, object> kvp in dict)
			{
				using (var key = new AndroidJavaObject("java.lang.String", kvp.Key))
				{
					using (var value = new AndroidJavaObject("java.lang.String", kvp.Value))
					{
						args[0] = key;
						args[1] = value;
						AndroidJNI.CallObjectMethod(hashMap.GetRawObject(), putMethod, AndroidJNIHelper.CreateJNIArgArray(args));
					}
				}
			}
			
			return hashMap;
		}
#endif
        /* ===================================================================
        * extern declarations for iOS Methods
        * =================================================================== */
#if UNITY_IPHONE

            private static string JsonStringFromDictionary(Dictionary<string, object> dict) 
		    {
			if (dict == null || dict.Count <= 0) 
			{
				return null;
			}
			
			var entries = dict.Select(d => string.Format("\"{0}\": \"{1}\"", d.Key, d.Value));
			string jsonString = "{" + string.Join (",", entries.ToArray()) + "}";
			
			return jsonString;
		    }

            [DLLImport ("__Internal")]
            private static extern System.IntPtr Griffon_ExtensionVersion();

            [DllImport ("__Internal")]
            private static extern void Griffon_StartSession(string url);

            [DllImport ("__Internal")]
            private static extern bool GriffonRegisterExtension();

            [DllImport ("__Internal")]
            private static extern void Griffon_EndSession();

            [DllImport ("__Internal")]
            private static extern void GriffonAttemptReconnect();

            [DllImport ("__Internal")]
            private static extern void SendGriffonEvent(string vendor, string type, string payload);

            [DllImport ("__Internal")]
            private static extern void GriffonLogLocalUILevel(int localLogLevel, string message);
            
#endif

        public enum UILogColorVisibility
        {
            LOW = 0,
            NORMAL = 1,
            HIGH = 2,
            CRITICAL = 3
        };


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

        public static void EndSession()
        {
        #if UNITY_IPHONE && !UNITY_EDITOR
            Griffon_EndSession();
        #elif UNITY_ANDROID && !UNITY_EDITOR
            if(AndroidJNI.AttachCurrentThread() >= 0){
            griffon.CallStatic("endSession");
            AndroidJNI.DetachCurrentThread();
            }
        #endif
        }

        public static void AttemptReconnect()
        {
        #if UNITY_IPHONE && !UNITY_EDITOR
            GriffonAttemptReconnect();
        #elif UNITY_ANDROID && !UNITY_EDITOR
            if(AndroidJNI.AttachCurrentThread() >= 0){
            griffon.CallStatic("attemptReconnect");
                AndroidJNI.DetachCurrentThread();
            }
        #endif
        }

        public static void SendGriffonEvent(string vendor, string type, Dictionary<string, object> payload)
        {
        #if UNITY_IPHONE && !UNITY_EDITOR
            SendGriffonEvent(vendor, type, JsonStringFromDictionary(payload));
        #elif UNITY_ANDROID && !UNITY_EDITOR
                if(AndroidJNI.AttachCurrentThread() >= 0){
                using (var griffonEvent = new AndroidJavaObject("com.adobe.marketing.mobile.GriffonEvent", vendor, type, GetHashMapFromDictionary(payload))){
                    griffon.CallStatic("sendEvent", griffonEvent);
                    
                }  
                AndroidJNI.DetachCurrentThread();
              }
        #endif
        }

        public static void GriffonLogLocalUILevel(UILogColorVisibility uILogColorVisibility, string message) {

#if UNITY_IPHONE && !UNITY_EDITOR
            GriffonLogLocalUILevel((int)uILogColorVisibility, message);
#elif UNITY_ANDROID && !UNITY_EDITOR
                if(AndroidJNI.AttachCurrentThread() >= 0){
                using(var uiLogColorVisibiltyClass = new AndroidJavaObject("com.adobe.marketing.mobile.Griffon$UILogColorVisibility")){
                var logColorVisibility = uiLogColorVisibiltyClass.GetStatic<AndroidJavaObject>(uILogColorVisibility.ToString());

                griffon.CallStatic("logLocalUI", logColorVisibility, message);
            }                                           
            AndroidJNI.DetachCurrentThread();
        }
#endif

        }
    }
}