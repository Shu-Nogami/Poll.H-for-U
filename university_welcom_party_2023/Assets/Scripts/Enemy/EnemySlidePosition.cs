using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemySlidePosition : MonoBehaviour
    {
        private static readonly float Z_POSITION = 1.0f;
        private static readonly float X_OR_Y_POSITION = 4.0f;

        public static void SetEnemyPosition(int enemyPosition, GameObject enemy)
        {

            switch (enemyPosition)
            {
                case 1:
                    enemy.transform.position = new Vector3(0, X_OR_Y_POSITION, Z_POSITION);
                    break;
                case 2:
                    enemy.transform.position = new Vector3(0, -X_OR_Y_POSITION, Z_POSITION);
                    break;
                case 3:
                    enemy.transform.position = new Vector3(X_OR_Y_POSITION, 0, Z_POSITION);
                    break;
                case 4:
                    enemy.transform.position = new Vector3(-X_OR_Y_POSITION, 0, Z_POSITION);
                    break;
            }
        }

        public static void SlideEnemyPosition(List<EnemyAndPosition> enemyAndPositions)
        {
            foreach (var enemyAndPosition in enemyAndPositions)
            {
                enemyAndPosition.SlideEnemyPosition();
            }
        }
    }
}