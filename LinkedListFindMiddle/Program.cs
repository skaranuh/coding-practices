
using FindLinkedListMiddle;

Console.WriteLine("Creating linkedList");
var headNode=CreateLinkedList(8);

Console.WriteLine("Displaying linkedList");
DisplayLinkedList(headNode);

Console.WriteLine("Finding middle nodes in linkedList");
(Node midNode1, Node? midNode2) = FindMidNodes(headNode);

Console.WriteLine($"Middle nodes in linkedList");
Console.WriteLine($"First middle node: {midNode1.Id}");
Console.WriteLine($"Second middle node: {midNode2?.Id}");


(Node midNode1, Node? midNode2)FindMidNodes(Node headNode){
    
    Node? slow = headNode;
    Node? previous = null;
    Node? fast = headNode;

    //iterate until fast pointer reaches the end
    while(fast != null && fast.Next !=null){
        previous = slow; //move previous slow to next
        slow =slow!.Next; //move slow to next
        fast = fast.Next.Next;//move fast to next
    }

    if(fast!=null){
            return (slow!, null);
    }else{
        return (previous!, slow);
    }
}

Node CreateLinkedList(int itemsCount){
    
    Node? headNode =null;
    Node? previousNode =null;
    
    for(var i=0; i<itemsCount-1;i++){
       
        var currentNode= new Node{Id=i+1};

        // set first node as head node
        if(previousNode ==null){
            headNode=currentNode;
        }

        // set next node as new node if it is NOT the last node
        if (i<itemsCount-1){
            currentNode.Next=new Node{Id=i+2};
        }
        //set next node as null if it is the last node
        else {
            currentNode.Next=null;
        }    

        // link node to previous node
        if(previousNode!=null){
            previousNode.Next=currentNode;
        }
        
        // set previous node as node (move to next node)
        previousNode=currentNode;   
    }

    if(headNode==null){
        throw new InvalidOperationException("Head node cannot be null");
    }
    return headNode;
}

void DisplayLinkedList(Node headNode){
    
    //set current node as head node
    var currentNode=headNode;

    //iterate until last node
    while(currentNode !=null){
        Console.WriteLine($"Node Id: {currentNode.Id}");
        currentNode = currentNode.Next;
    }
}