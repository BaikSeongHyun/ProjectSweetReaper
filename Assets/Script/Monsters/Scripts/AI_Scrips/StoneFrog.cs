using UnityEngine;
using System.Collections;

public class StoneFrog : MonoBehaviour {


	NavMeshAgent agent; //내비메쉬에젠트 (내비게이션 사용을 위한 스크립트)
	public GameObject player; //플레이어 게임 오브젝트
	Animator ani; //애니메이션 (메카님)
	public GameObject monster; //몬스터 게임 오브젝트
	int PeaceOrFight=0; //평화,인식,싸움
	int CognitionRange = 30;
	int AttackRange = 5;
	// Use this for initialization
	void Start () {
		//내비메쉬 컴포넌트를 얻는다.
		agent = GetComponent<NavMeshAgent>(); 
		//플레이어 컴포넨트를 얻는다.
		player = GameObject.FindGameObjectWithTag("Player"); 
		//몬스터 오브젝트에 애니메이션을 얻는다.
		ani = GetComponent<Animator>();


	}

	// Update is called once per frame
	void LateUpdate () 
	{
		if (PeaceOrFight == 0) {
			if (Time.realtimeSinceStartup % 3 > 2) {
				MonsterPattern (1);
			}
			if (Time.realtimeSinceStartup % 3 < 1) {
				MonsterPattern (0);
			}
		}
		if ((monster.transform.position - player.transform.position).sqrMagnitude <= CognitionRange){
			PeaceOrFight = 1;
			MonsterPattern (2);
		}
		if((monster.transform.position - player.transform.position).sqrMagnitude > CognitionRange){
			PeaceOrFight =0;
			MonsterPattern (0);
		}
		if (PeaceOrFight == 2) {
			if ((monster.transform.position - player.transform.position).sqrMagnitude < AttackRange) {
				MonsterPattern (3);
			}
		}

	}


	void OnCollisionEnter(Collision col)
	{
		//if(col.gameObject.layer = LayerMask.LayerToName("Player"
	}
	void OnCollisionStay(Collision Coll){
	}

	void OnCollisionExit(Collision Coll){
	}


	public void	MonsterPattern(int state)
	{
		switch (state) {
		case 0://idle
//			ani.Play ("Idle");
			ani.SetBool ("Idle", true);
			ani.SetBool ("Walk", false);
			ani.SetBool	("StandBy", false);
			break;
		case 1://walk
//			ani.Play ("Walk");
			ani.SetBool ("Walk", true);
			ani.SetBool ("Idle", false);
			int randomCount = Random.Range (-1, 2);
			{if (randomCount >= -1 && randomCount < 0 ) {
					Vector3 monsterDirection = new Vector3 (Random.Range (-1, 1),0, Random.Range (-1, 1));
					monster.transform.Translate (monsterDirection*3*Time.deltaTime);
					Debug.Log (-1);
				}
			else if (randomCount >= 0 && randomCount < 1){
					Vector3 monsterDirection = new Vector3 (Random.Range (0, 1), 0, Random.Range (0, 1));
				monster.transform.Translate (monsterDirection*3*Time.deltaTime);
				Debug.Log (0);}
			else if (randomCount >=1){Vector3 monsterDirection = new Vector3 (Random.Range (1, 1), 0, Random.Range (-1, 1));
				monster.transform.Translate (monsterDirection*3*Time.deltaTime);
				Debug.Log (1);}

		}



			break;
		case 2://cognition
			ani.Play ("Jump");//cognition=jump.filename
			monster.transform.LookAt (player.transform.position);
			Debug.Log ((monster.transform.position - player.transform.position).sqrMagnitude);
			break;
		case 3://bit
			ani.Play ("Attack1");
			break;
		case 4://backattack
			Vector3 playerPosition = player.transform.position;
			Vector3 playerDirection = player.transform.forward;
			monster.transform.position = playerPosition - playerDirection * 20;
			monster.transform.LookAt (player.transform.position);
			ani.Play ("Attack1");
			monster.transform.Translate (playerPosition-(playerDirection*3));
			break;
		}
	}

	public void MonsterDo()
	{
		
	}

}
