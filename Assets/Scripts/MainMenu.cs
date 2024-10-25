using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject loadManagerPrefab;
    LoadManager loadManager;

    // Start is called before the first frame update
    void Start()
    {
        
        GameObject lm = GameObject.FindGameObjectWithTag("LoadManager");
        if (lm != null)
        {
            loadManager = lm.GetComponent<LoadManager>();
            return;
        }

		loadManager = Instantiate(loadManagerPrefab, null).GetComponent<LoadManager>();

	}

    public void StartGame()
    {
        loadManager.LoadScene(1);
    }
}
