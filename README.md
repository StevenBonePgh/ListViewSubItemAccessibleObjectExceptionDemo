# ListViewSubItemAccessibleObjectExceptionDemo
Demonstrate bug in .NET 5 Winforms ListView 

https://github.com/dotnet/winforms/issues/4742

This project uses the nuget package 'ObjectListView.Repack.Core3', source is here: https://github.com/FizzcodeSoftware/ObjectListViewRepack

To repoduce this bug, run this project. Click an item from the list view in the first Column to see the exception.

This appears to be a regression due to https://github.com/dotnet/winforms/pull/3224, though the call stack is difficult to reconcile. 
The ObjectListView is a control inherited from ListView, and it overrides WndProc. After receiving a WM_LBUTTONDOWN, there is a call to base.WndProc. An ArgumentNullException 
for parameter 'owningItem' is raised with this stack trace:

   at System.Windows.Forms.ListViewItem.ListViewSubItem.ListViewSubItemAccessibleObject..ctor(ListViewSubItem owningSubItem, ListViewItem owningItem)
   at System.Windows.Forms.ListView.ListViewAccessibleObject.HitTest(Int32 x, Int32 y)
   at System.Windows.Forms.ListView.WmMouseDown(Message& m, MouseButtons button, Int32 clicks)
   at System.Windows.Forms.ListView.WndProc(Message& m)
   at ObjectListView.WndProc(Message& m) in 
   at System.Windows.Forms.Control.ControlNativeWindow.WndProc(Message& m)
   at System.Windows.Forms.NativeWindow.Callback(IntPtr hWnd, WM msg, IntPtr wparam, IntPtr lparam)

Clicking other columns or space without an item does not trigger the exception/crash.
