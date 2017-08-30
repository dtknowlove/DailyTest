using UnityEditor;

	public class ShortcutKeyEditor
{
		[MenuItem("LLL/ShortcutKey/Open _l")]
		static void ShortcutKey_AssetsOpen()
		{
			EditorApplication.ExecuteMenuItem("Assets/Open");
		}

}