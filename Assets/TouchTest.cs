using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{

	private HingeJoint myHingeJoint;
	private float defaultAngle = 20;
	private float flickAngle = -20;


	void Start()
	{	
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}
	void Update()
	{
		foreach (Touch t in Input.touches)
		{
			if (t.position.x >= Screen.width / 2 && tag == "RightFripperTag")
			{
				SetAngle (this.flickAngle);
			}
			if (t.position.x <= Screen.width / 2 && tag == "LeftFripperTag")
			{
				SetAngle (this.flickAngle);
			}
		}
		//タップを離された時フリッパーを元に戻す
		foreach (Touch t in Input.touches)
		{
			if (t.phase == TouchPhase.Ended  && t.position.x <= Screen.width / 2 && tag == "LeftFripperTag") {
				// 離した時
				SetAngle (this.defaultAngle);
			}
			if (t.phase == TouchPhase.Ended  && t.position.x >= Screen.width / 2 && tag == "RightFripperTag") {
				// 離した時
				SetAngle (this.defaultAngle);
			}
		}

	}
	//フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}