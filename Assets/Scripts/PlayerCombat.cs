using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private int damageModifier = 1;
    [SerializeField] private PolygonCollider2D swordCollider;
    [SerializeField] private float attackDuration = 0.05f;
    private bool enemyHit = false;

    // Start is called before the first frame update
    void Start()
    {
        swordCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //get the left button
        if (Input.GetMouseButton(0))
        {
            swordCollider.enabled = true;
            StartCoroutine(AttackCounter());
        }
    }

    private IEnumerator AttackCounter()
    {

        //NOTE SET THE DURATION TO BE ALLIGNED WITH THE LENGTH OF THE ANIMATION

        yield return new WaitForSeconds(attackDuration);
        //must be done here and not after the StartCoroutine as that runs this at the same time as the game
        swordCollider.enabled = false;
        enemyHit = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !enemyHit)
        {
            enemyHit = true;
            //get enemy health script and take away health and maybe add knockback
            EnemyHealth.removeHealth();
        }
    }
}
