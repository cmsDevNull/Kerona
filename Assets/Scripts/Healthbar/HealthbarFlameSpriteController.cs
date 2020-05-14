using UnityEngine;
using System.Collections.Generic;

public class HealthbarFlameSpriteController : MonoBehaviour
{
    public int animationSpeed = 18;
    public List<Sprite> sprites;

    private int timer;
    private int spriteIndex;

    void Start() {
        spriteIndex = 0;
        timer = animationSpeed;
    }

    void Update() {
        switch (timer) {
            case 0:
                GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
                spriteIndex++;
                if (spriteIndex >= sprites.Count) spriteIndex = 0;
                timer = animationSpeed;
                break;
            default:
                timer--;
                break;
        }
    }
}
