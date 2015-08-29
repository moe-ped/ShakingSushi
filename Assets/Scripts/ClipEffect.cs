using UnityEngine;
using System.Collections;

public class ClipEffect : MonoBehaviour 
{
	public float Lifetime = 1;

	private float Life = 0;
	
	// Update is called once per frame
	void Update () 
	{
		Life -= Time.deltaTime;
		if (Life <= 0)
		{
			Deactivate ();
		}
	}

	public void Activate ()
	{
		Life = Lifetime;
		gameObject.SetActive (true);
	}

	private void Deactivate ()
	{
		gameObject.SetActive (false);
	}
}
