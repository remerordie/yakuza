using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public AudioMixer audioMixer;

	Resolution[] resolutions;

	public Dropdown resolutionDropdown;

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
}
