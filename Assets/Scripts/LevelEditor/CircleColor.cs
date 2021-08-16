using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CircleColor : MonoBehaviour
{
	public Image Image;

	public void Click()
	{
		ToolsEditor.Instance.CurrentColor = Image.color;
	}


}
