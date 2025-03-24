using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectMoving : MonoBehaviour
{

    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, moveSpeed);
 
    }
}
