using UnityEngine;
using System.Collections;

public class textBlockRenderer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float position = transform.position.y;
		float percent = (.125F * (2F * position + 3F))*100;
		foreach (TextMesh mesh in GetComponentsInChildren<TextMesh> ()) {
			mesh.text = (int)percent + "%";
		}
	}
}
