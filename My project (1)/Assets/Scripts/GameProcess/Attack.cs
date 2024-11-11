using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public float dist;
    public GameObject target;
    public GameObject TrgTxt;
    public int Dmg;


    private void OnMouseDown()
    {
        FindTrg();
        Health TargetHealt = target.GetComponent<Health>();
        TargetHealt.TakeDmg(Dmg);
        HealthTxt that=TrgTxt.GetComponent<HealthTxt>();
        that.HTchange();
    }

    void FindTrg()
    {
        Ray ray = new Ray(transform.position, Vector3.right);
        
        RaycastHit hit;
        Physics.Raycast(ray,out hit, dist);
        target = hit.collider.gameObject;
        TrgTxt=target.transform.GetChild(0).GetChild(0).gameObject;

    }


}
