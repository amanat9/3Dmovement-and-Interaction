using UnityEngine;

[ExecuteAlways]
public class SunTimeOfDay : MonoBehaviour
{
    public enum TimeOfDay
    {
        Sunrise,
        Morning,
        Noon,
        Afternoon,
        Sunset,
        Night,
        Custom
    }

    public TimeOfDay timeOfDay = TimeOfDay.Noon;

    [Header("X Rotation For Each Time")]
    public float sunriseXRotation = 15f;
    public float morningXRotation = 35f;
    public float noonXRotation = 90f;
    public float afternoonXRotation = 130f;
    public float sunsetXRotation = 170f;
    public float nightXRotation = 230f;
    public float customXRotation = 90f;

    private void Start()
    {
        ApplyTimeOfDay();
    }

    private void OnValidate()
    {
        ApplyTimeOfDay();
    }

    private void ApplyTimeOfDay()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.x = GetXRotation();
        transform.eulerAngles = rotation;
    }

    private float GetXRotation()
    {
        switch (timeOfDay)
        {
            case TimeOfDay.Sunrise:
                return sunriseXRotation;
            case TimeOfDay.Morning:
                return morningXRotation;
            case TimeOfDay.Noon:
                return noonXRotation;
            case TimeOfDay.Afternoon:
                return afternoonXRotation;
            case TimeOfDay.Sunset:
                return sunsetXRotation;
            case TimeOfDay.Night:
                return nightXRotation;
            case TimeOfDay.Custom:
                return customXRotation;
            default:
                return noonXRotation;
        }
    }
}
