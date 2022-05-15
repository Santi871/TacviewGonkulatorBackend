namespace TacviewGonkulatorBackend.Classes
{
    public record TacviewProcessingMessage
    {
        public string TacviewGuid { get; set; }
        public string TacviewUri { get; set; }
    }
}