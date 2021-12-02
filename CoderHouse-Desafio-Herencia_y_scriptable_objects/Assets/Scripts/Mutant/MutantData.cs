using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mutant Data", menuName = "Mutant Data")]
public class MutantData : ScriptableObject
{

    [SerializeField]  private string mutantName;
    [SerializeField]  private int hp;
    [SerializeField]  private float speed;
    [SerializeField]  private float distanceRay;

    public string GetMutantName()
    {
        return mutantName;
    }

    public void SetMutantName(string name)
    {
        mutantName = name;
    }
    public int GetMutantHp()
    {
        return hp;
    }

    public void SetMutantHp(int newHp)
    {
        hp = newHp;
    }

    public float GetMutantSpeed()
    {
        return speed;
    }

    public  void SetMutantSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public float GetMutantDistanceRaycast()
    {
        return distanceRay;
    }

    public void SetMutantDistanceRaycast(float newDistanceRaycast)
    {
        distanceRay = newDistanceRaycast;
    }


}
