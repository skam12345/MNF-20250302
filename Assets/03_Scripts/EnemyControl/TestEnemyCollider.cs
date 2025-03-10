using Cinemachine;
using System.Collections;
using UnityEngine;


public class TestEnemyCollider : MonoBehaviour
{
    [SerializeField] private GameObject testEnemy;
    [SerializeField] private Animator gruntAnimator;
    [SerializeField] private InputSystem inputSystem;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private AnimationClip[] animationClips;
    private AnimatorOverrideController gruntOverrideController;
    private GameObject target;
    private GameObject playerObject;

    //���� �Ѿ� ���� �ӵ�
    private float chaseSpeed = 6f;
    //���� ��ҿ� �����̴� �ӵ�
    private float moveSpeed = 4f;
    // ���� ȸ���ϴ� �ӵ�
    private float rotationSpeed = 5f;
    // ���� Ʈ����
    private bool access = false;
    // ���� �÷��̾�� �����ߴ����� ���� ���θ� üũ�ϴ� Ʈ����
    private bool randomMove = true;
    // ���� ��ҿ� ������ �� �־��� �Ÿ���ŭ �̵� �ߴ� �� ���� üũ�ϴ� Ʈ����
    private bool moveFinish = false;
    // ���� ó���� ��� �������� ȸ���� �� �����ϴ� �ε��� ��.
    private int rotateIdx = 0;
    // ���� �̵��� �Ÿ��� ������ ������.
    private int moveDistance = 0;

    private float initialEnemyPositionX = 0;

    void Awake()
    {
        playerObject = Resources.Load<GameObject>(ResourcesDirectory.PlayerController);
        target = Instantiate(playerObject, new Vector3(10, 0, 0), Quaternion.Euler(new Vector3(0, 90, 0)));
        inputSystem.PlayerCtrl = target.GetComponent<PlayerControll>();
        virtualCamera.Follow = target.transform;
        virtualCamera.LookAt = target.transform;
    }
    void Start()
    {
        testEnemy = GameObject.Find("TestEnemy");
        initialEnemyPositionX = testEnemy.transform.position.x;
        gruntAnimator = testEnemy.transform.Find("GruntHP").GetComponent<Animator>();

        if (gruntAnimator != null)
        {
            gruntOverrideController = new AnimatorOverrideController(gruntAnimator.runtimeAnimatorController);
            animationClips = gruntOverrideController.animationClips;
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
            gruntAnimator.SetTrigger("Run");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            access = false;
            gruntAnimator.SetTrigger("Walk");
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
        if(moveDistance == 0)
        {
            moveDistance = UnityEngine.Random.Range(5, 8);

        }
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
