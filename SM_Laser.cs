using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_Laser : MonoBehaviour {

    [SerializeField] private Transform s_Sight;
    private LineRenderer laserSight;
    private Transform target = null;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask mask;
    private int baseDamage = 50;

    private void TargetSearch()
    {
        RaycastHit hit;
        Ray ray = new Ray(s_Sight.position, s_Sight.forward);
        if (Physics.Raycast(ray, out hit, distance, mask))
        {
           if (hit.collider.tag == "Player")
            {
                hit.collider.GetComponent<Health>().ApplyDamage(baseDamage);
                
            }
        }
    }

    private void Start()
    {
        laserSight = s_Sight.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update () {
        TargetSearch();
    }
}
