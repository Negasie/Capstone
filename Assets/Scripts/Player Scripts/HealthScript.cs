using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class HealthScript : MonoBehaviour {

	private EnemyAnimator enemy_Anim;
	private NavMeshAgent navAgent;
	private EnemyController enemy_Controller;

	public float health = 100f;

	public bool is_Player, is_Boar, is_Cannibal;

	private bool is_Dead;

    void Awake() {
        
		if (is_Boar || is_Cannibal) {
			enemy_Anim = GetComponent<EnemyAnimator>();
			enemy_Controller = GetComponent<EnemyController>();
			navAgent = GetComponent<NavMeshAgent>();
		}

		if (is_Player) {


		
		}

    }

	public void ApplyDamage(float damage) {
		if (is_Dead) 
			return;

		health -= damage;

		if (is_Player) {
			// show health stats in UI
		}

		if (is_Boar || is_Cannibal) {
			if(enemy_Controller.Enemy_State == EnemyState.PATROL) {
				enemy_Controller.chase_Distance = 50f;
			}
		}

		if (health <= 0f) {
			PlayerDied();

			is_Dead = true;
		}
	} // ApplyDamage

	void PlayerDied() {

		if (is_Cannibal) {
			// this is only until we find a way to animate the Cannibal's death, like Boar.

			GetComponent<Animator>().enabled = false;
			GetComponent<BoxCollider>().isTrigger = false;
			GetComponent<Rigidbody>().isKinematic = false;
			GetComponent<Rigidbody>().AddTorque(-transform.forward * 50f, ForceMode.VelocityChange);
			print("HEYYYYYOOOOOO");

			navAgent.velocity = Vector3.zero;
			navAgent.isStopped = true;
			enemy_Controller.enabled = false;
			navAgent.enabled = false;
			enemy_Anim.enabled = false;

			// Start Coroutine

			// EnemyManager will spawn a new enemy.
		}

		if (is_Boar) {

			navAgent.velocity = Vector3.zero;
			navAgent.isStopped = true;
			enemy_Controller.enabled = false;

			enemy_Anim.Dead();

			// Start Coroutine

			// EnemyManager will spawn a new enemy.
		
		}

		if (is_Player) {

			GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);

			for(int i = 0; i < enemies.Length; i++) {
				enemies[i].GetComponent<EnemyController>().enabled = false;
			}

			// call EnemyManager to stop spawning enemies.

			GetComponent<PlayerMovement>().enabled = false;
			GetComponent<PlayerAttack>().enabled = false;
			GetComponent<WeaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);
				
		}

		if (tag == Tags.PLAYER_TAG) {

			Invoke ("RestartGame", 3f);
		
		} else {

			Invoke("TurnOffGameObject", 3f);
		}

	} // player died

	void RestartGame() {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("SampleScene");
	}

	void TurnOffGameObject() {
		gameObject.SetActive (false);

	}

} // class
















