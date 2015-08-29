using UnityEngine;
using UnityEngine.UI;

public class TextMarquee : MonoBehaviour
{
	private GUIStyle style = new GUIStyle();

	public string message;
	public Font bulkyPixel;

	public Rect messageRect;

	Vector2 dimensions;

	public float scrollSpeed = 50;
	

	void Start () {
		style.font = bulkyPixel;
		style.normal.textColor = Color.white;

	}

	void OnGUI ()
	{



		// Set up message's rect if we haven't already.
		if (messageRect.width == 0) {
			dimensions = GUI.skin.label.CalcSize(new GUIContent(message));

			// Start message past the left side of the screen.
			messageRect.x = (Screen.width * 0.9f);
			messageRect.width = dimensions.x;
			messageRect.height = dimensions.y;
		}
		
		messageRect.x += Time.deltaTime * scrollSpeed;
		
		// If message has moved past the right side, move it back to the left.
		if (messageRect.x < ((-Screen.width) - dimensions.x)) {
			messageRect.x = (Screen.width * 0.9995f);
		}

		messageRect.y = (Screen.height * 0.965f);
		
		GUI.Label(messageRect, message, style);
	}
}