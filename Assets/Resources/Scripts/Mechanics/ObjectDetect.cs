using System;
using Resources.Scripts.Gameplay;
using Resources.Scripts.UI;
using Sound;
using UnityEngine;

namespace Resources.Scripts.Mechanics
{
    public class ObjectDetect : MonoBehaviour
    {
        private GameObject player;
        private Transform column;
        
        [SerializeField] private GameObject cubePrefab;
        [SerializeField] private AudioClip pickup;
        
        [SerializeField] private AudioClip wallTouch;
        
        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            column = gameObject.transform.parent;
        }

        private void OnCollisionEnter(Collision collision)
        {
            DetectTag(collision.gameObject.tag, collision);
        }

        private void DetectTag(string tag, Collision collision)
        {
            Collider collider = collision.gameObject.GetComponent<Collider>();
            Vector3 highestPoint = collider.bounds.max;

            if (tag.Equals("Finish"))
            {
                GameState.Instance.WinGame();
            }

            if (gameObject.transform.position.y < highestPoint.y)
            {
                if (collider != null)
                {
                    if (tag.Equals("Wall"))
                    {
                        if (Camera.main != null) DotweenManager.Instance.Shake(Camera.main.gameObject.transform, 0.3f, 0.5f);
                        SoundManager.Instance.Play(wallTouch, 1);
                        SetCubeParent(collision);
                    }
                    else if (tag.Equals("Cube"))
                    {
                        if (ColumnLogic.Instance.ColumnObjectsExceptCount >= 4)
                        {
                            InGameUI.Instance.ActivatingText("Column is full");
                        }
                        else
                        {
                            CreateBlockInColumn();
                            Destroy(collision.gameObject);
                        }
                    }
                }
            }
        }
        
        private void CreateBlockInColumn()
        {
            SoundManager.Instance.Play(pickup, 1);
            var position = player.transform.position;
            position = new Vector3(position.x, position.y + 1, position.z);
            player.transform.position = position;
            var position2 = new Vector3(position.x, position.y - 1, position.z);

            Instantiate(cubePrefab, position2, Quaternion.identity, column);
        }

        private void SetCubeParent(Collision collision)
        {
            gameObject.transform.parent = collision.gameObject.transform;
        }
    }
}
