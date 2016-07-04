using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FrogBossAI : MonoBehaviour
{

	public Animator bossAiAnimator;
	public GameObject player;
	EnterPlayerCheck collCheck;
	AnimatorStateInfo attackStateBoss;
	int bossAngryPattern=0;
	float runRange=10.0f;
	float attackRange=2.5f;
	public Image bossAngryImage;
	float imageDelayTime;

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
		BossPattern (BossPatternName.AttackIdle);
		bossAngryImage.gameObject.SetActive (false);

	}


	void Update()
	{
		float searchRange = Vector3.Distance(player.transform.position,transform.position);

		//Vector3 frogLookAt = player.transform.position - transform.position;


		if (searchRange<= runRange && bossAngryPattern == 0) 
		{			
			transform.LookAt (player.transform.position);
			//			transform.rotation = Quaternion.Lerp (transform.rotation,
			//				Quaternion.LookRotation (frogLookAt,Vector3.forward), 
			//				Time.deltaTime * 4f);
			bossAngryImage.gameObject.SetActive (true);
			BossPattern (BossPatternName.Angry);

			bossAngryPattern = 1;		
		}

		else if (searchRange<= runRange && bossAngryPattern == 1)
		{

			BossPattern (BossPatternName.Run);


			if (attackStateBoss.IsName ("Run") && searchRange<=runRange)
			{
				bossAngryImage.gameObject.SetActive (false);
				transform.LookAt (player.transform.position);
				transform.position = Vector3.Lerp (transform.position, player.transform.position, Time.deltaTime * 0.5f);
			}

		}
		else if (searchRange > runRange)
		{
			BossPattern (BossPatternName.BossIdle);
		}
	

		attackStateBoss = this.bossAiAnimator.GetCurrentAnimatorStateInfo( 0 );

		if (searchRange < attackRange) 
		{
			BossPattern (BossPatternName.BossNormalAttack);
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
