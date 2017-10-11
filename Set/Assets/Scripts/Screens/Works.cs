using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Works : GenericScreen 
{
	public GameObject bookObject;
	private int zoomScale = 0;

	public void Start () 
	{
		AlertsAPI.instance.Init();
		backScene = "Home";
	}

	public void ZoomIn()
	{
		bookObject.transform.localScale += new Vector3(0.5F, 0.5F, 0);
		zoomScale++;
	}

	public void ZoomOut()
	{
		if (zoomScale > 0)
		{
			bookObject.transform.localScale -= new Vector3(0.5F, 0.5F, 0);
			zoomScale--;
		}
	}
}
