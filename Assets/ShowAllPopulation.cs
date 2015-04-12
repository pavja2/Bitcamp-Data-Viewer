﻿using UnityEngine;
using System.Collections;
using Hover.Common.Items;
using Hover.Common.Items.Types;
public class ShowAllPopulation : BaseListener<ISelectorItem> {
	
	// Use this for initialization
	protected override void Setup () {
		Item.OnSelected += HandleSelected;
	}
	
	// Update is called once per frame
	protected override void BroadcastInitialValue () {
		
	}
	
	private void HandleSelected(ISelectableItem pItem){
		DataMapper.renderTotalPopulation(DataMapper.loadPopulation());
	}
}