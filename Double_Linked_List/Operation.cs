namespace Double_Linked_List
{
    public class Operation
    {
        public delegate void OperationDelegate();

        public string Name { get; }

        public OperationDelegate GetOperationDelegate { get; }

        public Operation(string name, OperationDelegate operationDelegate)
        {
            Name = name;
            GetOperationDelegate = operationDelegate;
        }
    }
}
