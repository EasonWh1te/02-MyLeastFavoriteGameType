using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_Bar : MonoBehaviour {
	[SerializeField] RectTransform myFill;

	public void SetValue (float g_value) {
		myFill.localScale = new Vector2 (g_value, 1);
	}
}
