using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SpelerInfo : NetworkBehaviour
{
	public GameObject bulletPhrefab; 
	Vector3 spawn;

	[SyncVar]
	public int score = 0;
	public TextMesh scoreText;
	private GameObject camera1;

	// Use this for initialization
	void Start () 
	{
		camera1 = GameObject.Find ("Camera");
		spawn = this.GetComponent<Transform> ().position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isLocalPlayer)
		{
			float h = Input.GetAxis ("Horizontal");
			float v = Input.GetAxis ("Vertical") * 0.5f;

			transform.Rotate (new Vector3 (0, h, 0));
			transform.position -= transform.forward * v;

			if (Input.GetKeyDown (KeyCode.Space)) {
				Cmdfire ();
			}
		}


		if (transform.position.y < 0.2f)
		{
			score = 0;
			transform.position = spawn;
		}

		scoreText.text = "Score: " + score;
		scoreText.transform.LookAt (scoreText.transform.position - camera1.transform.position);

			
	}

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer> ().material.color = Color.red;
	}

	[Command]
	void Cmdfire()
	{
		var bullet = (GameObject)Instantiate (bulletPhrefab, new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z ) - transform.forward, Quaternion.identity);

		bullet.GetComponent<KogelHit> ().afgevuurdDoor = this.gameObject;

		bullet.GetComponent<Rigidbody> ().velocity = -transform.forward * 40;

		NetworkServer.Spawn (bullet);


		Destroy (bullet, 2.0f);
	}

	public void VerhoogScore()
	{
		score++;
	}
}
