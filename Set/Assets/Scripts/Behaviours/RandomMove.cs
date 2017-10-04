using UnityEngine;
using System.Collections;

public class RandomMove : MonoBehaviour 
{
	public float verticalSpeed, amplitude;
	private Vector3 _startPosition;
 
	public void Start () 
	{
	    _startPosition = transform.position;
	}
	 
	public void Update()
	{
	     transform.position = _startPosition + new Vector3(0.0f, Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude + 2.35f, 0.0f);
	}
}