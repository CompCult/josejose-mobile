using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Home : GenericScreen 
{
	public Text backNameField;
	public Color loadToColor;

	public void Start () 
	{
		AlertsAPI.instance.Init();
		backScene = null;

		if (!PlayerPrefs.HasKey("JoseJose-FirstTime-" + UserManager.user.id))
			Initiate.Fade("Tutorial", loadToColor, 0.5f);

		backNameField.text = UserManager.user.name;
	}

	public void UpdateUserInfo()
	{
		WWW userRequest = UserAPI.RequestUser(UserManager.user.id);

		string Error = userRequest.error,
		Response = userRequest.text;

		if (userRequest.responseHeaders["STATUS"] == "HTTP/1.1 200 OK")
		{
			Debug.Log("User updated");

			AlertsAPI.instance.makeToast("Perfil atualizado", 1);
			UserManager.UpdateUser(Response);
		}
		else
		{
			AlertsAPI.instance.makeAlert("Falha ao atualizar!\nVerifique sua conexão e tente novamente.", "OK");
		}
	}
}
