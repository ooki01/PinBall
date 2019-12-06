﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	int score;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;
	private GameObject ScoreText;

	void Scorepoint(int score){
		this.ScoreText.GetComponent<Text> ().text = "Score"+ this.score;
	}

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find ("GameOverText");
		this.ScoreText = GameObject.Find ("ScoreText");

		Scorepoint (score);
	}

	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "SmallStarTag"){
			this.score += 10;
		}
		else if(other.gameObject.tag == "LargeStarTag"){
			this.score += 20;
		}
		else if(other.gameObject.tag == "SmallCloudTag"){
			this.score += 30;
		}
		else if(other.gameObject.tag == "LargeCloudTag"){
			this.score += 40;
		}
		this.ScoreText.GetComponent<Text> ().text = "Score" + this.score;
	}
}