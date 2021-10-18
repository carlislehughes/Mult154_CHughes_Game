using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMovement : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    private Rigidbody rbBody;
    // Start is called before the first frame update
    void Start()
    {

        rbBody = target.GetComponent<Rigidbody>();
        agent = this.GetComponent<NavMeshAgent>();
    }

    float currentSpeed
    {
        get { return rbBody.velocity.magnitude; }
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSeeTarget())
        {
            Pursue();

        }
        else
        {
            Wander();
        }
    }

    Vector3 wanderTarget = Vector3.zero;
    public void Wander()
    {
        float wanderRadius = 10;
        float wanderDistance = 10;
        float wanderJitter = 1;

        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
                                        0,
                                        Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);

        agent.SetDestination(transform.position + targetLocal);
    }

    public void Pursue()
    {
        Vector3 targetDir = target.transform.position - this.transform.position;
        float lookAhead = targetDir.magnitude / (agent.speed + currentSpeed);
        agent.SetDestination(target.transform.position + target.transform.forward * lookAhead);
    }

    public bool CanSeeTarget()
    {
        RaycastHit raycastInfo;
        Vector3 targetXZPos = new Vector3(target.transform.position.x, 1.5f, target.transform.position.z);
        Vector3 thisXZPos = new Vector3(transform.position.x, 1.5f, target.transform.position.z);
        Vector3 rayToTarget = targetXZPos - thisXZPos;
        if (Physics.Raycast(thisXZPos, rayToTarget, out raycastInfo))
        {
            if (raycastInfo.transform.gameObject == target.gameObject)
                return true;
        }
        return false;
    }

    public bool CanTargetSeeMe()
    {
        RaycastHit raycastInfo;
        if (Physics.Raycast(target.transform.position, target.transform.forward, out raycastInfo))
        {
            if (raycastInfo.transform.gameObject == gameObject)
                return true;
        }
        return false;
    }
}
