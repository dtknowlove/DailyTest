using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
#if UNITY_IOS
using UnityEngine.iOS;
using CalendarIdentifier = UnityEngine.iOS.CalendarIdentifier;
using CalendarUnit = UnityEngine.iOS.CalendarUnit;
using LocalNotification = UnityEngine.iOS.LocalNotification;
using NotificationServices = UnityEngine.iOS.NotificationServices;
#endif

public class LocalNotificationHelper
{
	#if UNITY_IOS
	[DllImport("__Internal")]
	private static extern void CancelAllLocalNotifications();

	[DllImport("__Internal")]
	private static extern void ClearLocalNotifications();
	#endif
	
	private static int mIconBadgeNumber;

	public static void Register(bool registerForRemote = false)
	{
		#if UNITY_IOS
		NotificationServices.RegisterForNotifications(NotificationType.Alert|NotificationType.Badge|NotificationType.Sound,registerForRemote);
		#endif
	}
	
	public static void NotificationMessage(string message, int hour, bool isRepeatDay)
	{
		#if UNITY_IOS
		DateTime newDate=new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,hour,0,0);
		NotificationMessage(message,newDate,isRepeatDay);
		#endif
	}

	public static void NotificationMessage(string message, DateTime newDate, bool isRepeateDay)
	{
		#if UNITY_IOS
		//大于当前时间进行推送
		if (newDate > DateTime.Now)
		{
			mIconBadgeNumber++;
			LocalNotification localNotification=new LocalNotification();
			localNotification.alertAction = "CNM,看这里！！！";
			localNotification.fireDate = newDate;
			localNotification.alertBody = message;
			localNotification.applicationIconBadgeNumber =mIconBadgeNumber;
			localNotification.hasAction = true;
			if (isRepeateDay)
			{
				localNotification.repeatCalendar=CalendarIdentifier.ChineseCalendar;
				localNotification.repeatInterval= CalendarUnit.Day;
			}
			localNotification.soundName = LocalNotification.defaultSoundName;
			NotificationServices.ScheduleLocalNotification(localNotification);
		}
		Debug.Log(mIconBadgeNumber);
		#endif
	}

	public static void ClearNotification()
	{
		#if UNITY_IOS
		mIconBadgeNumber = 0;
		CancelAllLocalNotifications();
		ClearLocalNotifications();
		
		LocalNotification localNotification = new LocalNotification();
		localNotification.applicationIconBadgeNumber = -1;
		NotificationServices.PresentLocalNotificationNow(localNotification);
		NotificationServices.CancelAllLocalNotifications();
		NotificationServices.ClearLocalNotifications();
		#endif
	}

}
