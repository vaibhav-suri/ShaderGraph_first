using UnityEngine;
using UnityEngine.UI;

public class distortlayer : MonoBehaviour
{
    /// <summary>
    /// Material used to play with the webcam texture.
    /// </summary>
    /// 
    [SerializeField]
    private Material _material = default;

    /// <summary>
    /// Texture containing the webcam capture, will be sent to the shader.
    /// </summary>
    private WebCamTexture _webCamTexture;

    /// <summary>
    /// Initialize the webcam texture and start capturing.
    /// </summary>
    private void Start()
    {
        if (_webCamTexture == null)
        {
            _webCamTexture = new WebCamTexture();
        }

        // _webCamTexture.requestedHeight = Screen.height;
        //  _webCamTexture.requestedWidth = Screen.width;
        //     this.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        _webCamTexture.Play();
    }

    /// <summary>
    /// Send texture to the shader.
    /// </summary>
    private void Update()
    {
       
            if (_material == null)
                return;
            _material.SetTexture("_WebcamTex", _webCamTexture);
        
    }
}