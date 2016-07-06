using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FrogBossAI : MonoBehaviour
{

	public Animator bossAiAnimator;
	AnimatorStateInfo attackStateBoss;
	public GameObject player;



	//Boss Pattern Range
	int bossAngryPattern = 0;
	public float runRange = 10.0f;
	public float attackRange = 2.5f;
	public float attackCycle;
	public float frogBossSpeed = 0.5f;



	//Boss Angry Image or Warning
	public Image bossAngryImage;
	float imageDelayTime;
	public float warningRange = 30.0f;
	Image warningImage;


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
	void Start()
	{
		bossAiAnimator = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag( "Player" );
		BossPattern( BossPatternName.AttackIdle );
		bossAngryImage.gameObject.SetActive( false );


	}


	void Update()
	{
		

		float searchRange = Vector3.Distance( player.transform.position, transform.position );

		//Vector3 frogLookAt = player.transform.position - transform.position;

		//Boss Warning Image

//		if(searchRange<=warningRange && bossAngryPattern ==0)
//		{
//
//
//		}
	


		if (searchRange < attackRange)
		{
			if (attackCycle >= 3)
			{
				BossPattern( BossPatternName.BossNormalAttack );
				attackCycle = 0;
			}
			else
			{
				BossPattern( BossPatternName.BossIdle );
				attackCycle += Time.deltaTime;
			}
		}
		else if (searchRange <= runRange && bossAngryPattern == 0)
		{			
			
			//			transform.rotation = Quaternion.Lerp (transform.rotation,
			//				Quaternion.LookRotation (frogLookAt,Vector3.forward), 
			//				Time.deltaTime * 4f);
			bossAngryImage.gameObject.SetActive( true );
			BossPattern( BossPatternName.Angry );

			bossAngryPattern = 1;		
		}
		else if (searchRange <= runRange && bossAngryPattern == 1)
		{

			BossPattern( BossPatternName.Run );

			if (attackStateBoss.IsName( "Run" ))
			{

				bossAngryImage.gameObject.SetActive( false );
				transform.LookAt( player.transform.position );
				transform.position = Vector3.Lerp( transform.position, player.transform.position, Time.deltaTime * frogBossSpeed );

			}


		}

		if (searchRange > runRange && searchRange > runRange)
		{
			BossPattern( BossPatternName.BossIdle );
		}
	

		attackStateBoss = this.bossAiAnimator.GetCurrentAnimatorStateInfo( 0 );



		//set default rotation
		transform.rotation = new Quaternion ( 0f, transform.rotation.y, 0f, 0f );
		transform.position = new Vector3 ( transform.position.x, 0f, transform.position.z );
		transform.LookAt( player.transform.position );


	}

	public void OnTriggerEnter( Collider col )
	{

	}

	public void BossPattern( BossPatternName state )
	{
		switch (state)
		{

			case BossPatternName.BossIdle:
				bossAiAnimator.SetInteger( "state", 1 );
				break;

			case BossPatternName.Angry:
				bossAiAnimator.SetInteger( "state", 2 );
				break;

			case BossPatternName.Run:
				bossAiAnimator.SetInteger( "state", 3 );
				break;

			case BossPatternName.BossNormalAttack:
				bossAiAnimator.SetInteger( "state", 4 );
				break;

			case BossPatternName.BossCriticalAttack:
				bossAiAnimator.SetInteger( "state", 5 );
				break;

			case BossPatternName.AttackIdle:
				bossAiAnimator.SetInteger( "state", 6 );
				break;

			case BossPatternName.TakeDamage:
				bossAiAnimator.SetInteger( "state", 7 );
				break;

			case BossPatternName.Death:
				bossAiAnimator.SetInteger( "state", 8 );
				break;
		

		}
	}

}
