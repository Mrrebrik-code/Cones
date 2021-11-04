using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLevelHandler : MonoBehaviour
{
	public List<LevelButton> LeveButtons = new List<LevelButton>();
	public Color ColorNoActive;
	public Color ColorActive;
	public Color ColorComplet;
	[SerializeField] private GameObject[] _listLevels;
	private int _currentIndexList = 0;

	public void NextListing()
	{
		if (_currentIndexList == _listLevels.Length - 1) return;
		_currentIndexList++;
		SetlevelsGroup(_currentIndexList);
	}

	public void BackListing()
	{
		if (_currentIndexList == 0) return;
		_currentIndexList--;
		SetlevelsGroup(_currentIndexList);

	}

	private void SetlevelsGroup(int index)
	{
		foreach (var levelsGroup in _listLevels)
		{
			levelsGroup.SetActive(false);
		}
		if (index == 2) index--;
		 _listLevels[index].SetActive(true);
	}

	public void ShowCurrentLevelGroup(int id)
	{
		SetlevelsGroup(id);
	}
	public void UpdateLevelButton()
	{
		Level tempLevel = default;
		foreach (var level in GameHandler.Instance.Levels)
		{
			if(level.isComplet == false)
			{
				tempLevel = level;
				break;
			}
		}
		foreach (var level in GameHandler.Instance.Levels)
		{
			if (level.isComplet)
			{
				LeveButtons[level.Id - 1].SetColor(ColorComplet);
				LeveButtons[level.Id - 1].GetComponent<Button>().interactable = true;
			}
			else
			{
				LeveButtons[level.Id - 1].SetColor(ColorNoActive);
				LeveButtons[level.Id - 1].GetComponent<Button>().interactable = false;
			}
		}
		for (int i = GameHandler.Instance.Levels.Count; i < LeveButtons.Count; i++)
		{
			LeveButtons[i].SetColor(ColorNoActive);
			LeveButtons[i].GetComponent<Button>().interactable = false;
		}
		foreach (var levelButton in LeveButtons)
		{
			if (tempLevel != null && levelButton.LevelId == tempLevel.Id)
			{
				levelButton.SetColor(ColorActive);
				levelButton.GetComponent<Button>().interactable = true;
			}
		}


	}
}
