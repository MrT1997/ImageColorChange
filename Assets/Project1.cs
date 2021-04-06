using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Project1 : MonoBehaviour {
    private Texture2D myPicture;

    public int width;
    public int height;

    string pathToEdit = "tinypix";


    void Load_Image()
    {
            string allText = System.IO.File.ReadAllText(@"C:\Users\tanner\Desktop\Image_File\" + pathToEdit + ".ppm");
            string replaceText = Regex.Replace(allText, "[^a-zA-Z0-9%._]", " ");
            string[] entries = replaceText.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);

            width = int.Parse(entries[1]);
            height = int.Parse(entries[2]);

            myPicture = new Texture2D((int)(width), (int)(height));
            int normalize = int.Parse(entries[3]);

            int myX = 0;
            int myY = height - 1;
            for (int i = 4; i < entries.Length; i += 3)
            {
                Color c = new Color(float.Parse(entries[i]) / normalize, float.Parse(entries[i + 1]) / normalize, float.Parse(entries[i + 2]) / normalize);
                myPicture.SetPixel(myX, myY, c);
                myX++;
                if (myX == width)
                {
                    myX = 0;
                    myY--;
                }
            }

            myPicture.Apply();
    }

    // Update is called once per frame
    /*void Update () {
        Load_Image();
	}*/

    void Start()
    {
        Load_Image();
    }

    void Awake()
    {   
        myPicture = new Texture2D((int)(Screen.width), (int)(Screen.height));
    }

    public void openFile(string path)
    {
        string allText = System.IO.File.ReadAllText(@"C:\Users\tanner\Desktop\Image_File\" + path + ".ppm");
        string replaceText = Regex.Replace(allText, "[^a-zA-Z0-9%._]", " ");
        string[] entries = replaceText.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);
        width = int.Parse(entries[1]);
        height = int.Parse(entries[2]);

        myPicture = new Texture2D((int)(width), (int)(height));
        int normalize = int.Parse(entries[3]);

        int myX = 0;
        int myY = height - 1;
        for (int i = 4; i < entries.Length; i += 3)
        {
            Color c = new Color(float.Parse(entries[i]) / normalize, float.Parse(entries[i + 1]) / normalize, float.Parse(entries[i + 2]) / normalize);
            myPicture.SetPixel(myX, myY, c);
            myX++;
            if (myX == width)
            {
                myX = 0;
                myY--;
            }
        }

        myPicture.Apply();
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(10, 10, Screen.width, Screen.height), myPicture);
        pathToEdit = GUI.TextField(new Rect(200, 10, 200, 20), pathToEdit, 250);
        if (GUI.Button(new Rect(10, 330, 100, 30), "Open File"))
        {
            openFile(pathToEdit);
        }
        if (GUI.Button(new Rect(10, 10, 100, 30), "Negate Red"))
        {
            negate_red();
        }
        if (GUI.Button(new Rect(10, 50, 100, 30), "Negate Green"))
        {
            negate_green();
        }
        if (GUI.Button(new Rect(10, 90, 100, 30), "Negate Blue"))
        {
            negate_blue();
        }
        if (GUI.Button(new Rect(10, 130, 100, 30), "Flip Horizontal"))
        {
            flip_horizontal();
        }
        if (GUI.Button(new Rect(10, 170, 100, 30), "Grey Scale"))
        {
            grey_scale();
        }
        if (GUI.Button(new Rect(10, 210, 100, 30), "Flatten Red"))
        {
            flatten_red();
        }
        if (GUI.Button(new Rect(10, 250, 100, 30), "Flatten Green"))
        {
            flatten_green();
        }
        if (GUI.Button(new Rect(10, 290, 100, 30), "Flatten Blue"))
        {
            flatten_blue();
        }
    }

    void MakeItRed()
    {
        for (int x = 0; x < myPicture.width; x++)
        {
            for (int y = 0; y < myPicture.height; y++)
            {
                Color color = Color.red;
                myPicture.SetPixel(x, y, color);
            }
        }
        //We also need to apply the changes we have made to the image (texture)
        //This is a part that can cause much pain and frustration if forgotten

        myPicture.Apply();
    }

    public void negate_red()
    {
        for (int x = 0; x < myPicture.width; x++)
        {
            for (int y = 0; y < myPicture.height; y++)
            {
                Color c;
                c = myPicture.GetPixel(x, y);
                float newColorValue; 
                newColorValue = c.r;
                newColorValue = 1 - newColorValue;
                c.r = newColorValue;
                myPicture.SetPixel(x, y, c);
            }
        }

        myPicture.Apply();
    }

    public void negate_green()
    {
        for (int x = 0; x < myPicture.width; x++)
        {
            for (int y = 0; y < myPicture.height; y++)
            {
                Color c;
                c = myPicture.GetPixel(x, y);
                float newColorValue;
                newColorValue = c.g;
                newColorValue = 1 - newColorValue;
                c.g = newColorValue;
                myPicture.SetPixel(x, y, c);
            }
        }

        myPicture.Apply();
    }

    public void negate_blue()
    {
        for (int x = 0; x < myPicture.width; x++)
        {
            for (int y = 0; y < myPicture.height; y++)
            {
                Color c;
                c = myPicture.GetPixel(x, y);
                float newColorValue;
                newColorValue = c.b;
                newColorValue = 1 - newColorValue;
                c.b = newColorValue;
                myPicture.SetPixel(x, y, c);
            }
        }

        myPicture.Apply();
    }

    public void flip_horizontal()
    {
        string allText = System.IO.File.ReadAllText(@"C:\Users\tanner\Desktop\Image_File\" + pathToEdit + ".ppm");
        string replaceText = Regex.Replace(allText, "[^a-zA-Z0-9%._]", " ");
        string[] entries = replaceText.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);

        width = int.Parse(entries[1]);
        height = int.Parse(entries[2]);

        myPicture = new Texture2D((int)(width), (int)(height));
        int normalize = int.Parse(entries[3]);

        int myX = width;
        int myY = height - 1;
        for (int i = 4; i < entries.Length; i += 3)
        {
            Color c = new Color(float.Parse(entries[i]) / normalize, float.Parse(entries[i + 1]) / normalize, float.Parse(entries[i + 2]) / normalize);
            myPicture.SetPixel(myX, myY, c);
            myX--;
            if (myX == 0)
            {
                myX = width;
                myY--;
            }
        }

        myPicture.Apply();
    }

    public void grey_scale()
    {
        for (int x = 0; x < myPicture.width; x++)
        {
            for (int y = 0; y < myPicture.height; y++)
            {
                Color c;
                c = myPicture.GetPixel(x, y);
                float newColorValue = (c.r + c.g + c.b) / 3;
                c.r = newColorValue;
                c.g = newColorValue;
                c.b = newColorValue;
                myPicture.SetPixel(x, y, c);
            }
        }

        myPicture.Apply();
    }

    public void flatten_red()
    {
        for (int x = 0; x < myPicture.width; x++)
        {
            for (int y = 0; y < myPicture.height; y++)
            {
                Color c;
                c = myPicture.GetPixel(x, y);
                float newColorValue;
                newColorValue = c.r;
                newColorValue = 0;
                c.r = newColorValue;
                myPicture.SetPixel(x, y, c);
            }
        }

        myPicture.Apply();
    }

    public void flatten_green()
    {
        for (int x = 0; x < myPicture.width; x++)
        {
            for (int y = 0; y < myPicture.height; y++)
            {
                Color c;
                c = myPicture.GetPixel(x, y);
                float newColorValue;
                newColorValue = c.g;
                newColorValue = 0;
                c.g = newColorValue;
                myPicture.SetPixel(x, y, c);
            }
        }

        myPicture.Apply();
    }

    public void flatten_blue()
    {
        for (int x = 0; x < myPicture.width; x++)
        {
            for (int y = 0; y < myPicture.height; y++)
            {
                Color c;
                c = myPicture.GetPixel(x, y);
                float newColorValue;
                newColorValue = c.b;
                newColorValue = 0;
                c.b = newColorValue;
                myPicture.SetPixel(x, y, c);
            }
        }

        myPicture.Apply();
    }
}   

