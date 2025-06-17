using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    private int _spawnCount = 0;

     //void Update()
     //{
        //if (Input.GetKeyDown (KeyCode.Space))
        //{
            // EnemyAppear();
        //}
     //}

    private void Start()
    {
        StartCoroutine(EnemyAppearing());
    }

    public void EnemyDied()
    {
        _spawnCount--;
    }


    public void EnemyAppear()
    {
        Vector2 enemySpawnZone = new Vector2(Random.Range (-7, 8.21f), -6f);
        Instantiate (_enemy, enemySpawnZone, Quaternion.identity); 
    }

    //Co Routine Implementation:
    IEnumerator EnemyAppearing()
    {
        while (true)
        {
            yield return new WaitForSeconds(2); //Enemy appear function will be taking place for every 2 seconds after clicking the SpaceBar key.
            if (_spawnCount < 8)
            { 
                EnemyAppear();
            _spawnCount++;
            }
        }
    }
}
