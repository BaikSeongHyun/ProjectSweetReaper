using UnityEngine;
using System.Collections;

public class FrogBossAI : MonoBehaviour
{

	public Animator bossAiAnimator;
	public GameObject player;
	public GameObject rangeCheck;
	EnterPlayerCheck collCheck;
	AnimatorStateInfo attackStateBoss;

	public enum BossPatternName
	{
		BossIdle = 1,
		Angry,
		Run,
		BossNormalAttack,
		BossCriticalAttack,
		AttackIdle,
		TakeDamage,
		Death}

	;


	// Use this for initialization
	void Start ()
	{
		bossAiAnimator = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	

	}


	void Update()
	{
		//Vector3 chaser= player.transform.position - transform.position;
		float searchRange = Vector3.Distance(player.transform.position,transform.position);

		if (searchRange <= 10) 
		{			
			Debug.Log ("사거리 안 ");
			BossPattern (BossPatternName.Angry);
			//BossPattern (BossPatternName.Run);
		}
		else
		{
			BossPattern (BossPatternName.BossIdle);
		}

		attackStateBoss = this.bossAiAnimator.GetCurrentAnimatorStateInfo( 0 );



		if (attackStateBoss.IsName ("Run"))
		{
			transform.position = Vector3.Lerp (transform.position, player.transform.position, Time.deltaTime * 0.5f);
		}


	}

	public void OnTriggerEnter(Collider col)
	{

	}


	public void BossPattern (BossPatternName state)
	{
		switch (state)
		{

				case BossPatternName.BossIdle:
				bossAiAnimator.SetInteger ("state", 1);
					break;

				case BossPatternName.Angry:
					bossAiAnimator.SetInteger ("state", 2);
					break;
				case BossPatternName.Run:
					bossAiAnimator.SetInteger ("state", 3);
					break;
				case BossPatternName.BossNormalAttack:
				bossAiAnimator.SetInteger ("state", 4);
					break;
				case BossPatternName.BossCriticalAttack:
				bossAiAnimator.SetInteger ("state", 5);
					break;
				case BossPatternName.AttackIdle:
				bossAiAnimator.SetInteger ("state", 6);
					break;
				case BossPatternName.TakeDamage:
				bossAiAnimator.SetInteger ("state", 7);
					break;
				case BossPatternName.Death:
				bossAiAnimator.SetInteger ("state", 8);
					break;

		}
	}

	}
