using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : GenericScreen 
{
	public GameObject fruitIcon, loadingIcon, alertMenu;

	public void Start () 
	{
		LocalizationManager.Start();
		ErrorManager.Start();
		backScene = null;

		SplashTime();
	}

	public void ContinueToLogin(bool DefinitiveContinue)
	{
		if (DefinitiveContinue)
			PlayerPrefs.SetString("ChangeTrees-NoAlert", "1");

		LoadScene("Login");
	}

	private void SplashTime () 
	{
		// Disables Android Status Bar
		AndroidScreen.statusBarState = AndroidScreen.States.Hidden;
		// Enables Android Navigation Bar
		AndroidScreen.navigationBarState = AndroidScreen.States.Visible;

		loadingIcon.SetActive(true);

		if (CheckConection())
		{
			LoadScene("Login");
		}
		else
		{
			loadingIcon.SetActive(false);
			fruitIcon.SetActive(true);
		}
	}

	private bool CheckConection()
	{
		WWW versionRequest = MiscAPI.RequestVersion();

		string Error = versionRequest.error,
		Response = versionRequest.text;

		if (versionRequest.responseHeaders["STATUS"] == "HTTP/1.1 200 OK")
		{
			return true;
		}
		else 
		{
			Debug.Log("Error on version: " + Response);
			AlertsAPI.instance.makeAlert("Problemas de conexão!\nVerifique sua conexão e tente novamente em breve.", "OK");
			return false;
		}
	}

	public void OpenPlayStore()
	{
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.compcult.josejose");
	}
}
