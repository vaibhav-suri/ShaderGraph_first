using UnityEngine;
using UnityEngine.UI;

public class WebcamCapture : MonoBehaviour
{
    /// <summary>
    /// Material used to play with the webcam texture.
    /// </summary>
    /// 
    [SerializeField]
    private Material _material = default;
    public GameObject distortlayer;
    public Material[] materials;
    public string[] texts;
    public Text enabletext;
    public int count;
    public Text effectname;

    bool enableflag;
    public int baseRotation;

    /// <summary>
    /// Texture containing the webcam capture, will be sent to the shader.
    /// </summary>
    private WebCamTexture _webCamTexture;

    public void EnableDistort()
    {
        enableflag = !enableflag;
        distortlayer.SetActive(enableflag);
        if(enableflag)
        {
            enabletext.text = "Distortion On";
        }
        else
        {
            enabletext.text = "Distortion Off";

        }
    }
    public void next()
    {
     count=count+1;
        count = count % 4;
    }
    /// <summary>
    /// Initialize the webcam texture and start capturing.
    /// </summary>
     void Start()
    {
       // baseRotation = transform.rotation;

        effectname.text = texts[count];

        enabletext.text = "Distortion Off";

        enableflag = false;
       // distortlayer.SetActive(enableflag);
        WebCamDevice[] devices = WebCamTexture.devices;
          distortlayer.SetActive(false);
        count = 0;
        if (_webCamTexture == null)
        {
            //foreach( WebCamDevice cam in devices)
            //{
            //    if (cam.isFrontFacing)
            //    {
            //        _webCamTexture = new WebCamTexture();
            //        _webCamTexture.deviceName = cam.name;
            //        _webCamTexture.Play();
            //    }
            //}
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
     //   baseRotation = -_webCamTexture.videoRotationAngle;
     //   this.transform.localEulerAngles = new Vector3(0, 0, baseRotation);
        // transform.rotation = baseRotation * Quaternion.AngleAxis(_webCamTexture.videoRotationAngle, Vector3.up);
      //  _webCamTexture.
        int rotangle = -_webCamTexture.videoRotationAngle;
        if(rotangle<0)
        {
            rotangle += 360;
        }
        if(rotangle>360)
        {
            rotangle -= 360;
        }
         
        //  distortlayer.SetActive(false);
            _material = materials[count];
            this.GetComponent<MeshRenderer>().material = materials[count];
            if (_material == null)
                return;
            _material.SetTexture("_WebcamTex", _webCamTexture);
        effectname.text = texts[count];

    }
}