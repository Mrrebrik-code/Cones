using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorHandler : MonoBehaviour
{
	public static EditorHandler Instance;
	public List<ConesEditor> ConesEditors = new List<ConesEditor>();
	public Transform ContentCones;
	public ConesEditor ConesPrefab;
	public AddButton AddButton;
	public int MaxCountCones;

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
	public void Run()
	{
		foreach (var cone in ConesEditors)
		{
			cone.Button.SetActive(true);
		}
	}

	public void AddCones()
	{
		ConesEditors.Add(Instantiate(ConesPrefab, ContentCones));
		if(ConesEditors.Count == MaxCountCones)
		{
			AddButton.Reversive();
		}
	}
	public void DelCones()
	{
		Destroy(ConesEditors[ConesEditors.Count - 1].gameObject);
		ConesEditors.Remove(ConesEditors[ConesEditors.Count - 1]);
	}


}
