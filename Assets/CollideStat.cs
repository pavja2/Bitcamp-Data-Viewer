using UnityEngine;
using System.Collections;
using Leap.Util;
using Leap;
public class CollideStat : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		HandController handController = GameObject.Find ("HandController").GetComponent<HandController> ();
		HandModel[] hands = handController.GetAllGraphicsHands ();
		foreach (HandModel hand in hands) {
			foreach (FingerModel finger in hand.fingers) {
				Ray fingerRay = finger.GetRay ();
				RaycastHit hit = new RaycastHit ();
				if (Physics.Raycast (fingerRay, out hit)) {
					if (hit.collider.gameObject.CompareTag ("Scaleable")) {
						switch(hit.collider.gameObject.name){
						case "Ward 1":

							break;
						case "Ward 2":
								break;
						case "Ward 3":
							break;
						case "Ward 4":
							break;
						case "Ward 5":
							break;
						case "Ward 6":
							break;
						case "Ward 7":
							break;
						case "Ward 8":
							break;
						default:
							break;
						}
					}
				}
			}
		}
	}

	void OntriggerEnter(Collider other){
		if (IsHand (other)) {
			Debug.Log ("Yay!");
		}
	}

	private bool IsHand(Collider other){
		if (other.transform.parent && other.transform.parent.parent && other.transform.parent.parent.GetComponent<HandModel>())
			return true;
		else
			return false;
	}
}
