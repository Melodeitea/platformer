using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public CanvasGroup canvasGroup;

	private void Start()
	{
		
        TogglePause(false);

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

    public void ShowMenu()
    {
        CanvasGroup.alpha = 1;
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
    }
    public void HideMenu()
    {
		CanvasGroup.alpha = 0;
		CanvasGroup.interactable = false;
		CanvasGroup.blocksRaycasts = false;
	}
}
}
