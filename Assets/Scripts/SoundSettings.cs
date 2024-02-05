using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private Slider _backgroundMusicVolumeSlider;
    [SerializeField] private AudioSource _backgroundMusicSource;
    [SerializeField] private static SoundSettings Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        //_uiDocument = UIHandler.Instance._uiDocument;
        _backgroundMusicSource = GetComponent<AudioSource>();
        _backgroundMusicVolumeSlider = UIHandler.Instance._uiDocument.rootVisualElement.Q<Slider>("BackgroundMusicVolumeSlider");
        _backgroundMusicSource.volume = _backgroundMusicVolumeSlider.value;
    }
    private void Update()
    {
        _backgroundMusicSource.volume = _backgroundMusicVolumeSlider.value;
    }
}
