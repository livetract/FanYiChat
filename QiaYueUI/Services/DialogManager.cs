using QiaYue.UI.Views;
using System;

namespace QiaYue.UI.Services
{
    public class DialogManager : IDialogManager
    {
        public DialogManager() { }
        public void ShowDialog()
        {
            var dialog = new DialogWindow();
            dialog.ShowDialog();
        }

        public void ShowDialog(string name)
        {
            var dialog = new DialogWindow();
            var type = Type.GetType(name);
            dialog.Content = Activator.CreateInstance(type!);
            dialog.ShowDialog();
        }

        public void ShowDialog<TView>()
        {
            var dialog = new DialogWindow();
            var content = Activator.CreateInstance(typeof(TView));
            dialog.Content = content;
            dialog.ShowDialog();
        }
    }
}
