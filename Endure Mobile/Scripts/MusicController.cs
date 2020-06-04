using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MusicController
{
    public static void FadeOut(MusicPlayer music_player,AudioSource a, float duration)
    {
        a.GetComponent<MonoBehaviour>().StartCoroutine(FadeOutCore(music_player, a, duration));
    }

    private static IEnumerator FadeOutCore(MusicPlayer m_player, AudioSource a, float duration)
    {
        float startVolume = a.volume;

        while (a.volume > 0)
        {
            a.volume -= startVolume * Time.deltaTime / duration;
            yield return new WaitForEndOfFrame();
        }


        a.Stop();
        m_player.setFightMusic(false);
        m_player.source.Stop();
        a.volume = startVolume;
    }

    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = 0.2f;

        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.volume = 1f;
    }

}
