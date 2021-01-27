using UnityEngine;
public class AudioController : MonoBehaviour
{
    [SerializeField] ScriptableAudioClip oneShotClip;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] ScriptableFloat master, sfx, music;
    private void OnEnable()
    {
        master.Value = 1f;
        sfx.Value = .5f;
        music.Value = .2f;
        UpdateVolume();
        musicSource.Play();
    }
    public void UpdateVolume()
    {
        SFXSource.volume = master.Value * sfx.Value;
        musicSource.volume = master.Value * music.Value;
    }
    public void PlayClip() => SFXSource.PlayOneShot(oneShotClip.Value);
    public void ChangeMusicClip()
    {
        musicSource.clip = oneShotClip.Value;
        musicSource.Play();
    }
}
