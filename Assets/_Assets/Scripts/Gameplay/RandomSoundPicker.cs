using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
	public class RandomSoundPicker : MonoBehaviour
	{
		[SerializeField] private AudioSource audioSource;
		[SerializeField] private AudioClip[] clips;
		private int _lastIndex;

		private void Awake()
		{
			AudioClip clip = clips[Random.Range(0, clips.Length)];
			audioSource.clip = clip;
			audioSource.Play();
			Destroy(gameObject, clip.length);
		}
	}
}
