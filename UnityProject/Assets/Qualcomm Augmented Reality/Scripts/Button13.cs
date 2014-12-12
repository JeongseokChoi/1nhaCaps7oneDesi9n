using UnityEngine;
using System.Collections;

public class Button13 : MonoBehaviour {

	public static bool b_changePW = false;
	//public GameObject Object_changePW = new GameObject(); 
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown() {
		
		//this.transform.position = new Vector3 (x, y, 0.6533f);
		
		if (Input.GetMouseButtonDown (0)) {
			if( b_changePW == false ){

				BtConnector.sendString ("abcd");

				b_changePW = true;
				Button12.b_changePW_confirm = false;
				Debug.Log ("SettingPassword");
				Debug.Log (b_changePW);
				// normal : false, SettingPassword : true
			}
			else{

				BtConnector.sendString ("bcde");

				InputQueue.queue.Clear ();
				b_changePW = false;
				Button12.b_confirmPW = false;
				Button12.change_password = "";
				Button12.change_password_confirm = "";
				Button12.b_changePW_confirm = false;
				Debug.Log ("SettingPassword");
				Debug.Log (b_changePW);
			}
		}

	}
}
