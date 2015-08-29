using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class DraggableObject : MonoBehaviour, IDragHandler, IDropHandler, IBeginDragHandler, IEndDragHandler
{
	public Action GotDestroyed = () => {};

	#region IDropHandler implementation

	public void OnDrop (PointerEventData eventData)
	{
		Debug.Log ("dropped " + gameObject.name + " on " + eventData.pointerCurrentRaycast.gameObject.name);
		foreach (GameObject hov in eventData.hovered)
		{
			Debug.Log (hov.name);
		}
	}

	#endregion

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
		GotDestroyed ();
	}
}
