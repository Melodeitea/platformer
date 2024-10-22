using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//for Text Mesh pro, enhances functionality in Ui text mesh

public class CoinCounter : MonoBehaviour
{
	//way of having globally accessible data or methods that aren't tied to Unity’s GameObject system.
	public static CoinCounter instance;

	public TMP_Text coinText;
	public int currentCoins = 0;

	//Awake is called when the script instance is being loaded
	private void Awake()
	{
		instance = this;
	}

	// Start is called before the first frame update
	void Start()
	{
		coinText.text = "COINS : " + currentCoins.ToString();
	}

	public void IncreaseCoins(int v)
	{
		currentCoins += v;
		coinText.text = "COINS : " + currentCoins.ToString();
	}
}

/*
 *⢀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠸⣧⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⡽⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⣿⠀⣿⠀⠀⠀⠀⠀⠀⠀⠸⣇⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⣿⠀⣿⣤⣄⠀⠀⠀⠀⠀⠀⣿⠀⣿⠀⠀⠀⠀⣴⠶⠂⠀⠀⠀⠀
⠀⠀⠀⣿⠀⣿⠀⣿⠀⠀⠀⠀⠀⠀⢹⣄⣿⡀⠀⠀⣴⠿⣦⠀⠀⠀⠀⠀
⠀⠀⠀⣿⠶⠿⠶⠿⠶⠶⢶⡄⠀⠀⢸⡏⠉⠙⠛⠛⠻⠶⠿⢦⣄⠀⠀⠀
⠀⠀⣠⣿⠶⠶⠶⢦⣄⡀⢸⣇⣀⣀⣸⡇⠀⢀⣀⣀⠀⠀⠀⣀⣘⡇⠀⠀
⠀⠸⣧⣤⠶⠶⠶⢦⣌⠛⢾⡏⠉⠉⠉⠁⠀⢈⣉⣉⠀⠀⠀⣿⣩⡇⠀⠀
⠀⣼⠋⠀⠀⣀⠀⠀⠙⢷⡈⢷⡶⠶⢦⡄⠀⠈⠉⠁⠀⠀⣀⣨⣭⣇⠀⠀
⢸⡇⠀⢠⡟⠉⢻⡄⠀⠘⡇⢸⡷⠶⠾⢷⡄⠀⠀⠀⢠⡟⠉⣀⡈⠙⢷⡀
⠸⣇⠀⠀⠛⠶⠟⠁⠀⣸⣇⣸⠷⠶⠶⠾⠷⠶⠶⠶⣿⠀⢸⣏⣿⠀⢸⡇
⠀⠙⢷⣄⣀⠀⣀⣠⡴⠋⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠘⢧⣀⡈⢁⣠⡾⠁
⠀⠀⠀⠈⠉⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠉⠁⠀⠀
*/
