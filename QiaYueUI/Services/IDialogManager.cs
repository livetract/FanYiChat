namespace QiaYue.UI.Services
{
    public interface IDialogManager
    {
        void ShowDialog();
        void ShowDialog(string name);
        void ShowDialog<TView>();
    }
}
