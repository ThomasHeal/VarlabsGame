using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScreenShotManager : MonoBehaviour
{
    public Camera screenshotCamera;
    public int screenshotWidth = 128;
    public int screenshotHeight = 128;
    public string screenshotFolder = "Screenshots";
    private int screenshotCount = 0;

    void Update()
    {
        // Take a screenshot when the user presses the space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeScreenshot();
        }
    }

    void TakeScreenshot()
    {
        // Create a directory to save screenshots in if it doesn't exist
        if (!Directory.Exists(screenshotFolder))
        {
            Directory.CreateDirectory(screenshotFolder);
        }

        // Take a screenshot and save it to a file
        string screenshotName = "screenshot" + screenshotCount + ".png";
        string screenshotPath = Path.Combine(screenshotFolder, screenshotName);
        Debug.Log("took screenshot");

        // Create a render texture and set it as the target texture of the screenshot camera
        RenderTexture renderTexture = new RenderTexture(screenshotWidth, screenshotHeight, 24);
        screenshotCamera.targetTexture = renderTexture;

        // Render the scene to the render texture
        screenshotCamera.Render();

        // Read the pixels from the render texture and create a texture from them
        Texture2D texture = new Texture2D(screenshotWidth, screenshotHeight, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;
        texture.ReadPixels(new Rect(0, 0, screenshotWidth, screenshotHeight), 0, 0);
        texture.Apply();

        // Encode the texture as a PNG file and write it to disk
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(screenshotPath, bytes);

        // Reset the camera and render texture, and destroy the render texture
        screenshotCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        // Increment the screenshot count
        screenshotCount++;
    }
}
