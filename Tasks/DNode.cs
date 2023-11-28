namespace Tasks
{
    public class DNode
    {
        public object data;
        public DNode prev;
        public DNode next;
        public DNode(object d)
        {
            data = d;
            prev = null;
            next = null;
        }
    }
}