using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BentoBox : MonoBehaviour, IDropHandler 
{
	#region IDropHandler implementation

	public void OnDrop (PointerEventData eventData)
	{
		Debug.Log ("dropped" + eventData.pointerDrag);
		Destroy (eventData.pointerDrag.gameObject);
		Game.Instance.Score++;
	}

	#endregion
}
