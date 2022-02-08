using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseEnemy : MonoBehaviour
{
    public enum Enemy { Rotate, Follow };

    public Enemy ActiveState = Enemy.Rotate;
    public EnemyFollow enemyFollow;
    public EnemyRotation enemyRotation;

    private void Start()
    {
        enemyFollow = GetComponent<EnemyFollow>();
        enemyRotation = GetComponent<EnemyRotation>();
    }
    void Update()
    {
        switch (ActiveState)
        {
            case Enemy.Rotate:
                enemyRotation.enabled = true;
                enemyFollow.enabled = false;
                break;

            case Enemy.Follow:
                enemyFollow.enabled = true;
            break;
        }
    }
}
