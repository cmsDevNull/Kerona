using UnityEngine;
using UnityEngine.UI;

public class HealthbarOverlayController : MonoBehaviour
{
    public Image overlayFull; // 100%; healthy state.
    public Image overlayGood; // 75%; good state.
    public Image overlayBad; // 50%; worrying state.
    public Image overlayCritical; // 25%; critical state.
    public Image overlayDying; // 0%; death.

    void Update()
    {
        
    }
}
