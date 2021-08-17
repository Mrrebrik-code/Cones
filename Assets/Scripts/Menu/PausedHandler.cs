using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausedHandler : MonoBehaviour
{
	public static PausedHandler Instance;
	[SerializeField] private GameObject _mapLevels;
	[SerializeField] private GameObject _winPanel;
	[SerializeField] private GameObject _homePanel;
	[SerializeField] private Text _textCurrentCompletLevel;
	[SerializeField] private GameObject _popupHelper;
	[SerializeField] private Text _textPopup;
	public Text _textCountMoleculesReward;
	private const string _sceneMenu = "_Menu";

	private void Awake()
	{
		Instance = this;
	}

	public void ActiveBoxColliderToCones(bool active)
	{
		if(GameHandler.Instance.CurrentLevel != null)
		{
			foreach (var cone in GameHandler.Instance.CurrentLevel.Cones)
			{
				cone.BoxCollierd2D.enabled = active;
			}
		}
		

	}
	public void ContinueToMenu()
	{
		SceneManager.LoadScene(_sceneMenu);
	}
	public void OpenMapLevels()
	{
		_mapLevels.SetActive(true);
		ActiveBoxColliderToCones(false);
	}
	public void CloseMapLevels()
	{
		ActiveBoxColliderToCones(true);
		_mapLevels.SetActive(false);
	}

	public void OpenWinPanel()
	{
		ActiveBoxColliderToCones(false);
		_winPanel.SetActive(true);
		_textCountMoleculesReward.text = GameHandler.Instance.CurrentLevel.RewardMolecules.ToString();
		_textCurrentCompletLevel.text = $"������� { GameHandler.Instance.CurrentLevel.Id}\n�������";
	}
	public void CloseWinPanel()
	{
		ActiveBoxColliderToCones(true);
		_winPanel.SetActive(false);
	}

	public void CloseHomePanel()
	{
		ActiveBoxColliderToCones(true);
		_homePanel.SetActive(false);
	}

	public void ShowPopupHelper(string comment)
	{
		StopAllCoroutines();
		_popupHelper.SetActive(false);
		_textPopup.text = comment;
		StartCoroutine(ShowPopup());
	}

	private IEnumerator ShowPopup()
	{
		_popupHelper.SetActive(true);
		yield return new WaitForSeconds(5.5f);
		_popupHelper.SetActive(false);

	}
}
