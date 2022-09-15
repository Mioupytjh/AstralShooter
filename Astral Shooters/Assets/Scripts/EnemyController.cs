using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float detectionRange = 30f;

    Transform target;
    NavMeshAgent agent;
    GameObject Ground;
    bool isPatroling = false;
    Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        Ground = GameObject.FindGameObjectWithTag("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance < detectionRange)
        {
            agent.SetDestination(target.position);
            isPatroling = false;
        }
        else if(!isPatroling)
        {
            Patrole();
        }
        else if(Vector3.Distance(destination, transform.position) < 2)
        {
            isPatroling = false;
        }
    }

    private void Patrole()
    {
        isPatroling = true;

        float maxX = Ground.transform.position.x + Ground.transform.lossyScale.x / 2f;
        float minX = Ground.transform.position.x - Ground.transform.lossyScale.x / 2f;
        float maxZ = Ground.transform.position.z + Ground.transform.lossyScale.z / 2f;
        float minZ = Ground.transform.position.z - Ground.transform.lossyScale.z / 2f;

        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);

        destination = new Vector3(x, transform.position.y, z);

        agent.SetDestination(destination);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}