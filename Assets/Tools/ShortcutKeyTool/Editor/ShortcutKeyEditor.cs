using UnityEditor;

public class ShortcutKeyEditor
{
		[MenuItem("LLL/ShortcutKey/NewScene ")]
		static void ShortcutKey_FileNewScene()
		{
			EditorApplication.ExecuteMenuItem("File/New Scene");
		}

		[MenuItem("LLL/ShortcutKey/OpenScene ")]
		static void ShortcutKey_FileOpenScene()
		{
			EditorApplication.ExecuteMenuItem("File/Open Scene");
		}

		[MenuItem("LLL/ShortcutKey/SaveScenes ")]
		static void ShortcutKey_FileSaveScenes()
		{
			EditorApplication.ExecuteMenuItem("File/Save Scenes");
		}

		[MenuItem("LLL/ShortcutKey/SaveSceneas... ")]
		static void ShortcutKey_FileSaveSceneas()
		{
			EditorApplication.ExecuteMenuItem("File/Save Scene as...");
		}

		[MenuItem("LLL/ShortcutKey/NewProject... ")]
		static void ShortcutKey_FileNewProject()
		{
			EditorApplication.ExecuteMenuItem("File/New Project...");
		}

		[MenuItem("LLL/ShortcutKey/OpenProject... ")]
		static void ShortcutKey_FileOpenProject()
		{
			EditorApplication.ExecuteMenuItem("File/Open Project...");
		}

		[MenuItem("LLL/ShortcutKey/SaveProject ")]
		static void ShortcutKey_FileSaveProject()
		{
			EditorApplication.ExecuteMenuItem("File/Save Project");
		}

		[MenuItem("LLL/ShortcutKey/BuildSettings... ")]
		static void ShortcutKey_FileBuildSettings()
		{
			EditorApplication.ExecuteMenuItem("File/Build Settings...");
		}

		[MenuItem("LLL/ShortcutKey/Build&Run ")]
		static void ShortcutKey_FileBuildRun()
		{
			EditorApplication.ExecuteMenuItem("File/Build & Run");
		}

		[MenuItem("LLL/ShortcutKey/Close ")]
		static void ShortcutKey_FileClose()
		{
			EditorApplication.ExecuteMenuItem("File/Close");
		}

		[MenuItem("LLL/ShortcutKey/Undo ")]
		static void ShortcutKey_EditUndo()
		{
			EditorApplication.ExecuteMenuItem("Edit/Undo");
		}

		[MenuItem("LLL/ShortcutKey/Redo ")]
		static void ShortcutKey_EditRedo()
		{
			EditorApplication.ExecuteMenuItem("Edit/Redo");
		}

		[MenuItem("LLL/ShortcutKey/Cut ")]
		static void ShortcutKey_EditCut()
		{
			EditorApplication.ExecuteMenuItem("Edit/Cut");
		}

		[MenuItem("LLL/ShortcutKey/Copy ")]
		static void ShortcutKey_EditCopy()
		{
			EditorApplication.ExecuteMenuItem("Edit/Copy");
		}

		[MenuItem("LLL/ShortcutKey/Paste ")]
		static void ShortcutKey_EditPaste()
		{
			EditorApplication.ExecuteMenuItem("Edit/Paste");
		}

		[MenuItem("LLL/ShortcutKey/Duplicate ")]
		static void ShortcutKey_EditDuplicate()
		{
			EditorApplication.ExecuteMenuItem("Edit/Duplicate");
		}

		[MenuItem("LLL/ShortcutKey/Delete ")]
		static void ShortcutKey_EditDelete()
		{
			EditorApplication.ExecuteMenuItem("Edit/Delete");
		}

		[MenuItem("LLL/ShortcutKey/FrameSelected ")]
		static void ShortcutKey_EditFrameSelected()
		{
			EditorApplication.ExecuteMenuItem("Edit/Frame Selected");
		}

}