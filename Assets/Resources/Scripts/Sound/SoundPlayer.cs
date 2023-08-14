using System.Collections;
using Resources.Scripts.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Resources.Scripts.Sound
{
    public class SoundPlayer : MonoBehaviour, IUseSound
    {
        private bool canItPlay = true;
        [SerializeField] private bool haveTimout;

        public void PlaySound(AudioClip clip, float volume)
        {                
            if (haveTimout)
            {
                if (canItPlay)
                {
                    StartCoroutine(Play(clip, volume));
                    canItPlay = false;
                }
            }
            else
            {
                StartCoroutine(Play(clip, volume));
            }
        }

        private IEnumerator Play(AudioClip clip, float volume)
        {
            AudioSource source = Camera.main.AddComponent<AudioSource>();
            source.clip = clip;
            source.volume = volume;
            source.spatialBlend = 0f;
            source.Play();
            
            yield return new WaitForSeconds(.03f);
            canItPlay = true;
            yield return new WaitForSeconds(source.clip.length);
            Destroy(source);
        }
    }
}