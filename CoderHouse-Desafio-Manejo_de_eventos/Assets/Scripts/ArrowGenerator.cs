using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    [SerializeField] private float distanceRay;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private int shootCoolDown = 2;
    [SerializeField] private float timeShoot = 2f;
    private bool canShoot = true;
    private bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (canShoot)
            {
                RaycastCeiling();
            }
            else
            {
                timeShoot += Time.deltaTime;
            }

            if (timeShoot > shootCoolDown)
            {
                canShoot = true;
            }
        }
        else
        {
            gameObject.SetActive(isActive);
        }
        
    }
    private void RaycastCeiling()
    {
        RaycastHit hit;

        if (Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.TransformDirection(Vector3.left), out hit, distanceRay))
        {
            Debug.Log("FIREEEE!");
            canShoot = false;
            timeShoot = 0;
            GameObject arrowPb = Instantiate(arrowPrefab, spawnPoint.transform.position, arrowPrefab.transform.rotation);
            arrowPb.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.TransformDirection(Vector3.left) * 30f, ForceMode.Impulse);
        }

    }

    private void OnDrawGizmos()
    {
        if (canShoot && isActive)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawRay(spawnPoint.transform.position, spawnPoint.transform.TransformDirection(Vector3.left) * distanceRay);
        }
        
    }

    public void setActiveTrap(bool state)
    {
        Debug.Log("traps desactivated");
        isActive = state;
    }

}
