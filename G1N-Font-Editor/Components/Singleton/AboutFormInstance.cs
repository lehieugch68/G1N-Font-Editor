namespace G1N_Font_Editor.Components.Singleton
{
    internal class AboutFormInstance
    {
        private static AboutForm _aboutForm;
        public static AboutForm GetForm
        {
            get
            {
                if (_aboutForm == null || _aboutForm.IsDisposed) 
                    _aboutForm = new AboutForm();
                return _aboutForm;
            }
        }
    }
}
