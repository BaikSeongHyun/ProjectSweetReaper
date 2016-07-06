using UnityEngine;
using System.Collections;

public class StoneFrog : MonoBehaviour
{


	NavMeshAgent agent;
	//내비메쉬에젠트 (내비게이션 사용을 위한 스크립트)
	public GameObject player;
	//플레이어 게임 오브젝트
	AnimatorStateInfo NormalStateFrog;
	Animator ani;
	//애니메이션 (메카님)
	public GameObject monster;
	//몬스터 게임 오브젝트
	int CognitionRange = 30;
	int AttackRange = 5;
	bool IdelRandomMoveState;

	public enum NormalFrogPatternName
	{
		Idle = 1,
		walk,
		Angry,
		Run,
		NormalAttack,
		AttackIdle,
		TakeDamage,
		Death
	}

	// Use this for initialization
	void Start()
	{
		//내비메쉬 컴포넌트를 얻는다.
		agent = GetComponent<NavMeshAgent>(); 
		//플레이어 컴포넨트를 얻는다.
		player = GameObject.FindGameObjectWithTag( "Player" ); 
		//몬스터 오브젝트에 애니메이션을 얻는다.
		ani = GetComponent<Animator>();
		//IdleStateRandomMove (true);
	}

	IEnumerator IdleStateRandomMove()
	{
		while (true)
		{
			if (IdelRandomMoveState == true)
			{
				//NormalFrogPatternName.Idle;
				yield return new WaitForSeconds ( 5f ); //5초간 실행을 보류한다.
				MonsterPattern( NormalFrogPatternName.walk );
			}
			else
			{
				//NormalFrogPatternName.Angry;
				yield return null;
			}
		}
	}

	// Update is called once per frame
	void LateUpdate()
	{
		if (( monster.transform.position - player.transform.position ).sqrMagnitude <= CognitionRange)
		{
			MonsterPattern( NormalFrogPatternName.Angry );
		}
		else if (( monster.transform.position - player.transform.position ).sqrMagnitude > CognitionRange * 1.2f)
		{
			//NormalFrogPatternName.Idle;
			//IdleStateRandomMove (IdelRandomMoveState = true);
		}

		if (( monster.transform.position - player.transform.position ).sqrMagnitude < AttackRange)
		{
			//NormalFrogPatternName.AttackIdle;
			MonsterPattern( NormalFrogPatternName.NormalAttack );
		}

	}









	void OnCollisionEnter( Collision col )
	{
		//if(col.gameObject.layer = LayerMask.LayerToName("Player");
	}

	void OnCollisionStay( Collision Coll )
	{
	}

	void OnCollisionExit( Collision Coll )
	{
	}




	public void	MonsterPattern( NormalFrogPatternName state )
	{
		switch (state)
		{
//			case NormalFrogPatternName.Idle:
//				ani.SetBool ("Idle", true);
//				ani.SetBool ("Walk", false);
//				ani.SetBool	("StandBy", false);
			case NormalFrogPatternName.walk:
				ani.SetBool( "Walk", true );
				ani.SetBool( "Idle", false );
				float randomCount = Random.Range( -1, 3 );
				if (randomCount >= -1 && randomCount < 0)
				{
					Vector3 monsterDirection = new Vector3 ( Random.Range( -1, 1 ), 0, Random.Range( -1, 1 ) );
					monster.transform.Translate( monsterDirection * 3 * Time.deltaTime );

				}
				else if (randomCount >= 0 && randomCount < 1)
				{
					Vector3 monsterDirection = new Vector3 ( Random.Range( 0, 1 ), 0, Random.Range( 0, 1 ) );
					monster.transform.Translate( monsterDirection * 3 * Time.deltaTime );
				}
				else if (randomCount >= 1)
				{
					Vector3 monsterDirection = new Vector3 ( Random.Range( 1, 1 ), 0, Random.Range( -1, 1 ) );
					monster.transform.Translate( monsterDirection * 3 * Time.deltaTime );
				}
				break; //"임의로 주석처리"
			case NormalFrogPatternName.Angry://cognition
				ani.Play( "Jump" );//cognition=jump.filename
				monster.transform.LookAt( player.transform.position );
				Debug.Log( ( monster.transform.position - player.transform.position ).sqrMagnitude );
				break;
			case NormalFrogPatternName.NormalAttack://bit
				ani.Play( "Attack1" );
				break;
		//		case 4://backattack
		//			Vector3 playerPosition = player.transform.position;
		//			Vector3 playerDirection = player.transform.forward;
		//			monster.transform.position = playerPosition - playerDirection * 20;
		//			monster.transform.LookAt (player.transform.position);
		//			ani.Play ("Attack1");
		//			monster.transform.Translate (playerPosition-(playerDirection*3));
		//			break; "보스에 넣어보면 어떨가??"
		}
	}


}