using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    #region Sigleton
    public static AudioController Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField]
    private AudioSource ButtonClickedAudio, Swipe, PopUpOpen, PopUpClose;
    [SerializeField]
    private AudioSource Bump, Cheese, Bomb, ShieldActive, SpeedBoostActive, ShieldPickUp, SpeedPickUp, Eating, DoorClose;
    [SerializeField]
    private AudioSource InGameMusic, ShopMusic, MainMenuMusic, WinSound, LoseSound;

    public void PlayButtonCLickedAudio()
    {
        ButtonClickedAudio.Play();
    }

    public void PlayPopUpOpenAudio()
    {
        PopUpOpen.Play();
    }

    public void PlayPopUpCloseAudio()
    {
        PopUpClose.Play();
    }

    public void PlayBumpAudio()
    {
        Bump.Play();
    }

    public void PlayCheeseAudio()
    {
        Cheese.Play();
    }

    public void PlayBombAudio()
    {
        Bomb.Play();
    }

    public void PlayInGameMusicAudio()
    {
        InGameMusic.Play();
    }

    public void StopInGameMusicAudio()
    {
        InGameMusic.Stop();
    }

    public void PlayShopMusicAudio()
    {
        ShopMusic.Play();
    }

    public void StopShopMusicAudio()
    {
        ShopMusic.Stop();
    }

    public void PlayMainMenuMusicAudio()
    {
        MainMenuMusic.Play();
    }

    public void StopMainMenuMusicAudio()
    {
        MainMenuMusic.Stop();
    }

    public void PlayWinSoundAudio()
    {
        WinSound.Play();
    }

    public void PlayLoseSoundAudio()
    {
        LoseSound.Play();
    }

    public void PlayShieldActiveAudio()
    {
        ShieldActive.Play();
    }

    public void PlayShieldDeActiveAudio()
    {
        ShieldActive.Stop();
    }

    public void PlaySpeedBoostActiveAudio()
    {
        SpeedBoostActive.Play();
    }

    public void PlaySpeedBoostDeActiveAudio()
    {
        SpeedBoostActive.Stop();
    }

    public void PlaySpeedBoostPickUpAudio()
    {
        SpeedPickUp.Play();
    }

    public void PlayShieldBoostPickUpAudio()
    {
        ShieldPickUp.Play();
    }

    public void PlaySwipeSound()
    {
        Swipe.Play();
    }

    public void PlayEatingActiveAudio()
    {
        Eating.Play();
    }

    public void PlayEatingDeActiveAudio()
    {
        Eating.Stop();
    }

    public void PlayDoorCloseAudio()
    {
        DoorClose.Play();
    }
}
