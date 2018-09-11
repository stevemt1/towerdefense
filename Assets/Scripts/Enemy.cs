using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public bool player1;
	public float speed = 2f;
	public float health = 5f;
	public float dps = 1f;
	public bool attacking = false;
    public bool healing = false;
	public bool alreadyhealed = false;
	public float cooldown = 2f;
	public float invulcooldown = 4f;
	public float nextFire = 1f;
	public bool invulnerable = false;

	public GameObject target;
	private Animator animator;


	void Start()
	{
		animator = GetComponent<Animator> ();
		if (transform.position.x < 0)
			player1 = true;
		else
			player1 = false;

        //----Special Minion Stats----//
        if(this.tag == "p1_warrior" || this.tag == "p2_warrior")
        {
            dps = 1.3f;
        }
        else if (this.tag == "p1_healer" || this.tag == "p2_healer")
        {
            cooldown = 1.4f;
                // call healer function
        }
        else if (this.tag == "p1_mage" || this.tag == "p2_mage")
        {
            speed = 3f;
			cooldown = 1.6f;
        }
        else if (this.tag == "p1_tank" || this.tag == "p2_tank")
        {
            health = 6;
        }
        //else it's regular minion. do nothing.
	}


	void Update () 
	{
		cooldown -= Time.deltaTime;
		nextFire -= Time.deltaTime;

		if (!attacking && !healing) {
			Movement ();
		}
		if (invulnerable) 
		{
			invulcooldown -= Time.deltaTime;
			if (invulcooldown <= 0)
				invulnerable = false;
		}

		if (attacking && !CheckIfEnemyDead () && cooldown <= 0) {
			Attack ();
			if (this.tag == "p1_mage" || this.tag == "p2_mage")
				cooldown = 1.6f;
			if (this.tag == "p1_healer" || this.tag == "p2_healer")
				cooldown = 1.4f;
			else
				cooldown = 2.0f;
			animator.SetTrigger ("EnemyAttack");
		}

        if(healing && cooldown <= 0)
        {
			target.GetComponent<Enemy> ().health += 1;
			target = null;
			healing = false;
			alreadyhealed = true;
            cooldown = 1.4f;
        }

	}

	void OnTriggerStay2D(Collider2D other)
    {
        //other is an enemy, attack!
		if ((this.tag [1] != other.tag [1]) && target == null) {
			attacking = true;
			healing = false;
			target = other.gameObject;
		}
        //this is a healer and other is an ally, heal!
        else if (((this.tag == "p1_healer" && this.tag [1] == other.tag [1]) ||
			(this.tag == "p2_healer" && this.tag [1] == other.tag [1])) && target == null && alreadyhealed == false) {
			healing = true;
			target = other.gameObject;
		} 
        // else, minion sees its own healer. continue
    }

	void Attack()
	{
		if (target.GetComponent<Enemy>().invulnerable)
			target.GetComponent<Enemy> ().health -= 0;
		else
			target.GetComponent<Enemy> ().health -= dps;
		if (target.GetComponent<Enemy> ().health <= 0) 
		{
			Destroy (target);
			target = null;
			attacking = false;
		}

	}

    void Movement()
	{
		if (player1) 
		{
			transform.position += new Vector3 (speed * Time.deltaTime, 0.0f, 0.0f);
		} 
		else
			transform.position -= new Vector3 (speed * Time.deltaTime, 0.0f, 0.0f);
	}


	bool CheckIfEnemyDead()
	{
		if (target == null) 
		{
			attacking = false;
			return true;
		}
		return false;
	}
}
