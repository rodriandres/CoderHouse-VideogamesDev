using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantMutant : Mutant
{

    [SerializeField] private GameObject player;
    [SerializeField] protected MutantData data;

    public override void Move()
    {
        //base.Move();
        Vector3 playerDirection = GetPlayerDirection();
        rbMutant.rotation = Quaternion.LookRotation(new Vector3(playerDirection.x, 0, playerDirection.z));
        rbMutant.AddForce(playerDirection * data.GetMutantSpeed(), ForceMode.Impulse);
    }

    public Vector3 GetPlayerDirection()
    {
        return player.transform.position - transform.position;
    }
}
