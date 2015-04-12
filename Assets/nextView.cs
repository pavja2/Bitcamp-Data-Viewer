using UnityEngine;
using System.Collections;
using Hover.Common.Items;
using Hover.Common.Items.Types;
public class nextView : BaseListener<ISelectorItem> {

	int currentView = 0;
	// Use this for initialization
	protected override void Setup () {
		Item.OnSelected += HandleSelected;
		currentView = 1;
	}
	
	// Update is called once per frame
	protected override void BroadcastInitialValue () {
		
	}
	
	private void HandleSelected(ISelectableItem pItem){
		GameObject rig = GameObject.Find ("MainRig");
		currentView++;
		if (currentView == 2) {
			rig.transform.position = new Vector3 (-0.3435819F, 1.133678F, -0.8087363F);
			OVRManager.display.RecenterPose();
		}
		else{
			rig.transform.position = new Vector3 (3.119982F, 2.042149F, 0.4924417F);
			OVRManager.display.RecenterPose();
			currentView = 1;
		}
	}
}
