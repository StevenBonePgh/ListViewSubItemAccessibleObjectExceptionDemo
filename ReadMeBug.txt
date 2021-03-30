
The attached project uses the nuget package 'ObjectListView.Repack.Core3'. 
Source here: https://github.com/FizzcodeSoftware/ObjectListViewRepack

Run this project. Click an item from the list view in the first Column to see the exception.

This appears to be a regression due to #3224, though the call stack does not make sense. 
The ObjectListView is a control inherited from ListView, and it overrides WndProc. 
After receiving a WM_LBUTTONDOWN, there is a call to base.WndProc. An ArgumentNullException 
for parameter 'owningItem' is raised with this stack trace:

   at System.Windows.Forms.ListViewItem.ListViewSubItem.ListViewSubItemAccessibleObject..ctor(ListViewSubItem owningSubItem, ListViewItem owningItem)
   at System.Windows.Forms.ListView.ListViewAccessibleObject.HitTest(Int32 x, Int32 y)
   at System.Windows.Forms.ListView.WmMouseDown(Message& m, MouseButtons button, Int32 clicks)
   at System.Windows.Forms.ListView.WndProc(Message& m)
   at ObjectListView.WndProc(Message& m) in 
   at System.Windows.Forms.Control.ControlNativeWindow.WndProc(Message& m)
   at System.Windows.Forms.NativeWindow.Callback(IntPtr hWnd, WM msg, IntPtr wparam, IntPtr lparam)

Clicking other columns or space without an item does not trigger the exception/crash.