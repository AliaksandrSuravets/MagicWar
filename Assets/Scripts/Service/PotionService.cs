using System;
using MagicWar.Game.Potions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MagicWar.Service
{
    public class PotionService : MonoBehaviour
    {
        #region Variables

        [Range(0, 100)]
        [SerializeField] private int _potionsDropChance = 50;
        [SerializeField] private PotionSpawnData[] _potions;

        #endregion

        #region Public methods

        public void OnDied(Component sender, object data)
        {
            if (data is not GameObject)
            {
                return;
            }

            GameObject gameObjectData = (GameObject) data;
            CreatePotion(gameObjectData.transform.position);
        }
        
        
        public void CreatePotion(Vector3 position)
        {
            if (_potions == null || _potions.Length == 0)
            {
                return;
            }

            int chance = Random.Range(0, 101);
            if (_potionsDropChance >= chance)
            {
                InstantiateRandomPotion(position);
            }
        }

        #endregion

        #region Private methods

        private void InstantiateRandomPotion(Vector3 position)
        {
            int weightSum = 0;
            foreach (PotionSpawnData spawnData in _potions)
            {
                weightSum += spawnData.SpawnWeight;
            }

            int randomWeight = Random.Range(0, weightSum + 1);
            int selectedWeight = 0;

            for (int i = 0; i < _potions.Length; i++)
            {
                PotionSpawnData spawnData = _potions[i];
                selectedWeight += spawnData.SpawnWeight;

                if (selectedWeight >= randomWeight)
                {
                    Instantiate(spawnData.PotionPrefab, position, Quaternion.identity);

                    return;
                }
            }
        }

        #endregion

        #region Local data

        [Serializable]
        private class PotionSpawnData
        {
            #region Variables

            public Potion PotionPrefab;
            public int SpawnWeight;

            #endregion
        }

        #endregion
    }
}