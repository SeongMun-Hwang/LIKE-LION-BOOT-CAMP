using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, Health.IHealthListenter
{
    NavMeshAgent agent;
    GameObject player;
    Animator animator;

    AudioSource audioSource;
    enum State
    {
        Idle,
        Follow,
        Attack,
        Die,
    }

    State state;
    float currentStateTime;
    public float timeForNextState = 2;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        agent.destination = player.transform.position;

        animator = GetComponent<Animator>();

        state = State.Idle;
        currentStateTime = timeForNextState;

        audioSource=GetComponent<AudioSource>();
    }
    void Update()
    {
        switch (state)
        {
            case State.Idle:
                currentStateTime -= Time.deltaTime;
                if (currentStateTime < 0)
                {
                    float distance = (player.transform.position - transform.position).magnitude;
                    if (distance < 1.5f)
                    {
                        StartAttack();
                    }
                    else
                    {
                        StartFollow();
                    }
                }
                break;
            case State.Follow:
                if (agent.remainingDistance < 1.5f || !agent.hasPath)
                {
                    StartIdle();
                }
                break;
            case State.Attack:
                currentStateTime -= Time.deltaTime;
                if (currentStateTime < 0)
                {
                    StartIdle();
                }
                break;
        }
    }
    void StartIdle()
    {
        audioSource.Stop();
        state = State.Idle;
        currentStateTime = timeForNextState;
        agent.isStopped = true;
        animator.SetTrigger("Idle");
    }
    void StartFollow()
    {
        audioSource.Play();
        state = State.Follow;
        agent.destination = player.transform.position;
        agent.isStopped = false;
        animator.SetTrigger("Run");
    }
    void StartAttack()
    {
        state = State.Attack;
        currentStateTime = timeForNextState;
        animator.SetTrigger("Attack");
    }
    public void OnDie()
    {
        state = State.Die;
        agent.isStopped = true;
        animator.SetTrigger("Death");
        Invoke("DestroyThis", 2f);
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Health>().Damage(10);
        }
    }
}