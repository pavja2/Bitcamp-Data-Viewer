using UnityEngine;
using System.Collections;

public class textbillboard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (Camera.current.transform);
		transform.Rotate (0, 180, 0);
	}
}
