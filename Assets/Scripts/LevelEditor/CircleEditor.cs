using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CircleEditor : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Image Image;
	public bool EnterMouse;
	public Color CurrentColor;
	public Action OnActiveToCellAction;
	public bool isRunEditor;
	private void Start()
	{
		CurrentColor = Image.color;
		EditorHandler.Instance.Circles.Add(this);
	}
	public void OnPointerClick(PointerEventData eventData)
	{
		if (!isRunEditor)
		{
			if (ToolsEditor.Instance.CurrentTools != null)
			{
				EnterMouse = false;
				if (ToolsEditor.Instance.CurrentTools.TypeTool == ToolsType.circles)
				{
					SetColor(ToolsEditor.Instance.CurrentconfigColor.Color);
					CurrentColor = ToolsEditor.Instance.CurrentconfigColor.Color;
					_id = ToolsEditor.Instance.CurrentconfigColor.Id;
				}
				if (ToolsEditor.Instance.CurrentTools.TypeTool == ToolsType.lastik)
				{
					OnActiveToCellAction?.Invoke();
					Image.color = new Color(0, 0, 0, 0f);
					CurrentColor = Image.color;
				}
			}
		}

	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!isRunEditor)
		{
			EnterMouse = true;
			SetColor(new Color(0, 0, 0, 0.5f));
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!isRunEditor)
		{
			if (EnterMouse)
			{
				SetColor(CurrentColor);
			}
			EnterMouse = false;
		}

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
