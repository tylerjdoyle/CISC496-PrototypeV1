using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour {
	private bool camAvailable;
	private WebCamTexture camTexture;

	public AspectRatioFitter fit;
	public RawImage bg; // may be GI

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;

		WebCamDevice[] devices = WebCamTexture.devices;

		if (devices.Length == 0) {
			Debug.Log ("No camera available");
			camAvailable = false;
			return;
		}

		for (int i = 0; i < devices.Length; i++) {
			camTexture = new WebCamTexture (devices [i].name, Screen.width, Screen.height);
			if (!devices [i].isFrontFacing) { // Will have to remove this in order to test with a webcam
				camTexture = new WebCamTexture (devices [i].name, Screen.width, Screen.height);
			}
		}

		if (camTexture == null) {
			Debug.Log ("Unable to find back camera");
			return;
		}

		camTexture.Play ();
		bg.texture = camTexture;

		camAvailable = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!camAvailable)
			return;

		float camRatio = (float)camTexture.width / (float)camTexture.height;
		fit.aspectRatio = camRatio;

		int orient = -camTexture.videoRotationAngle;
		bg.rectTransform.localEulerAngles = new Vector3 (0, 0, orient);

	}
}
