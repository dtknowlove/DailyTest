using UnityEditor;

public class ShortcutKeyEditor
{
		[MenuItem("LLL/ShortcutKey/Player _p")]
		static void ShortcutKey_EditProjectSettingsPlayer()
		{
			EditorApplication.ExecuteMenuItem("Edit/Project Settings/Player");
		}

		[MenuItem("LLL/ShortcutKey/Folder #f")]
		static void ShortcutKey_AssetsCreateFolder()
		{
			EditorApplication.ExecuteMenuItem("Assets/Create/Folder");
		}

		[MenuItem("LLL/ShortcutKey/RevealinFinder #r")]
		static void ShortcutKey_AssetsRevealinFinder()
		{
			EditorApplication.ExecuteMenuItem("Assets/Reveal in Finder");
		}

		[MenuItem("LLL/ShortcutKey/Open #o")]
		static void ShortcutKey_AssetsOpen()
		{
			EditorApplication.ExecuteMenuItem("Assets/Open");
		}

}