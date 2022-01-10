using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorTexture : MonoBehaviour
{

    [SerializeField] private Texture2D[] cursorTextureArray;
    [SerializeField] private int frameCount;
    [SerializeField] private float frameRate;

    private int CurrentFrame;
    private float FrameTimer;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTextureArray[0], new Vector2(10, 10), CursorMode.Auto);
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        FrameTimer -= Time.deltaTime;
        if(FrameTimer <= 0f)
        {
            FrameTimer += frameRate;
            CurrentFrame = (CurrentFrame + 1) % frameCount;
            Cursor.SetCursor(cursorTextureArray[CurrentFrame], new Vector2(10, 10), CursorMode.Auto);
        }
    }
}
