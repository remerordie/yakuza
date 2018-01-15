using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

//serialize it and make it presist between scenes?

public class GameManager : MonoBehaviour {

	public static Gamemanager instance = null;
	public AudioMixer audioMixer;
	public Dropdown resolutionDropdown;
	Resolution[] resolutions;

	//private int player_level;

	// Use this for initialization
	void Start () {
		resolutions = Screen.resolutions;

		resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

		for (int i = 0; i < resolutions.Length; i++) {
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);
		}
		resolutionDropdown.AddOptions(options);
	}

	public void StartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LoadMainMenu() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public void QuitGame() {
		Debug.Log("QUIT GAME...");
		Application.Quit();
	}

	public void SetVolume (float volume) {
		Debug.Log(volume);
		audioMixer.SetFloat("volume", volume);
	}

	public void SetQuality(int qualityIndex) {
		QualitySettings.SetQualityLevel(qualityIndex);

	}

	public void SetFullScreen(bool isFullscreen) {
		Screen.fullScreen = isFullscreen;
	}

	void Telekinesis() {
		/*check that the object the player is trying to interact
		with is within interaction distance, and then if the
		object is of the interactable class

		if true..

		preform the telekinesis skill...
		*/
	}

}
