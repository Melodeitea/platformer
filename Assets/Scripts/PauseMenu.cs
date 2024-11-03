using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    LoadManager loadManager;
    public bool isPaused = false;

    bool[] myBools = new bool[100];
	bool[,] myBools2 = new bool[3,3];


	void Start()
	{
		loadManager = GameObject.FindGameObjectWithTag("LoadManager").GetComponent<LoadManager>();
        TogglePause(false);
        myBools[0] = true;

	}

	public void TogglePause(bool isPaused)
    {
        if (isPaused)
        {
            Time.timeScale = 0;
            this.isPaused = true;
            ShowMenu();
        }
        else
        {
			Time.timeScale = 0;
			this.isPaused = false;
			HideMenu();
		}

     void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
     void HideMenu()
    {
		canvasGroup.alpha = 0;
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
	}
}
}
