using UnityEngine;
using System.Collections;

public class Button12 : MonoBehaviour {
	
	public string password;
	public static string change_password;
	public static string change_password_confirm;
	
	public static bool b_pw = false;
	public static bool b_checkPw = false;
	
	
	// Use this for initialization
	void Start () {
		
		password = "";
		change_password = "";
		change_password_confirm = "";

	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnMouseDown() {
		if (InputQueue.queue.Count != 4) {
			InputQueue.queue.Clear ();
			return;
		}
		
		password = "";
		if ( Button13.b_changePw == false)
		{
            // 비번 입력 , password
			if (Input.GetMouseButtonDown (0)) {
				while (InputQueue.queue.Count > 0) {
					password += ((int)(InputQueue.queue.Dequeue ())).ToString ();
				}
			}
			
			BtConnector.sendString(password);
		}
		else
		{
            // 비번바꾸기_비번확인, password
			if( b_checkPw == false ){
				if (Input.GetMouseButtonDown (0)) {
					while (InputQueue.queue.Count > 0) {
						password += ((int)(InputQueue.queue.Dequeue ())).ToString ();
					}
				}
				
				BtConnector.sendString(password);
				
				b_checkPw = true;
			}
			else{   // 비번확인 후
                // 비번 변경, change_password
				if( b_pw == false ){
					if (Input.GetMouseButtonDown (0)) {
						while (InputQueue.queue.Count > 0) {
							change_password += ((int)(InputQueue.queue.Dequeue ())).ToString ();
						}
					}
					b_pw = true;
				}
                // 비번 변경 재입력 change_password_confirm
				else {
					if (Input.GetMouseButtonDown (0)) {
						while (InputQueue.queue.Count > 0) {
							change_password_confirm += ((int)(InputQueue.queue.Dequeue ())).ToString ();
						}
					}
					
					// 비번 같은지 확인
					if( change_password == change_password_confirm){
                        // 두번 입력한 비밀번호가 같으면 password 전송
						password = change_password_confirm;					
						BtConnector.sendString(password);
						
					}
					else{
                        // 두번 입력한 비밀번호가 다르면 "bcde" 전송					
						BtConnector.sendString("bcde");
					}

                    // 초기화
                    InputQueue.queue.Clear();
                    b_pw = false;
                    b_checkPw = true;
                    Button13.b_changePw = false;
                    change_password = "";
                    change_password_confirm = "";
				}
			}
		}
	}
}

