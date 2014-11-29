using UnityEngine;
using System.Collections;

public class Button12 : MonoBehaviour {

	public string password;

	// Use this for initialization
	void Start ()
	{
		password = "";
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	
	void OnMouseDown()
	{
		password = "";
		if (Input.GetMouseButtonDown (0)) {
			while (InputQueue.queue.Count > 0)
				password += ((int)(InputQueue.queue.Dequeue ())).ToString ();
			Debug.Log (password);

			if (password != "")
			{
				//
				//byte[] cipher = AesEncryption.encrypt (password);
				//

				if (BtConnector.isConnected())
					BtConnector.sendString(password);
			}
		}
	}
}
