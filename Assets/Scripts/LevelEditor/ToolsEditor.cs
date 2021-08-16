using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsEditor : MonoBehaviour
{
	public static ToolsEditor Instance;
	[SerializeField] private GameObject PanelActiveCircleTool;

	public Tools CurrentTools;

	public ConfigColorEditor CurrentconfigColor;

	public void Awake()
	{
		Instance = this;
	}

	public void SetActivePanel()
	{
		if(CurrentTools.TypeTool == ToolsType.circles)
		{
			PanelActiveCircleTool.SetActive(true);
		}
		else
		{
			PanelActiveCircleTool.SetActive(false);
		}
	}
}
