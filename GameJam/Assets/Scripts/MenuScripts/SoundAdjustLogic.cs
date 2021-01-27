using UnityEngine;
using UnityEngine.UI;

public class SoundAdjustLogic : MonoBehaviour
{
    [SerializeField] ScriptableFloat VolumeObject;
    [SerializeField] Slider mySlider;

    private void OnEnable() => UpdateSlider();
    public void UpdateVolume() => VolumeObject.Value = mySlider.value;
    void UpdateSlider() => mySlider.value = VolumeObject.Value;
}