using UnityEngine;
using System.Collections;

public class Button12 : MonoBehaviour {

	public string password;

	//private float x, y;

	// Use this for initialization
	void Start () {
		password = "";
		//x = this.transform.position.x;
		//y = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
//		password = "";
//		if (Input.GetMouseButtonDown (0)) {
//			while (InputQueue.queue.Count > 0)
//				password += ((int)(InputQueue.queue.Dequeue ())).ToString ();
//			Debug.Log (password);
//		}
	}
	
	void OnMouseDown() {

		//this.transform.position = new Vector3 (x, y, 0.6533f);

		password = "";
		if (Input.GetMouseButtonDown (0)) {
			while (InputQueue.queue.Count > 0)
					password += ((int)(InputQueue.queue.Dequeue ())).ToString ();
			Debug.Log (password);

			// Testing
			AesEncryption.encrypt (password);
		}
	}
}
