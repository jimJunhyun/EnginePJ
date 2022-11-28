using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public enum StageProgress
	{
		None = -1,

		Home,
		OutHome,
		Alley,
		CandyHouseHallway,
		CandyHouseRoom,
		FrontApartment,
		InsideApartment,
		InsideElevator,

	}

	public StageProgress curProgress{get; private set; }
	private void Awake()
	{
		instance = this;
		curProgress = StageProgress.Home;
	}
	public void SetProgress(int progress)
	{
		curProgress = (StageProgress)progress;
	}
}
