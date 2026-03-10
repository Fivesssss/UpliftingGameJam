using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private static Animator enemyAnim;
    [SerializeField] private static int enemyHealth = 5;

    private void Start()
    {
        enemyAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //destroy gameobject and then play animation
        //animation window after final death animation destroy game object
    }

    public static void removeHealth() 
    {
        Debug.Log("Hit");
    }

    public void DestroyObject() 
    {
        Destroy(gameObject);
    }
}
