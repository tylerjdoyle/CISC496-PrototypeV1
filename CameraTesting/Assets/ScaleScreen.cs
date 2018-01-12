using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int width = Screen.width;
		int height = Screen.height;
		gameObject.transform.localScale.Set (width, height, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
