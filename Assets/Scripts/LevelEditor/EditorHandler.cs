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
	[SerializeField] private Text _textButtonRun;
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
			foreach (var cell in cone.Cells)
			{
				cell.StartCircleBusy.SetColor(Color.white);
				cell.StartCircleBusy.CurrentColor = Color.white;
				cell.Restart();
			}
		}
	}
	public void Save()
	{
		foreach (var cone in ConesEditors)
		{
			foreach (var cell in cone.Cells)
			{
				cell.SaveCurrent();
				if(cell.CircleBusy != null)
				{
					cell.CircleBusy.SaveCurrent();
				}
					
			}
		}
	}
	public void Recuve()
	{
		foreach (var cone in ConesEditors)
		{
			foreach (var cell in cone.Cells)
			{
				cell.UndoToSave();
				if(cell.CircleBusy != null)
				{
					cell.CircleBusy.UndoToSave();
				}
				
			}
		}
	}

	public bool isRun;
	public void Run()
	{

		if (!isRun)
		{
			_textButtonRun.text = "Œ—“¿ÕŒ¬»“‹";
			Save();
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
			_textButtonRun.text = "«¿œ”—“»“‹";
			Break();
			Recuve();
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
