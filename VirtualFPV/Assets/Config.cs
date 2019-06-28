using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour {

	public bool ShowBalloonLabel = true;
	public bool SoundEffect = true;
    public bool DemoMode = false;

    public Material matIllust;
    public Material matPhoto;

    // 制御用
    public ConfigWindow configWindow;
    GameObject balloonLabel;

    static Config instance;

    // 起動時に読み込み、終了時に保存したい

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        balloonLabel = GameObject.Find("/Balloon/Infobox");

        // 他のオブジェクトの準備ができてから初期化処理をおこなう
        StartCoroutine(DelayedInit());
    }

    private IEnumerator DelayedInit()
    {
        yield return new WaitForSeconds(0.3f);
        Init();
    }

    private void Init()
    {
        SetShowBalloonLabel(ShowBalloonLabel);
        SetSoundEffect(SoundEffect);
    }

    public static Config GetInstance()
    {
        return instance;
    }

    public void SetShowBalloonLabel(bool flag)
    {
        ShowBalloonLabel = flag;
        balloonLabel.SetActive(flag);
    }

    public void SetSoundEffect(bool flag)
    {
        SoundEffect = flag;
    }

    public void SetDemoMode(bool flag)
    {
        DemoMode = flag;
    }

    void Update () {
        if (Input.GetKeyUp(KeyCode.B))
        {
            bool flag = !ShowBalloonLabel;
            SetShowBalloonLabel(flag);
            configWindow.SetShowBalloonLabel(flag);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            bool flag = !SoundEffect;
            SetSoundEffect(flag);
            configWindow.SetSoundEffect(flag);
        }
    }
}
