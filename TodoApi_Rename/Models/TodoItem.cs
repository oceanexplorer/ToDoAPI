namespace TodoApi.Models
{
    public class TodoItem
    {
        private TodoItem(){}

        public TodoItem(long id, string name, bool isComplete)
        {
            Id = id;
            Name = name;
            IsComplete = isComplete;
        }

        public TodoItem(string name, bool isComplete)
        {
            Name = name;
            IsComplete = isComplete;
        }
        
        public long Id { get;set; }
        public string Name { get;set; }
        public bool IsComplete { get;set; }
    }
}