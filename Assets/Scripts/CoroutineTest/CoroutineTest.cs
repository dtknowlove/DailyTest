using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    private Action<WWW> onSuccess;
    private MeshRenderer mr;

    void Awake()
    {
        LocalNotificationHelper.Register();
        LocalNotificationHelper.ClearNotification();
    }

    void OnApplicationPause(bool paused)
    {
        if (paused)
        {
            LocalNotificationHelper.NotificationMessage("dtknowlove:10秒后推送",DateTime.Now.AddSeconds(10),false);
            LocalNotificationHelper.NotificationMessage("dtknowlove:15秒后推送",DateTime.Now.AddSeconds(15),false);
            LocalNotificationHelper.NotificationMessage("dtknowlove:每天11点推送",11,true);
        }
        else
        {
            LocalNotificationHelper.ClearNotification();
        }
    }

    void Start()
    {
//        StartCoroutine(ScreenShotPNG());

//        IEnumerator ienmuertor = NextHaveData();
//        bool hasNext=ienmuertor.MoveNext();
//        print("第一次调用");
//        print("是否有数据:"+hasNext);
//        hasNext = ienmuertor.MoveNext();
//        print("第二次调用");
//        print("是否有数据:"+hasNext);
//        hasNext = ienmuertor.MoveNext();
//        print("第三次调用");
//        print("是否有数据:"+hasNext+"current:"+ienmuertor.Current);
        mr = this.GetComponent<MeshRenderer>();
        
        onSuccess += this.OnSuccessFuc;
        HttpWrapper hw = GetComponent<HttpWrapper>();
        hw.Get(@"http://www.bz55.com/uploads/allimg/160601/140-1606010R501.jpg",onSuccess);

        Int32? testNull = null;
        Int32? testInt = testNull ?? 99;
        
        Debug.Log(testInt.HasValue+"  "+testInt.Value);
        Debug.Log(testNull.HasValue+"  "+testNull.GetValueOrDefault());
    }

    void OnSuccessFuc(WWW www)
    {
        this.GetComponent<MeshRenderer>().material.mainTexture = www.texture;
    }

    IEnumerator ScreenShotPNG()
    {
        yield return new WaitForEndOfFrame();
        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex=new Texture2D(width,height,TextureFormat.ARGB32,false);
        tex.ReadPixels(new Rect(0,0,width,height),0,0);
        tex.Apply();
        byte[] bytes = tex.EncodeToPNG();
        Destroy(tex);
        File.WriteAllBytes(Application.dataPath+"/../SavedScreen.png",bytes);
        Debug.Log("截屏完成!");
    }

    IEnumerator NextHaveData()
    {
        print("1=======>before");
        yield return 1;
        print("1========>after");
        print("2=======>before");
        yield return 10;
        print("2=======>after");
        
    }

    void OnGUI()
    {
        if (GUILayout.Button("打开"))
        {
           
        }
    }

//    private MeshRenderer mr;
//    
//    void Start()
//    {
//        mr = this.GetComponent<MeshRenderer>();
//    }
//
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Press F");
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        for (float f = 1; f >= 0; f -= Time.deltaTime)
        {
            Debug.Log(string.Format("第{0}次啦啦啦",f));
            Color c = mr.material.color;
            c.a = f;
            mr.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }

//	IEnumerator Start () 
//	{
//		print("Starting "+Time.time);
//		yield return StartCoroutine("WaitAndPrint",2.0f);
//		print("Done"+Time.time);
//	}
//	
//	
//	IEnumerator WaitAndPrint (float waitTime) 
//	{
//		yield return new WaitForSeconds(waitTime);
//		print("WaitAndPrint "+Time.time);
//	}
}
