using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
	public static GameHandler Instance;
	public List<Cone> SelectedCones = new List<Cone>();
	public List<Level> Levels = new List<Level>();
	public Level CurrentLevel;
	[SerializeField] private Text _levelText;
	public void SelectedCone(Cone cone)
	{
		SelectedCones.Add(cone);
	}

	private void Awake()
	{
		Instance = this;
		StartLevel(Levels[0]);
	}
	public void StartLevel(Level levelStart)
	{
		_levelText.text = $"спнбемэ {levelStart.Id}";
		if (CurrentLevel != null)
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

	public void CheckLevel()
	{
		var temp = 0;
		foreach (var cone in CurrentLevel.Cones)
		{
			if (cone.isComplet)
			{
				temp++;
			}

		}
		if(temp == CurrentLevel.CountCones)
		{
			NextLevel();
		}
			
	}
	private void NextLevel()
	{
		StartLevel(Levels[CurrentLevel.Id]);
	}

	public void BreakLevel()
	{
		SelectedCones = new List<Cone>();
		foreach (var Cone in CurrentLevel.Cones)
		{
			Cone.isComplet = false;
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
