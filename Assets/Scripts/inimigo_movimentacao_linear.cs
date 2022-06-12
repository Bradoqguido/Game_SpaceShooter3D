using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class inimigo_movimentacao_linear : MonoBehaviour
{
    public float distanciaMinima = 2;
    //public Transform alvo1;
    //public Transform alvo2;
    //private int direcao = 1;

    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        //ctrlDeDano = new DealDamage();

        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.stoppingDistance = distanciaMinima;
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(GameObject.Find("Player").transform.position);
        /*if (direcao == 1)
        {
            navMeshAgent.SetDestination(alvo1.transform.position);
            direcao = -1;
        }
        else
        {
            navMeshAgent.SetDestination(alvo2.transform.position);
            direcao = 1;
        }*/
    }

    void OnCollisionEnter(Collision col)
    {
        // Se o inimigo encostar no player o player morre.
        if (col.gameObject.name == "Player")
        {
            Debug.Log("Tocou no player.");

            GameObject playerObject = GameObject.Find("Player");
            personagem scriptPlayer = (personagem)playerObject.GetComponent(typeof(personagem));
            scriptPlayer.DarDanoAoPlayer(33);

            Debug.Log("Deu dano ao player.");
        }
    }
}

