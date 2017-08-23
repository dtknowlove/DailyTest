using UnityEngine;
using UnityEngine.UI;
 
 
public class JARTest : MonoBehaviour {
 
	public Text Text_Message;
 
 
#if UNITY_ANDROID
	private AndroidJavaObject m_ANObj = null;
#endif
 
 
	// Use this for initialization
	void Start () { }
     
	// Update is called once per frame
	void Update () { }
 
 
	public void Button_1_Clicked()
	{
#if UNITY_ANDROID
		if(InitNotificator())
		{
			m_ANObj.CallStatic(
				"ShowNotification",
				Application.productName,
				"温馨提示",
				"你该食屎了",
				10,
				false);
			this.Text_Message.text = "Notification will show in 10 sec.";
		}
#endif
	}
 
 
	public void Button_2_Clicked()
	{
#if UNITY_ANDROID
		if(InitNotificator())
		{
			m_ANObj.CallStatic("ClearNotification");
			this.Text_Message.text = "Notification has been cleaned";
		}
#endif
	}
 
 
#if UNITY_ANDROID
	private bool InitNotificator()
	{
		if (m_ANObj == null)
		{
			try
			{
				m_ANObj = new AndroidJavaObject("com.android.androidhelper.AndroidNotificator");
			}
			catch
			{
				this.Text_Message.text = "Init AndroidNotificator Fail";
				return false;
			}
		}
 
		if (m_ANObj == null)
		{
			this.Text_Message.text = "AndroidNotificator Not Found.";
			return false;
		}
 
		return true;
	}
#endif
}
