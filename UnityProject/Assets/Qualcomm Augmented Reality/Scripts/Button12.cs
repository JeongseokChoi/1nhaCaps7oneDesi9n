using UnityEngine;
using System.Collections;

public class Button12 : MonoBehaviour {

	public string password;
	public static string change_password;
	public static string change_password_confirm;

	public static bool b_confirmPW = false;
	public static bool b_changePW_confirm = false;

	//private float x, y;
	
	// Use this for initialization
	void Start () {

		password = "";
		change_password = "";
		change_password_confirm = "";
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
		if (InputQueue.queue.Count != 4) {
			InputQueue.queue.Clear ();
			return;
		}

		password = "";
		if ( Button13.b_changePW == false)
		{
			if (Input.GetMouseButtonDown (0)) {
				while (InputQueue.queue.Count > 0) {
					password += ((int)(InputQueue.queue.Dequeue ())).ToString ();
					Debug.Log (password);
				}
				Debug.Log ("비번입력");
				Debug.Log ("password");
				Debug.Log (password);
			}

			BtConnector.sendString(password);
		}
		else
		{
			if( b_changePW_confirm == false ){
				if (Input.GetMouseButtonDown (0)) {
					while (InputQueue.queue.Count > 0) {
						password += ((int)(InputQueue.queue.Dequeue ())).ToString ();
						Debug.Log (InputQueue.queue);
					}
					Debug.Log ("비번바꾸기_비번확인");
					Debug.Log ("password");
					Debug.Log (password);
				}

				BtConnector.sendString(password);

				b_changePW_confirm = true;
			}
			else{
				if( b_confirmPW == false ){
					if (Input.GetMouseButtonDown (0)) {
						while (InputQueue.queue.Count > 0) {
							change_password += ((int)(InputQueue.queue.Dequeue ())).ToString ();
							Debug.Log (InputQueue.queue);
						}
						Debug.Log ("비번바꾸기");
						Debug.Log ("change_password");
						Debug.Log (change_password);
					}
					b_confirmPW = true;
				}
				else {
					if (Input.GetMouseButtonDown (0)) {
						while (InputQueue.queue.Count > 0) {
							change_password_confirm += ((int)(InputQueue.queue.Dequeue ())).ToString ();
							Debug.Log (InputQueue.queue);
						}
						Debug.Log ("비번바꾸기확인");
						Debug.Log ("change_password_confirm");
						Debug.Log (change_password_confirm);
					}
					
					// 비번 같은지 확인
					if( change_password == change_password_confirm){
						password = change_password_confirm;
						Debug.Log ("같다");
						b_confirmPW = false;
						Button13.b_changePW = false;
						change_password = "";
						change_password_confirm = "";
						b_changePW_confirm = true;

						BtConnector.sendString(password);

					}
					else{
						Debug.Log ("다르다");
						b_confirmPW = false;
						Button13.b_changePW = false;
						change_password = "";
						change_password_confirm = "";
						b_changePW_confirm = true;

						BtConnector.sendString("bcde");

					}
				}
			}
		}
	}
}
