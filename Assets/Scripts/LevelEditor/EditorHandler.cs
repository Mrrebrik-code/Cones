using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorHandler : MonoBehaviour
{
	public static EditorHandler Instance;
	public List<ConesEditor> ConesEditors = new List<ConesEditor>();
	public Transform ContentCones;
	public ConesEditor ConesPrefab;
	public AddButton AddButton;
	public int MaxCountCones;

	public List<ConfigColorEditor> ConfigColorEditor = new List<ConfigColorEditor>();

	public List<CircleEditor> Circles = new List<CircleEditor>();

	[SerializeField] private Image statusRun;

	public List<ConesEditor> SelectedCones = new List<ConesEditor>();
	public void SelectedCone(ConesEditor cone)
	{
		SelectedCones.Add(cone);
	}

	private void Awake()
	{
		Instance = this;
	}

	public void Break()
	{
		foreach (var cone in ConesEditors)
		{
			/*foreach (var cell in cone.CellEditor)
			{
				//cell.SetColor(Color.white);
				//cell.CurrentColor = Color.white;
			}*/
		}
	}
	public void Save()
	{

	}
	public void Recuve()
	{

	}

	public bool isRun;
	public void Run()
	{
		if (!isRun)
		{
			statusRun.color = Color.red;
			isRun = !isRun;
			foreach (var cone in ConesEditors)
			{
				cone.Button.SetActive(true);

			}
			foreach (var circle in Circles)
			{
				circle.isRunEditor = true;
			}
		}
		else
		{
			isRun = !isRun;
			statusRun.color = Color.white;
			foreach (var cone in ConesEditors)
			{
				cone.Button.SetActive(false);
			}
			foreach (var circle in Circles)
			{
				circle.isRunEditor = false;
			}
		}
		
	}

	public void AddCones()
	{
		ConesEditors.Add(Instantiate(ConesPrefab, ContentCones));
	}
	public void DelCones()
	{
		Destroy(ConesEditors[ConesEditors.Count - 1].gameObject);
		ConesEditors.Remove(ConesEditors[ConesEditors.Count - 1]);
	}


}
