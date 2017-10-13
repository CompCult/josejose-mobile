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

	private void SplashTime () 
	{
		// Disables Android Status Bar
		AndroidScreen.statusBarState = AndroidScreen.States.Hidden;
		// Enables Android Navigation Bar
		AndroidScreen.navigationBarState = AndroidScreen.States.Visible;

		loadingIcon.SetActive(true);

		StartCoroutine(CheckConnection());
	}

	private IEnumerator CheckConnection()
	{
		yield return new WaitForSeconds(3);

		WWW versionRequest = MiscAPI.RequestVersion();

		string Error = versionRequest.error,
		Response = versionRequest.text;

		if (versionRequest.error == null)
		{
			LoadScene("Login");
		}
		else 
		{
			Debug.Log("Error on check connection: " + Error);
			AlertsAPI.instance.makeAlert("Problemas de conexão!\nVerifique sua conexão e tente novamente em breve.", "OK");
			
			loadingIcon.SetActive(false);
			fruitIcon.SetActive(true);
		}

		yield return null;
	}

	public void OpenPlayStore()
	{
		Application.OpenURL("https://play.google.com/store/apps/details?id=net.compcult.josejose");
	}
}
