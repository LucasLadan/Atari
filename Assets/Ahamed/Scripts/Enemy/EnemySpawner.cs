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
            StartCoroutine(EnemyAppearing());
        }
            
        
        
     }
    // Update is called once per frame
    public void EnemyAppear()
    {
        Vector2 enemySpawnZone = new Vector2(Random.Range (-7, 8.21f), Random.Range(-3.46f, -3.46f));
        Instantiate (_enemy, enemySpawnZone, Quaternion.identity); 
    }

    IEnumerator EnemyAppearing()
    {
        yield return new WaitForSeconds (2);
        EnemyAppear ();
    }
}
