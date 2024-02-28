using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AIUIMeter : MonoBehaviour
{
	[SerializeField] TMP_Text label;
	[SerializeField] Slider slider;
	[SerializeField] Image image;

	// Property for setting position of the UI meter
	public Vector3 position
	{
		set
		{
			// Drawing a debug line from the given position to a position 3 units up
			Debug.DrawLine(value, value + Vector3.up * 3);
			// Converting world space position to viewport space
			Vector2 viewportPoint = Camera.main.WorldToViewportPoint(value);
			// Setting anchor points of the RectTransform to the converted viewport point
			GetComponent<RectTransform>().anchorMin = viewportPoint;
			GetComponent<RectTransform>().anchorMax = viewportPoint;
		}
	}

	// Property for setting the value of the UI meter
	public float value
	{
		set
		{
			slider.value = value;
		}
	}

	// Property for setting the text of the label
	public string text
	{
		set
		{
			label.text = value;
		}
	}

	// Property for toggling the visibility of the UI meter
	public bool visible
	{
		set
		{
			gameObject.SetActive(value);
		}
	}

	// Property for setting the alpha (transparency) of the image
	public float alpha
	{
		set
		{
			// Getting the current color of the image
			Color color = image.color;
			// Setting alpha value of the color
			color.a = value;
			// Setting the color back to the image
			image.color = color;
		}
	}
}