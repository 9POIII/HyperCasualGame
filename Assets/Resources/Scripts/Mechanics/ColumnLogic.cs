using System.Collections.Generic;
using System.Linq;
using Resources.Scripts.Gameplay;
using Sound;
using UnityEngine;

namespace Resources.Scripts.Mechanics
{
    public class ColumnLogic : MonoBehaviour
    {
        public static ColumnLogic Instance;
        
        private bool isDone = false;
        private Transform[] columnObjects;
        private IEnumerable<Transform> columnObjectsExcept;
        [SerializeField] private Transform[] exceptObjects;

        public int ColumnObjectsExceptCount => columnObjectsExcept.Count() - 1;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        void Update()
        {
            if (isDone) return;
            columnObjects = gameObject.GetComponentsInChildren<Transform>();
            columnObjectsExcept = columnObjects.Except(exceptObjects);

            if (ColumnObjectsExceptCount <= 0)
            {
                GameState.Instance.LoseGame();
                isDone = true;
            }
        }
    }
}