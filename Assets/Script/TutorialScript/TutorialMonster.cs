using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialMonster : MonoBehaviour 
{
	public TutorialManager expThrow;
	public GameObject hitObject;
	public GameObject hitEffect;
	public GameObject player;

	public MonsterHealth frogInfo;

	public float runRange;
	public float attackRange;
	public float attackCycle;
	public float frogBossSpeed;
	public float exp;

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

	public float Experience
	{
		get { return exp; }
	}

	public virtual void HitDamage( float _Damage )
	{
	}

	public void RotateHealthBar()
	{
		health.transform.forward = -Camera.main.transform.forward;
	}


}

