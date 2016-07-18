using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Monster : MonoBehaviour 
{

	public GameObject hitObject;
	public GameObject hitEffect;
	public GameObject player;

	public MonsterHealth frogInfo;

	public float runRange;
	public float attackRange;
	public float attackCycle;
	public float frogBossSpeed;

	public bool isAlive = true;
	public bool isAttack = false;

	public Image health;
	public GameObject dropItem;
	public GameObject dropGold;



	public bool IsAttack
	{
		get{ return isAttack; }
	}

	public void AttackTrigger()
	{
		isAttack = false;

	}

	public virtual void HitDamage( float _Damage )
	{


	}

	public void RotateHealthBar()
	{
		health.transform.forward = -Camera.main.transform.forward;
	}


}

