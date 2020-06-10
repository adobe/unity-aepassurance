using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class GriffonTestSuite
    {

		[UnityTest]
		public IEnumerator VerifyGriffonRegisterExtension()
		{
			yield return loadScene();
			Assert.AreEqual("Griffon Registered:: True", getActualResult());
		}

		[UnityTest]
		public IEnumerator VerifyGriffonVersion()
		{
			yield return loadScene();
			var gameObj = GameObject.Find("ButtonExtension");
			var button = gameObj.GetComponent<Button>();
			button.onClick.Invoke();
			yield return new WaitForSeconds(1f);
			Assert.AreEqual("Griffon Version: "+ (Application.platform == RuntimePlatform.Android ? "1.1.6" : "1.1.0"), getActualResult());
		}

		private string getActualResult() {
			var resultTextGameObject = GameObject.Find("ResultText");
			var resultText = resultTextGameObject.GetComponent<Text>();
			return resultText.text;
		}

		private IEnumerator loadScene()
		{
			AsyncOperation async = SceneManager.LoadSceneAsync("GriffonSampleScene");

			while (!async.isDone)
			{
				yield return null;
			}
		}
    }
}