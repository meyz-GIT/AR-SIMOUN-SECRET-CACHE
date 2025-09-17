using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MusicToggle : MonoBehaviour
{
    private bool muted = false;

    public GameObject switchButton;
    public RawImage background;
    public AudioSource musicSource;   // 🎵 assign your music AudioSource here

    // Colors
    public Color circleOnColor = Color.white;
    public Color circleOffColor = Color.black;
    public Color bgOnColor = new Color(196f / 255f, 164f / 255f, 132f / 255f, 1f);
    public Color bgOffColor = Color.white;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicMuted"))
            PlayerPrefs.SetInt("musicMuted", 0);

        muted = PlayerPrefs.GetInt("musicMuted") == 1;
        ApplyState();
    }

    public void SwitchButtonClick()
    {
        switchButton.transform.DOLocalMoveX(-switchButton.transform.localPosition.x, 0.5f);

        muted = !muted;
        PlayerPrefs.SetInt("musicMuted", muted ? 1 : 0);

        ApplyState();
    }

    private void ApplyState()
    {
        musicSource.mute = muted;  // 🔑 only mutes music

        if (muted)
        {
            switchButton.GetComponent<RawImage>().color = circleOffColor;
            background.color = bgOffColor;
            Debug.Log("Music: OFF");
        }
        else
        {
            switchButton.GetComponent<RawImage>().color = circleOnColor;
            background.color = bgOnColor;
            Debug.Log("Music: ON");
        }
    }
}
