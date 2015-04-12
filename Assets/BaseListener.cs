using UnityEngine;
using System.Collections;
using Hover.Cast;
using Hover.Cast.Custom;
using Hover.Cast.Items;
using Hover.Common.Items;
public abstract class BaseListener<T> : HovercastItemListener<T> where T : ISelectableItem {
	// Use this for initialization
	protected HovercastSetup CastSetup { get; private set; }
	protected HovercastItemVisualSettings ItemSett { get; private set; }
	protected InteractionSettings InteractSett { get; private set; }
}
