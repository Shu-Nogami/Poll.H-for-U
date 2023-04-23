using UnityEngine;

namespace Enemy
{
    public class EnemySpawn : MonoBehaviour
    {
        private readonly int SPAWN_ENEMY_KINDS = 3;
        private readonly string ENEMY_FILE_PATH = "Prefabs/Enemy/";
        private readonly string POLLEN_LEVEL_ONE = "PollenLevel1";
        private readonly string POLLEN_LEVEL_TWO = "PollenLevel2";
        private readonly string POLLEN_LEVEL_THREE = "PollenLevel3";

        private GameObject pollenLevelOne;
        private GameObject pollenLevelTwo;
        private GameObject pollenLevelThree;
        
        public void Initialize()
        {
            pollenLevelOne = (GameObject)Resources.Load(ENEMY_FILE_PATH + POLLEN_LEVEL_ONE);
            pollenLevelTwo = (GameObject)Resources.Load(ENEMY_FILE_PATH + POLLEN_LEVEL_TWO);
            pollenLevelThree = (GameObject)Resources.Load(ENEMY_FILE_PATH + POLLEN_LEVEL_THREE);
        }

        public void Spawn(int spawnNumber)
        {
            for (int i = 0; i < spawnNumber; i++)
            {
                var random = Random.Range(0, SPAWN_ENEMY_KINDS);
                switch (random)
                {
                    case 0:
                        InstantiateEnemy(pollenLevelOne);
                        break;
                    case 1:
                        InstantiateEnemy(pollenLevelTwo);
                        break;
                    case 2:
                        InstantiateEnemy(pollenLevelThree);
                        break;
                    default:
                        break;
                }
            }
        }

        private void InstantiateEnemy(GameObject enemy)
        {
            var instance = Instantiate(enemy);
            InGameManager.InGameInstance.AddEnemyList(instance);
        }
    }
}