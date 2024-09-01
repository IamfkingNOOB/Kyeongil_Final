using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        RenderSettings.skybox.SetFloat(name: "_Rotation", value: Time.time * rotateSpeed);
    }
}
