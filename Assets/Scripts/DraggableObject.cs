using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

// This means sushi. Do not use for anything else
// TODO: rename
public class DraggableObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
	public Action<int> GotDestroyed = (int Type) => {};
    public int Type;

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		transform.SetParent (Game.Instance.IgnoreRacastGroup);
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		transform.SetParent (Game.Instance.AllowRacastGroup);
	}

	#endregion

	void OnDestroy ()
	{
		GotDestroyed (Type);
	}
}
