using UnityEngine;
using UnityEngine.UI;

public class PNGToSprite : MonoBehaviour
{
    public string pngResourcePath = "Sickle";

    void Start()
    {
        // Load the PNG file from the Resources folder
        Texture2D texture = Resources.Load<Texture2D>(pngResourcePath);

        // Create a sprite from the texture
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

        // Assign the sprite to a sprite renderer or image component
        // Example: GetComponent<SpriteRenderer>().sprite = sprite;
        // Example: GetComponent<Image>().sprite = sprite;

        GetComponent<Image>().sprite = sprite;
    }
}
