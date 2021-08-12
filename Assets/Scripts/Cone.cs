using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour
{
	public List<Cell> _cells = new List<Cell>();
	public bool isReady = false;
	public Transform OutPositionToCone;
	public Circle CircleOut;

	private void OnMouseDown()
	{
		GameHandler.Instance.SelectedCone(this);
		var check = false;
		foreach (var cellCheck in _cells)
		{
			if (cellCheck.CircleBusy != null || GameHandler.Instance.SelectedCones.Count == 2)
			{
				if (!CheckFill())
				{
					check = true;
				}
				else
				{
					GameHandler.Instance.SelectedCones[0]._cells.Reverse();
					foreach (var cell in GameHandler.Instance.SelectedCones[0]._cells)
					{
						if (!cell.IsBusy && GameHandler.Instance.SelectedCones[0].CircleOut)
						{
							cell.CircleBusy = GameHandler.Instance.SelectedCones[0].CircleOut;
							cell.CircleBusy.isOut = false;
							cell.CircleBusy.SetPosition(cell.Transform.position);
							cell.IsBusy = true;
							GameHandler.Instance.SelectedCones[0].CircleOut = null;

							break;
						}
					}
					GameHandler.Instance.SelectedCones[0]._cells.Reverse();
				}
				break;
			}
			else
			{
				check = false;
			}
		}
		if (!check)
		{
			GameHandler.Instance.SelectedCones = new List<Cone>();
			return;
		}




		if (GameHandler.Instance.SelectedCones.Count < 2)
		{
			InAndOutCircleFromCell();
		}
		else if(GameHandler.Instance.SelectedCones[0] == GameHandler.Instance.SelectedCones[1])
		{
			InAndOutCircleFromCell();
			GameHandler.Instance.SelectedCones = new List<Cone>();
			return;
			
		}
		else if (CheckCircle())
		{
			GameHandler.Instance.SelectedCones[0]._cells.Reverse();
			foreach (var cell in GameHandler.Instance.SelectedCones[0]._cells)
			{
				if (!cell.IsBusy && GameHandler.Instance.SelectedCones[0].CircleOut)
				{
					cell.CircleBusy = GameHandler.Instance.SelectedCones[0].CircleOut;
					cell.CircleBusy.isOut = false;
					cell.CircleBusy.SetPosition(cell.Transform.position);
					cell.IsBusy = true;
					GameHandler.Instance.SelectedCones[0].CircleOut = null;
					break;
				}
			}
			GameHandler.Instance.SelectedCones[0]._cells.Reverse();
			GameHandler.Instance.SelectedCones = new List<Cone>();
			return;
		}
		else
		{
			GameHandler.Instance.SelectedCones[1]._cells.Reverse();
			foreach (var cell in GameHandler.Instance.SelectedCones[1]._cells)
			{
				if (cell.IsBusy == false)
				{
					cell.IsBusy = true;
					cell.CircleBusy = GameHandler.Instance.SelectedCones[0].CircleOut;
					GameHandler.Instance.SelectedCones[0].CircleOut.SetPosition(cell.Transform.position);
					GameHandler.Instance.SelectedCones[0].CircleOut.isOut = false;
					GameHandler.Instance.SelectedCones[0].CircleOut = null;

					break;

				}
			}
			GameHandler.Instance.SelectedCones[1]._cells.Reverse();
			GameHandler.Instance.SelectedCones = new List<Cone>();

		}

	}

	private bool CheckCircle()
	{
		GameHandler.Instance.SelectedCones[1]._cells.Reverse();
		foreach (var cell in GameHandler.Instance.SelectedCones[1]._cells)
		{
			if(cell.CircleBusy != null && cell.CircleBusy.Id == GameHandler.Instance.SelectedCones[0].CircleOut.Id)
			{
				Debug.LogError(cell.CircleBusy.Id + "-" + cell.CircleBusy.gameObject.name +  ":" + GameHandler.Instance.SelectedCones[0].CircleOut.Id + "-" + GameHandler.Instance.SelectedCones[0].CircleOut.gameObject.name);
				//GameHandler.Instance.SelectedCones[1]._cells.Reverse();
				GameHandler.Instance.SelectedCones[1]._cells.Reverse();
				return false;
			}
		}
		
		if (!GameHandler.Instance.SelectedCones[1]._cells[0].IsBusy)
		{
			GameHandler.Instance.SelectedCones[1]._cells.Reverse();
			return false;
		}
		GameHandler.Instance.SelectedCones[1]._cells.Reverse();
		return true;
	}
	private bool CheckFill()
	{
		bool check = true;
		if(GameHandler.Instance.SelectedCones.Count != 2)
		{
			return false;
		}
		foreach (var cellCheck in GameHandler.Instance.SelectedCones[1]._cells)
		{
			if (!cellCheck.IsBusy)
			{
				check = false;
			}
		}
		return check;
	}
	public void InAndOutCircleFromCell()
	{
		foreach (var cell in _cells)
		{
			if (cell.IsBusy && CircleOut == null )
			{
				if ( !cell.CircleBusy.isOut)
				{
					cell.CircleBusy.SetPosition(OutPositionToCone.position);
					cell.CircleBusy.isOut = true;
					cell.IsBusy = false;
					CircleOut = cell.CircleBusy;
					cell.CircleBusy = null;
					
				}
				return;
			}
		}
		_cells.Reverse();
		foreach (var cell in _cells)
		{
			if (!cell.IsBusy && CircleOut)
			{
				cell.CircleBusy = CircleOut;
				cell.CircleBusy.isOut = false;
				cell.CircleBusy.SetPosition(cell.Transform.position);
				cell.IsBusy = true;
				CircleOut = null;
				_cells.Reverse();
				return;
			}
		}
		_cells.Reverse();

	}
	private void SortCells()
	{
		var temp = new List<Cell>();
		for (int i = 0; i < _cells.Count; i++)
		{
			foreach (var cell in _cells)
			{
				if (cell.Id == i)
				{
					temp.Add(cell);
					break;
				}
			}
		}
		_cells = temp;
	}

}
