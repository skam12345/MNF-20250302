using System.Collections;
using UnityEngine;


public class EnemyCollider : MonoBehaviour
{
    [SerializeField] private Transform testEnemy;
    [SerializeField] private Animator gruntAnimator;
    [SerializeField] private float attackDistance;
    private AnimationClip[] animationClips;
    private AnimatorOverrideController gruntOverrideController;
    private GameObject target;

    //적이 쫓아 오는 속도
    [SerializeField] private float chaseSpeed = 4f;
    //적이 평소에 움직이는 속도
    [SerializeField] private float moveSpeed = 4f;

    public int monsterType;
    // 적이 회전하는 속도
    private float rotationSpeed = 5f;
    // 접근 트리거
    private bool access = false;
    // 적이 플레이어와 접촉했느지에 대한 여부를 체크하는 트리거
    private bool randomMove = true;
    // 적이 평소에 움직일 때 주어진 거리만큼 이동 했는 지 여부 체크하는 트리거
    private bool moveFinish = false;
    // 적이 처음에 어느 방향으로 회전할 지 결정하는 인덱스 값.
    private int rotateIdx = 0;
    // 적이 이동할 거리를 난수로 지정함.
    private int moveDistance = 5;


    private float initialEnemyPositionX = 0;


    void Start()
    {
        target = GameObject.FindWithTag("Player");
        testEnemy = gameObject.transform.parent;
        initialEnemyPositionX = testEnemy.transform.position.x;
        gruntAnimator = testEnemy.transform.GetChild(0).GetComponent<Animator>();


        if (gruntAnimator != null)
        {
            gruntOverrideController = new AnimatorOverrideController(gruntAnimator.runtimeAnimatorController);
            animationClips = gruntOverrideController.animationClips;
            gruntAnimator.SetTrigger("Walk");
        }
        if(!access)
        {
            StartCoroutine(AutoRotateEnemy());
            StartCoroutine(RandomDistanceEnemy());
        }
    }

    void Update()
    {
        Quaternion left = Quaternion.Euler(0, 90, 0);
        Quaternion right = Quaternion.Euler(0, -90, 0);
        Quaternion[] rotations = { left, right };
        if(access)
        {
            Vector3 direction = (target.transform.position - testEnemy.transform.position).normalized;
            float distance = Vector3.Distance(testEnemy.transform.position, target.transform.position);
            if(distance < attackDistance)
            {
                chaseSpeed = 0f;
                gruntAnimator.SetTrigger("Attack02");
            }else
            {
                if(monsterType == 1)
                {
                    chaseSpeed = 3f;
                }
                if(monsterType == 2)
                {
                    chaseSpeed = 0f;
                    gruntAnimator.SetTrigger("Attack02");
                }

                gruntAnimator.SetTrigger("Walk");
            }
                direction.y = 0;
            if(direction.x > 0)
            {
                testEnemy.transform.rotation = Quaternion.Slerp(testEnemy.transform.rotation, left, rotationSpeed * Time.deltaTime);
            }else if (direction.x < 0)
            {
                testEnemy.transform.rotation = Quaternion.Slerp(testEnemy.transform.rotation, right, rotationSpeed * Time.deltaTime);
            }

            testEnemy.transform.position += direction * chaseSpeed * Time.deltaTime;
        }else
        {
            testEnemy.transform.rotation = Quaternion.Slerp(testEnemy.transform.rotation, rotations[rotateIdx], rotationSpeed * Time.deltaTime);
            if(rotateIdx == 0)
            {
                if(!moveFinish)
                {
                 testEnemy.transform.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
                }
            }else
            {
                if(!moveFinish)
                {
                    testEnemy.transform.position += new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime;
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            access = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            access = false;
        }
    }
    IEnumerator AutoRotateEnemy()
    {
        rotateIdx = UnityEngine.Random.Range(0, 1);
        while(randomMove)
        {
            if(moveFinish)
            {
                moveFinish = false;
                if(rotateIdx == 0)
                {
                    rotateIdx = 1;
                }else
                {
                    rotateIdx = 0;
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }


    IEnumerator RandomDistanceEnemy()
    {
        while (randomMove)
        {
            if(rotateIdx == 0)
            {
                if (testEnemy.transform.position.x >= (initialEnemyPositionX + moveDistance))
                {
                    moveFinish = true;
                }
            }else
            {
                if (testEnemy.transform.position.x <= (initialEnemyPositionX - moveDistance))
                {
                    moveFinish = true;
                }
            }
                yield return new WaitForSeconds(0.5f); 
        }
    }
}
