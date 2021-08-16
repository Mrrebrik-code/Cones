using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ToolsType
{
	circles,
	zalivka,
	lastik
	
}
public class Tools : MonoBehaviour
{

	public ToolsType TypeTool;
	public void SetTools()
	{
		ToolsEditor.Instance.CurrentTools = this;
		ToolsEditor.Instance.SetActivePanel();
	}
}
