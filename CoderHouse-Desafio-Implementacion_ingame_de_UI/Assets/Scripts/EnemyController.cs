using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speedEnemy = 4f;
    [SerializeField] private GameObject player;
    [SerializeField] private float lifetime;
    [SerializeField] private float speedToLook = .5f;
    [SerializeField] private float distanceEnemy = 3;

    [SerializeField] private Rigidbody rbEnemy;

    void Start()
    {
        //player = GameObject.Find("Player");
        rbEnemy = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //LookAtLerp(player);
        //MoveEnemy(Vector3.back);
        //MoveTowards();
        //Destroy(gameObject, lifetime);

        Vector3 playerDirection = GetPlayerDirection();
        rbEnemy.AddForce(playerDirection * Time.deltaTime);
    }

    
    private void MoveEnemy(Vector3 direction)
    {
        //transform.Translate(speedEnemy * direction * Time.deltaTime);
        transform.position += speedEnemy * direction * Time.deltaTime;
    }

    private void MoveTowards()
    {
        Vector3 lookAtVector = player.transform.position - transform.position;
        Vector3 direction = lookAtVector.normalized;
        if (lookAtVector.magnitude > distanceEnemy)
        {
            transform.position += speedEnemy * direction * Time.deltaTime;
        }
    }

    private void LookAtLerp(GameObject lookObject)
    {
        Vector3 direction = (lookObject.transform.position - transform.position).normalized;
        Quaternion newQuaternion = Quaternion.LookRotation(direction);
        //transform.rotation = newQuaternion;
        transform.rotation = Quaternion.Lerp(transform.rotation, newQuaternion, speedToLook * Time.deltaTime);
    }

    private Vector3 GetPlayerDirection()
    {
        return player.transform.position - transform.position;
    }
}
