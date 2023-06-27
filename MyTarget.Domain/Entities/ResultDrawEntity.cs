namespace MyTarget.Domain.Entities
{
    public class ResultDrawEntity
    {
        public int contestNumber { get; set; }
        public DateTime contestDate { get; set; }

        public List<DrawnNumbers>? drawnNumbers { get; set; }
    }

    public class DrawnNumbers
    {
        public int drawnNumber { get; set; }
    }
}
