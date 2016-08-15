using UnityEngine;
using System.Collections;

public class ScreenTransition : MonoBehaviour {

	private GameObject mainMenu;
	private GameObject settingsMenu;

	// Use this for initialization
	void Start () 
	{
		mainMenu = GameObject.FindGameObjectWithTag("MainMenuTag");
		settingsMenu = GameObject.FindGameObjectWithTag("SettingsMenuTag");

		mainMenu.SetActive(true);
		settingsMenu.SetActive(false);
	}
	
	public void transitionToSettings ()
	{
		mainMenu.SetActive(false);
		settingsMenu.SetActive(true);
	}

	public void transitionToMainMenu ()
	{
		mainMenu.SetActive(true);
		settingsMenu.SetActive(false);
	}
}
