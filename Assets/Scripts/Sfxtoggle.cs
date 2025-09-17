using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SfxToggle : MonoBehaviour
{
    private bool muted = false;

    public GameObject switchButton;
    public RawImage background;
    public AudioSource[] sfxSources;  // 🎵 assign ALL button/back SFX AudioSources here

    // Colors
    public Color circleOnColor = Color.white;
    public Color circleOffColor = Color.black;
    public Color bgOnColor = new Color(196f / 255f, 164f / 255f, 132f / 255f, 1f);
    public Color bgOffColor = Color.white;

    void Start()
    {
        if (!PlayerPrefs.HasKey("sfxMuted"))
            PlayerPrefs.SetInt("sfxMuted", 0);

        muted = PlayerPrefs.GetInt("sfxMuted") == 1;
        ApplyState();
    }

    public void SwitchButtonClick()
    {
        switchButton.transform.DOLocalMoveX(-switchButton.transform.localPosition.x, 0.5f);

        muted = !muted;
        PlayerPrefs.SetInt("sfxMuted", muted ? 1 : 0);

        ApplyState();
    }

    private void ApplyState()
    {
        foreach (var sfx in sfxSources)
        {
            if (sfx != null)
                sfx.mute = muted;  // 🔑 only mutes SFX
        }

        if (muted)
        {
            switchButton.GetComponent<RawImage>().color = circleOffColor;
            background.color = bgOffColor;
            Debug.Log("SFX: OFF");
        }
        else
        {
            switchButton.GetComponent<RawImage>().color = circleOnColor;
            background.color = bgOnColor;
            Debug.Log("SFX: ON");
        }
    }
}
