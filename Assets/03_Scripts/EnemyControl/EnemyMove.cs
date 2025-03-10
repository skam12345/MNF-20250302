using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator gruntAnimator;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private AnimatorOverrideController gruntOverrideController;
    private AnimationClip[] animationClips;
    void Start()
    {
        gruntAnimator = gameObject.GetComponentInChildren<Animator>();

        if (gruntAnimator != null)
        {
            gruntOverrideController = new AnimatorOverrideController(gruntAnimator.runtimeAnimatorController);
            animationClips = gruntOverrideController.animationClips;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
