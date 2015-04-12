using UnityEngine;
using System.Collections;
public class lineofSight : MonoBehaviour {
	
	Transform cameraTransform = null;
	
	void Awake() {
		cameraTransform = GameObject.FindWithTag("MainCamera").transform;
	}
	
	void Update() {
		float length = 10.0f;
		RaycastHit hit;
		Vector3 rayDirection = cameraTransform.TransformDirection(Vector3.forward);
		Vector3 rayStart = cameraTransform.position + rayDirection;      // Start the ray away from the player to avoid hitting itself
		Debug.DrawRay(rayStart, rayDirection * length, Color.green);
		if (Physics.Raycast(rayStart, rayDirection, out hit, length)) {
				Debug.Log("Towers");
			}
		}
}
