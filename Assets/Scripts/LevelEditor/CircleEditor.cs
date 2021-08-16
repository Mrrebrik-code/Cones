using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CircleEditor : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Image Image;
	public bool EnterMouse;
	public Color CurrentColor;
	private void Awake()
	{
		CurrentColor = Image.color;
	}
	public void OnPointerClick(PointerEventData eventData)
	{

		if(ToolsEditor.Instance.CurrentTools != null)
		{
			EnterMouse = false;
			if (ToolsEditor.Instance.CurrentTools.TypeTool == ToolsType.circles)
			{
				SetColor(ToolsEditor.Instance.CurrentColor);
				CurrentColor = ToolsEditor.Instance.CurrentColor;
			}
			if (ToolsEditor.Instance.CurrentTools.TypeTool == ToolsType.lastik)
			{
				Image.color = new Color(0,0,0, 0f);
				CurrentColor = Image.color;
			}
		}
		
		
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		EnterMouse = true;
		SetColor(new Color(0, 0, 0, 0.5f));
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (EnterMouse)
		{
			SetColor(CurrentColor);
		}
		EnterMouse = false;

		
	}

	public void SetColor(Color color)
	{
		Image.color = color;
	}

	public Vector3 StartPosition;
	[SerializeField] private int _id;
	public bool isOut = false;
	public int Id { get { return _id; } }

	public void SetPosition(Vector3 position)
	{
		transform.position = position;
	}

	public void SetStartPosition()
	{
		StartPosition = transform.position;
	}
}
