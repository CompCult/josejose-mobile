using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Tutorial : GenericScreen 
{
	public Camera mainCamera;
	public Text text1, text2, text3;
	public Button btn1;
	public Color loadToColor;

	private double limitCamera = 21.6;
	private int tutorialPart = 1;

	public void Start () 
	{
		AlertsAPI.instance.Init();

		IEnumerator coroutine = MoveCamera (true);
		StartCoroutine(coroutine);
	}

	public void ContinueTutorial()
	{
		tutorialPart++;

		if (tutorialPart == 2)
		{
			btn1.gameObject.SetActive(false);
			text2.gameObject.SetActive(false);
			text1.gameObject.SetActive(false);
		}

		StartCoroutine(ShowTutorial());
	}

	private IEnumerator MoveCamera (bool firstTime)
	{
		if (firstTime)
			yield return new WaitForSeconds(3);

		Vector3 pos = mainCamera.transform.position;
		mainCamera.transform.position = new Vector3(pos.x, pos.y, pos.z + 0.1f);

        yield return new WaitForSeconds(0.01f);
        
        IEnumerator coroutine;
        if (mainCamera.transform.position.z <= limitCamera)
        	coroutine = MoveCamera(false);
		else
			coroutine = ShowTutorial();

		StartCoroutine(coroutine);
	}

	private IEnumerator ShowTutorial()
	{
		if (tutorialPart == 1)
		{
			if (!text1.gameObject.activeSelf && !text2.gameObject.activeSelf)
			{
				text1.gameObject.SetActive(true);
				yield return new WaitForSeconds(5f);
				StartCoroutine(ShowTutorial());
			} 
			else if (!text2.gameObject.activeSelf)
			{
				text1.gameObject.SetActive(false);
				text2.gameObject.SetActive(true);
				yield return new WaitForSeconds(8f);
				StartCoroutine(ShowTutorial());
			}
			else if (!btn1.gameObject.activeSelf && text2.gameObject.activeSelf)
			{
				btn1.gameObject.SetActive(true);
			}
		}
		else if (tutorialPart == 2)
		{
			if (!text3.gameObject.activeSelf)
			{
				text3.gameObject.SetActive(true);
				yield return new WaitForSeconds(8f);
				StartCoroutine(ShowTutorial());
			}
			else if (!btn1.gameObject.activeSelf)
			{
				btn1.gameObject.SetActive(true);
			}
		}
		else
		{
			EndTutorial();
		}

		yield return null;
	}

	private void EndTutorial()
	{
		 PlayerPrefs.SetString("JoseJose-FirstTime-" + UserManager.user.id, "Foobar");
		 Initiate.Fade("Home", loadToColor, 0.5f);
	}
}
