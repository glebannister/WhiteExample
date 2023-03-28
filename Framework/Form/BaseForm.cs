using Framework.WindowElement;

namespace Framework.Form
{
    public abstract class BaseForm
    {
        public string FormName { get; private set; }

        protected WFWindow formWindow;

        protected BaseForm(WFWindow formWindow, string formName) 
        {
            this.formWindow = formWindow;
            FormName = formName;
        }

        public bool IsFormVisible() 
        {
            formWindow.WaitWhileBusy();
            return formWindow.IsVisible;
        }
    }
}
