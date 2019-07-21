using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputNameController : MonoBehaviour {
	private static string playerNameKey = "PlayerName";

	void Start() {
		string defaultName = "";
		InputField inputNameField = this.GetComponent<InputField>();

		//前回プレイ開始時に入力した名前をロードして表示
		if (inputNameField != null) {
			if (PlayerPrefs.HasKey(playerNameKey)) {
				defaultName = PlayerPrefs.GetString(playerNameKey);
				inputNameField.text = defaultName;
			}
		}
	}

	public void setPlayerName(string value) {
		PhotonNetwork.playerName = value + " "; // player Name setting
		PlayerPrefs.SetString(playerNameKey, value); // player Name saving
		Debug.Log("PlayerName = " + PhotonNetwork.playerName); // player Name checking
	}

}
