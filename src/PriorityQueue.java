import java.util.EmptyStackException;

public class PriorityQueue<T extends Comparable<T> & Updatable> implements QueueInterface<T>
{
    private int numEntries = 0;
    private Node firstNode;
    private Node lastNode;

    public PriorityQueue()
    {
        firstNode = null;
        lastNode = null;
    }

    // implementation of queue opeartions go here

    private class Node
    {
        private T data;
        private Node next;

        private Node(T d, Node n)
        {
            next = n;
            data = d;
        }
        // methods go here


        public void setNextNode(Node n)
        {
            next = n;
        }

        public T getData(){ return data; }
        public void setData(T d) { data = d; }
        public Node getNextNode() { return next; }
    }
    
    @Override
    public void add(T newEntry) //Enqueue
    {
        Node newNode = new Node(newEntry, null);
        if(isEmpty())
        {
            firstNode = newNode;
            newNode.next = null;
            return;
        }
        if(newEntry.compareTo(firstNode.getData()) < 0)
        {
            newNode.next = firstNode;
            firstNode = newNode;
            return;
        }
        for(Node iterator = firstNode; iterator != null; iterator = iterator.next)
        {
            if(iterator.next == null)
            {
                iterator.next = newNode;
                return;
            }
            Node nextNode = iterator.next;
            if(nextNode.getData().compareTo(newNode.getData()) > 0)
            {
                iterator.next = newNode;
                newNode.next = nextNode;
                return;
            }
        }
        
    }
    public void updateValues()
    {
        for(Node iterator = firstNode; iterator != null; iterator = iterator.next)
        {
            iterator.getData().update();
        }
    }
    
    @Override
    public T remove() // Dequeue
    {
        T front = firstNode.getData();
        firstNode.setData(null);
        firstNode = firstNode.getNextNode();
        if (firstNode == null) {
            lastNode = null;
        }
        return front;
    }

    @Override
    public T peek()
    {
        return firstNode.getData();
    }

    @Override
    public int getSize()
    {
        return numEntries;
    }

    public T getBack()
    {
        return lastNode.getData();
    }

    @Override
    public boolean isEmpty()
    {
        return (firstNode == null) && (lastNode == null);
    }

    @Override
    public void clear()
    {
        firstNode = null;
        lastNode = null;
    }

    public int getNumEntries()
    {
        return numEntries;
    }
    
    public String toString()
    {
        String returnString = "";
        for(Node n = firstNode; n != null; n = n.next)
        {
            returnString += n.getData() + " \n";
        }
        return returnString;
    }
}