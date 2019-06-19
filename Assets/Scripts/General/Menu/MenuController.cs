using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject PauseMenuPanelUI, MuteMusicButton, UnMuteMusicButton, MuteSFXButton, UnMuteSFXButton, ExitPanel;
    [SerializeField]
    private int SceneToRestart, SceneToMainMenu, SceneToNextLevel, SceneToSkip;
    [SerializeField]
    private AudioMixer AudioMixer;
    [SerializeField]
    private Animator PauseMenuAnimator, TransitionAnimator, LevelSelectAnimator, ShopAnimator, ExitPanelAnimator, creditPanel;

    
    
    private void Start()
    {
        UpdateMusicButton();
        UpdateSFXButton();
        Time.timeScale = 1;

    }

    public void PlayButton()
    {
        LevelSelectAnimator.SetTrigger("IsStarting");
    }

    public void ExitButton()
    {
        ExitPanelAnimator.SetTrigger("IsStarting");
    }

    public void ExitCancelButton()
    {
        ExitPanelAnimator.SetTrigger("IsEnding");
    }

    public void ExitConfirmButton()
    {
        Application.Quit();
    }

    public void PauseButton()
    {
        PauseMenuAnimator.SetTrigger("IsStarting");
        GameManager.Instance.PausedState();
        PauseMenuPanelUI.SetActive(true);
    }

    public void PauseMenuResumeButton()
    {
        StartCoroutine(UnPauseTimer());
        GameManager.Instance.UnPausedState();
    }

    public void PauseMenuRestartButton()
    {
        PauseMenuPanelUI.SetActive(false);
        SceneManager.LoadScene(SceneToRestart);
    }

    //Timer
    IEnumerator UnPauseTimer()
    {
        PauseMenuAnimator.SetTrigger("IsEnding");
        yield return new WaitForSeconds(0.2f);
        PauseMenuPanelUI.SetActive(false);
    }

    public void PauseMenuMainMenuButton()
    {
        PauseMenuPanelUI.SetActive(false);
        SceneManager.LoadScene(SceneToMainMenu);
    }

    public void MainMenuShopUIButton()
    {
        ShopAnimator.SetTrigger("IsStarting");
    }

    public void MainMenuShopUIBackButton()
    {
        ShopAnimator.SetTrigger("IsEnding");
    }

    public void EndGameMainMenuButton()
    {
        SceneManager.LoadScene(SceneToMainMenu);
    }

    public void EndGameRestartButton()
    {
        SceneManager.LoadScene(SceneToRestart);
    }

    public void EndGameNextLevelButton()
    {
        //StartCoroutine(NextLevelTimer());
        SceneManager.LoadScene(SceneToNextLevel);
    }

    public void CreditPanelButton()
    {
        creditPanel.SetTrigger("isStarting");
    }

    public void CreditPanelBackButton()
    {
        creditPanel.SetTrigger("isEnding");
    }

    //Timer
    IEnumerator NextLevelTimer()
    {
        TransitionAnimator.SetTrigger("IsEnding");
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(SceneToNextLevel);
    }

    public void LevelSelectBackButton()
    {
        LevelSelectAnimator.SetTrigger("IsEnding");
    }

    public void LevelSelectIntroVideoButton()
    {
        if(PlayerPrefs.GetInt("Video Played") == 0)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
        
    }


    public void LevelSelect1Button()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelSelect2Button()
    {
        SceneManager.LoadScene(2);
    }

    public void LevelSelect3Button()
    {
        SceneManager.LoadScene(3);
    }

    public void LevelSelect4Button()
    {
        SceneManager.LoadScene(4);
    }

    public void LevelSelect5Button()
    {
        SceneManager.LoadScene(5);
    }

    public void LevelSelect6Button()
    {
        SceneManager.LoadScene(6);
    }

    public void LevelSelect7Button()
    {
        SceneManager.LoadScene(7);
    }

    public void LevelSelect8Button()
    {
        SceneManager.LoadScene(8);
    }

    public void LevelSelect9Button()
    {
        SceneManager.LoadScene(9);
    }

    public void LevelSelect10Button()
    {
        SceneManager.LoadScene(10);
    }

    public void SkipVideoButton()
    {
        SceneManager.LoadScene(SceneToSkip);
    }

    public void MuteButtonMusic()
    {
        SoundManager.instance.ToogleMusic();
        UpdateMusicButton();
    }

    public void UnMuteButtonMusic()
    {
        SoundManager.instance.ToogleMusic();
        UpdateMusicButton();
    }

    public void MuteButtonSFX()
    {
        SoundManager.instance.ToogleSFX();
        UpdateSFXButton();
    }

    public void UnMuteButtonSFX()
    {
        SoundManager.instance.ToogleSFX();
        UpdateSFXButton();
    }

    void UpdateMusicButton()
    {
        if (PlayerPrefs.GetInt("MutedMusic", 0) == 0)
        {
            MuteMusicButton.SetActive(true);
            UnMuteMusicButton.SetActive(false);
            AudioMixer.SetFloat("VolumeMusic", 0);
        }
        else
        {
            MuteMusicButton.SetActive(false);
            UnMuteMusicButton.SetActive(true);
            AudioMixer.SetFloat("VolumeMusic", -80);
        }
    }

    void UpdateSFXButton()
    {
        if (PlayerPrefs.GetInt("MutedSFX", 0) == 0)
        {
            MuteSFXButton.SetActive(true);
            UnMuteSFXButton.SetActive(false);
            AudioMixer.SetFloat("VolumeSFX", 0);
        }
        else
        {
            MuteSFXButton.SetActive(false);
            UnMuteSFXButton.SetActive(true);
            AudioMixer.SetFloat("VolumeSFX", -80);
        }
    }
}
