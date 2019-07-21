using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameStartButton : MonoBehaviour {
	// 非同期動作で使用するOperation
	private AsyncOperation op;
	// ロード画面
	[SerializeField]
	public GameObject loadView;
	// スライダー
	[SerializeField]
	public Slider slider;
	
	public void gameStartButtonTap() {
		loadView.SetActive(true);

		StartCoroutine("LoadSceneCoroutine");
	}

	IEnumerator LoadSceneCoroutine() {
		op = SceneManager.LoadSceneAsync("Game");
		while(!op.isDone) {
			var progressValue = Mathf.Clamp01(op.progress / 0.9f);
			slider.value = progressValue;
			yield return null;
		}
	}
}
