using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BooksModel
{
    public List<Story> stories ;
}

[Serializable]
public class Story
{
    public string name ;
    public string category ;
    public string cover ;
    public string audiofile_id ;
    public string audio_url ;
}

