using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : MonoBehaviour
{
    [SerializeField] protected MutantData data;
    [SerializeField] protected float speed = 5f;
    [SerializeField] private float distanceRay = 10f;
    protected Rigidbody rbMutant;
    [SerializeField] private Animator animMutant;

    bool isGrounded;
    bool isIddle;
    bool isAttack;

    [SerializeField] private GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        rbMutant = GetComponent<Rigidbody>();
        animMutant = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(!isAttack)
        {
            FindEnemy();
            Move();
        }
    }

    public virtual void Move()
    {
        Vector3 direction = Vector3.forward;
        rbMutant.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        rbMutant.AddForce(direction * data.GetMutantSpeed(), ForceMode.Impulse);
    }

    public void FindEnemy()
    {
        BroacastRaycast(spawnPoint.transform);
    }

    private void BroacastRaycast(Transform origen)
    {
        RaycastHit hit;

        if (Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.TransformDirection(Vector3.forward), out hit, data.GetMutantDistanceRaycast()))
        {
            if (hit.transform.CompareTag("Player"))
            {
                isAttack = true;
                rbMutant.velocity = Vector3.zero;
                animMutant.SetBool("isAttack", isAttack);
            }
        }
    }

    public void DrawRaycast(Transform origen)
    {
        Gizmos.color = Color.green;
        Vector3 direction = spawnPoint.transform.TransformDirection(Vector3.forward) * data.GetMutantDistanceRaycast();
        Gizmos.DrawRay(spawnPoint.transform.position, direction);
    }

    private void OnDrawGizmos()
    {
        if (!isAttack)
        {
            DrawRaycast(spawnPoint.transform);
        }
        
    }
}
