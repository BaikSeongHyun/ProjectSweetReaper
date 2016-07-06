using UnityEngine;
using System.Collections;

public class WolfAI : MonoBehaviour
{


	NavMeshAgent agent;
	//내비메쉬에젠트 (내비게이션 사용을 위한 스크립트)
	public GameObject player;
	//플레이어 게임 오브젝트
	Animation ani;
	//애니메이션 (레가시)
	public GameObject monster;
	//몬스터 게임 오브젝트
	public int check = 2;
	//기본 타입

	// Use this for initialization
	void Start()
	{
		//내비메쉬 컴포넌트를 얻는다.
		agent = GetComponent<NavMeshAgent>(); 
		//플레이어 컴포넨트를 얻는다.
		player = GameObject.FindGameObjectWithTag( "Player" ); 
		//몬스터 오브젝트에 애니메이션을 얻는다.
		ani = monster.GetComponent<Animation>();
		//만약 이 오브젝트가 보스라면,
		if (this.transform.name == "ghoulprefab")
		{
			//소환 애니메이션 속도를 줄인다.
			monster.GetComponent<Animation>()["creature1Spawn"].speed = 0.5f;
			//달리는 애니메이션의 속도를 줄인다.
			//느리게 하는 연출을 위함.
			monster.GetComponent<Animation>()["creature1run"].speed = 0.1f;
		}
		StartCoroutine( Monster_Action() );

	}

	IEnumerator Monster_Action()
	{
		//몹 소환시 등장 애니메이션 실행.
		ani.Play( "creature1Spawn" );
		//만약 보스면
		if (this.transform.name == "ghoulprefab")
		{
			//애니메이션이 끝날때까지 대기.
			yield return new WaitForSeconds ( 5.3f );

		}
		else
		{
			//애니메이션이 끝날때까지 대기.
			yield return new WaitForSeconds ( 1.5f );
		}
		//update check 1 참조.
		check = 1;
	}
	// Update is called once per frame
	void Update()
	{
		//체크 0 참조.
		if (check == 0)
		{
			//공격 애니메이션 실행.
			ani.Play( "creature1Attack1" );
		}
		else if (check == 1)
		{
			//플레이어를 최단거리로 추적. 보스면 코어나 플레이어중 가까운 곳을 추적
			if (this.transform.name == "ghoulprefab")
			{

				float CoreRange;
				CoreRange = Vector3.Distance( GameObject.Find( "dragon" ).transform.position, 
				                              this.transform.position );

				if (CoreRange <= 30.0f)
				{
					agent.SetDestination( GameObject.Find( "dragon" ).transform.position );

				}
				else
				{
					agent.SetDestination( player.transform.position );
				}


			}
			else
			{
				agent.SetDestination( player.transform.position );
			}
			//달리는 애니메이션 실행.
			ani.Play( "creature1run" );
		}

	}
	//몬스터가 충돌중일때,
	void OnCollisionStay( Collision Coll )
	{
		//만약 플레이어와 충돌 했을 경우,
		if (Coll.gameObject.tag == "Player")
		{
			//update check 0 참조
			check = 0;
		}
	}
	//충돌에서 벗어 났다면,
	void OnCollisionExit( Collision Coll )
	{
		//update check 1 참조
		check = 1;
	}


	int state = Random.Range( 1, 4 );

	public void	MonsterPattern( int state )
	{
		switch (state)
		{
			case 0://idle
				ani.Play( "idle" );
				break;
			case 1://cognition
				ani.Play( "standByLookat" );
				monster.transform.LookAt( player.transform.position );
				break;
			case 2://bit
				ani.Play( "bit" );
				break;
			case 3://hurt
				ani.Play( "hurt" );
				break;
			case 4://backattack
				Vector3 playerPosition = player.transform.position;
				Vector3 playerDirection = player.transform.forward;
				monster.transform.position = playerPosition - playerDirection * 20;
				monster.transform.LookAt( player.transform.position );
				ani.Play( "hurt" );


//			monster.transform.Translate ();
				break;
		}
	}

}
