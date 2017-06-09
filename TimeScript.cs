using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TimeScript : NetworkBehaviour 
{
	float timer = 10;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!isServer)
			return;

		if (NetworkServer.connections.Count < 2)
			return;

		timer -= Time.deltaTime;
		Debug.Log (timer);


















































	}
}
