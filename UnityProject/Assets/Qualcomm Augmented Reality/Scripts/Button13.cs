using UnityEngine;
using System.Collections;

public class Button13 : MonoBehaviour {
	
	public static bool b_changePw = false;
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

            // 비밀번호가 입력모드 일 때 Button13(비밀번호변경버튼)이 클릭되면
            if (b_changePw == false)
            {
                // "abcd" 전송, b_changePw 변경
				BtConnector.sendString ("abcd");
				b_changePw = true;
			}
            // 비밀번호가 변경모드 일 때 Button13(비밀번호변경버튼)이 클릭되면
            else
            {
				// "bcde" 전송, b_changePw 변경
                BtConnector.sendString ("bcde");
				b_changePw = false;
			}

            // 비밀번호 변경 버튼 누를 때마다 Queue, bool값과 변수 초기화
            InputQueue.queue.Clear();
            Button12.b_pw = false;
            Button12.b_checkPw = false;
            Button12.change_password = "";
            Button12.change_password_confirm = "";

		}
		
	}
}

