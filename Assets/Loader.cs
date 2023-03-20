using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using Assets;

public class Loader : MonoBehaviour
{
    public string ShpFilePath;
    public string DbfFilePath;

    // Start is called before the first frame update
    void Start()
    {
        IShpFile shapeFile = LoadFiles(ShpFilePath) as ShpFile;
        DbfFile dbfFile = LoadFiles(DbfFilePath) as DbfFile;
        Color color = new Color();
        RenderFiles(color, shapeFile, dbfFile);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IFile LoadFiles(string path)
    {
        IFile file;
        try
        {
            string fileExt = Path.GetExtension(path);
            file = FileFactory.CreateInstance(path);
            file.Load();
            return file;
        }
        catch (Exception e)
        {
            if (path.Length == 0)
            {
                Debug.Log("Path is empty.");
                return null;
            }
            Debug.Log(e);
            return null;
        }
    }

    private void RenderFiles(Color color, IShpFile shapeFile, DbfFile dbfFile)
    {
        try
        {
            ((IRenderable)shapeFile).Render(color, dbfFile);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}
