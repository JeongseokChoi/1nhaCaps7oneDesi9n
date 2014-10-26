using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	int i=0, j, random_result;
	int[] temp = new int[10]; // 
	bool bool_tmp = false;

	public GameObject[] menu_object = new GameObject[10];

		// Use this for initialization
	void Start () {

		// MENU_NUMBER random setting
		for( i=0; i<10; i++){
			bool_tmp = false;
			while( bool_tmp != true ){

				random_result = Random.Range (0,10);
				bool_tmp = true;
				for( j=0; j<i; j++){
					if( random_result == temp[j] ){
						bool_tmp = false;
						break;
					}
				}
			}

			temp[i] = random_result;

		}

/*
		for (i=0; i<10; i++) {	
			float temp_X = menu_object[i].transform.position.x;
			float temp_Y = menu_object[i].transform.position.y;
			float temp_Z = menu_object[i].transform.position.z;

			if( temp[i] == 1 || temp[i] == 4 || temp[i]== 7 ) menu_object[i].transform.position = new Vector3(-180.0f, temp_Y, temp_Z);
			else if( temp[i] == 2 || temp[i] ==  5 || temp[i] == 8 || temp[i] == 0 ) menu_object[i].transform.position = new Vector3(0.0f, temp_Y, temp_Z);
			else if( temp[i] == 3 || temp[i] ==  6 || temp[i] == 9 ) menu_object[i].transform.position = new Vector3(180f, temp_Y, temp_Z);

			temp_X = menu_object[i].transform.position.x;
			
			if( temp[i] == 1 || temp[i] == 2 || temp[i] == 3 ) menu_object[i].transform.position = new Vector3(temp_X, temp_Y, 360.0f);
			else if( temp[i] == 4 || temp[i] == 5 || temp[i] == 6 ) menu_object[i].transform.position = new Vector3(temp_X, temp_Y, 180.0f);
			else if( temp[i] == 7 || temp[i] == 8 || temp[i] == 9 ) menu_object[i].transform.position = new Vector3(temp_X, temp_Y, 0.0f);
			else if( temp[i] == 0 ) menu_object[i].transform.position = new Vector3(temp_X, temp_Y, -180.0f);
		}
*/
	}
	
	// Update is called once per frame
	void Update () {

		for (i=0; i<10; i++) {	
			float temp_X = menu_object[i].transform.position.x;
			float temp_Y = menu_object[i].transform.position.y;
			float temp_Z = menu_object[i].transform.position.z;
			Debug.Log(temp[i]);
			if( temp[i] == 1 || temp[i] == 4 || temp[i]== 7 ) menu_object[i].transform.position = new Vector3(-180.0f, temp_Y, temp_Z);
			else if( temp[i] == 2 || temp[i] ==  5 || temp[i] == 8 || temp[i] == 0 ) menu_object[i].transform.position = new Vector3(0.0f, temp_Y, temp_Z);
			else if( temp[i] == 3 || temp[i] ==  6 || temp[i] == 9 ) menu_object[i].transform.position = new Vector3(180f, temp_Y, temp_Z);
			
			temp_X = menu_object[i].transform.position.x;
			
			if( temp[i] == 1 || temp[i] == 2 || temp[i] == 3 ) menu_object[i].transform.position = new Vector3(temp_X, temp_Y, 360.0f);
			else if( temp[i] == 4 || temp[i] == 5 || temp[i] == 6 ) menu_object[i].transform.position = new Vector3(temp_X, temp_Y, 180.0f);
			else if( temp[i] == 7 || temp[i] == 8 || temp[i] == 9 ) menu_object[i].transform.position = new Vector3(temp_X, temp_Y, 0.0f);
			else if( temp[i] == 0 ) menu_object[i].transform.position = new Vector3(temp_X, temp_Y, -180.0f);
		}

	
	}
}
