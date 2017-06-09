using UnityEngine;
using System.Collections;

public class KogelHit : MonoBehaviour
{
	public GameObject afgevuurdDoor;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter(Collision collision)
	{
		GameObject hit = collision.gameObject;
		SpelerInfo hitPlayer = hit.GetComponent<SpelerInfo>();

		if(hitPlayer != null)
		{
			afgevuurdDoor.GetComponent<SpelerInfo>().VerhoogScore ();
			Destroy (gameObject);
		}
	}
}
