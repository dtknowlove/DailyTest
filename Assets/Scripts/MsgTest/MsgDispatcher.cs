using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicDelegate
{
	public delegate void VoidDelegateWithParam(params object[] param);
}

public interface IMsgReceiver
{
	
}
public interface IMsgSender
{
	
}

public static class MsgDispather 
{
	public class MsgTrap
	{
		public IMsgReceiver receiver;
		public PublicDelegate.VoidDelegateWithParam callBack;

		public MsgTrap (IMsgReceiver _r,PublicDelegate.VoidDelegateWithParam _callBack)
		{
			this.receiver=_r;
			this.callBack=_callBack;
		}
	}


	public static Dictionary<string,List<MsgTrap>> mMsgTrapDict=new Dictionary<string, List<MsgTrap>>();

	/// <summary>
	/// 注册
	/// 扩展方法必须为静态
	/// </summary>
	/// <param name="self">Self.</param>
	/// <param name="msg">Message.</param>
	/// <param name="callBack">Call back.</param>
	public static void RegisterSelf(this IMsgReceiver self,string msg,PublicDelegate.VoidDelegateWithParam callBack)
	{
		if (string.IsNullOrEmpty (msg))
		{
			Debug.LogError ("消息不能为空");
			return;
		}

		if(null==callBack)
		{
			Debug.LogError ("回调不能为空");
			return;
		}

		if (false == mMsgTrapDict.ContainsKey (msg)) 
		{
			mMsgTrapDict.Add (msg,new List<MsgTrap>());
		}

		var handers = mMsgTrapDict [msg];

		foreach (var item in handers) 
		{
			if (item.receiver == self && item.callBack == callBack)
			{
				Debug.Log (self+"has already a"+msg);
				return;
			}
		}

		handers.Add (new MsgTrap(self,callBack));
	}
	/// <summary>
	/// 发送消息
	/// </summary>
	/// <param name="self">Self.</param>
	/// <param name="msg">Message.</param>
	public static void SenderMsg(this IMsgSender self,string msg,params object[] param)
	{
		if(string.IsNullOrEmpty(msg))
		{
			Debug.LogError ("消息不能为空");
			return;
		}
		if (false == mMsgTrapDict.ContainsKey (msg))
		{
			Debug.LogError ("未注册消息："+msg);
			return;
		}
		var handers = mMsgTrapDict [msg];
		int handersCount = handers.Count;

		for (int i = handersCount-1; i >= 0; i--) 
		{
			var hander = handers [i];
			if (hander.receiver != null) 
			{
				Debug.Log ("SendMsg:" + msg);
				hander.callBack (param);
			} else
				handers.Remove (hander);
		}

	}
}

//#region 实现
///// <summary>
///// 消息分发器
///// C# this扩展 需要静态类
///// 字符串+字典+delegate方式实现
///// </summary>
//public static class PTMsgDispatcher  {
//
//	/// <summary>
//	/// 消息捕捉器
//	/// </summary>
//	class PTMsgHandler {
//
//		public IMsgReceiver receiver;
//		public  PTVoidDelegate.WithParams callback;
//
//		/*
//			 * VoidDelegate.WithParams 是一种委托 ,定义是这样的 
//			 * 
//			 *  public class VoidDelegate{
//			 *  	public delegate void WithParams(params object[] paramList);
//			 *  }
//			 */
//		public PTMsgHandler(IMsgReceiver receiver,PTVoidDelegate.WithParams callback)
//		{
//			this.receiver = receiver;
//			this.callback = callback;
//		}
//	}
//
//	/// <summary>
//	/// 每个消息名字维护一组消息捕捉器。
//	/// </summary>
//	static Dictionary<PTMsgChannel,Dictionary<string,List<PTMsgHandler>>> mMsgHandlerDict = new Dictionary<PTMsgChannel,Dictionary<string,List<PTMsgHandler>>> ();
//
//	/// <summary>
//	/// 注册消息,
//	/// 注意第一个参数,使用了C# this的扩展,
//	/// 所以只有实现IMsgReceiver的对象才能调用此方法
//	/// </summary>
//	public static void RegisterGlobalMsg(this IMsgReceiver self, string msgName,PTVoidDelegate.WithParams callback)
//	{
//		// 略过
//		if (string.IsNullOrEmpty(msgName)) {
//			Debug.LogError("RegisterMsg:" + msgName + " is Null or Empty");
//			return;
//		}
//
//		// 略过
//		if (null == callback) {
//			Debug.LogError ("RegisterMsg:" + msgName + " callback is Null");
//			return;
//		}
//
//		// 添加消息通道
//		if (!mMsgHandlerDict.ContainsKey (PTMsgChannel.Global)) {
//			mMsgHandlerDict [PTMsgChannel.Global] = new Dictionary<string, List<PTMsgHandler>> ();
//		}
//
//		// 略过
//		if (!mMsgHandlerDict[PTMsgChannel.Global].ContainsKey (msgName)) {
//			mMsgHandlerDict[PTMsgChannel.Global] [msgName] = new List<PTMsgHandler> ();
//		}
//
//		// 看下这里
//		var handlers = mMsgHandlerDict [PTMsgChannel.Global][msgName];
//
//		// 略过
//		// 防止重复注册
//		foreach (var handler in handlers) {
//			if (handler.receiver == self && handler.callback == callback) {
//				Debug.LogWarning ("RegisterMsg:" + msgName + " ayready Register");
//				return;
//			}
//		}
//
//		// 再看下这里
//		handlers.Add (new PTMsgHandler (self, callback));
//	}
//
//	/// <summary>
//	/// 注册消息,
//	/// 注意第一个参数,使用了C# this的扩展,
//	/// 所以只有实现IMsgReceiver的对象才能调用此方法
//	/// </summary>
//	public static void RegisterMsgByChannel(this IMsgReceiver self, PTMsgChannel channel,string msgName,PTVoidDelegate.WithParams callback)
//	{
//		// 略过
//		if (string.IsNullOrEmpty(msgName)) {
//			Debug.LogError("RegisterMsg:" + msgName + " is Null or Empty");
//			return;
//		}
//
//		// 略过
//		if (null == callback) {
//			Debug.LogError ("RegisterMsg:" + msgName + " callback is Null");
//			return;
//		}
//
//		// 添加消息通道
//		if (!mMsgHandlerDict.ContainsKey (channel)) {
//			mMsgHandlerDict [channel] = new Dictionary<string, List<PTMsgHandler>> ();
//		}
//
//		// 略过
//		if (!mMsgHandlerDict[channel].ContainsKey (msgName)) {
//			mMsgHandlerDict[channel] [msgName] = new List<PTMsgHandler> ();
//		}
//
//		// 看下这里
//		var handlers = mMsgHandlerDict [channel][msgName];
//
//		// 略过
//		// 防止重复注册
//		foreach (var handler in handlers) {
//			if (handler.receiver == self && handler.callback == callback) {
//				Debug.LogWarning ("RegisterMsg:" + msgName + " ayready Register");
//				return;
//			}
//		}
//
//		// 再看下这里
//		handlers.Add (new PTMsgHandler (self, callback));
//	}
//
//
//	/// <summary>
//	/// 其实注销消息只需要Object和Go就足够了 不需要callback
//	/// </summary>
//	public static void UnRegisterGlobalMsg(this IMsgReceiver self,string msgName)
//	{
//		if (CheckStrNullOrEmpty (msgName)) {
//			return;
//		}
//
//		if (!mMsgHandlerDict.ContainsKey (PTMsgChannel.Global)) {
//			Debug.LogError ("Channel:" + PTMsgChannel.Global.ToString() + " doesn't exist");
//			return;			
//		}
//
//		var handlers = mMsgHandlerDict[PTMsgChannel.Global] [msgName];
//
//		int handlerCount = handlers.Count;
//
//		// 删除List需要从后向前遍历
//		for (int index = handlerCount - 1; index >= 0; index--) {
//			var handler = handlers [index];
//			if (handler.receiver == self) {
//				handlers.Remove (handler);
//				break;
//			}
//		}
//	}
//
//	/// <summary>
//	/// 其实注销消息只需要Object和Go就足够了 不需要callback
//	/// </summary>
//	public static void UnRegisterMsgByChannel(this IMsgReceiver self,PTMsgChannel channel,string msgName)
//	{
//		if (CheckStrNullOrEmpty (msgName)) {
//			return;
//		}
//
//		if (!mMsgHandlerDict.ContainsKey (channel)) {
//			Debug.LogError ("Channel:" + channel.ToString () + " doesn't exist");
//			return;			
//		}
//
//		var handlers = mMsgHandlerDict[channel] [msgName];
//
//		int handlerCount = handlers.Count;
//
//		// 删除List需要从后向前遍历
//		for (int index = handlerCount - 1; index >= 0; index--) {
//			var handler = handlers [index];
//			if (handler.receiver == self) {
//				handlers.Remove (handler);
//				break;
//			}
//		}
//	}
//
//
//	static bool CheckStrNullOrEmpty(string str)
//	{
//		if (string.IsNullOrEmpty (str)) {
//			Debug.LogWarning ("str is Null or Empty");
//			return true;
//		}
//		return false;
//	}
//
//	static bool CheckDelegateNull(PTVoidDelegate.WithParams callback)
//	{
//		if (null == callback) {
//			Debug.LogWarning ("callback is Null");
//
//			return true;
//		}
//		return false;
//	}
//
//	/// <summary>
//	/// 发送消息
//	/// 注意第一个参数
//	/// </summary>
//	public static void SendGlobalMsg(this IMsgSender sender, string msgName,params object[] paramList)
//	{
//		if (CheckStrNullOrEmpty (msgName)) {
//			return;
//		}
//
//		if (!mMsgHandlerDict.ContainsKey (PTMsgChannel.Global)) {
//			Debug.LogError ("Channel:" + PTMsgChannel.Global.ToString() + " doesn't exist");
//			return;
//		}
//
//		// 略过,不用看
//		if (!mMsgHandlerDict[PTMsgChannel.Global].ContainsKey(msgName)){
//			Debug.LogError(msgName + " UnRegistered");
//			return;
//		}
//
//		// 开始看!!!!
//		var handlers = mMsgHandlerDict[PTMsgChannel.Global][msgName];
//
//		var handlerCount = handlers.Count;
//
//		// 之所以是从后向前遍历,是因为  从前向后遍历删除后索引值会不断变化
//		// 参考文章,http://www.2cto.com/kf/201312/266723.html
//		for (int index = handlerCount - 1;index >= 0;index--)
//		{
//			var handler = handlers[index];
//
//			if (handler.receiver != null) {
//				handler.callback (paramList);
//			} else {
//				handlers.Remove (handler);
//			}
//		}
//	}
//
//	public static void SendMsgByChannel(this IMsgSender sender,PTMsgChannel channel,string msgName,params object[] paramList)
//	{
//		if (CheckStrNullOrEmpty (msgName)) {
//			return;
//		}
//
//		if (!mMsgHandlerDict.ContainsKey (channel)) {
//			Debug.LogError ("Channel:" +channel.ToString() + " doesn't exist");
//			return;
//		}
//
//		// 略过,不用看
//		if (!mMsgHandlerDict[channel].ContainsKey(msgName)){
//			Debug.LogWarning("SendMsg is UnRegister");
//			return;
//		}
//
//		// 开始看!!!!
//		var handlers = mMsgHandlerDict[channel][msgName];
//
//		var handlerCount = handlers.Count;
//
//		// 之所以是从后向前遍历,是因为  从前向后遍历删除后索引值会不断变化
//		// 参考文章,http://www.2cto.com/kf/201312/266723.html
//		for (int index = handlerCount - 1;index >= 0;index--)
//		{
//			var handler = handlers[index];
//
//			if (handler.receiver != null) {
//				Debug.Log ("SendLogicMsg:" + msgName + " Succeed");
//				handler.callback (paramList);
//			} else {
//				handlers.Remove (handler);
//			}
//		}
//	}
//}
//#endregion
