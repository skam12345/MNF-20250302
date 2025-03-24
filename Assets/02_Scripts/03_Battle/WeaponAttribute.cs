using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttribute : MonoBehaviour //아군 무기에 넣을꺼
{

    public float atkPer;
    public StateManager playerMgr; // 플레이어 부착해줘야함


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemy") && playerMgr != null &&  ( playerMgr.CompareTag("Player") || playerMgr.CompareTag("BowClass")))
        {
            playerMgr.DealDamage(other.GetComponent<StateManager>().gameObject, atkPer);
            Debug.Log("딜 들어갔음");
        }
        if( other.CompareTag("Player")&& playerMgr != null && playerMgr.CompareTag("Enemy"))
        {
            playerMgr.DealDamage(other.GetComponent<StateManager>().gameObject, atkPer);
        }
    }
}
