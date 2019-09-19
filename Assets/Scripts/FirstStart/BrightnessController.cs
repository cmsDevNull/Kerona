using UnityEngine;

public class BrightnessController : MonoBehaviour
{
    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) decreaseBrightness();       
        if (Input.GetKeyDown(KeyCode.RightArrow)) increaseBrightness();       
    }

    public void decreaseBrightness() {
        this.gameObject.transform.Rotate(0, 0, 5f);
        Screen.brightness -= 0.1f;
    }

    public void increaseBrightness() {
        this.gameObject.transform.Rotate(0, 0, -5f);
        Screen.brightness += 0.1f;
    }
}
