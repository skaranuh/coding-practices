using LinkedListReversal;

//Linked list is created
var itemsCount=10;
var headNode=CreateLinkedList(itemsCount);

Console.WriteLine("Linked list is being displayed.");
DisplayLinkedList(headNode);

Console.WriteLine("LinkedList is being reversed");
var reversedHeadNode= ReverseLinkedList(headNode);

Console.WriteLine("Reversed linked list is being displayed.");
DisplayLinkedList(reversedHeadNode);


Node ReverseLinkedList(Node headNode)
{
    Node? previous = null;
    Node? current = headNode;

    while (current != null)
    {
        Node? nextNode = current.Next; // Store the next node
        current.Next = previous;       // Reverse the current node's pointer
        previous = current;            // Move the previous pointer to current
        current = nextNode;            // Move to the next node
    }

    return previous!; // The new head of the reversed linked list
}

void DisplayLinkedList(Node headNode){

    var currentNode=headNode;
    
    //iterate until last node is found
    while(currentNode  !=null){
        int? nextNodeId=currentNode.Next?.Id;
        Console.WriteLine($"Node Id : {currentNode.Id} Next Node Id : {nextNodeId}");
        currentNode = currentNode.Next;
    }
}

Node CreateLinkedList(int itemsCount){

    //create a linked list
    var linkedList=new List<Node>();

    //populate items
    for(var i=0; i<itemsCount;i++){

       linkedList.Add(new Node{ Id=i+1});

    }

    //bind each node to next node with Next property
    for(var i=0; i<linkedList.Count; i++){
        if(i!=linkedList.Count-1){
            linkedList[i].Next=linkedList[i+1];
        }
        else {
                linkedList[i].Next=null;
        }
    }

    //return head node
    return linkedList[0];
 } 
