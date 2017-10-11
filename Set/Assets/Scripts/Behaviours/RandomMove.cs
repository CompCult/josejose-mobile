using UnityEngine;
using System.Collections;

public class RandomMove : MonoBehaviour 
{
	public float verticalSpeed, amplitude;
	public string type;

	private Vector3 _startPosition;
 
	public void Start () 
	{
	    _startPosition = transform.position;
	}
	 
	public void Update()
	{
		if (type == "vertical")
	    	transform.position = _startPosition + new Vector3(0.0f, Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude + 2.35f, 0.0f);
	    if (type == "horizontal")
	    	transform.position = _startPosition + new Vector3(Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude + 2.35f, 0.0f, 0.0f);
	}
}