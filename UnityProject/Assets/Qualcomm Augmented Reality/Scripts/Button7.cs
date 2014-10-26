using UnityEngine;
using System.Collections;

public class Button7 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetMouseButtonDown (0)) {
//			InputQueue.queue.Enqueue (7);
//		}
	}
	
	void OnMouseDown() {
		InputQueue.queue.Enqueue (7);
	}
}
