namespace IncStores.TaskManager.Settings
{
    public class TwilioSettings
    {
        public string AccountSID { get; set; }
        public string Token { get; set; }
        public string FromNumber { get; set; }
        public string TestPhoneNumber { get; set; }
        public bool SendMessages { get; set; }
    }
}
