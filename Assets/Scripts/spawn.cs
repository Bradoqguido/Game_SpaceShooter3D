using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    // Controla o respaw de inimigos.
    public float tempoParaRespawnInimigo = 5;
    public float tempoParaSpawnVida = 15;
    public float tempoParaPassarDeFase = 60;
    public GameObject inimigoPrefab;
    public GameObject heartPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnInimigo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        // Controla o respawn de inimigos por tempo.
        if (tempoParaRespawnInimigo <= 0)
        {
            tempoParaRespawnInimigo = 10;
            Debug.Log("Iniciando respawn do inimigo.");
            SpawnInimigo();
            Debug.Log("Respawn do inimigo completo.");
        }
        tempoParaRespawnInimigo -= Time.deltaTime;

        // Controla o respawn de vida por tempo.
        if (tempoParaSpawnVida <= 0)
        {
            tempoParaSpawnVida = 15;
            Debug.Log("Iniciando spawn de vida.");
            SpawnHeart();
            Debug.Log("Spawn de vida completo.");
        }
        tempoParaSpawnVida -= Time.deltaTime;

        // Controla o respawn do Player por tempo.
        if (GameObject.Find("Player") == null)
        {
            Debug.Log("Acabou o jogo, game over!");
            Loader.Load(Loader.Scene.MenuScene);
        }

        if (tempoParaPassarDeFase <= 0)
        {
            Debug.Log("Passou de fase!");
            Loader.Load(Loader.Scene.Level01Scene);
        }
        tempoParaPassarDeFase -= Time.deltaTime;
    }

    void SpawnInimigo()
    {
        Instantiate(inimigoPrefab, RamdonSpawn(), Quaternion.identity);
    }

    void SpawnHeart()
    {
        Instantiate(heartPrefab, new Vector3(Random.Range(-30.0F, 30.0F), -6, Random.Range(-30.0F, 30.0F)), Quaternion.identity);
    }

    private Vector3 RamdonSpawn()
    {
        return new Vector3(Random.Range(-30.0F, 30.0F), 1, Random.Range(-30.0F, 30.0F));
    }
}
