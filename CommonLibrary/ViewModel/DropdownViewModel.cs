namespace ViewModel
{
    public class DropdownViewModel
    {
        public DropdownViewModel()
        {
            
        }

        public DropdownViewModel(string id, string text)
        {
            Id = id;
            Text = text;
        }

        public string Id { get; set; }
        public string Text { get; set; }
    }
}