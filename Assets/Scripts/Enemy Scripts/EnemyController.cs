using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public enum EnemyState {
	PATROL,
	CHASE,
	ATTACK

}



public class EnemyController : MonoBehaviour {

	private EnemyAnimator enemy_Anim;
	private NavMeshAgent navAgent;

	private EnemyState enemy_State;

	public float walk_Speed = 0.5f;
	public float run_Speed = 4f;

	public float chase_Distance = 7f;
	private float current_Chase_Distance;
	public float attack_Distance = 1.8f;
	public float chase_After_Attack_Distance = 2f;

	public float patrol_Radius_Min = 20f, patrol_Radius_Max = 60f;
	public float patrol_For_This_Time = 15f;
	private float patrol_Timer;

	public float wait_Before_Attack = 2f;
	private float attack_Timer;

	private Transform target;



	void Awake() {
		enemy_Anim = GetComponent<EnemyAnimator> ();
		navAgent = GetComponent<NavMeshAgent> ();

		target = GameObject.FindWithTag (Tags.PLAYER_TAG).transform;
	
	}



    void Start() {
        
    }



    void Update() {
        
    }




} // class

























