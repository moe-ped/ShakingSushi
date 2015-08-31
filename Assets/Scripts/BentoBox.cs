using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BentoBox : MonoBehaviour, IDropHandler 
{
	#region IDropHandler implementation

	public void OnDrop (PointerEventData eventData)
	{
		// Test
		int type = eventData.pointerDrag.GetComponent<DraggableObject> ().Type;
		Debug.Log (Game.Instance.SushiPrefabs[type].name);

		Destroy (eventData.pointerDrag.gameObject);
	}

	#endregion
}
