using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;

public class ScreanCap : MonoBehaviour
{
    public Camera Cam;  
    public GameObject Panel; 
    public Transform Grid; 
    public Button Button;
    bool OnYourHands=true;//이거 나중에 False로 바꾸고 손에들고있는지 만들기
    private int MenuClickCount;

    private RenderTexture renderTexture;
    private List<Texture2D> potoList = new List<Texture2D>(); 
    void Start()
    {
        renderTexture = new RenderTexture(1920, 1080, 24);
        Panel.SetActive(false);
    }

    void Update()
    {
        if(OnYourHands == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                TakePoto();
            }
        }
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    if (MenuClickCount % 2 == 0) 
        //    {
        //        Panel.SetActive(true);
        //    }
        //    if (MenuClickCount % 2 == 1) 
        //    {
        //        Panel.SetActive(false) ;
        //    }
        //    MenuClickCount++;
        //}
        if (Input.GetKeyDown(KeyCode.G))
        {
            Panel.SetActive(!Panel.activeSelf);
        }
    }

    void TakePoto()
    {
        if (potoList.Count < 10)
        {
            RenderTexture originalTarget = Cam.targetTexture;  // 원래 설정 저장
            Cam.targetTexture = renderTexture;
            Cam.Render();
            Texture2D poto = KimChee(renderTexture);
            potoList.Add(poto);
            ImageButton(poto);
            Cam.targetTexture = originalTarget;  // 원래 설정 복원
        }
    }

    Texture2D KimChee(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        RenderTexture.active = null;
        return tex;
    }

    void ImageButton(Texture2D poto)
    {
        Button ImageBT = Instantiate(Button, Grid);
        ImageBT.image.sprite = DrawImage(poto);
    }

    Sprite DrawImage(Texture2D Image)
    {
        return Sprite.Create(Image, new Rect(0, 0, Image.width, Image.height), new Vector2(0.5f, 0.5f));
    }
}
