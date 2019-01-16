using System;
using System.Collections;
using System.Linq;
using System.IO;
using Google.Cloud.Vision.V1;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class FM : MonoBehaviour
{
    Texture2D fphoto;
    WebCamTexture webCamTexture;
    // Start is called before the first frame update
    void Start()
    {
        webCamTexture = new WebCamTexture();
        webCamTexture.Play();

        raw.texture = webCamTexture;
    }

    public RawImage raw;

    public void buttonclick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("TakePhoto");
        }
    }

    IEnumerator TakePhoto()
    {
        //take pic
        Debug.Log("Take Pic");
        yield return new WaitForEndOfFrame();

        Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
        photo.SetPixels(webCamTexture.GetPixels());
        photo.Apply();

        File.WriteAllBytes("C:\\Users\\Cengiz Sirlan\\Documents\\SM\\Assets\\" + "photo.png", photo.EncodeToPNG());
        //detect face//detect prominent color
        Notmain();
        

       
     
    }



     void Notmain()
    {
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "C:\\Users\\Cengiz Sirlan\\Desktop\\key.json");


        var client = ImageAnnotatorClient.Create();
        var response = client.DetectFaces(Google.Cloud.Vision.V1.Image.FromFile("Assets/photo.png"));//should be photo.png

    
        foreach (var annotation in response)
        {
            Debug.Log(annotation.FdBoundingPoly);
        
            float width = annotation.FdBoundingPoly.Vertices[1].X - annotation.FdBoundingPoly.Vertices[0].X;
            Debug.Log(width);
            Debug.Log(width + "\n" + annotation.FdBoundingPoly.Vertices[1].X);

            float height = annotation.FdBoundingPoly.Vertices[2].Y - annotation.FdBoundingPoly.Vertices[0].Y;
            fphoto = new Texture2D(annotation.FdBoundingPoly.Vertices[1].X - annotation.FdBoundingPoly.Vertices[0].X, annotation.FdBoundingPoly.Vertices[2].Y - annotation.FdBoundingPoly.Vertices[0].Y);
          
            fphoto.SetPixels(webCamTexture.GetPixels());
            Debug.Log(width + "\n" + annotation.FdBoundingPoly.Vertices[1].X);
            Rect r = new Rect(annotation.FdBoundingPoly.Vertices[1].X- annotation.FdBoundingPoly.Vertices[0].X, annotation.FdBoundingPoly.Vertices[3].Y-annotation.FdBoundingPoly.Vertices[0].X, width,
                height);
            fphoto.ReadPixels(r,0,0);
            fphoto.wrapMode = TextureWrapMode.Clamp;
            fphoto.Apply();
            


            Debug.Log((annotation.FdBoundingPoly.Vertices[1].X - annotation.FdBoundingPoly.Vertices[0].X) + " " +( annotation.FdBoundingPoly.Vertices[2].Y - annotation.FdBoundingPoly.Vertices[0].Y));
            byte[] bytes = fphoto.EncodeToPNG();
            System.IO.File.WriteAllBytes("Assets/face-1.png",bytes);
            var response1 = client.DetectImageProperties(Google.Cloud.Vision.V1.Image.FromFile("Assets/face-1.png"));//should be face-1.png
            float re;
            float g;
            float b;
            foreach (var v in response1.DominantColors.Colors)
            {
                manager.GetComponent<ProductManager>().sortingRGB(new Vector3(v.Color.Red, v.Color.Green, v.Color.Blue));
            }
            Debug.Log(response1);
            break;
         
        }


    }
    // Update is called once per frame
    public GameObject manager;
}

