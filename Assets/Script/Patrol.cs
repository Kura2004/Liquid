using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] points;
    public float desitance;
    private GameObject player;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public static bool homing_on;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // autoBraking を無効にすると、目標地点の間を継続的に移動します
        //(つまり、エージェントは目標地点に近づいても
        destPoint = Random.Range(0, points.Length);
        // 速度をおとしません)
        agent.autoBraking = false;

        destPoint = Random.Range(0, points.Length);

        player = GameObject.FindWithTag("GameController");
        GotoNextPoint();
        homing_on = false;
    }

    void GotoNextPoint()
    {
        // 地点がなにも設定されていないときに返します
        if (points.Length == 0)
            return;

        // エージェントが現在設定された目標地点に行くように設定します
        agent.destination = points[destPoint].position;

        // 配列内の次の位置を目標地点に設定し、
        // 必要ならば出発地点にもどります
        destPoint = (destPoint + 1) % points.Length;

        destPoint = Random.Range(0, points.Length);
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, player.transform.position) < desitance || homing_on) 
        {
            agent.destination = player.transform.position;

        }

        else
        {
            // エージェントが現目標地点に近づいてきたら、
            // 次の目標地点を選択します
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
    }
}
