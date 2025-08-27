namespace be_ipubers_kartan.ModelsCustom
{
    public class LogInfo
    {
        public enum Action { Create, Update }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public LogInfo(Action action, DateTime date, string by)
        {
            if (action.Equals(Action.Create))
            {
                CreatedBy = by;
                CreatedAt = date;
            }
            else
            {
                UpdatedAt = date;
                UpdatedBy = by;
            }
        }
    }
}
