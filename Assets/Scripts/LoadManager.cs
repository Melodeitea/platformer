using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
	private void Start()
	{
		DontDestroyOnLoad(gameObject);
	}
	public void LoadScene(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);   
	}

	public void LoadScene(string name)
	{
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	public void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
	}

}
