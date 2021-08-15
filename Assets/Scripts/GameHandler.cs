using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
	public static GameHandler Instance;
	public List<Cone> SelectedCones = new List<Cone>();
	public List<Level> Levels = new List<Level>();
	public Level CurrentLevel;
	public void SelectedCone(Cone cone)
	{
		SelectedCones.Add(cone);
	}

	private void Awake()
	{
		Instance = this;
		StartLevel(Levels[4]);
	}
	public void StartLevel(Level levelStart)
	{
		if(CurrentLevel != null)
		{
			BreakLevel();
		}
		CurrentLevel = levelStart;
		foreach (var level in Levels)
		{

			if (level != levelStart) 
			{
				level.gameObject.SetActive(false);
			}
			levelStart.gameObject.SetActive(true);
		}
	}

	private void NextLevel()
	{

	}

	public void BreakLevel()
	{
		SelectedCones = new List<Cone>();
		foreach (var Cone in CurrentLevel.Cones)
		{
			if (Cone.CircleOut)
			{
				Cone.CircleOut.isOut = false;
				Cone.CircleOut = null;
			}
			foreach (var cell in Cone.Cells)
			{
				cell.Restart();
			}
		}
	}
}
