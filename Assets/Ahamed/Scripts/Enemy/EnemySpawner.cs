using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

     void Update()
     {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            //StartCoroutine(EnemyAppearing());
            EnemyAppear();
        }
     }

    
    public void EnemyAppear()
    {
        Vector2 enemySpawnZone = new Vector2(Random.Range (-7, 8.21f), Random.Range(-3.46f, -3.46f));
        Instantiate (_enemy, enemySpawnZone, Quaternion.identity); 
    }

    //Co Routine Implementation:
    //IEnumerator EnemyAppearing()
    //{
        
        
    //        yield return new WaitForSeconds(2); //Enemy appear function will be taking place for every 2 seconds after clicking the SpaceBar key.
    //        EnemyAppear();
       
    //}
}
